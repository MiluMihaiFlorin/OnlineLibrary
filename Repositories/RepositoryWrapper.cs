using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories.Interfaces;

namespace OnlineLibrary.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private OnlineLibraryContext _OnlineLibraryContext;
        private ICategoryRepository? _CategoryRepository;
        private IAuthorRepository? _AuthorRepository;
        private IBookRepository? _BookRepository;

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


        public RepositoryWrapper(OnlineLibraryContext onlineLibraryContext)
        {
            _OnlineLibraryContext = onlineLibraryContext;
        }

        public void Save()
        {
            _OnlineLibraryContext.SaveChanges();
        }
        
    }
}
