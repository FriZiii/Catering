using catering.Application.Managements.AccountManagment.AccountDtos;
using FluentValidation;

namespace catering.Application.Managements.AccountManagment.Commands.UpdateDeliveryAdressByUserId
{
    public class DeliveryAdressInputDtoValidator : AbstractValidator<DeliveryAdressInputDto>
    {
        public DeliveryAdressInputDtoValidator()
        {
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
