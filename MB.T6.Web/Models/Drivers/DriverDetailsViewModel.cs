using MB.T6.Utils.Enums;
using MB.T6.Web.Models.Cars;
using System.ComponentModel.DataAnnotations;

namespace MB.T6.Web.Models.Drivers
{
    public class DriverDetailsViewModel
    {
        public DriverDetailsViewModel()
        {
            Cars = new List<CarViewModel>();
        }

        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Display(Name = "Full Name")]
        public string FullName { get; set; }


        public Gender Gender { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public int Rating { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public List<CarViewModel> Cars { get; set; }
        public string? Image { get; set; }
    }
}