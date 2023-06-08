using catering.Domain.Interface;
using FluentValidation;

namespace catering.Application.DTO.Offer
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        private readonly IOfferRepository offerRepository;

        public ProductDtoValidator(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;

            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20)
                .Custom((value, context) =>
                {
                    var existingProduct = offerRepository.GetByName(value).Result;
                    if (existingProduct != null)
                    {
                        context.AddFailure($"{value} is not unique name for product.");
                    }
                });

            RuleFor(c => c.Description)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(c => c.Price)
                .NotEmpty()
                .GreaterThan(0).WithMessage("Price must be greater than 0.00$.");

            RuleFor(c => c.ImageFile)
                .NotEmpty().WithMessage("Product must have a photo."); ;
        }
    }
}
