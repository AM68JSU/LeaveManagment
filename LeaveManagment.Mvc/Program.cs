using Hanssens.Net;
using LeaveManagment.Mvc.Contratcs;
using LeaveManagment.Mvc.Services;
using LeaveManagment.Mvc.Services.Base;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpContextAccessor();


builder.Services.Configure<CookiePolicyOptions>(options => { options.MinimumSameSitePolicy=SameSiteMode.None;});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
{
    option.LoginPath = "/Users/Login";
});




// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IClient, Client>
    (c => c.BaseAddress = new Uri(builder.Configuration.GetSection("ApiAddress").Value)) ;

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton<ILocalStorage, LocalStorage>();

builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();


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
app.UseCookiePolicy();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
