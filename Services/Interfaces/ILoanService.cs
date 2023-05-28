using OnlineLibrary.Areas.Identity.Data;
using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Models.ModelViews;

namespace OnlineLibrary.Services.Interfaces
{
    public interface ILoanService
    {
        public List<Loan> GetAllLoans();

        public Task AddNewLoan(Loan loan, List<string> userIds, List<Guid> bookIds);

        public int GetNumberOfLoans();

        public List<Loan> GetBySearchCondition(string userName);
    }
}
