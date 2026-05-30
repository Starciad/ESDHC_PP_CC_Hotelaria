using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Web.ViewModels
{
    public sealed class ReservationDependentInputViewModel
    {
        [Required(ErrorMessage = "O nome do dependente é obrigatório.")]
        [Display(Name = "Nome")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de nascimento")]
        public DateTime BirthdayDate { get; set; }
    }
}
