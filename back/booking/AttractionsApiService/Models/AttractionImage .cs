using Globals.Models;

namespace AttractionsApiService.Models
{
    public class AttractionImage : EntityBase
    {
        public string Url { get; set; }
        public int AttractionId { get; set; }
        public Attraction Attraction{ get; set; }
    }
}
