using Microsoft.EntityFrameworkCore;
using MiPrimerAppMVC2.Data;
using MiPrimerAppMVC2.Data.Repository;
using MiPrimerAppMVC2.Data.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);


// Cadena de conexión a la BD desde appsettings.json.
var connection = builder.Configuration.GetConnectionString("DefaultConnection");


// Agregar DbContext y su fábrica de diseño.
//Registro de servicios:
//Aquí estamos registrando un DbContextFactory para la clase MyDbContext, que nos permitirá crear instancias de MyDbContext en
//toda la aplicación.

builder.Services.AddDbContextFactory<ProductosContext>(options =>
    options.UseSqlServer(connection));



//Atencion aqui

builder.Services.AddScoped<IProductoRepository, ProductoRepository>();



// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
