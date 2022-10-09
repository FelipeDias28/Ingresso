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
        Task<List<ReadUserDto>> GetUsers(Guid userId);
        Task<dynamic> Authenticate(LoginDto model);
    }
}
