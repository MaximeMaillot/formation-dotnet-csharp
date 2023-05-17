using Demo_Caisse.Binders;
using Demo_Caisse.Data;
using Demo_Caisse.Models;
using Demo_Caisse.Repositories;
using Demo_Caisse.Services;
using EFHelper.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();  // ici on a de l'inversion de contrôle, un couplage faible
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();  // ici on a de l'inversion de contrôle, un couplage faible

builder.Services.AddMvc((options) =>
{
    options.ModelBinderProviders.Insert(0, new CustomBinderProvider());
});

builder.Services.AddScoped<IUploadService, UploadService>();

builder.Services.AddSession();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
