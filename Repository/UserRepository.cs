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

        public async Task<List<ReadUserDto>> GetUsers(Guid userId)
        {
            List<User> userList;
            List<ReadUserDto> userDtoList = new List<ReadUserDto>();

            if (userId == Guid.Empty)
            {
                userList = await _context.Users.ToListAsync();
            }
            else
            {
                userList = await _context.Users.Where(x => x.Id.Equals(userId)).ToListAsync();
            }

            foreach(var user in userList)
            {
                var userDto = _mapper.Map<ReadUserDto>(user);
                userDtoList.Add(userDto);
            }

            return userDtoList;
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


        private async Task CheckIfTypeUserExists(CreateUserDto model)
        {
            var typeUser = await _context.TypeUsers.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(model.TypeUserId));

            if (typeUser == null)
                throw new Exception("type-user-not-found");
        }
    }
}
