using Microsoft.EntityFrameworkCore;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Web.Models
{
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
