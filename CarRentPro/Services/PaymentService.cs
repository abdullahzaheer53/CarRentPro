using CarRentPro.Data;
using CarRentPro.Models;
using CarRentPro.Repository;
using System;
using System.Linq;
using System.Web;

namespace CarRentPro.Services
{
    public class PaymentService
    {
        public PaymentRepository paymentRepo = new PaymentRepository(); 
        public BookingRepository bookingRepo = new BookingRepository();

        public object GetPayments()
        {
            var payments = paymentRepo.GetPayments();
            var Bookings = bookingRepo.GetAll();
            var result = payments
                .Join(
                    Bookings,
                    payment => payment.BookingId,
                    booking => booking.Id,
                    (payment, booking) => new
                    {
                        payment.Id,
                        payment.BookingId,
                        CustomerName = booking.User.Name,
                        CarName = booking.Car.Name,
                        payment.Amount,
                        payment.PaymentMethod,
                        Status = payment.PaymentStatus.ToString(),
                        payment.PaidAt
                    }
                )
                .ToList();

                

            return payments;
        }

        public object GetPaymentById(long id)
        {
            Payment payment = paymentRepo.GetPaymentById(id);
            if (payment == null) throw new Exception("Payment not found");
            Booking booking = bookingRepo.GetBookingById(payment.BookingId);
            return new
            {
                payment.Id,
                payment.BookingId,
                CustomerName = booking.User.Name,
                CarName = booking.Car.Name,
                payment.Amount,
                payment.PaymentMethod,
                Status = payment.PaymentStatus.ToString(),
                payment.PaidAt
            };
        }

        
    }
}