using MB.T6.Web.Models.Drivers;

namespace MB.T6.Web.Models.Cars
{
    public class CarListViewModel
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }

        public DriverDetailsViewModel Driver { get; set; }
    }
}
