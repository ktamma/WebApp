using App.DAL.DTO;
using AutoMapper;

namespace App.DAL.Mappers;

public class QuizTypeMapper: BaseMapper<App.DAL.DTO.QuizType, App.Domain.QuizType>
{
    public QuizTypeMapper(IMapper mapper) : base(mapper)
    {
    }

    public override QuizType Map(Domain.QuizType? entity)
    {
        return new App.DAL.DTO.QuizType()
        {
            Id = entity!.Id,
            Value = entity.Value,
            Description = entity.Description,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
        
    }

    public override Domain.QuizType? Map(QuizType? entity)
    {
        return new Domain.QuizType()
        {
            Id = entity!.Id,
            Value = entity.Value,
            Description = entity.Description,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
         
    }

}