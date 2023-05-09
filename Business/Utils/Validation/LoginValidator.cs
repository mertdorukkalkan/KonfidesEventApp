using Domain.IdentityModels;
using FluentValidation;

namespace Business.Validation;

public class LoginValidator : AbstractValidator<LoginModel>
{
    public  LoginValidator()
    {
        RuleFor(x => x.Email).NotNull().EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz");
        RuleFor(x => x.Password).NotEmpty()
            .MinimumLength(8)
            .Matches("[A-Z]").WithMessage("'{PropertyName}' must contain one or more capital letters.")
            .Matches("[a-z]").WithMessage("'{PropertyName}' must contain one or more lowercase letters.")
            .Matches(@"\d").WithMessage("'{PropertyName}' must contain one or more digits.")
            .Matches(@"[][""!@$%^&*(){}:;<>,.?/+_=|'~\\-]")
            .WithMessage("'{ PropertyName}' must contain one or more special characters.")
            .Matches("^[^£# “”]*$")
            .WithMessage("'{PropertyName}' must not contain the following characters £ # “” or spaces.");
    }
}