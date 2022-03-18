using System.ComponentModel.DataAnnotations;
using Base.Domain.Identity;

namespace App.DTO.v1.Identity;

public class AppUser : BaseUser
{

    [StringLength(128, MinimumLength = 1)]
    public string FirstName { get; set; } = default!;
    [StringLength(128, MinimumLength = 1)]
    public string LastName { get; set; } = default!;

    public ICollection<Category>? Categories { get; set; }
    public ICollection<AllowedUser>? AllowedUsers { get; set; }
    public ICollection<Take>? Takes { get; set; }
}
