using Base.Domain;

namespace App.DTO.v1;

public class TakeAnswer:DomainEntityMetaId
{
    public Guid QuizAnswerId { get; set; }
    public QuizAnswer? QuizAnswer { get; set; }
    public Guid TakeId { get; set; }
    public Take? Take { get; set; }
    public Guid QuizQuestionId { get; set; }
    public QuizQuestion? QuizQuestion { get; set; }

    public string Content { get; set; } = default!;
    public bool Active { get; set; }
}