using System.ComponentModel.DataAnnotations;

namespace Ingresso.Data.DTOs
{
    public class ReadEventDto
    {
        public string Name { get; set; }

        public int AvailableQuantity { get; set; }

        public double Value { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }
    }
}
