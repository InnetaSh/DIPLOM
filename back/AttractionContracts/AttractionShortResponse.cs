
using Globals.Controllers;

namespace AttractionContracts
{
    public class AttractionShortResponse : IBaseResponse
    {
        public int id { get; set; }
        public string? Title { get; set; }
        public string? ImageUrl_Main { get; set; }
        public string? Slug {  get; set; }


        public List<AttractionImageResponse>? Images { get; set; } = new();

       
    }
}
