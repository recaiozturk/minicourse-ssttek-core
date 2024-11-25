using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using MiniCourse.WebUI.Extensions;
using MiniCourse.WebUI.Extensions.Extensions;
using MiniCourse.WebUI.Filters;
using MiniCourse.WebUI.Handlers;
using MiniCourse.WebUI.Hubs;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddSignalR(); // SignalR 

builder.Services.AddControllersWithViews();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});

builder.Services.AddHttpContextAccessor();

ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

//cookiyi sifreleyen keyi kaydeder
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "keys")))
    .SetDefaultKeyLifetime(TimeSpan.FromDays(30));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {

        options.Cookie.Name = "ssttek_cookie";
        options.ExpireTimeSpan = TimeSpan.FromDays(30);
        options.LoginPath = "/Auth/SignIn";
        options.AccessDeniedPath = "/Home/AccessDenied";
    });
builder.Services.AddAuthorization();

builder.Services.AddHttpClientExt(builder.Configuration);

builder.Services.AddControllersWithViews(options =>
{
    options.ModelMetadataDetailsProviders.Clear(); // DataAnnotations validasyonlarini devre disi birakir
}).AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles; }); // Ýliskili entitylerde loopu onler

//ext ready
builder.Services.AddFluentExt(builder.Configuration);

builder.Services.AddMemoryCache();

builder.Services.AddScoped<ClientCredentialHandler>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.MapHub<BasketHub>("/basketHub");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
