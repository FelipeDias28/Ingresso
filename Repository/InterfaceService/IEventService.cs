using Ingresso.Data.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ingresso.Repository.InterfaceService
{
    public interface IEventService
    {
        Task<ReadEventDto> CreateEvent(CreateEventDto model);
        Task<List<ReadEventDto>> GetAllEvent();
        Task<ReadEventDto> GetEventById(int eventId);
        Task<List<ReadUserDto>> GetUsersParticipatingEvent(int eventId);
        Task<ReadEventDto> UpdateEvent(int eventId, UpdateEventDto model);
    }
}
