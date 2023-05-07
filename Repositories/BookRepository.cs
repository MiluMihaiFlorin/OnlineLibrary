using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories.Interfaces;

namespace OnlineLibrary.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(OnlineLibraryContext? onlineLibraryContext) : base(onlineLibraryContext)
        {
        }
    }
}
