using booking.Model;

namespace booking.Services
{
    public class OfferService
    {
        private List<Offer> _offers = new List<Offer>()
        {
            new Offer()
            {
                Country = new Country(){Name = "Poland"}
            }
        };
    }
}
