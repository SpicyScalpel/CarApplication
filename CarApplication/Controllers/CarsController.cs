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
            var result = _context.Carapp
                .OrderByDescending(y => y.Id)
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
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
            CarCreateUpdateViewModel car = new CarCreateUpdateViewModel();

            return View("CreateUpdate", car);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var dto = new CarsDto()
            {
                Id = vm.Id,
                CarBrand = vm.CarBrand,
                CarModel = vm.CarModel,
                CarYear = vm.CarYear,
                CarColor = vm.CarColor,
                CarPrice = vm.CarPrice,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt
            };

            var result = await _carServices.Create(dto);

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarDetailsViewModel();

            vm.Id = car.Id;
            vm.CarBrand = car.CarBrand;
            vm.CarModel = car.CarModel;
            vm.CarYear = car.CarYear;
            vm.CarColor = car.CarColor;
            vm.CarPrice = car.CarPrice;
            vm.CreatedAt = car.CreatedAt;
            vm.UpdatedAt = car.UpdatedAt;

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarCreateUpdateViewModel();

            vm.Id = car.Id;
            vm.CarBrand = car.CarBrand;
            vm.CarModel = car.CarModel;
            vm.CarYear = car.CarYear;
            vm.CarColor = car.CarColor;
            vm.CarPrice = car.CarPrice;
            vm.CreatedAt = car.CreatedAt;
            vm.UpdatedAt = car.UpdatedAt;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarsDto()
            {
                Id = vm.Id,
                CarBrand = vm.CarBrand,
                CarModel = vm.CarModel,
                CarYear = vm.CarYear,
                CarColor = vm.CarColor,
                CarPrice = vm.CarPrice,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
            };

            var result = await _carServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarDeleteViewModel();

            vm.Id = car.Id;
            vm.CarBrand = car.CarBrand;
            vm.CarModel = car.CarModel;
            vm.CarYear = car.CarYear;
            vm.CarColor = car.CarColor;
            vm.CarPrice = car.CarPrice;
            vm.CreatedAt = car.CreatedAt;
            vm.UpdatedAt = car.UpdatedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var carId = await _carServices.Delete(id);

            if (carId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
