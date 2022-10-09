using AutoMapper;
using Ingresso.Data.DTOs;
using Ingresso.Entity;

namespace Ingresso.Mappings
{
    public class TypeEventMapping : Profile
    {
        public TypeEventMapping()
        {
            CreateMap<CreateTypeEventDto, TypeEvent>();
        }
    }
}
