namespace Hotelaria.Server.Models
{
    public sealed class Reserve
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        public DateTime PretendedCheckInDate { get; set; }
        public DateTime PretendedCheckOutDate { get; set; }
    }
}