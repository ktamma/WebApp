using App.DAL.DTO;
using AutoMapper;

namespace App.DAL.Mappers;

public class FileTypeMapper: BaseMapper<App.DAL.DTO.FileType, App.Domain.FileType>
{
    public FileTypeMapper(IMapper mapper) : base(mapper)
    {
    }
    
    public override FileType Map(Domain.FileType? entity)
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

    public override Domain.FileType? Map(FileType? entity)
    {
        return new Domain.FileType()
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