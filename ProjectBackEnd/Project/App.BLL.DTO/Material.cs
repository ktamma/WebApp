using Base.Domain;

namespace App.BLL.DTO;

public class Material:DomainEntityMetaId
{

    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    public Guid FileTypeId { get; set; }
    public FileType? FileType { get; set; }

    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Payload { get; set; } = default!;
    
    public ICollection<QuizMaterial>? QuizMaterials { get; set; }

}