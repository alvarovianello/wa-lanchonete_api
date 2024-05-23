using Application.Contracts.Request.RequestCustomer;
using FluentValidation;

namespace Application.Validators.ValidatorsCustomer
{
    public sealed class CustomerPostRequestValidator : AbstractValidator<CustomerPostRequest>
    {
        public CustomerPostRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Cpf).NotEmpty().NotNull();
        }
    }
}
