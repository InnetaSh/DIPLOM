using Microsoft.Extensions.Localization;
using OfferApiService.Models.RentObjModel;
using OfferApiService.Models.View;

namespace OfferApiService.View.RentObj
{
    public class RentObjShortResponse
    {
        public int id { get; set; }
      
        public double Latitude { get; set; } // для карты -если надо
        public double Longitude { get; set; }
        public int CityId { get; set; }

        public int RoomCount { get; set; }              //Количество комнат
        public int LivingRoomCount { get; set; }         // Количество гостиных
        public int BathroomCount { get; set; }          //Количество ванных комнат 
        public double Area { get; set; } = 0;           //Площадь объекта (кв. м)

        public int TotalBedsCount { get; set; }       //Общее количество спальных мест
        public int SingleBedsCount { get; set; }      // Количество односпальных кроватей
        public int DoubleBedsCount { get; set; }      // Количество двуспальных кроватей
        public bool HasBabyCrib { get; set; }         // Детская кроватка


        // Одно основное фото (как на Booking)
        public string? MainImageUrl { get; set; }
        public List<RentObjParamValueResponse>? ParamValues { get; set; } = new();

        public static RentObjShortResponse MapToShortResponse(RentObject model, string baseUrl)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            var firstImage = model.Images?.FirstOrDefault();

            return  new RentObjShortResponse
                {
                    id = model.id,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    CityId = model.CityId,
                    RoomCount = model.RoomCount,
                    LivingRoomCount = model.LivingRoomCount,
                    Area = model.Area,
                    TotalBedsCount = model.TotalBedsCount,
                    SingleBedsCount = model.SingleBedsCount,
                    DoubleBedsCount = model.DoubleBedsCount,
                    HasBabyCrib = model.HasBabyCrib,


                    MainImageUrl = firstImage != null
                        ? $"{baseUrl}/images/rentobj/{model.id}/{Path.GetFileName(firstImage.Url)}"
                        : null,
                    ParamValues = model.ParamValues?
                        .Select(RentObjParamValueResponse.MapToResponse)
                        .ToList() ?? new List<RentObjParamValueResponse>(),

            };
        }
    }
}
