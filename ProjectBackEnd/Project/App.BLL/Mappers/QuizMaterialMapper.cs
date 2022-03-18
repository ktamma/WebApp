using App.BLL.DTO;
using App.BLL.Mappers.Base;
using AutoMapper;

namespace App.BLL.Mappers;

public class QuizMaterialMapper: BaseMapper<App.BLL.DTO.QuizMaterial, App.DAL.DTO.QuizMaterial>
{
    public QuizMaterialMapper(IMapper mapper) : base(mapper)
    {
    }
    public override QuizMaterial Map(App.DAL.DTO.QuizMaterial? entity)
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

    public override App.DAL.DTO.QuizMaterial? Map(QuizMaterial? entity)
    {
        return new App.DAL.DTO.QuizMaterial()
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