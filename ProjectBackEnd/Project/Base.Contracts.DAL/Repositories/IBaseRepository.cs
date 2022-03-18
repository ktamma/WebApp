using Base.Contracts.Domain;

namespace Base.Contracts.DAL.Repositories
{
    public interface IBaseRepository<TEntity> : IBaseRepository<TEntity, Guid>
        where TEntity : class, IDomainEntityId<Guid>
    {
        
    }
    
    public interface IBaseRepository<TEntity, TKey> : IBaseRepositoryAsync<TEntity, TKey>
        where TEntity : class, IDomainEntityId<TKey> 
        where TKey : IEquatable<TKey>
    {
       
    }
    
    
}