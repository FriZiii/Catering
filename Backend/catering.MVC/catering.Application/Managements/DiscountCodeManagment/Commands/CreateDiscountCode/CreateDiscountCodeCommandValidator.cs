using FluentValidation;

namespace catering.Application.Managements.DiscountCodeManagment.Commands.CreateDiscountCode
{
    public class CreateDiscountCodeCommandValidator : AbstractValidator<CreateDiscountCodeCommand>
    {
        public CreateDiscountCodeCommandValidator()
        {
            RuleFor(c => c.Code)
                .NotEmpty();

            RuleFor(c => c.DiscountPercentage)
                .NotEmpty()
                .LessThan(100)
                .GreaterThan(0);

            RuleFor(c => c.Expiration)
                .NotEmpty();
        }
    }
}
