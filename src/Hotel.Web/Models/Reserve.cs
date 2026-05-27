using Microsoft.EntityFrameworkCore;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Web.Models
{
    [PrimaryKey("Id")]
    public sealed class Reserve
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }

        [ForeignKey("GuestId")]
        public Guest Guest { get; set; }

        public DateTime PretendedCheckInDate { get; set; }
        public DateTime PretendedCheckOutDate { get; set; }
    }
}
