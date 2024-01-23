using Microsoft.AspNetCore.Mvc;
using CarApplication.Models;
using CarApplication.Models.Car;
using Car.Data;

//namespace CarApplication.Controllers
//{
//    public class CarsController : Controller
//    {
//        private readonly CarContext _context;
//        public CarsController
//            (
//                CarContext context
//            )
//        {
//            _context = context;
//        }
//        public IActionResult Index()
//        {
//            var result = _context.Cars
//                .Select(x => new CarIndexViewModel
//                {
//                    Id = x.Id,
//                    CarBrand = x.CarBrand,
//                    CarModel = x.CarModel,
//                    CarYear = x.CarYear,
//                    CarColor = x.CarColor,
//                    CarPrice = x.Carprice
//                });

//            return View(result);
//        }

//        [HttpGet]
//        public IActionResult Create()
//        {
//            return View();
//        }
//    }
//}
