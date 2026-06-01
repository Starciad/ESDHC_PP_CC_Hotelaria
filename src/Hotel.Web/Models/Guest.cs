using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace Hotel.Web.Models
{
    // O hóspede é a entidade principal do sistema, pois é ele quem
    // realiza as reservas e tem um relacionamento direto com o
    // usuário do sistema (ApplicationUser).

    [PrimaryKey(nameof(Id))]
    public sealed class Guest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string CPF { get; set; } = string.Empty;

        public string? Phone { get; set; }
    }
}
