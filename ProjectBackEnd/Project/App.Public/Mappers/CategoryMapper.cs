using App.BLL.DTO;
using App.Public.Mappers.Base;
using AutoMapper;

namespace App.Public.Mappers;

public class CategoryMapper: BaseMapper<App.DTO.v1.Category, App.BLL.DTO.Category>
{
    public CategoryMapper(IMapper mapper) : base(mapper)
    {
    }
    public override Category Map(App.DTO.v1.Category? entity)
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

    public override App.DTO.v1.Category? Map(Category? entity)
    {
        return new App.DTO.v1.Category()
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