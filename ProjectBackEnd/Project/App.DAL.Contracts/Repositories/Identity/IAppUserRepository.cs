using App.DAL.DTO.Identity;
using Base.Contracts.DAL.Repositories;

namespace App.DAL.Contracts.Repositories.Identity;

public interface IAppUserRepository: IBaseRepository<AppUser>
{
    
}public interface IAppUserRepositoryCustom<TEntity>
{
}