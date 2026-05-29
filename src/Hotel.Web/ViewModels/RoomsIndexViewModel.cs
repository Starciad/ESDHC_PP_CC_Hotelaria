using Hotel.Web.Models;

using System.Collections.Generic;

namespace Hotel.Web.ViewModels
{
    public sealed class RoomsIndexViewModel
    {
        public IEnumerable<Room> Rooms { get; set; } = [];
        public RoomFilterViewModel Filter { get; set; } = new();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
