using App.DAL.DTO;
using AutoMapper;

namespace App.DAL.Mappers;

public class AnswerFileMapper: BaseMapper<App.DAL.DTO.AnswerFile, App.Domain.AnswerFile>
{
    public AnswerFileMapper(IMapper mapper) : base(mapper)
    {
    }
    public override AnswerFile Map(Domain.AnswerFile? entity)
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

    public override Domain.AnswerFile? Map(AnswerFile? entity)
    {
        return new Domain.AnswerFile()
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