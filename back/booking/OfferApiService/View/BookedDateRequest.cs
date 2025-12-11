using Globals.Controllers;
using OfferApiService.Models;

namespace OfferApiService.View
{
    public class BookedDateRequest : IBaseRequest
    {
        public int id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int OfferId { get; set; }

        public static BookedDate MapToModel(BookedDateRequest request)
        {
            return new BookedDate
            {
                id = request.id,
                Start = request.Start,
                End = request.End,
                OfferId = request.OfferId
            };
        }
    }
}
