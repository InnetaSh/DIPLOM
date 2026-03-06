using AttractionApiService.Models;
using AttractionContracts;

namespace AttractionApiService.Mappers
{
    public static class AttractionImageMapper
    {
        public static AttractionImage MapToModel(AttractionImageRequest request)
        {
            return new AttractionImage
            {
                id = request.id,
                Url = request.Url,
                AttractionId = request.AttractionId
            };
        }

        public static AttractionImageResponse MapToResponse(AttractionImage model, string baseUrl)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            return new AttractionImageResponse
            {
                id = model.id,
                Url = $"{baseUrl}{model.Url}",
                AttractionId = model.AttractionId
            };
        }
    }
}
