using App.DAL.Contracts.Repositories;
using App.DAL.Contracts.Repositories.Identity;
using Base.Contracts.BLL.Services;

namespace App.Contracts.BLL.IdentityService;

public interface IAppUserService:IBaseEntityService<App.BLL.DTO.Identity.AppUser, App.DAL.DTO.Identity.AppUser>, IAppUserRepositoryCustom<App.DAL.DTO.Identity.AppUser>
{
    
}
