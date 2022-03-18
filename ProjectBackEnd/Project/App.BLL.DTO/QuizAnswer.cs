using Base.Domain;

namespace App.BLL.DTO;

public class QuizAnswer:DomainEntityMetaId
{
    public Guid QuizId { get; set; }
    public Quiz? Type { get; set; }
    
    public Guid QuizQuestionId { get; set; }
    public QuizQuestion? QuizQuestion { get; set; }

    public string Content { get; set; } = default!;
    public bool Correct { get; set; }
    public bool Active { get; set; }


    public ICollection<TakeAnswer>? TakeAnswers { get; set; }
    public ICollection<AnswerFile>? AnswerFiles { get; set; }
}