using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.AccountManagment.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("Please provide your first name.");

            RuleFor(c => c.LastName)
                 .NotEmpty().WithMessage("Please provide your last name.");

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Please provide a password.");

            RuleFor(c => c.PasswordConfirm)
                .Equal(c => c.Password).WithMessage("Passwords do not match. Please ensure both passwords are the same.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Please provide your email address.")
                .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("Please provide your birth date.");

            RuleFor(c => c.Adress1)
                .NotEmpty().WithMessage("Please provide your address (line 1).");

            RuleFor(c => c.Adress2)
                .NotEmpty().WithMessage("Please provide your address (line 2).");

            RuleFor(c => c.PostalCode)
                .NotEmpty().WithMessage("Please provide your postal code.")
                .Matches(@"^\d{2}-\d{3}$").WithMessage("Please enter a valid postal code in the format XX-XXX.");

            RuleFor(c => c.State)
                .NotEmpty().WithMessage("Please provide your state or region.");

            RuleFor(c => c.Country)
                .NotEmpty().WithMessage("Please provide your country.");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Please provide your phone number.")
                .Matches(@"^[0-9]{9,}$").WithMessage("Please enter a valid phone number containing at least 9 numeric digits.");
        }
    }
}
