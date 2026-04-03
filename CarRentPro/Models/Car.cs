using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentPro.Models
{
    public class Car
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Model { get; set; }

        public decimal RentPerHour { get; set; }

        public string Color { get; set; }

        public bool Deleted { get; set; } = false;
    }
}