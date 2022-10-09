using AutoMapper;
using Ingresso.Data.DTOs;
using Ingresso.Entity;

namespace Ingresso.Mappings
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<CreateUserDto, User>();

            CreateMap<User, ReadUserDto>()
                .ForMember(dest => dest.Type, map => map.MapFrom(src => src.TypeUser.Name))
                .ReverseMap();
        }
    }
}
