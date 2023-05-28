using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories.Interfaces;
using OnlineLibrary.Areas.Identity.Data;
using OnlineLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace OnlineLibrary.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(OnlineLibraryContext? onlineLibraryContext) : base(onlineLibraryContext)
        {
        }
        public async Task<List<Book>> GetBooks()
        {
            return await OnlineLibraryContext.Books.Select(x => new Book()
            {
                BookId = x.BookId,
                Title = x.Title,
                Publisher = x.Publisher,
                PublishYear = x.PublishYear,
                ISBN = x.ISBN,
                Quantity = x.Quantity,
            }).ToListAsync();
        }
    }
}
