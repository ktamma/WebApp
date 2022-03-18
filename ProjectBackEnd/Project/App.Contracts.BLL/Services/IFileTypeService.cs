using App.DAL.Contracts.Repositories;
using Base.Contracts.BLL.Services;

namespace App.Contracts.BLL.Services;

public interface IFileTypeService: IBaseEntityService<App.BLL.DTO.FileType, App.DAL.DTO.FileType>, IFileTypeRepositoryCustom<App.DAL.DTO.FileType>
{
    
}