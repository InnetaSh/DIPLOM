using AttractionApiService.Models;
using Globals.Controllers;

namespace AttractionApiService.View
{
    public class AttractionImageResponse : IBaseResponse
    {
        public int id { get; set; }
        public string Url { get; set; }
        public int AttractionId { get; set; }

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
