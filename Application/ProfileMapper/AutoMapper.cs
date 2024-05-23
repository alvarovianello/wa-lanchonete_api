using Application.Contracts.Request.RequestCategory;
using Application.Contracts.Request.RequestCustomer;
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
        }
    }
}
