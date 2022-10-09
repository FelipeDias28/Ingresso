using AutoMapper;
using Ingresso.Data.Dto;
using Ingresso.Entity;

namespace Ingresso.Mappings
{
    public class TypeUserMapping : Profile
    {
        public TypeUserMapping()
        {
            CreateMap<CreateTypeUserDto, TypeUser>();
        }
    }
}
