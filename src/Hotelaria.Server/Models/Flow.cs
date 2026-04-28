namespace Hotelaria.Server.Models
{
    public sealed class Flow
    {
        public int Id { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int GuestId { get; set; }
        public int RoomId { get; set; }
        public int ReserveId { get; set; }
        public int EmployeeId { get; set; }
    }
}