using AutoMapper;
using Ingresso.Data.DTOs;
using Ingresso.Entity;

namespace Ingresso.Mappings
{
    public class EventMapping : Profile
    {
        public EventMapping()
        {
            CreateMap<CreateEventDto, Event>();

            CreateMap<Event, ReadEventDto>()
                .ForPath(dest => dest.StartDate, map => map.MapFrom(src => src.StartDate.ToString("dd/MM/yyyy")))
                .ForPath(dest => dest.EndDate, map => map.MapFrom(src => src.EndDate.ToString("dd/MM/yyyy")))
                .ReverseMap();
        }
    }
}
