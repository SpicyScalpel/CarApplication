using Microsoft.AspNetCore.Mvc;
using CarApplication.Models;
using CarApplication.Models.Car;
using Car.Data;
using Car.Core.ServiceInterface;
using System.Runtime.Intrinsics.X86;
using Car.Core.Dto;

namespace CarApplication.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarContext _context;
        private readonly ICarServices _carServices;
        public CarsController
            (
                CarContext context,
                ICarServices carServices
            )
        {
            _context = context;
            _carServices = carServices;
        }
        public IActionResult Index()
        {
            var result = _context.CarShop
                .Select(x => new CarIndexViewModel
                {
                    //Id = x.Id,
                    CarBrand = x.CarBrand,
                    CarModel = x.CarModel,
                    CarYear = x.CarYear,
                    CarColor = x.CarColor,
                    CarPrice = x.CarPrice
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarsCreateViewModel vm)
        {
            var dto = new CarsDto()
            {
                Id = vm.Id,
                CarBrand = vm.CarBrand,
                CarModel = vm.CarModel,
                CarYear = vm.CarYear,
                CarColor = vm.CarColor,
                CarPrice = vm.CarPrice
            };

            var result = await _carServices.Create(dto);

            return RedirectToAction(nameof(Index), vm);
        }
    }
}
