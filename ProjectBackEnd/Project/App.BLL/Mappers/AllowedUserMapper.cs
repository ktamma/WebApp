using App.BLL.DTO;
using App.BLL.Mappers.Base;
using AutoMapper;

namespace App.BLL.Mappers;

public class AllowedUserMapper: BaseMapper<App.BLL.DTO.AllowedUser, App.DAL.DTO.AllowedUser>
{
    public AllowedUserMapper(IMapper mapper) : base(mapper)
    {
    }
    public override AllowedUser Map(App.DAL.DTO.AllowedUser? entity)
    {
        return new AllowedUser()
        {
            Id = entity!.Id,
            AppUserId = entity.AppUserId,
            QuizId = entity.QuizId,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
        
    }

    public override App.DAL.DTO.AllowedUser? Map(AllowedUser? entity)
    {
        return new App.DAL.DTO.AllowedUser()
        {
            Id = entity!.Id,
            AppUserId = entity.AppUserId,
            QuizId = entity.QuizId,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
         
    }
}