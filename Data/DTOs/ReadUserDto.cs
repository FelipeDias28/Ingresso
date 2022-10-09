using Ingresso.Entity;
using System;

namespace Ingresso.Data.DTOs
{
    public class ReadUserDto
    {
        public Guid Id { get; set; }
        public int AmountOwn { get; set; }
        public string UserName { get; set; }
        public string Document { get; set; }
        public string Type { get; set; }
    }
}
