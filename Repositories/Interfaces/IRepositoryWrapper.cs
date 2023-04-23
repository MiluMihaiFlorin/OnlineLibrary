namespace OnlineLibrary.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository CategoryRepository { get; }

        void Save();
    }
}
