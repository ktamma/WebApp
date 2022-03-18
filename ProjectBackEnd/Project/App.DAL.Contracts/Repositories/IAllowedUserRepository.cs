using App.DAL.DTO;
using Base.Contracts.DAL.Repositories;

namespace App.DAL.Contracts.Repositories;

public interface IAllowedUserRepository: IBaseRepository<AllowedUser>
{
    
}
public interface IAllowedUserRepositoryCustom<TEntity>
{
}