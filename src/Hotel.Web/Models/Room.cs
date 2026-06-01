using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Hotel.Web.Models
{
    // O quarto é a entidade que representa um quarto disponível
    // para reserva no hotel. Ele tem um relacionamento direto com
    // as reservas, e é identificado por um título, uma descrição,
    // um preço, uma capacidade e outras características (como se
    // tem wifi, varanda ou piscina).

    [PrimaryKey(nameof(Id))]
    public sealed class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Range(1, 999999)]
        public decimal Price { get; set; }

        [Range(1, 20)]
        public int Capacity { get; set; }

        [MaxLength(500)]
        public string ImageUrl { get; set; } = string.Empty;

        public bool HasWifi { get; set; }

        public bool HasBalcony { get; set; }

        public bool HasPool { get; set; }
    }
}
