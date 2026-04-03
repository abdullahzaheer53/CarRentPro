using CarRentPro.Data;
using CarRentPro.DTO;
using CarRentPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentPro.Repository
{
    public class CarRepository
    {
        private AppDbContext db = new AppDbContext();

        public List<CarResponseDto> GetCars()
        {
            return db.Cars
               .Where(x => x.Deleted == false)
               .Select(x => new CarResponseDto
               {
                   Id = x.Id,
                   Name = x.Name,
                   Model = x.Model,
                   RentPerHour = x.RentPerHour,
                   Color = x.Color
               }).ToList();
        }

        public Car GetCarById(long id)
        {
            return db.Cars.Find(id);
        }

        public Car CreateCar(Car car)
        {
            db.Cars.Add(car);   
            db.SaveChanges();
            return car;

        }
        public void Save()
            {
                db.SaveChanges();
        }   
    }
}