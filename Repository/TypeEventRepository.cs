using AutoMapper;
using Ingresso.Data;
using Ingresso.Data.DTOs;
using Ingresso.Entity;
using Ingresso.Repository.InterfaceService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ingresso.Repository
{
    public class TypeEventRepository : ITypeEventService
    {
        private readonly DbDataContext _context;
        private readonly IMapper _mapper;

        public TypeEventRepository(DbDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TypeEvent> CreateTypeEvent(CreateTypeEventDto model)
        {
            var newTypeEvent = _mapper.Map<TypeEvent>(model);

            try
            {
                await _context.TypeEvents.AddAsync(newTypeEvent);
                await _context.SaveChangesAsync();

                return newTypeEvent;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<List<TypeEvent>> GetTypeEvent()
        {
            var typeEventList = await _context.TypeEvents.AsNoTracking().ToListAsync();

            return typeEventList;
        }
    }
}
