using App.BLL.DTO;
using App.BLL.Mappers.Base;
using AutoMapper;

namespace App.BLL.Mappers;

public class CategoryMapper: BaseMapper<App.BLL.DTO.Category, App.DAL.DTO.Category>
{
    public CategoryMapper(IMapper mapper) : base(mapper)
    {
    }
    public override Category Map(App.DAL.DTO.Category? entity)
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

    public override App.DAL.DTO.Category? Map(Category? entity)
    {
        return new App.DAL.DTO.Category()
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