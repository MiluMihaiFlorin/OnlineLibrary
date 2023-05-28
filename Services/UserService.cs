using OnlineLibrary.Areas.Identity.Data;
using OnlineLibrary.Services.Interfaces;
using OnlineLibrary.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using OnlineLibrary.Models.DBEntities;

namespace OnlineLibrary.Services
{
  
    public class UserService : IUserService
    {
        private IRepositoryWrapper _repositoryWrapper;
        private UserManager<OnlineLibraryUser> _userManager;

        public UserService(IRepositoryWrapper repositoryWrapper, UserManager<OnlineLibraryUser> userManager)
        {
            _repositoryWrapper = repositoryWrapper; 
            _userManager = userManager;
        }
        public Task SetFirstNameAsync(OnlineLibraryUser user, string firstName)
        {
            if (user.FirstName == null)
            {
                user.FirstName = new string(firstName);
            }
            else
            {
                user.FirstName = firstName;
            }

            _repositoryWrapper.UserRepository.Update(user);
            return _repositoryWrapper.SaveA();

        }

        public Task SetLastNameAsync(OnlineLibraryUser user, string lastName)
        {
            if (user.LastName == null)
            {
                user.LastName = new string(lastName);
            }
            else
            {
                user.LastName = lastName;
            }

            _repositoryWrapper.UserRepository.Update(user);
            return _repositoryWrapper.SaveA();

        }

        public string GetUserRole(OnlineLibraryUser user)
        {
            IList<string> role = _userManager.GetRolesAsync(user).Result;
            string mainrole = role.First();

            return mainrole;
        }
        public int GetNumberOfUsers()
        {
            var result = _repositoryWrapper.UserRepository.FindAll().Count();
            return result;
        }
        public List<OnlineLibraryUser> GetBySearchCondition(string searchString)
        {
            var result = _repositoryWrapper.UserRepository.FindByCondition(s => s.FirstName + " " + s.LastName == searchString).ToList();
            return result;
        }


        public Task<List<OnlineLibraryUser>> GetAllUsers()
        {
            return _repositoryWrapper.UserRepository.GetUsers();
        }

        public OnlineLibraryUser GetUserById(string userId)
        {
            return _repositoryWrapper.UserRepository.GetById(userId);
        }
    }
}
