using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories.Interfaces;
using OnlineLibrary.Areas.Identity.Data;
using OnlineLibrary.Data;

namespace OnlineLibrary.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private OnlineLibraryContext _OnlineLibraryContext;
        private ICategoryRepository? _CategoryRepository;
        private IAuthorRepository? _AuthorRepository;
        private IBookRepository? _BookRepository;
        private ILoanRepository? _LoanRepository;
        private IUserRepository? _UserRepository;

        public ICategoryRepository CategoryRepository 
        {
            get
            {
                if(_CategoryRepository == null)
                {
                    _CategoryRepository = new CategoryRepository(_OnlineLibraryContext);
                }

                return _CategoryRepository;
            }
        
        }

        public IAuthorRepository AuthorRepository
        {
            get
            {
                if (_AuthorRepository == null)
                {
                    _AuthorRepository = new AuthorRepository(_OnlineLibraryContext);
                }

                return _AuthorRepository;
            }

        }

        public IBookRepository BookRepository
        {
            get
            {
                if (_BookRepository == null)
                {
                    _BookRepository = new BookRepository(_OnlineLibraryContext);
                }

                return _BookRepository;
            }

        }

        public ILoanRepository LoanRepository
        {
            get
            {
                if (_LoanRepository == null)
                {
                    _LoanRepository = new LoanRepository(_OnlineLibraryContext);
                }

                return _LoanRepository;
            }

        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_UserRepository == null)
                {
                    _UserRepository = new UserRepository(_OnlineLibraryContext);
                }

                return _UserRepository;
            }

        }


        public RepositoryWrapper(OnlineLibraryContext onlineLibraryContext)
        {
            _OnlineLibraryContext = onlineLibraryContext;
        }

        public void Save()
        {
            _OnlineLibraryContext.SaveChanges();
        }

        public Task SaveA()
        {
            return _OnlineLibraryContext.SaveChangesAsync();
        }

    }
}
