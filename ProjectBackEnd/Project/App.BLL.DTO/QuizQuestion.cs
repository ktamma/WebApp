using Base.Domain;

namespace App.BLL.DTO;

public class QuizQuestion:DomainEntityMetaId
{
    public Guid QuizId { get; set; }
    public Quiz? Quiz { get; set; }

    
    public string Content { get; set; } = default!;
    public int Number { get; set; }
    public int Score { get; set; }
    public bool Active { get; set; }

    public ICollection<QuizAnswer>? QuizAnswers { get; set; }
    public ICollection<TakeAnswer>? TakeAnswers { get; set; }
}