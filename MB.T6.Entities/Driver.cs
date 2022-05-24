using MB.T6.Utils.Enums;

namespace MB.T6.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }

        public List<Car> Cars { get; set; }
    }
}