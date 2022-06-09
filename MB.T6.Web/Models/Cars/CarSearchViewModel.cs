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

        [Display(Name = "Production Date")]
        public DateTime? ProductionDate { get; set; }
        public KnownColor? Color { get; set; }

        [Display(Name = "Number of Seats")]
        public int? NumberOfSeats { get; set; }


        [Display(Name = "Driver First Name")]
        public string? DriverFirstName { get; set; }

        [Display(Name = "Driver Second Name")]
        public string? DriverLastName { get; set; }



        // This is for the table of search results on the bottom of the page
        public List<CarListViewModel> Results { get; set; }
    }
}
