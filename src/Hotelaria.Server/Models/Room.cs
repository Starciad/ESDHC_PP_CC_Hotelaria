namespace Hotelaria.Server.Models
{
    public sealed class Room
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
    }
}