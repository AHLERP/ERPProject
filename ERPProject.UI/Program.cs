using FirstProgramUI.ApiServices.Interfaces;
using FirstProgramUI.ApiServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using ERPProject.UI.Handler;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

//#region HttpClient
//builder.Services.AddHttpClient<IAuthApiService, AuthApiService>(opt =>
//{
//    opt.BaseAddress = new Uri("https://localhost:7161/api/");
//});
//builder.Services.AddHttpClient<IRequestApiService, RequestApiService>(opt =>
//{
//    opt.BaseAddress = new Uri("https://localhost:7161/api/");
//});
//builder.Services.AddHttpClient<IUserApiService, UserApiService>(opt =>
//{
//    opt.BaseAddress = new Uri("https://localhost:7161/api/");
//}).AddHttpMessageHandler<AuthTokenHandler>();

//#endregion

#region Cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Auths/Login";
    opt.ExpireTimeSpan = TimeSpan.FromDays(60);
    opt.SlidingExpiration = true;
    opt.Cookie.Name = "mvccookie";
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
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
