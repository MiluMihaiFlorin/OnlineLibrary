using OnlineLibrary.Models.DBEntities;

namespace OnlineLibrary.Services.Interfaces
{
    public interface IBookService
    {
        List<Models.DBEntities.Book> GetBookByTitle(string bookTitle);
        public List<Book> GetAll();

        public List<Book> GetBySearchCondition(string searchString);

        public int GetNumberOfListedBooks();

        public Task<List<Book>> GetAllBooks();

        public Book GetBookById(Guid bookId);

    }
}
