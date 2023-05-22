using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Areas.Identity.Data;

namespace OnlineLibrary.Data;

public class OnlineLibraryContext : IdentityDbContext<OnlineLibraryUser>
{
    public OnlineLibraryContext(DbContextOptions<OnlineLibraryContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

	public DbSet<OnlineLibrary.Models.DBEntities.Book>? Books { get; set; }

	public DbSet<OnlineLibrary.Models.DBEntities.Author>? Authors { get; set; }

	public DbSet<OnlineLibrary.Models.DBEntities.Loan>? Loans { get; set; }

	public DbSet<OnlineLibrary.Models.DBEntities.Category> Categories { get; set; }

}
