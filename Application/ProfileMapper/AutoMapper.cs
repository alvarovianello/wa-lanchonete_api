using Application.Contracts.Request;
using AutoMapper;
using Domain.Entities;

namespace Application.ProfileMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Customer, CustomerPostRequest>().ReverseMap();
        }
    }
}
