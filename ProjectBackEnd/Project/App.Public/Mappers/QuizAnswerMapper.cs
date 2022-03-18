using App.BLL.DTO;
using App.Public.Mappers.Base;
using AutoMapper;

namespace App.Public.Mappers;

public class QuizAnswerMapper: BaseMapper<App.DTO.v1.QuizAnswer, App.BLL.DTO.QuizAnswer>
{
    public QuizAnswerMapper(IMapper mapper) : base(mapper)
    {
    }
    public override QuizAnswer Map(App.DTO.v1.QuizAnswer? entity)
    {
        return new QuizAnswer()
        {
            Id = entity!.Id,
            QuizId = entity.QuizId,
            QuizQuestionId = entity.QuizQuestionId,
            Content = entity.Content,
            Correct = entity.Correct,
            Active = entity.Active,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
        
    }

    public override App.DTO.v1.QuizAnswer? Map(QuizAnswer? entity)
    {
        return new App.DTO.v1.QuizAnswer()
        {
            Id = entity!.Id,
            QuizId = entity.QuizId,
            QuizQuestionId = entity.QuizQuestionId,
            Content = entity.Content,
            Correct = entity.Correct,
            Active = entity.Active,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
         
    }
}