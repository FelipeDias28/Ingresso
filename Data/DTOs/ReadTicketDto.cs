using Ingresso.Entity;
using System;

namespace Ingresso.Data.DTOs
{
    public class ReadTicketDto
    {
        public Guid Id { get; set; }

        public ReadUserDto User { get; set; }
        public ReadEventDto Event { get; set; }
    }
}
