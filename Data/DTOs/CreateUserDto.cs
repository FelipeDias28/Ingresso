using System.ComponentModel.DataAnnotations;

namespace Ingresso.Data.DTOs
{
    public class CreateUserDto
    {
        public int AmountOwn { get; set; } = 0;

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O campo Documento é obrigatório.")]
        public string Document { get; set; }

        [Required(ErrorMessage = "O campo de Senha é obrigatório.")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "A senha deve conter no mínimo 6 e no máximo 30 caracateres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "É necessário escolher um tipo de usuário")]
        public int TypeUserId { get; set; }
    }
}
