using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Hotel.Web.Models
{
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
