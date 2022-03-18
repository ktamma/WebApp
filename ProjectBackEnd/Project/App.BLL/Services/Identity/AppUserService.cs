using App.BLL.Mappers.Identity;
using App.Contracts.BLL.IdentityService;
using App.DAL.Contracts;
using App.DAL.Contracts.Repositories.Identity;
using AutoMapper;
using Base.BLL.Services;

namespace App.BLL.Services.Identity;

public class AppUserService: BaseEntityService<IAppUnitOfWork, IAppUserRepository, App.BLL.DTO.Identity.AppUser, App.DAL.DTO.Identity.AppUser>, IAppUserService
{
    public AppUserService(IAppUnitOfWork serviceUow, IAppUserRepository serviceRepository, IMapper mapper) : base(serviceUow, serviceRepository, new AppUserMapper(mapper))
    {
    }
}