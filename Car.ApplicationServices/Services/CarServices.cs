using Car.Core.Domain;
using Car.Core.Dto;
using Car.Core.ServiceInterface;
using Car.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.ApplicationServices.Services
{
    public class CarServices : ICarServices
    {
        private readonly CarContext _context;

        public CarServices
            (
                CarContext context
            )
        {
            _context = context;
        }

        public async Task<Cars> Create(CarsDto dto)
        {

            Cars car = new Cars();

            car.Id = Guid.NewGuid();
            car.CarBrand = dto.CarBrand;
            car.CarModel = dto.CarModel;
            car.CarYear = dto.CarYear;
            car.CarColor = dto.CarColor;
            car.CarPrice = dto.CarPrice;
            car.CreatedAt = DateTime.Now;
            car.UpdatedAt = DateTime.Now;

            await _context.CarShop.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }
    }
}