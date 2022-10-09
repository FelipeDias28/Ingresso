using AutoMapper;
using Ingresso.Data;
using Ingresso.Repository.InterfaceService;
using System.Threading.Tasks;
using System;
using Ingresso.Data.DTOs;
using Ingresso.Entity;
using Microsoft.EntityFrameworkCore;
using Ingresso.Enums;
using System.Collections.Generic;

namespace Ingresso.Repository
{
    public class TicketRepository : ITicketService
    {
        private readonly DbDataContext _context;
        private readonly IMapper _mapper;

        public TicketRepository(DbDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReadTicketDto> BuyTicket(BuyTicketDto model)
        {
            var user = await GetUser(model.UserId);
            var currentEvent = await GetEvent(model.EventId);
            
            CheckIfEventIsAvailable(currentEvent, model.QuantityToBuy);

            user.AmountOwn += model.QuantityToBuy;
            var newTicket = _mapper.Map<Ticket>(model);

            try
            {
                _context.Users.Update(user);
                _context.Events.Update(currentEvent);

                await _context.Tickets.AddAsync(newTicket);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
            
            var readTicket = _mapper.Map<ReadTicketDto>(newTicket);
            return readTicket;
        }

        public async Task<List<ReadTicketDto>> GetAllTickets()
        {
            List<ReadTicketDto> readTicketList = new List<ReadTicketDto>();

            var ticketList = await _context.Tickets.ToListAsync();

            foreach (var ticket in ticketList)
            {
                var readTicket = _mapper.Map<ReadTicketDto>(ticket);
                readTicketList.Add(readTicket);
            }

            return readTicketList;
        }

        public async Task<ReadTicketDto> GetTicketById(Guid ticketId)
        {
            var ticket = await _context.Tickets.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(ticketId));

            if (ticket == null)
                throw new Exception("ticket-not-found");

            var readTicket = _mapper.Map<ReadTicketDto>(ticket);

            return readTicket;
        }

        private async Task<User> GetUser(Guid userId)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(userId));

            if (user == null)
                throw new Exception("user-not-found");

            return user;
        }

        private async Task<Event> GetEvent(int eventId)
        {
            var currentEvent = await _context.Events.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(eventId));

            if (currentEvent == null)
                throw new Exception("event-not-found");

            return currentEvent;
        }

        private void CheckIfEventIsAvailable(Event currentEvent, int quantityToBuy)
        {
            if (currentEvent.AvailableQuantity == 0)
                throw new Exception("ticket-sold-out");

            if (DateTime.Now.Date > currentEvent.EndDate.Date)
                throw new Exception("event-has-passed-date");

            if (currentEvent.StatusEventId == (int)StatusEventEnum.Finished)
                throw new Exception("event-already-finalized");

            var result = currentEvent.AvailableQuantity -= quantityToBuy;

            if (result < 0)
                throw new Exception("do-not-have-enough-tickets");
        }
    }
}
