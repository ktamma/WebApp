using App.BLL.DTO.Identity;
using Base.Domain;
using Contracts.Domain.Base;

namespace App.BLL.DTO;

public class Take:DomainEntityMetaId, IDomainAppUser<AppUser>, IDomainAppUserId
{
    public int Status { get; set; } 
    public int Score { get; set; } 
    public DateTime StartedAt { get; set; } = default!;
    public DateTime FinishedAt { get; set; } = default!;
    
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    
    public Guid QuizId { get; set; }
    public Quiz? Quiz { get; set; }
    
    public ICollection<TakeAnswer>? TakeAnswers { get; set; }


}