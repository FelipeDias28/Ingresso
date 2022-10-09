using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ingresso.Entity
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Number { get; set; }
        public string City { get; set; }

        [JsonIgnore]
        public virtual List<Event> Events { get; set; }
    }
}
