using Microsoft.VisualBasic;
using OnlineLibrary.Areas.Identity.Data;
using OnlineLibrary.Data;
using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Models.ModelViews;
using OnlineLibrary.Repositories.Interfaces;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary.Services
{
    public class LoanService: ILoanService
    {
        private IRepositoryWrapper _repositoryWrapper;
        private IUserService _userService;
        private IBookService _bookService;

        public LoanService(IRepositoryWrapper repositoryWrapper, IUserService userService, IBookService bookServie)
        {
            _repositoryWrapper = repositoryWrapper; _userService = userService; _bookService= bookServie ;
        }        
        public async Task AddNewLoan(Loan loan, List<string> userIds, List<Guid>bookIds)
        {            
            loan.LoanId = Guid.NewGuid();
            _repositoryWrapper.LoanRepository.Create(loan);
            await _repositoryWrapper.SaveA();
            foreach (var user in userIds) {
                var selectedUser = _userService.GetUserById(user);
                loan.Users.Add(selectedUser);
                _repositoryWrapper.UserRepository.Update(selectedUser);
            }
            foreach (var book in bookIds)
            {
                var selectedBook = _bookService.GetBookById(book);
                loan.Books.Add(selectedBook);
                _repositoryWrapper.BookRepository.Update(selectedBook);
            }

            await _repositoryWrapper.SaveA();


        }

        public List<Loan> GetBySearchCondition(string userName)
        {
            var result = _repositoryWrapper.LoanRepository.FindByCondition(u =>u.Users == _userService.GetBySearchCondition(userName)).ToList()  ;
            return result;
        }


        public int GetNumberOfLoans()
        {
            var result = _repositoryWrapper.LoanRepository.FindAll().Count();
            return result;
        }



        public List<Loan> GetAllLoans(OnlineLibraryUser  user)
        {
            var result =  new List<Loan>();

            if(_userService.GetUserRole(user) == "Admin")
            {
                result = _repositoryWrapper.LoanRepository.GetAllLoans();
            }
            else
            {
                result = _repositoryWrapper.LoanRepository.GetLoansForUser(user).ToList();
            }
            return result;
        }        



    }
}
