using MB.T6.Utils.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MB.T6.Entities
{
    public class Driver
    {
        public Driver()
        {
            Cars = new List<Car>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DOB { get; set; }
        public int Rating { get; set; }
        public string? PhoneNumber { get; set; }

        public List<Car> Cars { get; set; }


        // EF CORE Will ignore NotMapped properties
        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        [NotMapped]
        public int Age
        {
            get
            {
                if(DOB.HasValue == false)
                {
                    throw new Exception("Driver has no date of birth!");
                }
                return DateTime.Now.Year - DOB.Value.Year;
            }

        }

        public string? Image { get; set; }
    }
}