using App.DAL.DTO;
using AutoMapper;

namespace App.DAL.Mappers;

public class QuizAnswerMapper: BaseMapper<App.DAL.DTO.QuizAnswer, App.Domain.QuizAnswer>
{
    public QuizAnswerMapper(IMapper mapper) : base(mapper)
    {
    }
    public override QuizAnswer Map(Domain.QuizAnswer? entity)
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

    public override Domain.QuizAnswer? Map(QuizAnswer? entity)
    {
        return new Domain.QuizAnswer()
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