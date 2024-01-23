using Microsoft.AspNetCore.Mvc;
using CarApplication.Models;
using CarApplication.Models.Car;

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
