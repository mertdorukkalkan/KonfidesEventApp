using Microsoft.AspNetCore.Identity;

namespace Core.Domain;

public class ApplicationUser : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}