using MB.T6.Web.Models.Drivers;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace MB.T6.Web.Models.Cars
{
    public class CarListViewModel
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        [Display(Name = "Production Date")]
        public DateTime? ProductionDate { get; set; }
        public KnownColor Color { get; set; } = KnownColor.White;

        [Display(Name = "Number of Seats")]
        public int NumberOfSeats { get; set; } = 4;

        public DriverDetailsViewModel Driver { get; set; }
    }
}
