using Ingresso.Entity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ingresso.Data.DTOs
{
    public class BuyTicketDto
    {
        [Required(ErrorMessage = "O campo ID do Evento é obrigatório.")]
        public int EventId { get; set; }

        [Required(ErrorMessage = "O campo ID do Usuário é obrigatório.")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "O campo Quantidade à comprar é obrigatório.")] 
        public int QuantityToBuy { get; set; }
    }
}
