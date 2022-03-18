using App.BLL.DTO;
using App.BLL.Mappers.Base;
using AutoMapper;

namespace App.BLL.Mappers;

public class QuizTypeMapper: BaseMapper<App.BLL.DTO.QuizType, App.DAL.DTO.QuizType>
{
    public QuizTypeMapper(IMapper mapper) : base(mapper)
    {
    }
    
    public override QuizType Map(App.DAL.DTO.QuizType? entity)
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

    public override App.DAL.DTO.QuizType? Map(QuizType? entity)
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
}