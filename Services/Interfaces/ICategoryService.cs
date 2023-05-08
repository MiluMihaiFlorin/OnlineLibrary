using OnlineLibrary.Models.DBEntities;

namespace OnlineLibrary.Services.Interfaces
{
    public interface ICategoryService
    {        
        public List<Category> GetAllCategories();

        public List<Category> GetBySearchCondition(string searchString);
        
        public Category GetCategory(Guid id);

        public int GetNumberOfListedCategories();

        public void UpdateCategory(Category category);

        public void DeleteCategory(Guid id);

        public void CreateCategory(Category category);

        public bool CategoryExists(string name);

    }
}
