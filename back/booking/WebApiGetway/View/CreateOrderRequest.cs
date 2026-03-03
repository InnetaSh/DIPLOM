using WebApiGetway.Enum;

namespace WebApiGetway.View
{
    public class CreateOrderRequest
    {
        // === Order ===
        public int OfferId { get; set; }
    
        public int Guests { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public string? MainGuestFirstName { get; set; }
        public string? MainGuestLastName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
     
        public string? ClientNote { get; set; }
        public bool? isBusinessTrip { get; set; } = false;

        public string? PaymentMethod { get; set; }

  
    }
}
