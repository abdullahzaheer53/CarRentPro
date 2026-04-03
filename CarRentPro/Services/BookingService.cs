using CarRentPro.DTO;
using CarRentPro.Enums;
using CarRentPro.Models;
using CarRentPro.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRentPro.Services
{
    public class BookingService
    {
        private BookingRepository bookingRepo = new BookingRepository();
        private CarRepository carRepo = new CarRepository();
        private UserRepository userRepo = new UserRepository();
        private PaymentRepository paymentRepo = new PaymentRepository();
        private HistoryRepository historyRepo = new HistoryRepository();

        

        public List<BookingResponseDto> GetAllBookings()
        {
            var bookings = bookingRepo.GetAll();

            return bookings.Select(b => new BookingResponseDto
            {
                Id=b.Id,
                Description=b.Description,
                CarId = b.CarId,
                UserId = b.UserId,
                StartTime = b.StartTime,
                EndTime = b.EndTime,
                TotalRent = b.TotalRent,
                Status = (int)b.Status
            }).ToList();
        }

        public BookingResponseDto GetBookingById(long id)
        {
            var booking = bookingRepo.GetBookingById(id);
            if (booking == null) return null;

            return new BookingResponseDto
            {
                Id = booking.Id,
                Description = booking.Description,
                CarId = booking.CarId,
                UserId = booking.UserId,
                StartTime = booking.StartTime,
                EndTime = booking.EndTime,
                TotalRent = booking.TotalRent,
                Status = (int)booking.Status
            };
        }

        

        public object CreateBooking(CreateBookingDTO dto)
        {
            
            var car = carRepo.GetCarById(dto.CarId);
            if (car == null)
                throw new Exception("Car Not Found");

           
            var user = userRepo.GetUserById(dto.UserId);
            if (user == null)
                throw new Exception("User Not Found");

          
            if (dto.EndTime <= DateTime.Now)
                throw new Exception("End time must be greater than current time");

           
            bool isBooked = bookingRepo.IsCarBooked(dto.CarId, DateTime.Now, dto.EndTime);
            if (isBooked)
                throw new Exception("The car is already booked for the selected time period");

            var hours = (dto.EndTime - DateTime.Now).TotalHours;
            var totalRent = (decimal)hours * car.RentPerHour;

            
            var booking = new Booking
            {
                Description = dto.Description,
                CarId = dto.CarId,
                UserId = dto.UserId,
                StartTime = DateTime.Now,
                EndTime = dto.EndTime,
                TotalRent = totalRent,
                Status = BookingStatus.Pending
            };

            bookingRepo.Add(booking); 
          
            var payment = new Payment
            {
                BookingId = booking.Id,
                Amount = booking.TotalRent,
                PaymentMethod = "Cash",
                PaymentStatus = PaymentStatus.Paid,
                PaidAt = DateTime.Now
            };
            paymentRepo.AddPayment(payment);

           
            var history = new History
            {
                BookingId = booking.Id,
                UserId = booking.UserId,
                CarId = booking.CarId,
                PickupDate = booking.StartTime,
                ReturnDate = booking.EndTime,
                TotalPaid = booking.TotalRent
            };
            historyRepo.AddHistory(history);

         
            return new
            {
                Booking = booking,
                Payment = payment,
                History = history
            };
        }


        public object UpdateBooking(int id, CreateBookingDTO dto)
        {
            
            var booking = bookingRepo.GetBookingById(id);
            if (booking == null)
                throw new Exception("Booking not found");

            
            if (booking.Status == BookingStatus.Completed)
                throw new Exception("Completed bookings cannot be updated");

            
            var car = carRepo.GetCarById(dto.CarId);
            if (car == null)
                throw new Exception("Car not found");

            var user = userRepo.GetUserById(dto.UserId);
            if (user == null)
                throw new Exception("User not found");

           
            if (dto.EndTime <= DateTime.Now)
                throw new Exception("End time must be greater than current time");

           
            bool isBooked = bookingRepo.IsCarBooked(dto.CarId, booking.StartTime, dto.EndTime, id);
            if (isBooked)
                throw new Exception("The car is already booked for the selected time period");

            
            booking.Description = dto.Description;
            booking.CarId = dto.CarId;
            booking.UserId = dto.UserId;
            booking.EndTime = dto.EndTime;

            
            var hours = (booking.EndTime - booking.StartTime).TotalHours;
            booking.TotalRent = (decimal)hours * car.RentPerHour;

            bookingRepo.Update(booking);

           
            var payment = paymentRepo.GetPaymentByBookingId(booking.Id);
            if (payment != null)
            {
                payment.Amount = booking.TotalRent;
                payment.PaidAt = DateTime.Now;
                payment.PaymentStatus = PaymentStatus.Paid;
                paymentRepo.UpdatePayment(payment);
            }

            
            var history = historyRepo.GetHistoryByBookingId(booking.Id);
            if (history != null)
            {
                history.CarId = booking.CarId;
                history.UserId = booking.UserId;
                history.ReturnDate = booking.EndTime;
                history.TotalPaid = booking.TotalRent;
                historyRepo.UpdateHistory(history);
            }

            
            return new
            {
                Booking = new
                {
                    booking.Id,
                    booking.Description,
                    booking.CarId,
                    booking.UserId,
                    booking.StartTime,
                    booking.EndTime,
                    booking.TotalRent,
                    Status = booking.Status.ToString()
                },
                Payment = payment,
                History = history
            };
        }

        

        public object DeleteBooking(int id)
        {
            var booking = bookingRepo.GetBookingById(id);
            if (booking == null)
                throw new Exception("Booking Not Found");

            bookingRepo.Delete(id);

            return new
            {
                booking.Id,
                booking.Description,
                booking.CarId,
                booking.UserId,
                booking.StartTime,
                booking.EndTime,
                booking.TotalRent,
                Status = booking.Status.ToString()
            };
        }
    }
}