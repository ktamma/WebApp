namespace Base.Contracts.Domain;

public interface IDomainEntity : IDomainEntity<Guid>
{
        
}
    
public interface IDomainEntity<TKey> : IDomainEntityId<TKey>, IDomainEntityMeta
    where TKey: IEquatable<TKey>

{
        
}