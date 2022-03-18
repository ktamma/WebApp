using App.DAL.DTO;
using AutoMapper;

namespace App.DAL.Mappers;

public class MaterialMapper: BaseMapper<App.DAL.DTO.Material, App.Domain.Material>
{
    public MaterialMapper(IMapper mapper) : base(mapper)
    {
    }
    public override Material Map(Domain.Material? entity)
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

    public override Domain.Material? Map(Material? entity)
    {
        return new Domain.Material()
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