using OnlineLibrary.Models.DBEntities;

namespace OnlineLibrary.Services.Interfaces
{
    public interface IAuthorService
    {
        List<Models.DBEntities.Author> GetAuthorByName(string authorName);
        public List<Author> GetAll();

        public List<Author> GetBySearchCondition(string searchString);

        public int GetNumberOfListedAuthors();

    }
}
