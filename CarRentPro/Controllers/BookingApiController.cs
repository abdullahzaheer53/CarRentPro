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
    [RoutePrefix("api/booking")]
    [Authorize]
    public class BookingApiController : ApiController
    {
        private BookingService bookingService =new BookingService();

        // GET ALL BOOKINGS
        [HttpGet]
        [Route("")]
        
        public IHttpActionResult GetBookings()
        {
            var bookings = bookingService.GetAllBookings();
            return Ok(bookings);
        }

        // GET BOOKING BY ID
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetBookingById(int id)
        {
            var booking = bookingService.GetBookingById(id);

            return Ok(booking);
        }

        // CREATE BOOKING
        [HttpPost]
        [Route("")]
        public IHttpActionResult CreateBooking(CreateBookingDTO dto)
        {
            var booking = bookingService.CreateBooking(dto);
            return Ok(booking);


        }


        [HttpPut]
        [Route("{id:int}")]
        public IHttpActionResult UpdateBooking(int id, CreateBookingDTO dto)
        {
            try
            {
                var updatedData = bookingService.UpdateBooking(id, dto);
                return Ok(updatedData);
            }
            catch (Exception ex)
            {
                // Return a 400 Bad Request with the exception message
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public IHttpActionResult DeleteBooking(int id)
        {
            var deleteBooking= bookingService.DeleteBooking(id);
            return Ok(deleteBooking);
        }

    }
}
