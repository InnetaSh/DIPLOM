using LocationApiService.Models;
using LocationContracts;

namespace LocationApiService.Mappers
{
    public static class DistrictMapper
    {

        public static District MapToModel( DistrictRequest request)
        {
            return new District
            {
                id = request.id,
                CityId = request.CityId,

                Latitude = request.Latitude,
                Longitude = request.Longitude,

            };
        }

        public static DistrictResponse MapToResponse( District model)
        {
            return new DistrictResponse
            {
                id = model.id,
                CityId = model.CityId,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
            };
        }
    }
}
