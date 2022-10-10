using System;
using System.ComponentModel.DataAnnotations;

namespace Ingresso.Data.DTOs
{
    public class CreateEventDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Quantidade de Ingresso Disponível é obrigatório.")]
        public int AvailableQuantity { get; set; }

        [Required(ErrorMessage = "O campo Valor do Evento é obrigatório.")]
        public double Value { get; set; }

        [Required(ErrorMessage = "O campo Data Inicial é obrigatório.")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "O campo Data de Encerramento é obrigatório.")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "O campo ID do Tipo de Evento é obrigatório.")]
        public int TypeEventId { get; set; }

        [Required(ErrorMessage = "O campo ID do Status de Evento é obrigatório.")]
        public int StatusEventId { get; set; }
        
        [Required(ErrorMessage = "O campo ID do Endereço é obrigatório.")]
        public int AddressId { get; set; }
    }
}
