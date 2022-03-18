using App.DAL.DTO;
using AutoMapper;

namespace App.DAL.Mappers;

public class QuizMaterialMapper: BaseMapper<App.DAL.DTO.QuizMaterial, App.Domain.QuizMaterial>
{
    public QuizMaterialMapper(IMapper mapper) : base(mapper)
    {
    }
    public override QuizMaterial Map(Domain.QuizMaterial? entity)
    {
        return new QuizMaterial()
        {
            Id = entity!.Id,
            MaterialId = entity.MaterialId,
            QuizId = entity.QuizId,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
        
    }

    public override Domain.QuizMaterial? Map(QuizMaterial? entity)
    {
        return new Domain.QuizMaterial()
        {
            Id = entity!.Id,
            MaterialId = entity.MaterialId,
            QuizId = entity.QuizId,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
         
    }
}