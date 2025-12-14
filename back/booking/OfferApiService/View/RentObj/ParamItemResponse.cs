using Globals.Controllers;
using OfferApiService.Models.RentObjModel;
using OfferApiService.Models.RentObjModel.Enums;

namespace OfferApiService.View.RentObj
{
    public class ParamItemResponse : IBaseResponse
    {
        public int id { get; set; }
        public string? Title { get; set; }
        public int CategoryId { get; set; }
        public ParamValueType ValueType { get; set; } = ParamValueType.Boolean;

        public static ParamItemResponse MapToResponse(ParamItem model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            return new ParamItemResponse
            {
                id = model.id,
                ValueType = model.ValueType,
                CategoryId = model.CategoryId
            };
        }
    }
}
