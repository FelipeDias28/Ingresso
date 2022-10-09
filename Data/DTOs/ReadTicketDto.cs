using Ingresso.Entity;
using System;

namespace Ingresso.Data.DTOs
{
    public class ReadTicketDto
    {
        public Guid Id { get; set; }
        public int AvailableQuantity { get; set; }
        public double Value { get; set; }
        public string Place { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public User User { get; set; }
        public Event Event { get; set; }
    }
}
