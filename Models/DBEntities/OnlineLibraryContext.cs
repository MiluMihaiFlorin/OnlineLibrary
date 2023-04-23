using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Models.DBEntities;

namespace OnlineLibrary.Models.DBEntities
{
    public class OnlineLibraryContext:DbContext
    {
        public OnlineLibraryContext(DbContextOptions<OnlineLibrary.Models.DBEntities.OnlineLibraryContext> options) :base(options) { }

        public DbSet<OnlineLibrary.Models.DBEntities.User>? Users { get; set; }

        public DbSet<OnlineLibrary.Models.DBEntities.Book>? Books { get; set; }  

        public DbSet<OnlineLibrary.Models.DBEntities.Author>? Author { get; set; }   

        public DbSet<OnlineLibrary.Models.DBEntities.Loan>? Loans { get; set; }  

        public DbSet<OnlineLibrary.Models.DBEntities.Category> Category { get; set; } = default!;
        
    }
}
