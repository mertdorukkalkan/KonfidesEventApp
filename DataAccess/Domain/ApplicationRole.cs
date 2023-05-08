using Microsoft.AspNetCore.Identity;

namespace DataAccess.Domain;

public class ApplicationRole : IdentityRole<int>
{
    public string Description { get; set; }
}