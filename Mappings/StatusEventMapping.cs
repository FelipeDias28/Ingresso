using AutoMapper;
using Ingresso.Data.DTOs;
using Ingresso.Entity;

namespace Ingresso.Mappings
{
    public class StatusEventMapping : Profile
    {
        public StatusEventMapping()
        {
            CreateMap<CreateStatusEventDto, StatusEvent>();
        }
    }
}
