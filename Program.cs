using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories;
using OnlineLibrary.Repositories.Interfaces;
using OnlineLibrary.Services;
using OnlineLibrary.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OnlineLibraryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineLibraryDb")));

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

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
