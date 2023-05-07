using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories.Interfaces;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary.Services
{
    public class BookService : IBookService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public BookService(IRepositoryWrapper repositoryWrapper) { _repositoryWrapper = repositoryWrapper; }
        public List<Book> GetAll()
        {
            var result = _repositoryWrapper.BookRepository.FindAll().ToList();
            return result;

        }

        public List<Book> GetBookByTitle(string bookTitle)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBySearchCondition(string searchString)
        {
            var result = _repositoryWrapper.BookRepository.FindByCondition(s => s.Title == searchString).ToList();
            return result;
        }

        public int GetNumberOfListedBooks()
        {
            var nrOfListedBooks = _repositoryWrapper.BookRepository.FindAll().Count();
            return nrOfListedBooks; 
        }
    }
}
