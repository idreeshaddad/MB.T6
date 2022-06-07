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

        // Those are the search parameters
        public int Id { get; set; }
        public string? Manufacturer { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public DateTime? ProductionDate { get; set; }
        public KnownColor? Color { get; set; }
        public int? NumberOfSeats { get; set; }
        public string? DriverFirstName { get; set; }
        public string? DriverLastName { get; set; }



        // This is for the table of search results on the bottom of the page
        public List<CarListViewModel> Results { get; set; }
    }
}
