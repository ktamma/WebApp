using Base.Domain;

namespace App.DAL.DTO;

public class QuizType:DomainEntityMetaId
{
    public string Value { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ICollection<Quiz>? Quizzes { get; set; }
    public override string ToString()
    {
        return $"Id: {Id}, Value: {Value}, Description: {Description}, {CreatedAt}, {CreatedBy}, {UpdatedAt}, {UpdatedBy}";
    }
}