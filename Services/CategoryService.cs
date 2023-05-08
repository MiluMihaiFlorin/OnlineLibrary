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

        public List<Category> GetAllCategories()
        {
            var result = _repositoryWrapper.CategoryRepository.FindAll().ToList();
            return result;
        }

        public List<Category> GetBySearchCondition(string searchString)
        {
            var result = _repositoryWrapper.CategoryRepository.FindByCondition(s => s.Name == searchString).ToList();
            return result;
        }
        public int GetNumberOfListedCategories()
        {
            var result = _repositoryWrapper.CategoryRepository.FindAll().Count();
            return result;
        }

        public Category GetCategory(Guid id)
        {
            return _repositoryWrapper.CategoryRepository.GetCategoryWithDetails(id);
        }

        public void UpdateCategory(Category category)
        {
            var currentCategory = _repositoryWrapper.CategoryRepository.Get(category.CategoryId);

            currentCategory.Name = category.Name;
            currentCategory.IsActive = category.IsActive;

            _repositoryWrapper.CategoryRepository.Update(currentCategory);
            _repositoryWrapper.Save();
        }

        public void DeleteCategory(Guid id)
        {
            var category = _repositoryWrapper.CategoryRepository.Get(id);
            if(category != null)
            {
                _repositoryWrapper.CategoryRepository.Delete(category);
            }
            _repositoryWrapper.Save();
        }

        public void CreateCategory(Category category)
        {
            _repositoryWrapper.CategoryRepository.Create(new Category
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                IsActive = category.IsActive,
            });
            _repositoryWrapper.Save();
        }

        public bool CategoryExists(string name)
        {
            if(_repositoryWrapper.CategoryRepository.GetCategoryByName(name) != null)
            {
                return true;
            }
            else 
            {
                return false; 
            }
        }
    }
}
