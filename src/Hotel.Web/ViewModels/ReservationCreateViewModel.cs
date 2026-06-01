using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Web.ViewModels
{
    // Responsável por representar os dados de criação de
    // reserva que serão enviados pela view de criação de
    // reserva.

    public sealed class ReservationCreateViewModel
    {
        public int RoomId { get; set; }
        public string RoomTitle { get; set; } = string.Empty;
        public string RoomDescription { get; set; } = string.Empty;
        public string RoomImageUrl { get; set; } = string.Empty;
        public decimal RoomPrice { get; set; }
        public int RoomCapacity { get; set; }

        [Required(ErrorMessage = "A data de check-in é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Check-in")]
        public DateTime PretendedCheckInDate { get; set; }

        [Required(ErrorMessage = "A data de check-out é obrigatória.")]
        [DataType(DataType.Date)]
        [Display(Name = "Check-out")]
        public DateTime PretendedCheckOutDate { get; set; }

        [Range(1, 20, ErrorMessage = "Informe uma quantidade válida de hóspedes.")]
        [Display(Name = "Quantidade de hóspedes")]
        public int GuestsCount { get; set; } = 1;

        public List<ReservationDependentInputViewModel> Dependents { get; set; } = [];
    }
}
