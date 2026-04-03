using CarRentPro.Data;
using CarRentPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentPro.Repository
{
    public class PaymentRepository
    {
        private AppDbContext db = new AppDbContext();


        public List<Payment> GetPayments()
        {
            return db.Payments.ToList();
        }

        public void AddPayment(Payment payment)
        {
            db.Payments.Add(payment);
            db.SaveChanges();
        }

        public Payment GetPaymentById(long id)
        {
            return db.Payments.Find(id);
        }

        public Payment GetPaymentByBookingId(long bookingId)
        {
            return db.Payments.FirstOrDefault(p => p.BookingId == bookingId);
        }

        public void UpdatePayment(Payment payment)
        {
            db.SaveChanges();
        }

    }
}