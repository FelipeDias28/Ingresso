using AutoMapper;
using Ingresso.Data.DTOs;
using Ingresso.Entity;

namespace Ingresso.Mappings
{
    public class AddressMapping : Profile
    {
        public AddressMapping()
        {
            CreateMap<CreateAddressDto, Address>();
        }
    }
}
