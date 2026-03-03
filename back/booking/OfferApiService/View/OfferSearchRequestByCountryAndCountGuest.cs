namespace OfferApiService.View
{
    public class OfferSearchRequestByCountryAndCountGuest
    {
        public int CountryId { get; set; }

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

        public int Adults { get; set; } = 1;
        public int Children { get; set; } = 0;
        public int Rooms { get; set; } = 1;

    }

}
