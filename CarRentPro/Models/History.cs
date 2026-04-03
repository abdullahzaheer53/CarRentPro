using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarRentPro.Models
{
    public class History
    {
        public long Id { get; set; }

        
        public long BookingId { get; set; }

        public long UserId { get; set; }

        public long CarId { get; set; }

        public DateTime PickupDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public decimal TotalPaid { get; set; }
        [ForeignKey("BookingId")]
        public virtual Booking Booking { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}