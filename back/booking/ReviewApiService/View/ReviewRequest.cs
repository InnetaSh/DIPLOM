using Globals.Controllers;

namespace ReviewApiService.View
{
    public class ReviewRequest : IBaseRequest
    {
        public int OfferId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }

        // Оценки по категориям (1-10)
        public double Staff { get; set; }
        public double Facilities { get; set; }
        public double Cleanliness { get; set; }
        public double Comfort { get; set; }
        public double ValueForMoney { get; set; }
        public double Location { get; set; }
    }
}
