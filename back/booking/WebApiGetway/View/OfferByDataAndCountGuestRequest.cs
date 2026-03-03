namespace WebApiGetway.View
{
    public class OfferByDataAndCountGuestRequest
    {
        private DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set => _startDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get => _endDate;
            set => _endDate = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        public int Adults { get; set; }
        public int Children { get; set; }


        public static OfferByDataAndCountGuestRequest MapToResponse(DateTime startDate, DateTime endDate, int adults, int children)
        {

            return new OfferByDataAndCountGuestRequest
            {
                StartDate = startDate,
                EndDate = endDate,
                Adults = adults,
                Children = children
            };         
        }
    }
}
