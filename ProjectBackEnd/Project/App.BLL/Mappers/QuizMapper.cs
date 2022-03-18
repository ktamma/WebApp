using App.BLL.DTO;
using App.BLL.Mappers.Base;
using AutoMapper;

namespace App.BLL.Mappers;

public class QuizMapper: BaseMapper<App.BLL.DTO.Quiz, App.DAL.DTO.Quiz>
{
    public QuizMapper(IMapper mapper) : base(mapper)
    {
    }
    public override Quiz Map(App.DAL.DTO.Quiz? entity)
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

    public override App.DAL.DTO.Quiz? Map(Quiz? entity)
    {
        return new App.DAL.DTO.Quiz()
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