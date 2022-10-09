using AutoMapper;
using Ingresso.Data;
using Ingresso.Data.DTOs;
using Ingresso.Entity;
using Ingresso.Repository.InterfaceService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ingresso.Repository
{
    public class StatusEventRepository : IStatusEventService
    {
        private readonly DbDataContext _context;
        private readonly IMapper _mapper;

        public StatusEventRepository(DbDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StatusEvent> CreateStatusEvent(CreateStatusEventDto model)
        {
            var statusEvent = _mapper.Map<StatusEvent>(model);

            try
            {
                await _context.StatusEvents.AddAsync(statusEvent);
                await _context.SaveChangesAsync();

                return statusEvent;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<List<StatusEvent>> GetStatusEvent()
        {
            var statusEventList = await _context.StatusEvents.AsNoTracking().ToListAsync();
            return statusEventList;
        }
    }
}
