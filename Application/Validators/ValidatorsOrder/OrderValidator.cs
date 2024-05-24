using Application.Contracts.Request.RequestOrder;
using FluentValidation;

namespace Application.Validators.ValidatorsOrder
{
    public class OrderValidator : AbstractValidator<OrderRequest>
    {
        public OrderValidator()
        {
            RuleForEach(order => order.OrderItems).SetValidator(new OrderItemValidator());
        }
    }

    public class OrderItemValidator : AbstractValidator<OrderItemRequest>
    {
        public OrderItemValidator()
        {
            RuleFor(orderItem => orderItem.ProductId).NotEmpty().WithMessage("ProductId is required");
            RuleFor(orderItem => orderItem.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero");
            RuleFor(orderItem => orderItem.Price).GreaterThan(0).WithMessage("Price must be greater than zero");
        }
    }
}
