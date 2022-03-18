using App.BLL.DTO;
using App.Public.Mappers.Base;
using AutoMapper;

namespace App.Public.Mappers;

public class QuizMapper: BaseMapper<App.DTO.v1.Quiz, App.BLL.DTO.Quiz>
{
    public QuizMapper(IMapper mapper) : base(mapper)
    {
    }
    public override Quiz Map(App.DTO.v1.Quiz? entity)
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

    public override App.DTO.v1.Quiz? Map(Quiz? entity)
    {
        return new App.DTO.v1.Quiz()
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