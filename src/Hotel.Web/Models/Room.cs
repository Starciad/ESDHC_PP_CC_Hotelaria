using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Hotel.Web.Models
{
    [PrimaryKey("Id")]
    public sealed class Room
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
    }
}
