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

        public async Task<List<ReadEventDto>> GetEvent(int eventId = 0)
        {
            List<Event> events;
            List<ReadEventDto> readEventList = new List<ReadEventDto>();

            if (eventId == 0)
            {
                events = await _context.Events.AsNoTracking().ToListAsync();
            }
            else
            {
                events = await _context.Events.Where(x => x.Id.Equals(eventId)).ToListAsync();
            }

            foreach(var currentEvent in events)
            {
                var readEvent = _mapper.Map<ReadEventDto>(currentEvent);
                readEventList.Add(readEvent);
            }

            return readEventList;
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
