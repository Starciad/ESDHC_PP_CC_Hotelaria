using Microsoft.EntityFrameworkCore;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Web.Models
{
    [PrimaryKey(nameof(Id))]
    public sealed class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FlowId { get; set; }

        [Required]
        [Range(1, 999999)]
        public decimal Price { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [ForeignKey("FlowId")]
        public Flow Flow { get; set; } = default!;
    }
}
