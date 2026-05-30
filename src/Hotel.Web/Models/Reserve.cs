using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Web.Models
{
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
