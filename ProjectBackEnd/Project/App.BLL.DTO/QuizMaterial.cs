using Base.Domain;

namespace App.BLL.DTO;

public class QuizMaterial:DomainEntityMetaId
{
    public Guid QuizId { get; set; }
    public Quiz? Quiz { get; set; }
    public Guid MaterialId { get; set; }
    public Material? Material { get; set; }

}