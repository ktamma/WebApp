using App.BLL.DTO;
using App.BLL.Mappers.Base;
using AutoMapper;

namespace App.BLL.Mappers;

public class AnswerFileMapper : BaseMapper<App.BLL.DTO.AnswerFile, App.DAL.DTO.AnswerFile>
{
    public AnswerFileMapper(IMapper mapper) : base(mapper)
    {
    }

    public override AnswerFile Map(App.DAL.DTO.AnswerFile? entity)
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

    public override App.DAL.DTO.AnswerFile? Map(AnswerFile? entity)
    {
        return new App.DAL.DTO.AnswerFile()
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