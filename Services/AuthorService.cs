using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories.Interfaces;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary.Services
{
    public class AuthorService:IAuthorService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public AuthorService(IRepositoryWrapper repositoryWrapper) { _repositoryWrapper = repositoryWrapper; }

        public List<Author> GetAll()
        {
            var result = _repositoryWrapper.AuthorRepository.FindAll().ToList();
            return result;
        }

        public List<Author> GetBySearchCondition(string searchString)
        {
            var result = _repositoryWrapper.AuthorRepository.FindByCondition(s => s.Name == searchString).ToList();
            return result;
        }

        public List<Author> GetAuthorByName(string authorName)
        {
            throw new NotImplementedException();
        }

        public int GetNumberOfListedAuthors()
        {
            var nrOfAuthors = _repositoryWrapper.AuthorRepository.FindAll().Count();
            return nrOfAuthors;
        }

    }
}
