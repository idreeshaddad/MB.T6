using System.Drawing;

namespace MB.T6.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime? ProductionDate { get; set; }
        public KnownColor Color { get; set; } = KnownColor.White;
        public int NumberOfSeats { get; set; } = 4;

        public int DriverId { get; set; }
        public Driver Driver { get; set; }

        public string? Image { get; set; }
        public string? LogoImage { get; set; }
    }
}
