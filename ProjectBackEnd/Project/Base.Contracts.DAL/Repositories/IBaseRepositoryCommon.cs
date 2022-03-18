using Base.Contracts.Domain;

namespace Base.Contracts.DAL.Repositories
{
    public interface IBaseRepositoryCommon<TEntity, TKey>
        where TEntity : class, IDomainEntityId<TKey> // any more rules? maybe ID?
        where TKey : IEquatable<TKey>
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Remove(TEntity entity, TKey? userId);
        TEntity Remove(TEntity entity);

    }
}