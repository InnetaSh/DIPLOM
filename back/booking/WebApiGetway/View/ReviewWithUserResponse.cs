namespace WebApiGetway.View
{
    public class ReviewWithUserDto
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public double OverallRating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public UserShortInfo User { get; set; }
    }

    public class UserShortInfo
    {
        public string Username { get; set; }
        public string Country { get; set; }
    }

}
