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

            if(categoryType == "IsActive")
            {
                categories = _repositoryWrapper.CategoryRepository.FindByCondition(l => l.IsActive == true).ToList();
            }
            else if(categoryType == "IsInactive")
            {
                categories= _repositoryWrapper.CategoryRepository.FindByCondition(l => l.IsActive == false).ToList();
            }
            return categories;
        }
    }
}
