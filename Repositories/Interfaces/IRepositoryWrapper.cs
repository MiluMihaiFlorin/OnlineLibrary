namespace OnlineLibrary.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository CategoryRepository { get; }

        IAuthorRepository AuthorRepository { get; } 

        IBookRepository BookRepository { get; }

        ILoanRepository LoanRepository { get; }

        IUserRepository UserRepository { get; }
        void Save();

        public Task SaveA();
    }
}
