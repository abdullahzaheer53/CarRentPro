using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentPro.DTO
{
    public class CreateHistoryDTO
    {
        public long BookingId { get; set; }

        public long UserId { get; set; }

        public long CarId { get; set; }

        public DateTime PickupDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public decimal TotalPaid { get; set; }
    }
}