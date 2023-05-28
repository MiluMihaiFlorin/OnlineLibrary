using OnlineLibrary.Areas.Identity.Data;
using OnlineLibrary.Models.DBEntities;

namespace OnlineLibrary.Services.Interfaces
{
    public interface IUserService
    {

        public Task SetFirstNameAsync( OnlineLibraryUser user, string firstName );

        public Task SetLastNameAsync( OnlineLibraryUser user, string lastName );

        public string GetUserRole(OnlineLibraryUser user);

        public Task<List<OnlineLibraryUser>> GetAllUsers();

        public OnlineLibraryUser GetUserById(string userId);

        public List<OnlineLibraryUser> GetBySearchCondition(string searchString);

        public int GetNumberOfUsers();
    }
}
