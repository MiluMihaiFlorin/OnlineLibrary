using Microsoft.CodeAnalysis;
using OnlineLibrary.Models.DBEntities;

namespace OnlineLibrary.Repositories.Interfaces
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        public Task<List<Book>> GetBooks();
    }
}
