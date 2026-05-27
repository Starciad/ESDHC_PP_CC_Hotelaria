using Microsoft.EntityFrameworkCore;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Web.Models
{
    [PrimaryKey("Id")]
    public sealed class Flow
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("GuestId")]
        public Guest Guest { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }

        [ForeignKey("ReserveId")]
        public Reserve Reserve { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
