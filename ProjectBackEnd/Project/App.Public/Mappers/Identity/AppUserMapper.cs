using App.BLL.DTO.Identity;
using App.Public.Mappers.Base;
using AutoMapper;

namespace App.BLL.Mappers.Identity;

public class AppUserMapper: BaseMapper<App.BLL.DTO.Identity.AppUser, App.DAL.DTO.Identity.AppUser>
{
    public AppUserMapper(IMapper mapper) : base(mapper)
    {
    }
    
    public override AppUser Map(App.DAL.DTO.Identity.AppUser? entity)
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

    public override App.DAL.DTO.Identity.AppUser? Map(AppUser? entity)
    {
        return new App.DAL.DTO.Identity.AppUser()
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