using App.DAL.DTO;
using AutoMapper;

namespace App.DAL.Mappers;

public class AllowedUserMapper: BaseMapper<App.DAL.DTO.AllowedUser, App.Domain.AllowedUser>
{
    public AllowedUserMapper(IMapper mapper) : base(mapper)
    {
    }
    public override AllowedUser Map(Domain.AllowedUser? entity)
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

    public override Domain.AllowedUser? Map(AllowedUser? entity)
    {
        return new Domain.AllowedUser()
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