using AutoMapper;
using TödebBootcampAssignment4.DTOs.Customer;
using TödebBootcampAssignment4.EntityLayer.Entities;

namespace TödebBootcampAssignment4.BusinessLayer.Configuration.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateCustomerDto, Customer>().ReverseMap();
            CreateMap<GetCustomerDto, Customer>().ReverseMap();
            CreateMap<UpdateCustomerDto, Customer>();
        }
    }
}
