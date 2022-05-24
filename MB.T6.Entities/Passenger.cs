using MB.T6.Utils.Enums;

namespace MB.T6.Entities
{
    public class Passenger
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Gender Gender { get; set; }
    }
}
