using System.Collections.Generic;
using System.Text.Json.Serialization;
using System;

namespace Ingresso.Entity
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AvailableQuantity { get; set; }
        public double Value { get; set; }
        public string Place { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [JsonIgnore]
        public int TypeEventId { get; set; }
        public virtual TypeEvent TypeEvent { get; set; }

        [JsonIgnore]
        public int StatusEventId { get; set; }
        public virtual StatusEvent StatusEvent { get; set; }

        
        [JsonIgnore]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        [JsonIgnore]
        public virtual List<Ticket> Tickets { get; set; }
    }
}
