using App.BLL.DTO;
using App.Public.Mappers.Base;
using AutoMapper;

namespace App.Public.Mappers;

public class TakeAnswerMapper: BaseMapper<App.DTO.v1.TakeAnswer, App.BLL.DTO.TakeAnswer>
{
    public TakeAnswerMapper(IMapper mapper) : base(mapper)
    {
    }
    public override TakeAnswer Map(App.DTO.v1.TakeAnswer? entity)
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

    public override App.DTO.v1.TakeAnswer? Map(TakeAnswer? entity)
    {
        return new App.DTO.v1.TakeAnswer()
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