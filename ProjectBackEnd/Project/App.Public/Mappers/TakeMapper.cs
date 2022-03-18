using App.BLL.DTO;
using App.Public.Mappers.Base;
using AutoMapper;

namespace App.Public.Mappers;

public class TakeMapper: BaseMapper<App.DTO.v1.Take, App.BLL.DTO.Take>
{
    public TakeMapper(IMapper mapper) : base(mapper)
    {
    }
    public override Take Map(App.DTO.v1.Take? entity)
    {
        return new Take()
        {
            Id = entity!.Id,
            QuizId = entity.QuizId,
            AppUserId = entity.AppUserId,
            Status = entity.Status,
            Score = entity.Score,
            StartedAt = entity.StartedAt,
            FinishedAt = entity.FinishedAt,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
        
    }

    public override App.DTO.v1.Take? Map(Take? entity)
    {
        return new App.DTO.v1.Take()
        {
            Id = entity!.Id,
            QuizId = entity.QuizId,
            AppUserId = entity.AppUserId,
            Status = entity.Status,
            Score = entity.Score,
            StartedAt = entity.StartedAt,
            FinishedAt = entity.FinishedAt,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
         
    }
}