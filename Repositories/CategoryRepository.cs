using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories.Interfaces;
using OnlineLibrary.Areas.Identity.Data;
using OnlineLibrary.Data;

namespace OnlineLibrary.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(OnlineLibraryContext? onlineLibraryContext) : base(onlineLibraryContext)
        {
        }

        public Category GetCategoryWithDetails(Guid id)
        {
            return OnlineLibraryContext.Categories.Where(x => x.CategoryId.Equals(id)).Include(x => x.Books).FirstOrDefault();
        }

        public Category GetCategoryByName(string categoryName)
        {
            return OnlineLibraryContext.Categories.FirstOrDefault(g => g.Name == categoryName);
        }

    }
}
