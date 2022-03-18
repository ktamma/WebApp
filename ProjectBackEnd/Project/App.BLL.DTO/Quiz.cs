using Base.Domain;

namespace App.BLL.DTO;

public class Quiz:DomainEntityMetaId
{

    public string Title { get; set; } = default!;

    public string Description { get; set; } = default!;
    
    public string Access { get; set; } = default!;
    
    public int Score { get; set; } = default!;
    
    public decimal Rating { get; set; } = default!;

    public int Time { get; set; } = default!;

    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    
    public Guid QuizTypeId { get; set; }
    public QuizType? QuizType { get; set; }
    
    public ICollection<AllowedUser>? AllowedUsers { get; set; }

    public ICollection<TakeAnswer>? TakeAnswers { get; set; }
    
    public ICollection<Take>? Takes { get; set; }
    
    public ICollection<QuizQuestion>? QuizQuestions { get; set; }
    
    public ICollection<QuizMaterial>? QuizMaterials { get; set; }
    
    public ICollection<QuizAnswer>? QuizAnswers { get; set; }







}