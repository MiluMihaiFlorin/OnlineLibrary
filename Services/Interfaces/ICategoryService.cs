using OnlineLibrary.Models.DBEntities;

namespace OnlineLibrary.Services.Interfaces
{
    public interface ICategoryService
    {
        List<Models.DBEntities.Category> GetCategoryByType(string categoryType);
        public List<Category> GetAll();

        public List<Category> GetBySearchCondition(string searchString);
    }
}
