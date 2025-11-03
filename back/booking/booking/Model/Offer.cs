namespace booking.Model
{
    public class Offer
    {
        public DateTime Startrent { get; set; }
        public DateTime Endrent { get; set; }
        public Double Price { get; set; }
        public Country Country { get; set; }
    }
}
