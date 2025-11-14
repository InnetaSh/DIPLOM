using Globals.Models;

namespace RentObjectApiService.Models
{
    public class RentObjImage : EntityBase
    {
        public string Url { get; set; }
        public int RentObjId { get; set; }
        public RentObj RentObj { get; set; }
    }
}
