namespace OfferApiService.View
{
    public class OfferMainSearchRequest
    {
        public int CityId { get; set; }

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
    }

}
