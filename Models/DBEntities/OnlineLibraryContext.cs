using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Models.DBEntities;

namespace OnlineLibrary.Models.DBEntities
{
    public class OnlineLibraryContext: IdentityDbContext<IdentityUser>
    {
        public OnlineLibraryContext(DbContextOptions<OnlineLibrary.Models.DBEntities.OnlineLibraryContext> options) :base(options) { }
        

        public DbSet<OnlineLibrary.Models.DBEntities.Book>? Books { get; set; }  

        public DbSet<OnlineLibrary.Models.DBEntities.Author>? Authors { get; set; }   

        public DbSet<OnlineLibrary.Models.DBEntities.Loan>? Loans { get; set; }  

        public DbSet<OnlineLibrary.Models.DBEntities.Category> Categories { get; set; } = default!;
        
    }
}
