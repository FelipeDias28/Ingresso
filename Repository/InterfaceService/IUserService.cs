using Ingresso.Data.DTOs;
using Ingresso.Entity;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Ingresso.Repository.InterfaceService
{
    public interface IUserService
    {
        Task<User> CreateUser(CreateUserDto model);
        Task<List<ReadUserDto>> GetAllUsers();
        Task<ReadUserDto> GetUsersById(Guid userId);
        Task<dynamic> Authenticate(LoginDto model);
        Task<List<ReadEventDto>> GetEventsUserParticipate(Guid userId);
        Task<ReadUserDto> UpdateUser(Guid userId, UpdateUserDto model);
    }
}
