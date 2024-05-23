using Application.Contracts.Request.RequestCategory;
using Application.Contracts.Request.RequestCustomer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.ValidatorsCustomer
{
    public sealed class CustomerPuttRequestValidator : AbstractValidator<CustomerPutRequest>
    {
        public CustomerPuttRequestValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
        }
    }
}
