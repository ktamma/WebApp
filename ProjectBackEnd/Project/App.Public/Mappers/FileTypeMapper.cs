using App.BLL.DTO;
using App.Public.Mappers.Base;
using AutoMapper;

namespace App.Public.Mappers;

public class FileTypeMapper: BaseMapper<App.DTO.v1.FileType, App.BLL.DTO.FileType>
{
    public FileTypeMapper(IMapper mapper) : base(mapper)
    {
    }
    
    public override FileType Map(App.DTO.v1.FileType? entity)
    {            Console.WriteLine("------------------------------------------------------");

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

    public override App.DTO.v1.FileType? Map(FileType? entity)
    {
        Console.WriteLine("------------------------------------------------------");
        return new App.DTO.v1.FileType()
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