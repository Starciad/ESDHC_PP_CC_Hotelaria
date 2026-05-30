using Microsoft.AspNetCore.Identity;

namespace Hotel.Web.Models
{
    public sealed class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
    }
}
