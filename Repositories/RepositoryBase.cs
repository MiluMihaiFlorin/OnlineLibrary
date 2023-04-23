using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories.Interfaces;
using System.Linq.Expressions;

namespace OnlineLibrary.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected Models.DBEntities.OnlineLibraryContext OnlineLibraryContext { get; set; }

        public RepositoryBase(OnlineLibraryContext? onlineLibraryContext)
        {
            this.OnlineLibraryContext = onlineLibraryContext;
        }

        public IQueryable<T>FindAll()
        {
            return OnlineLibraryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.OnlineLibraryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.OnlineLibraryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.OnlineLibraryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.OnlineLibraryContext.Set<T>().Remove(entity);
        }
    }
}
