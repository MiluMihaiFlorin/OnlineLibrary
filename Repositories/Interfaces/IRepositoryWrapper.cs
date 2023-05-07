namespace OnlineLibrary.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository CategoryRepository { get; }

        IAuthorRepository AuthorRepository { get; } 

        IBookRepository BookRepository { get; }
        void Save();
    }
}
