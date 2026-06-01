using System.ComponentModel.DataAnnotations;

namespace Hotel.Web.ViewModels
{
    // Responsável por representar os dados de login
    // que serão enviados pela view de login.

    public sealed class LoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Lembrar-me?")]
        public bool RememberMe { get; set; }
    }
}
