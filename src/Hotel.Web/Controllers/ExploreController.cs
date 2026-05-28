using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class ExploreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
