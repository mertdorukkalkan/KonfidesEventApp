using Microsoft.AspNetCore.Identity;

namespace Core.Domain;

public class ApplicationRole : IdentityRole<int>
{
    public string Description { get; set; }
}