namespace OrderApiGetway.View
{
    public class DateValidationRequest
    {
        public List<int> OrdersIdList { get; set; } = new();
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
