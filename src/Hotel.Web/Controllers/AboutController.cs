using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    // Esse controller é responsável por exibir a página "Sobre" do site,
    // que geralmente contém informações sobre a empresa, sua história,
    // missão, visão e valores. Ele tem uma única ação chamada "Index"
    // que retorna a view correspondente.
    public sealed class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
