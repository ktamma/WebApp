using App.BLL.DTO;
using App.BLL.Mappers;
using App.Contracts.BLL.Services;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories;
using AutoMapper;
using Base.BLL.Services;
using Base.Contracts.BLL.Mappers;

namespace App.BLL.Services;

public class MaterialService:BaseEntityService<IAppUnitOfWork, IMaterialRepository, App.BLL.DTO.Material, App.DAL.DTO.Material>, IMaterialService
{
    public MaterialService(IAppUnitOfWork serviceUow, IMaterialRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new MaterialMapper(mapper))
    {
    }
}