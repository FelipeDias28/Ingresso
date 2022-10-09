using System;

namespace Ingresso.Entity
{
    public class Ticket
    {
        public Guid Id { get; set; }

        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
