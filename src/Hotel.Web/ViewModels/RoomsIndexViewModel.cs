using Hotel.Web.Models;

using System.Collections.Generic;

namespace Hotel.Web.ViewModels
{
    // Responsável por representar os dados necessários para exibir a
    // view de listagem de quartos, incluindo a lista de quartos, os
    // dados de filtro e a paginação.

    public sealed class RoomsIndexViewModel
    {
        public IEnumerable<Room> Rooms { get; set; } = [];
        public RoomFilterViewModel Filter { get; set; } = new();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
