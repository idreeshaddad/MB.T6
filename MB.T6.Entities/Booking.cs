namespace MB.T6.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime PickUpDateTime { get; set; }
        public double Price { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
    }
}
