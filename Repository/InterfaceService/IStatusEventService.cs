using Ingresso.Data.DTOs;
using Ingresso.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ingresso.Repository.InterfaceService
{
    public interface IStatusEventService
    {
        Task<StatusEvent> CreateStatusEvent(CreateStatusEventDto model);
        Task<List<StatusEvent>> GetStatusEvent();
    }
}
