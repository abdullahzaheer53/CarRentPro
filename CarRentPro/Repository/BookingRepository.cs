using CarRentPro.Data;
using CarRentPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRentPro.Repository
{
    public class BookingRepository
    {
        private AppDbContext db = new AppDbContext();

    

        public List<Booking> GetAll()
        {
            return db.Bookings.Where(b => !b.Deleted).ToList();
        }

        public Booking GetBookingById(long id)
        {
            return db.Bookings.FirstOrDefault(b => b.Id == id && !b.Deleted);
        }

        public void Add(Booking booking)
        {
            db.Bookings.Add(booking);
            db.SaveChanges();
        }

        public void Update(Booking booking)
        {
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var booking = db.Bookings.Find(id);
            if (booking != null)
            {
                booking.Deleted = true;
                db.SaveChanges();
            }
        }

        public bool IsCarBooked(int carId, DateTime start, DateTime end, int? excludeId = null)
        {
            var query = db.Bookings.Where(b =>
                b.CarId == carId &&
                !b.Deleted &&
                b.StartTime < end &&
                start < b.EndTime
            );

            if (excludeId.HasValue)
                query = query.Where(b => b.Id != excludeId.Value);

            return query.Any();
        }

    }
}