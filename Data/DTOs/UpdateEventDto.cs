using System.ComponentModel.DataAnnotations;

namespace Ingresso.Data.DTOs
{
    public class UpdateEventDto
    {
        public string Name { get; set; }

        public int AvailableQuantity { get; set; }
    }
}
