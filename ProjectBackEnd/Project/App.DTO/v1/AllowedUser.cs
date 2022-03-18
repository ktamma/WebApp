using App.DTO.v1.Identity;
using Base.Domain;
using Contracts.Domain.Base;

namespace App.DTO.v1;

public class AllowedUser:DomainEntityMetaId, IDomainAppUser<AppUser>, IDomainAppUserId
{
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    
    public Guid QuizId { get; set; }
    public Quiz? Quiz { get; set; }
}