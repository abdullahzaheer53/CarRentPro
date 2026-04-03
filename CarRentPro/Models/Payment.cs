using CarRentPro.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentPro.Models
{
    public class Payment
    {
        public long Id { get; set; }            // Primary Key

        public long BookingId { get; set; }     // Foreign key to Booking

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }   // Cash, Card, Online

        public virtual Booking Booking { get; set; }

        public PaymentStatus PaymentStatus { get; set; }  // Enum: Pending, Paid, Failed

        public DateTime PaidAt { get; set; } = DateTime.Now;    
    }
}