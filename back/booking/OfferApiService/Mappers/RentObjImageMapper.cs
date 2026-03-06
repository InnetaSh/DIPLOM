using OfferApiService.Models;
using OfferApiService.Models.RentObjModel;
using OfferContracts;
using OfferContracts.RentObj;

namespace OfferApiService.Mappers
{
    public static class RentObjImageMapper
    {
        public static RentObjImage MapToModel( RentObjImageRequest request)
        {
            return new RentObjImage
            {
                id = request.id,
                Url = request.Url,
                RentObjId = request.RentObjId

            };
        }

        public static RentObjImageResponse MapToResponse( RentObjImage model, string baseUrl)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            return new RentObjImageResponse
            {
                id = model.id,
                Url = $"{baseUrl}/images/rentobj/{model.RentObjId}/{Path.GetFileName(model.Url)}",
                RentObjId = model.RentObjId
            };
        }

    }
}
