using System.ComponentModel.DataAnnotations;

namespace MB.T6.Web.Models.Drivers
{
    public class DriverListViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public int Age { get; set; }

        [Display(Name = "Phone Number")]

        public string? PhoneNumber { get; set; }
        public int Rating { get; set; }
    }
}
