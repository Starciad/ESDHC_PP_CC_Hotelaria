using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public sealed class ExploreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
