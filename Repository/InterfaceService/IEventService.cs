using Ingresso.Data.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ingresso.Repository.InterfaceService
{
    public interface IEventService
    {
        Task<ReadEventDto> CreateEvent(CreateEventDto model);
        Task<List<ReadEventDto>> GetEvent(int eventId = 0);
    }
}
