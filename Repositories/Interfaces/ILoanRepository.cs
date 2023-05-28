using OnlineLibrary.Areas.Identity.Data;
using OnlineLibrary.Models.DBEntities;

namespace OnlineLibrary.Repositories.Interfaces
{
    public interface ILoanRepository : IRepositoryBase<Loan>
    {
        public List<Book> GetBooksForLoan(Guid loanId);

        public List<Loan> GetAllLoans();
    }
}
