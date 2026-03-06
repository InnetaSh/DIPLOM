
using Globals.Controllers;

namespace AttractionContracts
{
    public class AttractionImageResponse : IBaseResponse
    {
        public int id { get; set; }
        public string Url { get; set; }
        public int AttractionId { get; set; }

    }
}
