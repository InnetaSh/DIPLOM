


using Globals.Controllers;
using OfferApiService.Models.RentObject;

namespace OfferApiService.View.RentObject
{
    public class ParamsCategoryResponse : IBaseResponse
    {
        public int id { get; set; }
        public string Title { get; set; }
        public List<ParamItemResponse> Items { get; set; }
    }
}
