using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Areas.Identity.Data;
using OnlineLibrary.Data;
using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories.Interfaces;

namespace OnlineLibrary.Repositories
{
    public class UserRepository:RepositoryBase<OnlineLibraryUser>, IUserRepository
    {
        public UserRepository(OnlineLibraryContext context) : base(context) { }

        public async Task<List<OnlineLibraryUser>> GetUsers()
        {
            return await OnlineLibraryContext.Users.Select(x => new OnlineLibraryUser()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                UserName = x.UserName,
                PasswordHash = x.PasswordHash,
            }).ToListAsync();
        }
        
        public OnlineLibraryUser GetById(string userId) {
            return OnlineLibraryContext.Users.Where(_user => _user.Id == userId).First();
        }

    }
}
