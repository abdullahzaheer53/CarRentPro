using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentPro.DTO
{
    public class CreateCarDTO
    {
        public string Name { get; set; }

        public string Model { get; set; }

        public decimal RentPerHour { get; set; }

        public string Color { get; set; }
    }
}