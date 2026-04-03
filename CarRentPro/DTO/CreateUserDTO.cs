using CarRentPro.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentPro.DTO
{
    public class CreateUserDTO
    {
        
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public int Role { get; set; }
    
}
}