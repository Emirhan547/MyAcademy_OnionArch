using Microsoft.AspNetCore.Authentication.JwtBearer;
using OnionApp.WebUI.Extensions;
using OnionApp.WebUI.Filters;
using System.Net;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

builder.Services.AddServiceExt();

var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"]
                 ?? throw new InvalidOperationException("ApiSettings:BaseUrl is required.");

builder.Services.AddHttpClient("ApiClient", (sp, client) =>
{
    client.BaseAddress = new Uri(apiBaseUrl);

    var httpContextAccessor = sp.GetRequiredService<IHttpContextAccessor>();

    var token = httpContextAccessor.HttpContext?
        .User
        .Claims
        .FirstOrDefault(x => x.Type == "carbooktoken")
        ?.Value;

    if (!string.IsNullOrEmpty(token))
    {
        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);
    }
});

builder.Services
    .AddAuthentication(AuthSchemes.AppCookie)
    .AddCookie(AuthSchemes.AppCookie, opt =>
    {
        opt.LoginPath = "/Login/Index/";
        opt.LogoutPath = "/Login/LogOut/";
        opt.AccessDeniedPath = "/Pages/AccessDenied/";
        opt.Cookie.SameSite = SameSiteMode.Strict;
        opt.Cookie.HttpOnly = true;
        opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        opt.Cookie.Name = "CarBookJwt";
    });

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<ValidationExceptionFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();