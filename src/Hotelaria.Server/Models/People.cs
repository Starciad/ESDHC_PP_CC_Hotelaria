namespace Hotelaria.Server.Models
{
    public abstract class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Telephone { get; set; }
    }
}