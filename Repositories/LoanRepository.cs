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
    }
    
}
