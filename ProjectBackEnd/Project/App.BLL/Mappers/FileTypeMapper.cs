using App.BLL.DTO;
using App.BLL.Mappers.Base;
using AutoMapper;

namespace App.BLL.Mappers;

public class FileTypeMapper: BaseMapper<App.BLL.DTO.FileType, App.DAL.DTO.FileType>
{
    public FileTypeMapper(IMapper mapper) : base(mapper)
    {
    }
    
    public override FileType Map(App.DAL.DTO.FileType? entity)
    {
        return new FileType()
        {
            Id = entity!.Id,
            FileExtension = entity.FileExtension,
            Description = entity.Description,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
        
    }

    public override App.DAL.DTO.FileType? Map(FileType? entity)
    {
        return new App.DAL.DTO.FileType()
        {
            Id = entity!.Id,
            FileExtension = entity.FileExtension,
            Description = entity.Description,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,

        };
         
    }
}