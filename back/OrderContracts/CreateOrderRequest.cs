
namespace OrderContracts
{
    public class CreateOrderRequest
    {
        // === Order ===
        public int OfferId { get; set; }
        public int OwnerId { get; set; }
        public int Guests { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int Rooms { get; set; }
        public string? MainGuestFirstName { get; set; }
        public string? MainGuestLastName { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
     
        public string? ClientNote { get; set; }
        public bool? isBusinessTrip { get; set; } = false;

        public string? PaymentMethod { get; set; }

    }
}
