namespace ReviewApiService.View
{
    public class OfferReviewStats
    {
        public int OfferId { get; set; }
        public double AverageRating { get; set; }
        public bool IsRecommended { get; set; }
        public bool IsTopLocation { get; set; }
        public bool IsTopCleanliness { get; set; }
    }

}
