using OnlineLibrary.Models.DBEntities;

namespace OnlineLibrary.Repositories.Interfaces
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {
        public Author GetAuthorWithDetails(Guid id);

        public Author GetAuthorByName(string authorName);
    }
    
}
