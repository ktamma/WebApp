using Base.Domain;

namespace App.DTO.v1;

public class FileType:DomainEntityMetaId
{
    public ICollection<AnswerFile>? AnswerFiles { get; set; }
    public ICollection<Material>? Materials { get; set; }

    public string Description { get; set; } = default!;
    public string FileExtension { get; set; } = default!;

}