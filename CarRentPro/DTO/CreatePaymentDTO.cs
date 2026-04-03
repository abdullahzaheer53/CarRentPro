using CarRentPro.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentPro.DTO
{
    public class CreatePaymentDTO
    {
        public long BookingId { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
    }
}