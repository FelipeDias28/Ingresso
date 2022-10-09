using System.ComponentModel.DataAnnotations;

namespace Ingresso.Data.DTOs
{
    public class CreateAddressDto
    {
        [Required(ErrorMessage = "O campo Rua é obrigatório.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        public string State { get; set; }

        [Required(ErrorMessage = "O campo Número é obrigatório.")]
        public string Number { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        public string City { get; set; }
    }
}
