using OnlineLibrary.Areas.Identity.Data;

namespace OnlineLibrary.Repositories.Interfaces
{
    public interface IUserRepository: IRepositoryBase<OnlineLibraryUser>
    {
        public Task<List<OnlineLibraryUser>> GetUsers();

        public OnlineLibraryUser GetById(string userId);
    }
}
