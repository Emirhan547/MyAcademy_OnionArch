using Microsoft.AspNetCore.Authentication.JwtBearer;
using OnionApp.WebUI.Extensions;
using OnionApp.WebUI.Filters;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddServiceExt();
var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? throw new InvalidOperationException("ApiSettings:BaseUrl is required.");
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
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
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
