using App.BLL.DTO;
using App.BLL.Mappers;
using App.Contracts.BLL.Services;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories;
using AutoMapper;
using Base.BLL.Services;
using Base.Contracts.BLL.Mappers;

namespace App.BLL.Services;

public class FileTypeService:BaseEntityService<IAppUnitOfWork, IFileTypeRepository, App.BLL.DTO.FileType, App.DAL.DTO.FileType>, IFileTypeService
{
    public FileTypeService(IAppUnitOfWork serviceUow, IFileTypeRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new FileTypeMapper(mapper))
    {
    }
}