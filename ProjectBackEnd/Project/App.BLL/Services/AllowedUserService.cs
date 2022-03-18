using App.BLL.Mappers;
using App.Contracts.BLL.Services;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories;
using AutoMapper;
using Base.BLL.Services;

namespace App.BLL.Services;

public class AllowedUserService: BaseEntityService<IAppUnitOfWork, IAllowedUserRepository, App.BLL.DTO.AllowedUser, App.DAL.DTO.AllowedUser>, IAllowedUserService
{
    
    public AllowedUserService(IAppUnitOfWork serviceUow, IAllowedUserRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new AllowedUserMapper(mapper))
    {
    }
}
