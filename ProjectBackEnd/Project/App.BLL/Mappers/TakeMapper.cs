using App.BLL.DTO;
using App.BLL.Mappers.Base;
using AutoMapper;

namespace App.BLL.Mappers;

public class TakeMapper: BaseMapper<App.BLL.DTO.Take, App.DAL.DTO.Take>
{
    public TakeMapper(IMapper mapper) : base(mapper)
    {
    }
    public override Take Map(App.DAL.DTO.Take? entity)
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

    public override App.DAL.DTO.Take? Map(Take? entity)
    {
        return new App.DAL.DTO.Take()
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