using Globals.Controllers;
using Globals.Models;

namespace OfferApiService.View
{
    public class BookedDateRequest : IBaseRequest
    {
        public int id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int OfferId { get; set; }
    }
}
