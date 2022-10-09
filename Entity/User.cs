using System.Collections.Generic;
using System.Text.Json.Serialization;
using System;

namespace Ingresso.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public int AmountOwn { get; set; }
        public string Document { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public int TypeUserId { get; set; }
        public virtual TypeUser TypeUser { get; set; }

        public virtual List<Ticket> Tickets { get; set; }
    }
}
