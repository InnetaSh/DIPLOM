namespace WebApiGetway.View
{
    public class OfferByIdRequest
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

        public int Guests { get; set; }


        public static OfferByIdRequest MapToResponse(DateTime startDate, DateTime endDate, int guests)
        {

            return new OfferByIdRequest
            {
                StartDate = startDate,
                EndDate = endDate,
                Guests = guests
            };         
        }
    }
}
