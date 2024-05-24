using Application.Contracts.Request.RequestCustomer;
using Domain.Entities;

namespace Application.Contracts.Response.ResponseOrder
{
    public class OrderResponse
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string? OrderNumber { get; set; }

        public decimal? TotalPrice { get; set; }

        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public ICollection<OrderItemResponse> OrderItems { get; set; }

        public CustomerPostRequest? Customer { get; set; }

    }
}
