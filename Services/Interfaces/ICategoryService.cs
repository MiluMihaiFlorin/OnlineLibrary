namespace OnlineLibrary.Services.Interfaces
{
    public interface ICategoryService
    {
        List<Models.DBEntities.Category> GetCategoryByType(string categoryType);
    }
}
