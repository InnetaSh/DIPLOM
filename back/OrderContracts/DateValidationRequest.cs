namespace OrderContracts
{
    public class DateValidationRequest
    {
        public int OfferId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
