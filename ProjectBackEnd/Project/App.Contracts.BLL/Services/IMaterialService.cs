using App.DAL.Contracts.Repositories;
using Base.Contracts.BLL.Services;

namespace App.Contracts.BLL.Services;

public interface IMaterialService: IBaseEntityService<App.BLL.DTO.Material, App.DAL.DTO.Material>, IMaterialRepositoryCustom<App.DAL.DTO.Material>
{
    
}