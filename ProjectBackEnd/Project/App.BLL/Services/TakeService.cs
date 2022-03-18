using App.BLL.DTO;
using App.BLL.Mappers;
using App.Contracts.BLL.Services;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories;
using AutoMapper;
using Base.BLL.Services;
using Base.Contracts.BLL.Mappers;

namespace App.BLL.Services;

public class TakeService:BaseEntityService<IAppUnitOfWork, ITakeRepository, App.BLL.DTO.Take, App.DAL.DTO.Take>, ITakeService
{
    public TakeService(IAppUnitOfWork serviceUow, ITakeRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new TakeMapper(mapper))
    {
    }
}