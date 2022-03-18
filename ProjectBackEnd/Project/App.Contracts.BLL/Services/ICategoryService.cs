using App.DAL.Contracts.Repositories;
using Base.Contracts.BLL.Services;

namespace App.Contracts.BLL.Services;

public interface ICategoryService: IBaseEntityService<App.BLL.DTO.Category, App.DAL.DTO.Category>, ICategoryRepositoryCustom<App.DAL.DTO.Category>
{
    
}