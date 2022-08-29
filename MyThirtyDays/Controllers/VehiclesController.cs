using Microsoft.AspNetCore.Mvc;

namespace MyThirtyDays.Controllers
{
    public class VehiclesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
