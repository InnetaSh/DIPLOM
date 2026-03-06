
using Globals.Controllers;

namespace AttractionContracts
{
    public class AttractionImageRequest : IBaseRequest
    {
        public int id { get; set; }
        public string Url { get; set; }
        public int AttractionId { get; set; }

    }
}
