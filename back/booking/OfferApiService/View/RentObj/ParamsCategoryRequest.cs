using Globals.Controllers;
using OfferApiService.Models.RentObjModel;
using System.Linq;

namespace OfferApiService.View.RentObj
{
    public class ParamsCategoryRequest : IBaseRequest
    {
        public int id { get; set; }
        public List<ParamItemRequest> Items { get; set; } = new();

        public static ParamsCategory MapToModel(ParamsCategoryRequest request)
        {
            return new ParamsCategory
            {
                id = request.id,
                Items = request.Items?
                    .Select(ParamItemRequest.MapToModel)
                    .ToList() ?? new List<ParamItem>()
            };
        }
    }
}
