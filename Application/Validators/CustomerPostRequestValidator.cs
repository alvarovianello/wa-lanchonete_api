using Application.Contracts.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
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
