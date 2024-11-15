using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using MiniCourse.WebUI.Auths;
using MiniCourse.WebUI.Extensions.Extensions;
using MiniCourse.WebUI.Handlers;
using MiniCourse.WebUI.Users;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

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

//builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddHttpClient<IAuthService,AuthService>(x =>
{
    x.BaseAddress = new Uri(builder.Configuration.GetSection("ApiOption")["BaseAddress"]!);
});

builder.Services.AddHttpClient<IUserService, UserService>(x =>
{
    x.BaseAddress = new Uri(builder.Configuration.GetSection("ApiOption")["BaseAddress"]!);
}).AddHttpMessageHandler<ClientCredentialHandler>(); ;

builder.Services.AddMemoryCache();

builder.Services.AddScoped<ClientCredentialHandler>();


builder.Services.AddControllersWithViews(options =>
{
    options.ModelMetadataDetailsProviders.Clear(); // DataAnnotations validasyonlarini devre disi birakir
}).AddJsonOptions(options => { options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles; }); // Ýliskili entitylerde loopu onler

//ext ready
builder.Services.AddFluentExt(builder.Configuration);



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

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
