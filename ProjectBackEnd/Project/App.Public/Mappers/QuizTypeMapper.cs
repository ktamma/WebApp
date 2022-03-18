using App.BLL.DTO;
using App.Public.Mappers.Base;
using AutoMapper;

namespace App.Public.Mappers;

public class QuizTypeMapper: BaseMapper<App.DTO.v1.QuizType, App.BLL.DTO.QuizType>
{
    public QuizTypeMapper(IMapper mapper) : base(mapper)
    {
    }
    
    public override QuizType Map(App.DTO.v1.QuizType? entity)
    {
        return new QuizType()
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

    public override App.DTO.v1.QuizType? Map(QuizType? entity)
    {
        return new App.DTO.v1.QuizType()
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