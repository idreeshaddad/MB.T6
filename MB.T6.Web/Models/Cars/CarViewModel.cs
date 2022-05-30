using System.ComponentModel.DataAnnotations;

namespace MB.T6.Web.Models.Cars
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public int DriverId { get; set; }

        [Display(Name = "Driver")]
        public string? DriverFullName { get; set; }
    }
}
