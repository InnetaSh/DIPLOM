

using Globals.Controllers;
using OfferApiService.Models.RentObject;

namespace OfferApiService.View.RentObject
{
    public class ParamsCategoryRequest : IBaseRequest
    {
        public int id { get; set; }
        public string Title { get; set; }
        public List<ParamItemRequest> Items { get; set; }
    }
}
