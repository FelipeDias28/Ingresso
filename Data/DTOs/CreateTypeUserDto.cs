using System.ComponentModel.DataAnnotations;

namespace Ingresso.Data.Dto
{
    public class CreateTypeUserDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Name { get; set; }
    }
}
