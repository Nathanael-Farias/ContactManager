using AuthSystem.Repository;
using AuthSystem.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco de dados
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injeção de dependências
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Adiciona suporte para MVC com View
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura middleware
app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "contactDelete",
    pattern: "contact/delete/{id}",
    defaults: new { controller = "Contact", action = "Delete" });

app.MapControllerRoute(
    name: "contactDeleteConfirmation",
    pattern: "contact/delete/confirm/{id}",
    defaults: new { controller = "Contact", action = "DeleteConfirmation" });


// Configura os endpoints da aplicação
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
