using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Web.Models
{
    // Representa a ação de reservar um quarto feita por um hóspede. Ela tem
    // um relacionamento direto com o hóspede e com o quarto, e também pode
    // ter dependentes (pessoas que vão se hospedar junto com o hóspede
    // principal).

    [PrimaryKey(nameof(Id))]
    public sealed class Reserve
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public int GuestId { get; set; }

        [Required]
        public DateTime PretendedCheckInDate { get; set; }

        [Required]
        public DateTime PretendedCheckOutDate { get; set; }

        [Required]
        [ForeignKey("RoomId")]
        public Room Room { get; set; } = default!;

        [Required]
        [ForeignKey("GuestId")]
        public Guest Guest { get; set; } = default!;

        public ICollection<ReserveDependent> Dependents { get; set; } = [];
    }
}
