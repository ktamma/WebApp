using Base.Domain;

namespace App.DAL.DTO;

public class AnswerFile:DomainEntityMetaId
{
    public Guid FileTypeId { get; set; }
    public FileType? FileType { get; set; }
    public Guid QuizAnswerId { get; set; }
    public QuizAnswer? QuizAnswer { get; set; }

    public string Title { get; set; } = default!;
    public string LocationString { get; set; } = default!;
    public string Content { get; set; } = default!;
}