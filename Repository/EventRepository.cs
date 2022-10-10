using AutoMapper;
using Ingresso.Data;
using Ingresso.Entity;
using Ingresso.Repository.InterfaceService;
using System.Threading.Tasks;
using System;
using Ingresso.Data.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Ingresso.Repository
{
    public class EventRepository : IEventService
    {
        private readonly DbDataContext _context;
        private readonly IMapper _mapper;

        public EventRepository(DbDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReadEventDto> CreateEvent(CreateEventDto model)
        {
            await CheckIfTypeEventExists(model.TypeEventId);

            await CheckIfStatusEventExists(model.StatusEventId);

            await CheckIfAddressExists(model.AddressId);

            var newEvent = _mapper.Map<Event>(model);

            try
            {

                await _context.Events.AddAsync(newEvent);

                await _context.SaveChangesAsync();

                var readEvent = _mapper.Map<ReadEventDto>(newEvent);

                return readEvent;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<ReadEventDto>> GetAllEvent()
        {
            var eventList = await _context.Events.ToListAsync();

            List<ReadEventDto> readEventDtos = _mapper.Map<List<ReadEventDto>>(eventList);
            return readEventDtos;
        }

        public async Task<ReadEventDto> GetEventById(int eventId)
        {
            var currentEvent = await _context.Events.FirstOrDefaultAsync(x => x.Id.Equals(eventId));

            if (currentEvent == null)
                throw new Exception("event-not-found");

            var readEvent = _mapper.Map<ReadEventDto>(currentEvent);
            return readEvent;
        }

        public async Task<List<ReadUserDto>> GetUsersParticipatingEvent(int eventId)
        {

            List<User> userList = await _context.Users.ToListAsync();

            IEnumerable<User> query = from user in userList
                                     where user.Tickets.Any(ticket =>
                                     ticket.Event.Id == eventId)
                                     select user;

            userList = query.ToList();

            var readUser = _mapper.Map<List<ReadUserDto>>(userList);

            return readUser;
        }

        public async Task<ReadEventDto> UpdateEvent(int eventId, UpdateEventDto model)
        {
            var currentEvent = await _context.Events.FirstOrDefaultAsync(x => x.Id.Equals(eventId));

            if (currentEvent == null)
                throw new Exception("event-not-found");


            if (!string.IsNullOrEmpty(model.Name))
                currentEvent.Name = model.Name;

            if (model.AvailableQuantity > 0)
                currentEvent.AvailableQuantity = model.AvailableQuantity;

            try
            {
                _context.Update(currentEvent);
                await _context.SaveChangesAsync();

                var eventDto = _mapper.Map<ReadEventDto>(currentEvent);

                return eventDto;
            }
            catch
            {
                throw new Exception();
            }
        }

        private async Task CheckIfStatusEventExists(int statusEventId)
        {
            var statusEvent = await _context.StatusEvents.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(statusEventId));

            if (statusEvent == null)
                throw new Exception("status-event-not-found");
        }

        private async Task CheckIfTypeEventExists(int typeEventId)
        {
            var typeEvent = await _context.TypeEvents.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(typeEventId));

            if (typeEvent == null)
                throw new Exception("type-event-not-found");
        }

        private async Task CheckIfAddressExists(int addressId)
        {
            var address = await _context.Addresses.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(addressId));

            if (address == null)
                throw new Exception("address-not-found");
        }
    }
}
