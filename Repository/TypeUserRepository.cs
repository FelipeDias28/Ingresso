using AutoMapper;
using Ingresso.Data;
using Ingresso.Data.Dto;
using Ingresso.Entity;
using Ingresso.Repository.InterfaceService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ingresso.Repository
{
    public class TypeUserRepository : ITypeUserService
    {
        private readonly DbDataContext _context;
        private readonly IMapper _mapper;

        public TypeUserRepository(DbDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TypeUser> CreateTypeUser(CreateTypeUserDto model)
        {
            var typeUser = _mapper.Map<TypeUser>(model);

            try
            {
                await _context.TypeUsers.AddAsync(typeUser);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw new Exception();
            }

            return typeUser;
        }

        public async Task<List<TypeUser>> GetTypeUser()
        {
            var typeUsers = await _context.TypeUsers.AsNoTracking().ToListAsync();
            return typeUsers;
        }
    }
}
