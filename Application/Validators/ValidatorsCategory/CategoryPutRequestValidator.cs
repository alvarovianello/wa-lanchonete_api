using Application.Contracts.Request.RequestCategory;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.ValidatorsCategory
{
    public sealed class CategoryPutRequestValidator : AbstractValidator<CategoryPutRequest>
    {
        public CategoryPutRequestValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull();
            RuleFor(c => c.Description).NotEmpty().NotNull();
        }
    }
}
