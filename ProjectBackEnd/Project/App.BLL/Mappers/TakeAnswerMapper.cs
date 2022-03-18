using App.BLL.DTO;
using App.BLL.Mappers.Base;
using AutoMapper;

namespace App.BLL.Mappers;

public class TakeAnswerMapper: BaseMapper<App.BLL.DTO.TakeAnswer, App.DAL.DTO.TakeAnswer>
{
    public TakeAnswerMapper(IMapper mapper) : base(mapper)
    {
    }
    public override TakeAnswer Map(App.DAL.DTO.TakeAnswer? entity)
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

    public override App.DAL.DTO.TakeAnswer? Map(TakeAnswer? entity)
    {
        return new App.DAL.DTO.TakeAnswer()
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