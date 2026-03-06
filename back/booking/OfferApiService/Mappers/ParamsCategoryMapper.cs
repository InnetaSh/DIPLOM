using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;
using OfferContracts;
using OfferContracts.RentObj;

namespace OfferApiService.Mappers
{
    public static class ParamsCategoryMapper
    {
        public static ParamsCategory MapToModel( ParamsCategoryRequest request)
        {
            return new ParamsCategory
            {
                id = request.id,
                IsFilterable = request.IsFilterable,
                Items = request.Items?
                     .Select(x => ParamItemMapper.MapToModel(x))
                    ?.ToList() ?? new List<ParamItem>()
            };
        }


        public static ParamsCategoryResponse MapToResponse( ParamsCategory model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            return new ParamsCategoryResponse
            {
                id = model.id,
                IsFilterable = model.IsFilterable,
                Items = model.Items?.Select(x => ParamItemMapper.MapToResponse(x))?.ToList()
                        ?? new List<ParamItemResponse>()
            };
        }
    }
}
