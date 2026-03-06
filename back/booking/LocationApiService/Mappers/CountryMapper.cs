using LocationApiService.Models;
using LocationContracts;

namespace LocationApiService.Mappers
{
    public static class CountryMapper
    {
        public static Country MapToModel( CountryRequest request)
        {
            return new Country
            {
                id = request.id,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                CountryCode = request.CountryCode,

                Regions = request.Regions?
                     .Select(x => RegionMapper.MapToModel(x))
                    ?.ToList() ?? new List<Region>()
            };
        }

        public static CountryResponse MapToResponse( Country model, string baseUrl)
        {
            return new CountryResponse
            {
                id = model.id,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                CountryCode = model.CountryCode,

                Regions = model.Regions?
                    .Select(x => RegionMapper.MapToResponse(x,baseUrl))
                    ?.ToList() ?? new List<RegionResponse>()
            };
        }
    }
}
