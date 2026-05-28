using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Hotel.Web.Models
{
    [PrimaryKey(nameof(Id))]
    public sealed class Guest
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
