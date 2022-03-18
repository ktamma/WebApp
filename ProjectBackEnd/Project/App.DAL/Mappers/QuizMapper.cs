using App.DAL.DTO;
using AutoMapper;

namespace App.DAL.Mappers;

public class QuizMapper : BaseMapper<App.DAL.DTO.Quiz, App.Domain.Quiz>
{
    public QuizMapper(IMapper mapper) : base(mapper)
    {
    }
    public override Quiz Map(Domain.Quiz? entity)
    {
        return new Quiz()
        {
            Id = entity!.Id,
            CategoryId = entity.CategoryId,
            QuizTypeId = entity.QuizTypeId,
            Title = entity.Title,
            Description = entity.Description,
            Access = entity.Access,
            Score = entity.Score,
            Rating = entity.Rating,
            Time = entity.Time,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
        
    }

    public override Domain.Quiz? Map(Quiz? entity)
    {
        return new Domain.Quiz()
        {
            Id = entity!.Id,
            CategoryId = entity.CategoryId,
            QuizTypeId = entity.QuizTypeId,
            Title = entity.Title,
            Description = entity.Description,
            Access = entity.Access,
            Score = entity.Score,
            Rating = entity.Rating,
            Time = entity.Time,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
         
    }
}