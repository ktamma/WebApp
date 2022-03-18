using App.DAL.DTO.Identity;
using AutoMapper;

namespace App.DAL.Mappers.Identity;

public class AppUserMapper: BaseMapper<App.DAL.DTO.Identity.AppUser, App.Domain.Identity.AppUser>
{
    public AppUserMapper(IMapper mapper) : base(mapper)
    {
    }
    
    public override AppUser Map(Domain.Identity.AppUser? entity)
    {
        return new AppUser()
        {
            Id = entity!.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            UserName = entity.UserName,
            Email = entity.Email,
            NormalizedEmail = entity.NormalizedEmail,
            NormalizedUserName = entity.NormalizedUserName,

        };
        
    }

    public override Domain.Identity.AppUser? Map(AppUser? entity)
    {
        return new Domain.Identity.AppUser()
        {
            Id = entity!.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            UserName = entity.UserName,
            Email = entity.Email,
            NormalizedEmail = entity.NormalizedEmail,
            NormalizedUserName = entity.NormalizedUserName,

        };
         
    }
}