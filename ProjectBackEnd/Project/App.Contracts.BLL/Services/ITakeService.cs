using App.DAL.Contracts.Repositories;
using Base.Contracts.BLL.Services;

namespace App.Contracts.BLL.Services;

public interface ITakeService: IBaseEntityService<App.BLL.DTO.Take, App.DAL.DTO.Take>, ITakeRepositoryCustom<App.DAL.DTO.Take>
{
    
}