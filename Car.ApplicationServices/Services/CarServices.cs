﻿using Car.Core.Domain;
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
            //if here change CreatedAt and UpdatedAt to dto so we can insert any day - it wont be fixed

            await _context.Carapp.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Cars> Update(CarsDto dto)
        {
            var domain = new Cars()
            {
                Id = dto.Id,
                CarBrand = dto.CarBrand,
                CarModel = dto.CarModel,
                CarYear = dto.CarYear,
                CarColor= dto.CarColor,
                CarPrice = dto.CarPrice,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = DateTime.Now,

            };

            _context.Carapp.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }

        public async Task<Cars> Delete(Guid id)
        {
            var carId = await _context.Carapp
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Carapp.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }

        public async Task<Cars>GetAsync(Guid id)
        {
            var result = await _context.Carapp
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}