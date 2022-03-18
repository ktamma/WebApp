using App.BLL.DTO;
using App.BLL.Mappers.Base;
using AutoMapper;

namespace App.BLL.Mappers;

public class QuizQuestionMapper: BaseMapper<App.BLL.DTO.QuizQuestion,App.DAL.DTO.QuizQuestion>
{
    public QuizQuestionMapper(IMapper mapper) : base(mapper)
    {
    }
    public override QuizQuestion Map(App.DAL.DTO.QuizQuestion? entity)
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

    public override App.DAL.DTO.QuizQuestion? Map(QuizQuestion? entity)
    {
        return new App.DAL.DTO.QuizQuestion()
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