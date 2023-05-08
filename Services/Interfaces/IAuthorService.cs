using OnlineLibrary.Models.DBEntities;

namespace OnlineLibrary.Services.Interfaces
{
    public interface IAuthorService
    {        
        public List<Author> GetAllAuthors();

        public List<Author> GetBySearchCondition(string searchString);

        public Author GetAuthor(Guid id);
        

        public int GetNumberOfListedAuthors();

        public void UpdateAuthor(Author author);

        public void DeleteAuthor(Guid id);

        public void CreateAuthor(Author author);

        public bool AuthorExists(string name);

    }
}
