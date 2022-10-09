using AutoMapper;
using Ingresso.Data;
using Ingresso.Data.DTOs;
using Ingresso.Entity;
using Ingresso.Repository.InterfaceService;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Ingresso.Repository
{
    public class AddressRepository : IAddressService
    {
        private readonly DbDataContext _context;
        private readonly IMapper _mapper;

        public AddressRepository(DbDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Address> CreateAddress(CreateAddressDto model)
        {
            var newAddress = _mapper.Map<Address>(model);

            try
            {
                await _context.Addresses.AddAsync(newAddress);
                await _context.SaveChangesAsync();

                return newAddress;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<List<Address>> GetAddresses()
        {
            var addressList = await _context.Addresses.AsNoTracking().ToListAsync();
            return addressList;
        }
    }
}
