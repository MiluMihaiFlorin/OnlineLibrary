using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories;
using OnlineLibrary.Repositories.Interfaces;
using OnlineLibrary.Services;
using OnlineLibrary.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using OnlineLibrary.Data;
using OnlineLibrary.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDefaultIdentity<OnlineLibraryUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>().AddEntityFrameworkStores<OnlineLibraryContext>();
builder.Services.AddDbContext<OnlineLibraryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineLibraryDb")));


builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();  
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.Configure<IdentityOptions>(options =>

{
    //Passowrd settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredUniqueChars = 6;

    //Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    //User settings
    options.User.RequireUniqueEmail = true;

}
);

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
    pattern: "{controller=Home}/{action=Index}/{id?}");


using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "User" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}


using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<OnlineLibraryUser>>();
    string email = "admin@admin.com";
    string password = "Admin123456!";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var adminUser = new OnlineLibraryUser
        {
            UserName = email,
            Email = email,
        };
        await userManager.CreateAsync(adminUser, password);

        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}

app.MapRazorPages();

app.Run();
