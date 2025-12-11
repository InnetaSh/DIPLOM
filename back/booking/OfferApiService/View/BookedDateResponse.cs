using Globals.Controllers;
using OfferApiService.Models;

namespace OfferApiService.View
{
    public class BookedDateResponse : IBaseResponse
    {
        public int id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int OfferId { get; set; }

        public static BookedDateResponse MapToResponse(BookedDate model)
        {
            return new BookedDateResponse
            {
                id = model.id,
                Start = model.Start,
                End = model.End,
                OfferId = model.OfferId
            };
        }
    }
}
