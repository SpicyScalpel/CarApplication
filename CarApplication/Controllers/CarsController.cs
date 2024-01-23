using Microsoft.AspNetCore.Mvc;

namespace CarApplication.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
