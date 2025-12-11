using Globals.Controllers;
using OfferApiService.Models.RentObjModel;
using System.Linq;

namespace OfferApiService.View.RentObj
{
    public class ParamsCategoryResponse : IBaseResponse
    {
        public int id { get; set; }
        public string? Title { get; set; }
        public List<ParamItemResponse> Items { get; set; } = new();

        public static ParamsCategoryResponse MapToResponse(ParamsCategory model)
        {
            return new ParamsCategoryResponse
            {
                id = model.id,
                Items = model.Items?.Select(ParamItemResponse.MapToResponse).ToList()
                        ?? new List<ParamItemResponse>()
            };
        }
    }
}
