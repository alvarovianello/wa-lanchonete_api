using Application.Contracts.Request.RequestCategory;
using Application.Contracts.Request.RequestCustomer;
using Application.Contracts.Request.RequestOrder;
using Application.Contracts.Request.RequestProduct;
using Application.Contracts.Response.ResponseOrder;
using AutoMapper;
using Domain.Entities;

namespace Application.ProfileMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Customer, CustomerPostRequest>().ReverseMap();
            CreateMap<Customer, CustomerPutRequest>().ReverseMap();
            CreateMap<Customer, CustomerGetRequest>().ReverseMap();
            CreateMap<Category, CategoryPostRequest>().ReverseMap();
            CreateMap<Category, CategoryPutRequest>().ReverseMap();
            CreateMap<ProductRequest, Product>().ReverseMap();
            CreateMap<Order, OrderRequest>().ReverseMap();
            CreateMap<Order, OrderPostRequest>().ReverseMap();
            CreateMap<Orderitem, OrderItemRequest>().ReverseMap();
            CreateMap<Order, OrderResponse>().ReverseMap();
            CreateMap<Orderitem, OrderItemResponse>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ReverseMap();
        }
    }
}
