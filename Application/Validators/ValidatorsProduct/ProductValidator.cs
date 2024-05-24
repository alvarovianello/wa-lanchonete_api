using Application.Contracts.Request.RequestProduct;
using FluentValidation;

namespace Application.Validators.ValidatorsProduct
{
    public class ProductValidator : AbstractValidator<ProductRequest>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(product => product.CategoryId).NotEmpty().WithMessage("CategoryId is required");
            RuleFor(product => product.Price).GreaterThan(0).WithMessage("Price must be greater than zero");
        }
    }
}
