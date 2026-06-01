namespace Hotel.Web.ViewModels
{
    // Responsável por representar os dados de erro
    // que serão exibidos na view de erro.

    public sealed class ErrorViewModel
    {
        public required string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
