namespace Hotel.Web.ViewModels
{
    // Responsável por representar os dados de filtro de quartos
    // que serão enviados pela view de listagem de quartos.

    public sealed class RoomFilterViewModel
    {
        public string? Search { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? Capacity { get; set; }
        public int Page { get; set; } = 1;
    }
}
