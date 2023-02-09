using Core.Repository.AdminRepo;
using Core.Repository.MainRepo;
using Core.Servises.AdminSer;
using Core.Servises.MainSer;
using Data.MyDbFile;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyDb>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("strCon")
    ));
builder.Services.AddScoped<IAdminService, AdminRepository>();
builder.Services.AddScoped<IMainService, MainRepository>();

#region Security

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = "/SignIn";
    options.LogoutPath = "/SignOut";
    options.ExpireTimeSpan = TimeSpan.FromDays(29);
});

#endregion

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

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Main}/{controller=MainHome}/{action=Main}/{id?}");

app.Run();
