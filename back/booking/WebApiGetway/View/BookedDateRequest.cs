using Globals.Controllers;

namespace WebApiGetway.View
{
    public class BookedDateRequest : IBaseRequest
    {
        public int id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int OfferId { get; set; }

    }
}
