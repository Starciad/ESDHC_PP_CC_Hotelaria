using Microsoft.EntityFrameworkCore;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Web.Models
{
    // Representa uma pessoa que vai se hospedar junto com o hóspede principal, mas
    // que não é o responsável pela reserva. Ela tem um relacionamento direto
    // com a reserva, e é identificada por um nome e uma data de nascimento.

    [PrimaryKey(nameof(Id))]
    public sealed class ReserveDependent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ReserveId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime BirthdayDate { get; set; }

        [Required]
        [ForeignKey(nameof(ReserveId))]
        public Reserve Reserve { get; set; } = default!;
    }
}
