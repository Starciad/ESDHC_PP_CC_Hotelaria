using Hotel.Web.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace Hotel.Web.Controllers
{
    // Este controlador é responsável por gerenciar as ações relacionadas à
    // página inicial do site. Ele possui uma única ação, Index, que
    // retorna a view correspondente à página inicial. Esta página pode
    // conter informações gerais sobre o hotel, como uma breve descrição,
    // imagens, promoções e links para outras seções do site, como quartos,
    // contato e sobre.
    public sealed class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
