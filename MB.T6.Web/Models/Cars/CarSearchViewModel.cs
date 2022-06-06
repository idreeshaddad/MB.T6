using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace MB.T6.Web.Models.Cars
{
    public class CarSearchViewModel
    {
        public CarSearchViewModel()
        {
            Results = new List<CarListViewModel>();
        }

        public int Id { get; set; }
        public string? Manufacturer { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public DateTime? ProductionDate { get; set; }
        public KnownColor? Color { get; set; }
        public int? NumberOfSeats { get; set; }
        public string? DriverFirstName { get; set; }
        public string? DriverLastName { get; set; }


        public List<CarListViewModel> Results { get; set; }
    }
}
