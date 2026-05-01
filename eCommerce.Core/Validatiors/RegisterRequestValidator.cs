using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.Validatiors
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator() 
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email address format");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.");
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Person name is required.")
                .Length(1, 50).WithMessage("Person name must be between 1 and 50 characters.");
            RuleFor(x => x.Gender).IsInEnum().WithMessage("Invalid gender value.");
        }
    }
}
