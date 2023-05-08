using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories.Interfaces;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary.Services
{
    public class AuthorService:IAuthorService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public AuthorService(IRepositoryWrapper repositoryWrapper) { _repositoryWrapper = repositoryWrapper; }

        public List<Author> GetAllAuthors()
        {
            var result = _repositoryWrapper.AuthorRepository.FindAll().ToList();
            return result;
        }

        public List<Author> GetBySearchCondition(string searchString)
        {
            var result = _repositoryWrapper.AuthorRepository.FindByCondition(s => s.Name == searchString).ToList();
            return result;
        }

        public int GetNumberOfListedAuthors()
        {
            var nrOfAuthors = _repositoryWrapper.AuthorRepository.FindAll().Count();
            return nrOfAuthors;
        }

        public Author GetAuthor(Guid id)
        {
            return _repositoryWrapper.AuthorRepository.GetAuthorWithDetails(id);
        }

        public void UpdateAuthor(Author author)
        {
            var currentAuthor = _repositoryWrapper.AuthorRepository.Get(author.AuthorId);

            currentAuthor.Name = author.Name;

            _repositoryWrapper.AuthorRepository.Update(currentAuthor);
            _repositoryWrapper.Save();
        }

        public void DeleteAuthor(Guid id) 
        {
            var author = _repositoryWrapper.AuthorRepository.Get(id);
            if(author != null)
            {
                _repositoryWrapper.AuthorRepository.Delete(author);
            }
            _repositoryWrapper.Save();
        }

        public void CreateAuthor(Author author)
        {
            _repositoryWrapper.AuthorRepository.Create(new Author
            {
                AuthorId = author.AuthorId
                ,Name = author.Name
            });
            _repositoryWrapper.Save();
        }

        public bool AuthorExists(string name)
        {
            if (_repositoryWrapper.AuthorRepository.GetAuthorByName(name) != null)
            return true;

            return false;
        }
    }
}
