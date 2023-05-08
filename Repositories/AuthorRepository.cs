using Microsoft.EntityFrameworkCore;
using OnlineLibrary.Models.DBEntities;
using OnlineLibrary.Repositories.Interfaces;

namespace OnlineLibrary.Repositories
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(OnlineLibraryContext? onlineLibraryContext) : base(onlineLibraryContext)
        {            
        }

        public Author GetAuthorWithDetails(Guid id)
        {
            return OnlineLibraryContext.Authors.Where(x => x.AuthorId.Equals(id)).Include(x => x.Books).FirstOrDefault();
        }

        public Author GetAuthorByName(string authorName)
        {
            return OnlineLibraryContext.Authors.FirstOrDefault(g => g.Name == authorName);
        }
    }
}
