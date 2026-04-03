using CarRentPro.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentPro.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Address { get; set; }

        public UserRole Role { get; set; }

        public bool Deleted { get; set; }=false;

    }
}