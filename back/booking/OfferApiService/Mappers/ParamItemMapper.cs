using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;
using OfferContracts;
using OfferContracts.RentObj;

namespace OfferApiService.Mappers
{
    public static class ParamItemMapper
    {
        public static ParamItem MapToModel( ParamItemRequest request)
        {
            return new ParamItem
            {
                id = request.id,
                CategoryId = request.CategoryId,
                ValueType = request.ValueType,
                IsFilterable = request.IsFilterable,
                IconName = request.IconName,
            };
        }
        public static ParamItemResponse MapToResponse(  ParamItem model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            return new ParamItemResponse
            {
                id = model.id,
                ValueType = model.ValueType,
                CategoryId = model.CategoryId,
                IsFilterable = model.IsFilterable,
                IconName = model.IconName,
            };
        }

    }
}
