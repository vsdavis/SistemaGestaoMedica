using Microsoft.EntityFrameworkCore;
using SistemaGestaoMedica.Data;

var builder = WebApplication.CreateBuilder(args);

// Adicionando o Entity Framework e a conex�o com MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Adicionando servi�os do MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura��o do pipeline de requisi��o
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
