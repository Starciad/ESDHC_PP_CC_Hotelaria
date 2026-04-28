namespace Hotelaria.Server.Models
{
    public sealed class Room
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Prize { get; set; }
        public int Capacity { get; set; }
    }
}