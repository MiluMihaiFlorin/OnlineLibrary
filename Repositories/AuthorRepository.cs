using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories.Interfaces;

namespace OnlineLibrary.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(OnlineLibraryContext? onlineLibraryContext) : base(onlineLibraryContext)
        {
        }
    }
}
