using Ingresso.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ingresso.Repository.InterfaceService
{
    public interface ITicketService
    {
        Task<ReadTicketDto> BuyTicket(BuyTicketDto model);
        Task<List<ReadTicketDto>> GetAllTickets();
        Task<ReadTicketDto> GetTicketById(Guid ticketId);
    }
}
