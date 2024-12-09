using AuthSystem.Data;
using AuthSystem.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using AuthSystem.Helper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder.WithOrigins("http://localhost:5210")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials());
});


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ISection, Section>();
builder.Services.AddControllersWithViews();
builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true; 
    o.Cookie.IsEssential = true; 
});

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();
app.UseSession();
app.UseCors("AllowLocalhost");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "home",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
