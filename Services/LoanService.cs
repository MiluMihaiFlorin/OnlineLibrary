using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories.Interfaces;
using OnlineLibrary.Services.Interfaces;

namespace OnlineLibrary.Services
{
    public class LoanService: ILoanService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public LoanService(IRepositoryWrapper repositoryWrapper) { _repositoryWrapper = repositoryWrapper; }
        public List<Loan> GetAllLoans()
        {
            var result = _repositoryWrapper.LoanRepository.FindAll().ToList();
            return result;
        }

    }
}
