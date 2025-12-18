using WebApiGetway.Enum;

namespace WebApiGetway.View
{
    public class CreateOrderRequest
    {
        // === Order ===
        public int OfferId { get; set; }
    
        public int Guests { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
     
        public string? ClientNote { get; set; }
       // public PaymentMethod? PaymentMethod { get; set; }

      
        //public decimal UserDiscountPercent { get; set; }
    }
}
