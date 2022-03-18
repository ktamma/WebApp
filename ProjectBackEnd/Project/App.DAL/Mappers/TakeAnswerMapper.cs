using App.DAL.DTO;
using AutoMapper;

namespace App.DAL.Mappers;

public class TakeAnswerMapper: BaseMapper<App.DAL.DTO.TakeAnswer, App.Domain.TakeAnswer>
{
    public TakeAnswerMapper(IMapper mapper) : base(mapper)
    {
    }
    public override TakeAnswer Map(Domain.TakeAnswer? entity)
    {
        return new TakeAnswer()
        {
            Id = entity!.Id,
            TakeId = entity.TakeId,
            QuizAnswerId = entity.QuizAnswerId,
            QuizQuestionId = entity.QuizQuestionId,
            Content = entity.Content,
            Active = entity.Active,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
        
    }

    public override Domain.TakeAnswer? Map(TakeAnswer? entity)
    {
        return new Domain.TakeAnswer()
        {
            Id = entity!.Id,
            TakeId = entity.TakeId,
            QuizAnswerId = entity.QuizAnswerId,
            QuizQuestionId = entity.QuizQuestionId,
            Content = entity.Content,
            Active = entity.Active,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
         
    }
}