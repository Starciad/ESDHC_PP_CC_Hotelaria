namespace Hotelaria.Server.Models
{
    public sealed class Employee : People
    {
        public DateTime AdmissionDate { get; set; }
        public decimal Salary { get; set; }
        public string PIS { get; set; }
        public bool IsAdmin { get; set; }
    }
}