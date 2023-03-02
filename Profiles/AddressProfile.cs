using AutoMapper;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;

namespace MovieAPI.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile() 
        {
            CreateMap<CreateAddresDto, Address>();
            CreateMap<Address, ReadAddressDto>();
            CreateMap<UpdateAddressDto, Address>();
        }
    }
}
