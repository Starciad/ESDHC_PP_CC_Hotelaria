using Microsoft.AspNetCore.Mvc;

namespace Hotel.Web.Controllers
{
    public class RoomsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
