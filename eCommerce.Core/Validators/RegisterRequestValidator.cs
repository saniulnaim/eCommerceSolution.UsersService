using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators
{
  public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
  {
    public RegisterRequestValidator()
    {
      RuleFor(x => x.Email)
       .NotEmpty().WithMessage("Email is required.")
       .EmailAddress().WithMessage("Invalid email format.");

      RuleFor(x => x.Password)
        .NotEmpty().WithMessage("Password is required.");

      RuleFor(x => x.PersonName)
        .NotEmpty().WithMessage("Person Name is required.")
        .Length(1, 50).WithMessage("Person name should be 1 to 50 characters long");

      RuleFor(x => x.Gender)
        .IsInEnum().WithMessage("enum value is not valid.");
    }
  }
}
