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

        public int RoomCount { get; set; }
        public int LivingRoomCount { get; set; }
        public int BathroomCount { get; set; }
        public double Area { get; set; }

        public int BedsCount { get; set; }
        public bool HasBabyCrib { get; set; }

        // Одно основное фото (как на Booking)
        public string? MainImageUrl { get; set; }


        public static RentObjShortResponse MapToShortResponse(RentObject model, string baseUrl)
        {
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
                    BedsCount = model.BedsCount,
                    HasBabyCrib = model.HasBabyCrib,


                    MainImageUrl = firstImage != null
                        ? $"{baseUrl}/images/rentobj/{model.id}/{Path.GetFileName(firstImage.Url)}"
                        : null,


            };
        }
    }
}
