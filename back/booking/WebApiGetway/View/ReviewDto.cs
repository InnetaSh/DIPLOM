namespace WebApiGetway.View
{
    public class ReviewDto
    {
        public int OrderId { get; set; }
        public int OfferId { get; set; }
        public int UserId { get; set; }

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


        public static ReviewDto MapToDto(CreateReviewRequest request, int orderId, int userId)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            return new ReviewDto
            {
                OrderId = orderId,
                OfferId = userId,
                UserId = userId,
                Staff = request.Staff,
                Facilities = request.Facilities,
                Cleanliness = request.Cleanliness,

                Comfort = request.Comfort,
                ValueForMoney = request.ValueForMoney,
                Location = request.Location,
                CreatedAt = request.CreatedAt,
                IsApproved = false,
            };
        }
    }

}
