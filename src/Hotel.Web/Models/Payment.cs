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

        [ForeignKey("FlowId")]
        public Flow Flow { get; set; }

        public DateTime PaymentDate { get; set; }
        public decimal Price { get; set; }
    }
}
