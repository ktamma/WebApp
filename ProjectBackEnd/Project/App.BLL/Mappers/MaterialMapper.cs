using App.BLL.DTO;
using App.BLL.Mappers.Base;
using AutoMapper;

namespace App.BLL.Mappers;

public class MaterialMapper: BaseMapper<App.BLL.DTO.Material, App.DAL.DTO.Material>
{
    public MaterialMapper(IMapper mapper) : base(mapper)
    {
    }
    public override Material Map(App.DAL.DTO.Material? entity)
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

    public override App.DAL.DTO.Material? Map(Material? entity)
    {
        return new App.DAL.DTO.Material()
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