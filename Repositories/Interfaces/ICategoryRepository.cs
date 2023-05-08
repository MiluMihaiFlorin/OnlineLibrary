using Microsoft.CodeAnalysis;
using OnlineLibrary.Models.DBEntities;

namespace OnlineLibrary.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        public Category GetCategoryWithDetails(Guid id);

        public Category GetCategoryByName(string categoryName);

    }
}
