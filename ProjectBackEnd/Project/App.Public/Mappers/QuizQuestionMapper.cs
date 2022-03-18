using App.BLL.DTO;
using App.Public.Mappers.Base;
using AutoMapper;

namespace App.Public.Mappers;

public class QuizQuestionMapper: BaseMapper<App.DTO.v1.QuizQuestion,App.BLL.DTO.QuizQuestion>
{
    public QuizQuestionMapper(IMapper mapper) : base(mapper)
    {
    }
    public override QuizQuestion Map(App.DTO.v1.QuizQuestion? entity)
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

    public override App.DTO.v1.QuizQuestion? Map(QuizQuestion? entity)
    {
        return new App.DTO.v1.QuizQuestion()
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