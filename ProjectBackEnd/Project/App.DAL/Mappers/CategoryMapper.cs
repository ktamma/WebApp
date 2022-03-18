using App.DAL.DTO;
using AutoMapper;

namespace App.DAL.Mappers;

public class CategoryMapper: BaseMapper<App.DAL.DTO.Category, App.Domain.Category>
{
    public CategoryMapper(IMapper mapper) : base(mapper)
    {
    }
    public override Category Map(Domain.Category? entity)
    {
        return new Category()
        {
            Id = entity!.Id,
            AppUserId = entity.AppUserId,
            Name = entity.Name,
            Description = entity.Description,
            ImageUrl = entity.ImageUrl,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,
        };
        
    }

    public override Domain.Category? Map(Category? entity)
    {
        return new Domain.Category()
        {
            Id = entity!.Id,
            AppUserId = entity.AppUserId,
            Name = entity.Name,
            Description = entity.Description,
            ImageUrl = entity.ImageUrl,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,
        };
         
    }
}