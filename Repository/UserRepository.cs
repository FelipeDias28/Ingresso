using Ingresso.Data;
using Ingresso.Entity;
using Ingresso.Repository.InterfaceService;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using Ingresso.Data.DTOs;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Ingresso.Services;

namespace Ingresso.Repository
{
    public class UserRepository : IUserService
    {
        private readonly DbDataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DbDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<User> CreateUser(CreateUserDto model)
        {
            await CheckIfTypeUserExists(model);

            var user = _mapper.Map<User>(model);

            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<List<ReadUserDto>> GetAllUsers()
        {
            var userList = await _context.Users.ToListAsync();

            var userDtoList = _mapper.Map<List<ReadUserDto>>(userList);

            return userDtoList;
        }

        public async Task<ReadUserDto> GetUsersById(Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(userId));

            if (user == null)
                throw new Exception("user-not-found");

            var userDto = _mapper.Map<ReadUserDto>(user);

            return userDto;
        }

        public async Task<dynamic> Authenticate(LoginDto model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName.Equals(model.UserName) && x.Password.Equals(model.Password));

            if (user == null)
                throw new Exception("user-not-found");

            var token = TokenServices.GenerateToken(user);

            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }

        public async Task<List<ReadEventDto>> GetEventsUserParticipate(Guid userId)
        {
            var eventList = await _context.Events.ToListAsync();

            IEnumerable<Event> query = from currentEvent in eventList
                                    where currentEvent.Tickets.Any(ticket =>
                                    ticket.User.Id == userId)
                                    select currentEvent;

            eventList = query.ToList();

            var readEvent = _mapper.Map<List<ReadEventDto>>(eventList);
            return readEvent;
        }

        private async Task CheckIfTypeUserExists(CreateUserDto model)
        {
            var typeUser = await _context.TypeUsers.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(model.TypeUserId));

            if (typeUser == null)
                throw new Exception("type-user-not-found");
        }
    }
}
