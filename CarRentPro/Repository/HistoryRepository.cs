using CarRentPro.Data;
using CarRentPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentPro.Repository
{
    public class HistoryRepository
    {
        private AppDbContext db = new AppDbContext();

        public List<History> GetHistory()
        {
          return db.Histories.ToList();
        }

        public void AddHistory(History history)
        {
            db.Histories.Add(history);
            db.SaveChanges();
        }

        public History GetHistoryByBookingId(long bookingId)
        {
            return db.Histories.FirstOrDefault(h => h.BookingId == bookingId);
        }

        public void UpdateHistory(History history)
        {
            db.SaveChanges();
        }
    }
}