using App.DAL.DTO;
using AutoMapper;

namespace App.DAL.Mappers;

public class TakeMapper: BaseMapper<App.DAL.DTO.Take, App.Domain.Take>
{
    public TakeMapper(IMapper mapper) : base(mapper)
    {
    }
    public override Take Map(Domain.Take? entity)
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

    public override Domain.Take? Map(Take? entity)
    {
        return new Domain.Take()
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