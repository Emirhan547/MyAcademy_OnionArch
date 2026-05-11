using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnionApp.API.Hubs;
using OnionApp.API.Security;
using OnionApp.API.Services;
using OnionApp.Application.Contracts;
using OnionApp.Application.Extensions;
using OnionApp.Application.Tools;
using OnionApp.Domain.Entities;
using OnionApp.Domain.Enums;
using OnionApp.Persistence.Context;
using OnionApp.Persistence.Extensions;
using OnionApp.Infrastructure.Extensions;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Scalar.AspNetCore;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var serviceName = "OnionApp.API";
var serviceVersion = typeof(Program).Assembly.GetName().Version?.ToString() ?? "1.0.0";

var otelEndpoint = builder.Configuration["Elastic:OtlpEndpoint"] ?? "http://localhost:4317";
var otelHeaders = builder.Configuration["Elastic:OtlpHeaders"];

builder.Logging.ClearProviders();
builder.Logging.AddOpenTelemetry(options =>
{
    options.IncludeScopes = true;
    options.IncludeFormattedMessage = true;
    options.ParseStateValues = true;

    options.SetResourceBuilder(ResourceBuilder.CreateDefault()
        .AddService(serviceName: serviceName, serviceVersion: serviceVersion));

    options.AddOtlpExporter(exporterOptions =>
    {
        exporterOptions.Endpoint = new Uri(otelEndpoint);
        if (!string.IsNullOrWhiteSpace(otelHeaders))
        {
            exporterOptions.Headers = otelHeaders;
        }
    });
});

builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource.AddService(serviceName, serviceVersion: serviceVersion))
    .WithTracing(tracing =>
    {
        tracing
            .AddAspNetCoreInstrumentation()
            .AddHttpClientInstrumentation()
            .AddOtlpExporter(exporterOptions =>
            {
                exporterOptions.Endpoint = new Uri(otelEndpoint);
                if (!string.IsNullOrWhiteSpace(otelHeaders))
                {
                    exporterOptions.Headers = otelHeaders;
                }
            });
    });
// Add services to the container.
var jwtSection = builder.Configuration.GetSection("Jwt");
var jwtIssuer = jwtSection["Issuer"] ?? throw new InvalidOperationException("Jwt:Issuer is required.");
var jwtAudience = jwtSection["Audience"] ?? throw new InvalidOperationException("Jwt:Audience is required.");
var jwtKey = jwtSection["Key"] ?? throw new InvalidOperationException("Jwt:Key is required.");
if (jwtKey.Length < 32) throw new InvalidOperationException("Jwt:Key must be at least 32 characters.");
var insecureJwtPlaceholders = new[]
{
    "replace_this_with_a_secure_32+_char_secret_key",
    "changeme",
    "your-secret-key",
    "default-secret"
};
if (insecureJwtPlaceholders.Any(x => string.Equals(jwtKey, x, StringComparison.OrdinalIgnoreCase)))
{
    throw new InvalidOperationException("Jwt:Key contains a placeholder value. Configure a secure secret via environment variables or user secrets.");
}

if (!builder.Environment.IsDevelopment())
{
    var rabbitUser = builder.Configuration["RabbitMq:UserName"];
    var rabbitPassword = builder.Configuration["RabbitMq:Password"];

    if (string.Equals(rabbitUser, "guest", StringComparison.OrdinalIgnoreCase) &&
        string.Equals(rabbitPassword, "guest", StringComparison.Ordinal))
    {
        throw new InvalidOperationException("RabbitMq guest/guest credentials are not allowed outside Development.");
    }
}

var aiProvider = builder.Configuration["AiSettings:Provider"];
var aiApiKey = builder.Configuration["AiSettings:ApiKey"];
if (!string.IsNullOrWhiteSpace(aiProvider) && !string.Equals(aiProvider, "None", StringComparison.OrdinalIgnoreCase) && string.IsNullOrWhiteSpace(aiApiKey))
{
    throw new InvalidOperationException("AiSettings:ApiKey is required when an AI provider is configured.");
}
var corsOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? [];
if (corsOrigins.Length == 0) throw new InvalidOperationException("Cors:AllowedOrigins must include at least one origin.");

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins(corsOrigins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddSignalR();
builder.Services.AddScoped<ICarCountNotifier, CarCountNotifier>();
builder.Services.AddSingleton<IReservationNotifier, ReservationNotifier>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = !builder.Environment.IsDevelopment();
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = jwtAudience,
        ValidIssuer = jwtIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true
    };
    opt.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrWhiteSpace(accessToken) && path.StartsWithSegments("/carhub"))
            {
                context.Token = accessToken;
            }

            return Task.CompletedTask;
        }
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(PolicyNames.AdminOnly, policy => policy.RequireRole(RolesType.Admin.ToString()));
    options.AddPolicy(PolicyNames.EmployeeOnly, policy => policy.RequireRole(RolesType.Admin.ToString(), RolesType.Manager.ToString()));
    options.AddPolicy(PolicyNames.MemberOrAdmin, policy => policy.RequireRole(RolesType.Member.ToString(), RolesType.Admin.ToString()));
});

builder.Services.AddHttpClient("InternalApi", client =>
{
    var baseUrl = builder.Configuration["InternalServices:ApiBaseUrl"] ?? throw new InvalidOperationException("InternalServices:ApiBaseUrl is required.");
    client.BaseAddress = new Uri(baseUrl);
});
builder.Services.AddPersistenceServices(builder.Configuration)
                .AddInfrastructureServices(builder.Configuration)
                .AddApplicationServices();

builder.Services.AddControllers().AddJsonOptions(config =>
{
    config.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();
var app = builder.Build();

app.UseExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.MapOpenApi("/openapi/{documentName}.json").AllowAnonymous();

    app.MapScalarApiReference(options =>
    {
        options.WithOpenApiRoutePattern("/openapi/{documentName}.json");
    });
}
else
{
    app.UseExceptionHandler();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<CarHub>("/carhub");
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    await AppDbContextSeed.MigrateAsync(context, userManager);
}
app.Run();