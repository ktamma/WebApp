using App.BLL.DTO;
using App.Public.Mappers.Base;
using AutoMapper;

namespace App.Public.Mappers;

public class MaterialMapper: BaseMapper<App.DTO.v1.Material, App.BLL.DTO.Material>
{
    public MaterialMapper(IMapper mapper) : base(mapper)
    {
    }
    public override Material Map(App.DTO.v1.Material? entity)
    {
        return new Material()
        {
            Id = entity!.Id,
            CategoryId = entity.CategoryId,
            FileTypeId = entity.FileTypeId,
            Title = entity.Title,
            Payload = entity.Payload,
            Description = entity.Description,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
        
    }

    public override App.DTO.v1.Material? Map(Material? entity)
    {
        return new App.DTO.v1.Material()
        {
            Id = entity!.Id,
            CategoryId = entity.CategoryId,
            FileTypeId = entity.FileTypeId,
            Title = entity.Title,
            Payload = entity.Payload,
            Description = entity.Description,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
         
    }
}