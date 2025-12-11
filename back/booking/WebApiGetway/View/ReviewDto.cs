namespace WebApiGetway.View
{
    public class ReviewDto
    {
        public int id { get; set; }
        public int OfferId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }

     
        public double OverallRating { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }

}
