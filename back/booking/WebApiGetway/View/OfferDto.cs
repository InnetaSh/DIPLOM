namespace WebApiGetway.View
{
    public class OfferDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public decimal PricePerDay { get; set; }

        public double Rating { get; set; }

        // минимум данных о месте
        public string? City { get; set; }
        public string? Country { get; set; }

        // одна главная картинка
        public string? MainImageUrl { get; set; }
    }
}

}
