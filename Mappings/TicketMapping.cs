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

            CreateMap<Ticket, ReadTicketDto>();
        }
    }
}
