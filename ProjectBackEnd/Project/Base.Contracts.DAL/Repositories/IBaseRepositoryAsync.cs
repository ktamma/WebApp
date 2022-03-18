using Base.Contracts.Domain;

namespace Base.Contracts.DAL.Repositories
{
    public interface IBaseRepositoryAsync<TEntity, TKey>: IBaseRepositoryCommon<TEntity, TKey>
        where TEntity : class, IDomainEntityId<TKey> // any more rules? maybe ID?
        where TKey : IEquatable<TKey>
    {
        //list of TEntity
        Task<IEnumerable<TEntity>> GetAllAsync(bool noTracking = true);
        //single Tentity
        Task<TEntity?> FirstOrDefaultAsync(TKey id, bool noTracking = true);

        Task<bool> ExistsAsync(TKey id);
        
        Task <TEntity> RemoveAsync(TKey id);
        
        Task<IEnumerable<TEntity>> GetAllAsync(TKey userId, bool noTracking = true);
        
        Task<TEntity?> FirstOrDefaultAsync(TKey id, TKey userId, bool noTracking = true);
        
        Task<bool> ExistsAsync(TKey id, TKey userId);
        
        Task <TEntity> RemoveAsync(TKey id, TKey userId);

    }
}