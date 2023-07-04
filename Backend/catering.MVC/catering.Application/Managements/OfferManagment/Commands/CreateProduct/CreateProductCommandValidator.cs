using catering.Application.Managements.OfferManagment.Commands.AddProduct;
using catering.Domain.Interface;
using FluentValidation;

namespace catering.Application.Managements.OfferManagment.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IOfferRepository offerRepository;

        public CreateProductCommandValidator(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;

            RuleFor(c => c.Name)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20);

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
