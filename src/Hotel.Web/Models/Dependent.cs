using Microsoft.EntityFrameworkCore;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Web.Models
{
    [PrimaryKey(nameof(Id))]
    public sealed class Dependent
    {
        [Key]
        internal int Id { get; set; }

        [ForeignKey("GuestId")]
        internal Guest Guest { get; set; }

        internal string Name { get; set; } = string.Empty;
        internal DateTime BirthdayDate { get; set; }
    }
}
