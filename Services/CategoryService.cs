using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories.Interfaces;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary.Services
{
    public class CategoryService : ICategoryService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public CategoryService(IRepositoryWrapper repositoryWrapper) {  _repositoryWrapper = repositoryWrapper; }

        public List<Category> GetCategoryByType(string categoryType)
        {
            var categories = new List<Category>();

            if(categoryType == "active")
            {
                categories = _repositoryWrapper.CategoryRepository.FindByCondition(l => l.IsActive == true).ToList();
            }
            else if(categoryType == "inactive")
            {
                categories= _repositoryWrapper.CategoryRepository.FindByCondition(l => l.IsActive == false).ToList();
            }
            else if(categoryType == "all")
            {
                categories = (List<Category>)_repositoryWrapper.CategoryRepository.FindAll();
            }
            return categories;
        }

        public List<Category> GetAll()
        {
            var result = _repositoryWrapper.CategoryRepository.FindAll().ToList();
            return result;
        }

        public List<Category> GetBySearchCondition(string searchString)
        {
            var result = _repositoryWrapper.CategoryRepository.FindByCondition(s => s.Name == searchString).ToList();
            return result;
        }
    }
}
