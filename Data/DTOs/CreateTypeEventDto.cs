using System.ComponentModel.DataAnnotations;

namespace Ingresso.Data.DTOs
{
    public class CreateTypeEventDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Name { get; set; }
    }
}
