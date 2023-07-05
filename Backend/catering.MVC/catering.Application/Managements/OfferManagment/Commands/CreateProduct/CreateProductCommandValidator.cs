using catering.Application.Managements.OfferManagment.Commands.AddProduct;
using catering.Domain.Interface;
using FluentValidation;

namespace catering.Application.Managements.OfferManagment.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter product name")
                .MinimumLength(3).WithMessage("Product namet cannot be less then 3 characters")
                .MaximumLength(20).WithMessage("Product namet cannot be greater then 20 characters");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please enter product description")
                .MinimumLength(5).WithMessage("Product namet cannot be less then 5 characters");

            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("Please enter product price")
                .GreaterThan(0).WithMessage("Price must be greater than 0.00$.");

            RuleFor(c => c.ImageFile)
                .NotEmpty().WithMessage("Product must have a photo."); ;
        }
    }
}
