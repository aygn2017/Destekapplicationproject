using DestekApp.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("conn");
builder.Services.AddDbContext<DestekAppDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllersWithViews();


// g�venlik i�in koyuldu
builder.Services.Configure<Microsoft.AspNetCore.Mvc.CookieTempDataProviderOptions>(options =>
{
    options.Cookie.IsEssential = true;
});

// g�venlik i�in koyuldu
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

// g�venlik i�in koyuldu
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/Hesap/Giri�";
    options.AccessDeniedPath = "/Hesap/Giri�";
    options.LogoutPath = "/";

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
app.UseStaticFiles();

app.UseCookiePolicy();     // g�venlik i�in koyuldu
app.UseAuthentication();   // g�venlik i�in koyuldu


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
