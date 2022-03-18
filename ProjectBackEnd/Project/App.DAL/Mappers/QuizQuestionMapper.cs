using App.DAL.DTO;
using AutoMapper;

namespace App.DAL.Mappers;

public class QuizQuestionMapper: BaseMapper<App.DAL.DTO.QuizQuestion, App.Domain.QuizQuestion>
{
    public QuizQuestionMapper(IMapper mapper) : base(mapper)
    {
    }
    public override QuizQuestion Map(Domain.QuizQuestion? entity)
    {
        return new QuizQuestion()
        {
            Id = entity!.Id,
            QuizId = entity.QuizId,
            Content = entity.Content,
            Number = entity.Number,
            Score = entity.Score,
            Active = entity.Active,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
        
    }

    public override Domain.QuizQuestion? Map(QuizQuestion? entity)
    {
        return new Domain.QuizQuestion()
        {
            Id = entity!.Id,
            QuizId = entity.QuizId,
            Content = entity.Content,
            Number = entity.Number,
            Score = entity.Score,
            Active = entity.Active,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
         
    }
}