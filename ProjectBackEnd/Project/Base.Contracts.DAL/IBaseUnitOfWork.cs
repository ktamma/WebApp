namespace Base.Contracts.DAL
{
    public interface IBaseUnitOfWork
    {
        Task<int> SaveChangesAsync();
        TRepository GetRepository<TRepository>(Func<TRepository> repoCreationMethod)
            where TRepository : class;
    }
}