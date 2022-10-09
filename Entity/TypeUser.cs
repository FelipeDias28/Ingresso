using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ingresso.Entity
{
    public class TypeUser
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual List<User> Users { get; set; }
    }
}
