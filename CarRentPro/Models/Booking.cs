using CarRentPro.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentPro.Models
{
    public class Booking
    {
        public long Id { get; set; }

        public string Description { get; set; }

        public long CarId { get; set; }

        public long UserId { get; set; }

        public DateTime StartTime { get; set; } = DateTime.Now;

        public DateTime EndTime { get; set; }

        public BookingStatus Status { get; set; } = BookingStatus.Pending;

        public decimal TotalRent { get; set; }

        public virtual Car Car { get; set; }

        public virtual User User { get; set; }

        //public virtual Payment Payment { get; set; }

        
        public bool Deleted { get; set; }=false;
    }
}