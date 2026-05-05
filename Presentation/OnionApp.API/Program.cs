using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnionApp.API.Hubs;
using OnionApp.API.Security;
using OnionApp.Application.Extensions;
using OnionApp.Application.Tools;
using OnionApp.Domain.Entities;
using OnionApp.Domain.Enums;
using OnionApp.Persistence.Context;
using OnionApp.Persistence.Extensions;
using Scalar.AspNetCore;
using Serilog;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var jwtSection = builder.Configuration.GetSection("Jwt");
var jwtIssuer = jwtSection["Issuer"] ?? throw new InvalidOperationException("Jwt:Issuer is required.");
var jwtAudience = jwtSection["Audience"] ?? throw new InvalidOperationException("Jwt:Audience is required.");
var jwtKey = jwtSection["Key"] ?? throw new InvalidOperationException("Jwt:Key is required.");
if (jwtKey.Length < 32) throw new InvalidOperationException("Jwt:Key must be at least 32 characters.");

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