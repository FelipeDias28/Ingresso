using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ingresso.Entity
{
    public class StatusEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual List<Event> Events { get; set; }
    }
}
