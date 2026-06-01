using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    // Este controlador é responsável por gerenciar as ações relacionadas à
    // página de contato do site. Ele possui uma única ação, Index, que
    // retorna a view correspondente à página de contato. Esta página pode
    // conter informações de contato do hotel, como endereço, telefone e
    // e-mail, bem como um formulário para os usuários entrarem em contato
    // com o hotel.
    public sealed class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
