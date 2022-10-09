using Ingresso.Data.DTOs;
using Ingresso.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ingresso.Repository.InterfaceService
{
    public interface ITypeEventService
    {
        Task<TypeEvent> CreateTypeEvent(CreateTypeEventDto model);
        Task<List<TypeEvent>> GetTypeEvent();
    }
}
