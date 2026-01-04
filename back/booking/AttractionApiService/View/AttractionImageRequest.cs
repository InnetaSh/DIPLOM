using AttractionApiService.Models;
using Globals.Controllers;

namespace AttractionApiService.View
{
    public class AttractionImageRequest : IBaseRequest
    {
        public int id { get; set; }
        public string Url { get; set; }
        public int AttractionId { get; set; }

        public static AttractionImage MapToModel(AttractionImageRequest request)
        {
            return new AttractionImage
            {
                id = request.id,
                Url = request.Url,
                AttractionId = request.AttractionId

            };
        }
    }
}
