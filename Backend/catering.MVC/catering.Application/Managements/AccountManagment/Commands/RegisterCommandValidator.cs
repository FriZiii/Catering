using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace catering.Application.Managements.AccountManagment.Commands
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("First name is required.");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Last name is required.");

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Password is required.");

            RuleFor(c => c.PasswordConfirm)
                .Equal(c => c.Password).WithMessage("Passwords do not match.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email is required.");

            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("Birth date is required.");

            RuleFor(c => c.Adress1)
                .NotEmpty().WithMessage("Address 1 is required.");

            RuleFor(c => c.Adress2)
                .NotEmpty().WithMessage("Address 2 is required.");

            RuleFor(c => c.PostalCode)
                .NotEmpty().WithMessage("Postal code is required.");

            RuleFor(c => c.State)
                .NotEmpty().WithMessage("State/Region is required.");

            RuleFor(c => c.Country)
                .NotEmpty().WithMessage("Country is required.");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.");
        }
    }
}
