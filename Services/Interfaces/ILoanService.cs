using OnlineLibrary.Models.DBEntities;

namespace OnlineLibrary.Services.Interfaces
{
    public interface ILoanService
    {
        public List<Loan> GetAllLoans();
    }
}
