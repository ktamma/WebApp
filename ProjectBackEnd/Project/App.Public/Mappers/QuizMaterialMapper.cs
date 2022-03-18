using App.BLL.DTO;
using App.Public.Mappers.Base;
using AutoMapper;

namespace App.Public.Mappers;

public class QuizMaterialMapper: BaseMapper<App.DTO.v1.QuizMaterial, App.BLL.DTO.QuizMaterial>
{
    public QuizMaterialMapper(IMapper mapper) : base(mapper)
    {
    }
    public override QuizMaterial Map(App.DTO.v1.QuizMaterial? entity)
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

    public override App.DTO.v1.QuizMaterial? Map(QuizMaterial? entity)
    {
        return new App.DTO.v1.QuizMaterial()
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