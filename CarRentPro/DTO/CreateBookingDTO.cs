
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentPro.DTO
{
    public class CreateBookingDTO
    {
        public string Description { get; set; }

        public int CarId { get; set; }

        public int UserId { get; set; }

       // End date time by user

        public DateTime EndTime { get; set; }
    }
}