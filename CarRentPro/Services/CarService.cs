using CarRentPro.Data;
using CarRentPro.DTO;
using CarRentPro.Models;
using CarRentPro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentPro.Services
{
    public class CarService
    {
        private CarRepository carRepos = new CarRepository();

        public List<CarResponseDto> GetCars() 
        {
            return carRepos.GetCars();
        }

        public CarResponseDto GetCarById(int id)
        {
            var car = carRepos.GetCarById(id);
            if (car == null || car.Deleted ) return null;

            return new CarResponseDto  // Use DTO
            {
                Id = car.Id,
                Name = car.Name,
                Model = car.Model,
                RentPerHour = car.RentPerHour,
                Color = car.Color
            };
        }

        public CarResponseDto CreateCar(CreateCarDTO dto)
        {
            var car = new Car
            {
                Name = dto.Name,
                Model = dto.Model,
                RentPerHour = dto.RentPerHour,
                Color = dto.Color
            };

            car = carRepos.CreateCar(car); 

            return new CarResponseDto
            {
                Id = car.Id,
                Name = car.Name,
                Model = car.Model,
                RentPerHour = car.RentPerHour,
                Color = car.Color
            };
        }

        public CarResponseDto UpdateCar(int id, CreateCarDTO dto)
        {
            var car = carRepos.GetCarById(id);

            if (car == null || car.Deleted)
                return null;

            car.Name = dto.Name;
            car.Model = dto.Model;
            car.RentPerHour = dto.RentPerHour;
            car.Color = dto.Color;

            carRepos.Save();

            return new CarResponseDto
            {
                Id = car.Id,
                Name = car.Name,
                Model = car.Model,
                RentPerHour = car.RentPerHour,
                Color = car.Color
            };
        }

        public string DeleteCar(int id)
        {
            var car = carRepos.GetCarById(id);
            if (car == null || car.Deleted) return null;
            car.Deleted = true;
            carRepos.Save();
            return "Car deleted successfully";
        }
    }
}