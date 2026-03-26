using Globals.Controllers;


namespace ReviewContracts
{
    public class ReviewRequest : IBaseRequest
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int OfferId { get; set; }

        // Оценки по категориям (1-10)
        public double Staff { get; set; }
        public double Facilities { get; set; }
        public double Cleanliness { get; set; }
        public double Comfort { get; set; }
        public double ValueForMoney { get; set; }
        public double Location { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Опционально: статус модерации
        public bool IsApproved { get; set; } = true;

        public string Comment { get; set; }
    }
}
