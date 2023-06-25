using catering.Application.Managements.OrderManagment.OrderDto;
using FluentValidation;

namespace catering.Application.Managements.OrderManagment.Commands.AddGuestToOrder
{
    public class AddGuestToOrderCommandValidator : AbstractValidator<GuestAdressDto>
    {
        public AddGuestToOrderCommandValidator()
        {
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
