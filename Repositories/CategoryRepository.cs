using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories.Interfaces;

namespace OnlineLibrary.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(OnlineLibraryContext? onlineLibraryContext) : base(onlineLibraryContext)
        {
        }
    }
}
