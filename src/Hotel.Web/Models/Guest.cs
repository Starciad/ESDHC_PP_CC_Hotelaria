using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Hotel.Web.Models
{
    [PrimaryKey("Id")]
    public sealed class Guest
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Phone { get; set; }
    }
}
