using Microsoft.EntityFrameworkCore;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Web.Models
{
    [PrimaryKey(nameof(Id))]
    public sealed class Flow
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int GuestId { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public int ReserveId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Required]
        [ForeignKey("GuestId")]
        public Guest Guest { get; set; } = default!;

        [Required]
        [ForeignKey("RoomId")]
        public Room Room { get; set; } = default!;

        [Required]
        [ForeignKey("ReserveId")]
        public Reserve Reserve { get; set; } = default!;

        [Required]
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; } = default!;
    }
}
