using Base.Domain;

namespace App.Domain;

public class QuizType:DomainEntityMetaId
{
    public string Value { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ICollection<Quiz>? Quizzes { get; set; }

}