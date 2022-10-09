using Ingresso.Data.Dto;
using Ingresso.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ingresso.Repository.InterfaceService
{
    public interface ITypeUserService
    {
        Task<TypeUser> CreateTypeUser(CreateTypeUserDto model);
        Task<List<TypeUser>> GetTypeUser();
    }
}
