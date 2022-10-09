using AutoMapper;
using Ingresso.Data.DTOs;
using Ingresso.Entity;

namespace Ingresso.Mappings
{
    public class TicketMapping : Profile
    {
        public TicketMapping()
        {
            CreateMap<BuyTicketDto, Ticket>();

            CreateMap<Ticket, ReadTicketDto>()
                .ForPath(dest => dest.User.Id, map => map.MapFrom(src => src.User.Id))
                .ForPath(dest => dest.User.AmountOwn, map => map.MapFrom(src => src.User.AmountOwn))
                .ForPath(dest => dest.User.UserName, map => map.MapFrom(src => src.User.UserName))
                .ForPath(dest => dest.User.Document, map => map.MapFrom(src => src.User.Document))
                .ForPath(dest => dest.User.Type, map => map.MapFrom(src => src.User.TypeUser.Name))
                .ForPath(dest => dest.Event.Id, map => map.MapFrom(src => src.Event.Id))
                .ForPath(dest => dest.Event.Name, map => map.MapFrom(src => src.Event.Name))
                .ForPath(dest => dest.Event.AvailableQuantity, map => map.MapFrom(src => src.Event.AvailableQuantity))
                .ForPath(dest => dest.Event.Value, map => map.MapFrom(src => src.Event.Value))
                .ForPath(dest => dest.Event.StartDate, map => map.MapFrom(src => src.Event.StartDate.ToString("dd/MM/yyyy")))
                .ForPath(dest => dest.Event.EndDate, map => map.MapFrom(src => src.Event.EndDate.ToString("dd/MM/yyyy")))
                .ReverseMap();

        }
    }
}
