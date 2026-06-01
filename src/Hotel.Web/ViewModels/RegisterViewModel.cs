using System.ComponentModel.DataAnnotations;

namespace Hotel.Web.ViewModels
{
    // Responsável por representar os dados de registro que
    // serão enviados pela view de registro.

    public sealed class RegisterViewModel
    {
        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [DataType(DataType.Text)]
        public string FullName { get; set; } = string.Empty;

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [DataType(DataType.Text)]
        public string CPF { get; set; } = string.Empty;

        [Display(Name = "Número de Telefone")]
        [Required(ErrorMessage = "O número de telefone é obrigatório.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Confirmar Senha")]
        [Required(ErrorMessage = "A confirmação de senha é obrigatória.")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
