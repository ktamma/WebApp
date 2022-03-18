using App.BLL.DTO;
using App.Public.Mappers.Base;
using AutoMapper;

namespace App.Public.Mappers;

public class AllowedUserMapper: BaseMapper<App.DTO.v1.AllowedUser, App.BLL.DTO.AllowedUser>
{
    public AllowedUserMapper(IMapper mapper) : base(mapper)
    {
    }
    public override AllowedUser Map(App.DTO.v1.AllowedUser? entity)
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

    public override App.DTO.v1.AllowedUser? Map(AllowedUser? entity)
    {
        return new App.DTO.v1.AllowedUser()
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