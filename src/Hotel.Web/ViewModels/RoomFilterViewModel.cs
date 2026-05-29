namespace Hotel.Web.ViewModels
{
    public sealed class RoomFilterViewModel
    {
        public string? Search { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? Capacity { get; set; }
        public int Page { get; set; } = 1;
    }
}
