using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories.Interfaces;

namespace OnlineLibrary.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private OnlineLibraryContext _OnlineLibraryContext;
        private ICategoryRepository? _CategoryRepository;

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
