using System.ComponentModel.DataAnnotations;

namespace Domain.IdentityModels;

public class RegisterModel
{
    [Required(ErrorMessage = "First Name is required")]
    public string? FirstName { get; set; }
    
    [Required(ErrorMessage = "Last Name is required")]
    public string? Lastname { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}