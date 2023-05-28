using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Areas.Identity.Data;
using OnlineLibrary.Data;
using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories.Interfaces;

namespace OnlineLibrary.Repositories
{
    public class LoanRepository : RepositoryBase<Loan>, ILoanRepository
    {
        public LoanRepository(OnlineLibraryContext? onlineLibraryContext) : base(onlineLibraryContext)
        {
        }


        public List<Book> GetBooksForLoan(Guid loanId)
        {
            return OnlineLibraryContext.Books.Where(_book => _book.BookId == loanId).ToList();
        }

        public List<Loan> GetAllLoans()
        {
            return OnlineLibraryContext.Loans.Include(l => l.Users).Include(l => l.Books).ToList();

        }
    }
    
}
