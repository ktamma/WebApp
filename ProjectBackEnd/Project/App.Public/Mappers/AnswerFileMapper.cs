using App.BLL.DTO;
using App.Public.Mappers.Base;
using AutoMapper;

namespace App.Public.Mappers;

public class AnswerFileMapper : BaseMapper<App.DTO.v1.AnswerFile, App.BLL.DTO.AnswerFile>
{
    public AnswerFileMapper(IMapper mapper) : base(mapper)
    {
    }

    public override AnswerFile Map(App.DTO.v1.AnswerFile? entity)
    {
        return new AnswerFile()
        {
            Id = entity!.Id,
            FileTypeId = entity.FileTypeId,
            QuizAnswerId = entity.QuizAnswerId,
            Title = entity.Title,
            LocationString = entity.LocationString,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,
        };
    }

    public override App.DTO.v1.AnswerFile? Map(AnswerFile? entity)
    {
        return new App.DTO.v1.AnswerFile()
        {
            Id = entity!.Id,
            FileTypeId = entity.FileTypeId,
            QuizAnswerId = entity.QuizAnswerId,
            Title = entity.Title,
            LocationString = entity.LocationString,
            CreatedAt = entity.CreatedAt,
            CreatedBy = entity.CreatedBy,
            UpdatedAt = entity.UpdatedAt,
            UpdatedBy = entity.UpdatedBy,
        };
    }
}