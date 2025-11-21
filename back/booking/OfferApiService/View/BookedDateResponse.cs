using Globals.Controllers;
using System;

namespace OfferApiService.View
{
    public class BookedDateResponse : IBaseResponse
    {
        public int id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int OfferId { get; set; }
    }
}
