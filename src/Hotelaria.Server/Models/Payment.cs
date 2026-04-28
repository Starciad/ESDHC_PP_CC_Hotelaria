namespace Hotelaria.Server.Models
{
    public sealed class Payment
    {
        public int Id { get; set; }
        public int FlowId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal TotalPrize { get; set; }
    }
}