namespace CarRentPro.DTO
{
    public class CarResponseDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public decimal RentPerHour { get; set; }
        public string Color { get; set; }
    }
}