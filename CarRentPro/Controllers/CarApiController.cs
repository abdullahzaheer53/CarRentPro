using CarRentPro.Data;
using CarRentPro.DTO;
using CarRentPro.Models;
using CarRentPro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarRentPro.Controllers
{
    [RoutePrefix("api/car")]
    [Authorize]
    public class CarApiController : ApiController
    {
        private CarService carService = new CarService();
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetCars()
        {
            var cars = carService.GetCars();

            return Ok(cars);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetCarById(int id)
        {
            var car = carService.GetCarById(id);
            return Ok(car);
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateCar(CreateCarDTO dto)
        {
            var car = carService.CreateCar(dto);

            return Ok(car);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateCar(int id, CreateCarDTO dto)
        {
            var car = carService.UpdateCar(id, dto);

            return Ok(car);
        }

        // DELETE CAR (SOFT DELETE)
        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult DeleteCar(int id)
        {
            var car=carService.DeleteCar(id);

            return Ok("Car deleted successfully");
        }




    }

}
