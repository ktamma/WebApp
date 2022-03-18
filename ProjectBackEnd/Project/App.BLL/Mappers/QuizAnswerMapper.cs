using App.BLL.DTO;
using App.BLL.Mappers.Base;
using AutoMapper;

namespace App.BLL.Mappers;

public class QuizAnswerMapper: BaseMapper<App.BLL.DTO.QuizAnswer, App.DAL.DTO.QuizAnswer>
{
    public QuizAnswerMapper(IMapper mapper) : base(mapper)
    {
    }
    public override QuizAnswer Map(App.DAL.DTO.QuizAnswer? entity)
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

    public override App.DAL.DTO.QuizAnswer? Map(QuizAnswer? entity)
    {
        return new App.DAL.DTO.QuizAnswer()
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