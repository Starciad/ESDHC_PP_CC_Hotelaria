using Microsoft.AspNetCore.Identity;

namespace Hotel.Web.Models
{
    // Usuário personalizado para o ASP.NET Identity, adicionando
    // propriedades específicas para a aplicação de hotelaria.
    // A classe é selada (sealed) para evitar herança, garantindo
    // que a estrutura do usuário seja mantida.

    public sealed class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
    }
}
