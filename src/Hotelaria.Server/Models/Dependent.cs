namespace Hotelaria.Server.Models
{
    public sealed class Dependent
    {
        public int Id { get; set; }
        public int GuestId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}