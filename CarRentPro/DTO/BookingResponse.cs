

using System;

namespace CarRentPro.DTO
{
    public class BookingResponseDto
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public long CarId { get; set; }
        public long UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal TotalRent { get; set; }
        public int Status { get; set; }
    }
}
