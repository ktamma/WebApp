using App.DAL.Contracts.Repositories;
using Base.Contracts.BLL.Services;

namespace App.Contracts.BLL.Services;

public interface IAllowedUserService: IBaseEntityService<App.BLL.DTO.AllowedUser, App.DAL.DTO.AllowedUser>, IAllowedUserRepositoryCustom<App.DAL.DTO.AllowedUser>
{
    
}