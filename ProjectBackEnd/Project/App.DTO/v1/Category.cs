using App.DTO.v1.Identity;
using Base.Domain;
using Contracts.Domain.Base;

namespace App.DTO.v1;

public class Category:DomainEntityMetaId, IDomainAppUser<AppUser>, IDomainAppUserId
{
    public Guid AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    
    public ICollection<Material>? Materials { get; set; }
    public ICollection<Quiz>? Quizzes { get; set; }

}