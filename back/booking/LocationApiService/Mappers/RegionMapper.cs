using LocationApiService.Models;
using LocationContracts;

namespace LocationApiService.Mappers
{
    public static class RegionMapper
    {
        public static Region MapToModel( RegionRequest request)
        {
            return new Region
            {
                id = request.id,
                CountryId = request.CountryId,
                Latitude = request.Latitude,
                Longitude = request.Longitude,

                Cities = request.Cities?
                    .Select(x => CityMapper.MapToModel(x))
                    ?.ToList() ?? new List<City>()
            };
        }

        public static RegionResponse MapToResponse( Region model, string baseUrl)
        {
            return new RegionResponse
            {
                id = model.id,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                CountryId = model.CountryId,

                Cities = model.Cities?
                    .Select(x => CityMapper.MapToResponse(x,baseUrl))
                    .ToList() ?? new List<CityResponse>()
            };
        }
    }
}
