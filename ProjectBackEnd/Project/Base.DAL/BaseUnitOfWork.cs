using Base.Contracts.DAL;

namespace Base.DAL
{
    public abstract class BaseUnitOfWork: IBaseUnitOfWork
    {

        public abstract Task<int> SaveChangesAsync();
        private readonly Dictionary<Type, object> _repoCache = new Dictionary<Type, object>();


        public TRepository GetRepository<TRepository>(Func<TRepository> repoCreationMethod)
            where TRepository : class
        {
            if (_repoCache.TryGetValue(typeof(TRepository), out var repo))
            {
                return (TRepository)repo;
            }

            var repoInstance = repoCreationMethod();
            _repoCache.Add(typeof(TRepository), repoInstance);
            return repoInstance;
        }
    }
}