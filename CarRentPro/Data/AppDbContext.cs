using CarRentPro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarRentPro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DefaultConnection")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<History> Histories { get; set; }

        public DbSet<Payment> Payments { get; set; }

    }
}