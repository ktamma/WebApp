using Base.Contracts.Domain;

namespace Base.Contracts.DAL.Repositories
{
    public interface IBaseRepositorySync<TEntity, TKey> : IBaseRepositoryCommon<TEntity, TKey>
        where TEntity : class, IDomainEntityId<TKey> // any more rules? maybe ID?
        where TKey : IEquatable<TKey>
    {
        // non-async methods
        TEntity FirstOrDefault(TKey id, TKey? userId = default,  bool noTracking = true);
        IEnumerable<TEntity> GetAll(TKey? userId = default, bool noTracking = true);
        bool Exists(TKey id, TKey? userId = default);
        TEntity Remove(TKey id, TKey? userId = default);
    }
}