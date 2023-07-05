using FluentValidation;

namespace catering.Application.Managements.DiscountCodeManagment.Commands.CreateDiscountCode
{
    public class CreateDiscountCodeCommandValidator : AbstractValidator<CreateDiscountCodeCommand>
    {
        public CreateDiscountCodeCommandValidator()
        {
            RuleFor(c => c.Code)
                .NotEmpty().WithMessage("Please enter discount code");

            RuleFor(c => c.DiscountPercentage)
                .NotEmpty().WithMessage("Please enter percentage value of discount")
                .LessThan(100).WithMessage("Discount cannot be greather then 100%")
                .GreaterThan(0).WithMessage("Discount cannot be less then 0%");

            RuleFor(c => c.Expiration)
                .NotEmpty().WithMessage("Please enter expiration date"); ;
        }
    }
}
