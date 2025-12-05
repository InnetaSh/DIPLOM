using Globals.Abstractions;
using Globals.Controllers;
using LocationApiService.Models;
using LocationApiService.Service.Interfaces;
using LocationApiService.View;
using Microsoft.AspNetCore.Mvc;

namespace LocationApiService.Controllers
{
    public class CountryController : EntityControllerBase<Country, CountryResponse, CountryRequest>
    {
        public CountryController(ICountryService countryService, IRabbitMqService mqService)
            : base(countryService, mqService)
        {
        }

        [HttpGet("get-countries-by-district/{id}")]
        public async Task<ActionResult<CountryResponse>> GetByDistrictId(int id)
        {
            var countries = await _service.GetEntitiesAsync();
            //var country = 
            //    countries.FirstOrDefault(x => x.id == 
            //    x.Regions?.FirstOrDefault(r => r.id == 
            //    r.Cities?.FirstOrDefault(c => c.id == 
            //    c.Districts?.FirstOrDefault(d => d.id == id)
            //    ?.CityId)
            //    ?.RegionId)
            //    ?.CountryId);

            var country = countries
                .FirstOrDefault(c => c.Regions
                    .SelectMany(r => r.Cities)
                    .SelectMany(ci => ci.Districts)
                    .Any(d => d.id == id)
                );


            if (country == null)
                return NotFound(new { message = "country not found" });

            return Ok(MapToResponse(country));
        }


        [HttpGet("get-countries-by-city/{id}")]
        public async Task<ActionResult<CountryResponse>> GetByCityId(int id)
        {
            var countries = await _service.GetEntitiesAsync();
            var country = countries
                .FirstOrDefault(c => c.Regions
                    .SelectMany(r => r.Cities)
                    .Any(ci => ci.id == id));

            if (country == null)
                return NotFound(new { message = "country not found" });

            return Ok(MapToResponse(country));
        }


        [HttpGet("get-cities-from-country/{countryId}")]
        public async Task<ActionResult<IEnumerable<CityResponse>>> GetCitiesByCountryId(int countryId)
        {
            var countries = await _service.GetEntitiesAsync();
            var country = countries.FirstOrDefault(c => c.id == countryId);

            if (country == null)
                return NotFound(new { message = "country not found" });

            var cities = country.Regions
                .SelectMany(r => r.Cities)
                .Select(c => new CityResponse
                {
                    id = c.id,
                    Title = c.Title,
                    RegionId = c.RegionId,
                    Latitude = c.Latitude,
                    Longitude = c.Longitude,
                    Districts = c.Districts?.Select(d => new DistrictResponse
                    {
                        id = d.id,
                        Title = d.Title,
                        CityId = c.id,
                        Latitude = d.Latitude,
                        Longitude = d.Longitude,
                        Attractions = d.Attractions?.Select(a => new AttractionResponse
                        {
                            id = a.id,
                            Title = a.Title,
                            DistrictId = d.id,
                            Country = country.Title,
                            Latitude = a.Latitude,
                            Longitude = a.Longitude
                        }).ToList() ?? new List<AttractionResponse>()
                    }).ToList() ?? new List<DistrictResponse>()
                }).ToList();

            return Ok(cities);
        }

        [HttpGet("get-all-cities")]
        public async Task<ActionResult<IEnumerable<CityResponse>>> GetAllCities()
        {
            var countries = await _service.GetEntitiesAsync();

            var cities = countries
                .SelectMany(c => c.Regions)
                .SelectMany(r => r.Cities)
                .Select(c => new CityResponse
                {
                    id = c.id,
                    Title = c.Title,
                    RegionId = c.RegionId,
                    Latitude = c.Latitude,
                    Longitude = c.Longitude
                })
                .ToList();

            if (!cities.Any())
                return NotFound(new { message = "No cities found" });

            return Ok(cities);
        }



        [HttpPost("get-location-titles")]
        public async Task<ActionResult<LocationTitleResponse>> GetLocationTitles(
            [FromBody] LocationTitleRequest request)
        {
            var countries = await _service.GetEntitiesAsync();

           
            var country = countries.FirstOrDefault(c =>
                c.id == request.CountryId
                || c.Regions.Any(r =>
                    r.id == request.RegionId
                    || r.Cities.Any(ci =>
                        ci.id == request.CityId
                        || ci.Districts.Any(d => d.id == request.DistrictId)
                    )
                )
            );

            if (country == null)
                return NotFound(new { message = "Location not found in any country" });

            var region = country.Regions.FirstOrDefault(r => r.id == request.RegionId);

            var city = region?.Cities.FirstOrDefault(c => c.id == request.CityId)
                       ?? country.Regions.SelectMany(r => r.Cities)
                                         .FirstOrDefault(c => c.id == request.CityId);

            var district = city?.Districts.FirstOrDefault(d => d.id == request.DistrictId)
                           ?? country.Regions.SelectMany(r => r.Cities)
                                             .SelectMany(c => c.Districts)
                                             .FirstOrDefault(d => d.id == request.DistrictId);

   
            return Ok(new LocationTitleResponse
            {
                CountryTitle = country.Title,
                RegionTitle = region?.Title,
                CityTitle = city?.Title,
                DistrictTitle = district?.Title
            });
        }



        [HttpGet("get-country-title/{countryId}")]
        public async Task<ActionResult<string>> GetCountryTitle(int countryId)
        {
            var countries = await _service.GetEntitiesAsync();
            var country = countries.FirstOrDefault(c => c.id == countryId);

            if (country == null)
                return NotFound(new { message = "Country not found" });

            return Ok(country.Title);
        }

        [HttpGet("get-region-title/{regionId}")]
        public async Task<ActionResult<string>> GetRegionTitle(int regionId)
        {
            var countries = await _service.GetEntitiesAsync();
            var region = countries
                .SelectMany(c => c.Regions)
                .FirstOrDefault(r => r.id == regionId);

            if (region == null)
                return NotFound(new { message = "Region not found" });

            return Ok(region.Title);
        }

        [HttpGet("get-city-title/{cityId}")]
        public async Task<ActionResult<string>> GetCityTitle(int cityId)
        {
            var countries = await _service.GetEntitiesAsync();
            var city = countries
                .SelectMany(c => c.Regions)
                .SelectMany(r => r.Cities)
                .FirstOrDefault(c => c.id == cityId);

            if (city == null)
                return NotFound(new { message = "City not found" });

            return Ok(city.Title);
        }

        [HttpGet("get-district-title/{districtId}")]
        public async Task<ActionResult<string>> GetDistrictTitle(int districtId)
        {
            var countries = await _service.GetEntitiesAsync();
            var district = countries
                .SelectMany(c => c.Regions)
                .SelectMany(r => r.Cities)
                .SelectMany(ci => ci.Districts)
                .FirstOrDefault(d => d.id == districtId);

            if (district == null)
                return NotFound(new { message = "District not found" });

            return Ok(district.Title);
        }



        protected override Country MapToModel(CountryRequest request)
        {
            return new Country
            {
                id = request.id,
                Title = request.Title,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                Regions = request.Regions?.Select(r => new Region
                {
                    id = r.id,
                    Title = r.Title,
                    CountryId = request.id,
                    Latitude = r.Latitude,
                    Longitude = r.Longitude,
                    Cities = r.Cities?.Select(c => new City
                    {
                        id = c.id,
                        Title = c.Title,
                        RegionId = r.id,
                        Latitude = c.Latitude,
                        Longitude = c.Longitude,
                        Districts = c.Districts?.Select(d => new District
                        {
                            id = d.id,
                            Title = d.Title,
                            CityId = c.id,
                            Latitude = d.Latitude,
                            Longitude = d.Longitude,
                            Attractions = d.Attractions?.Select(a => new Attraction
                            {
                                id = a.id,
                                Title = a.Title,
                                DistrictId = d.id,
                                Latitude = a.Latitude,
                                Longitude = a.Longitude
                            }).ToList() ?? new List<Attraction>()
                        }).ToList() ?? new List<District>()

                    }).ToList() ?? new List<City>()
                }).ToList() ?? new List<Region>()
            };
        }




        protected override CountryResponse MapToResponse(Country model)
        {
            return new CountryResponse
            {
                id = model.id,
                Title = model.Title,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Regions = model.Regions?.Select(r => new RegionResponse
                {
                    id = r.id,
                    Title = r.Title,
                    Latitude = r.Latitude,
                    Longitude = r.Longitude,
                    Cities = r.Cities?.Select(c => new CityResponse
                    {
                        id = c.id,
                        Title = c.Title,
                        RegionId = r.id,
                        Latitude = c.Latitude,
                        Longitude = c.Longitude,
                        Districts = c.Districts?.Select(d => new DistrictResponse
                        {
                            id = d.id,
                            Title = d.Title,
                            CityId = c.id,
                            Latitude = d.Latitude,
                            Longitude = d.Longitude,
                            Attractions = d.Attractions?.Select(a => new AttractionResponse
                            {
                                id = a.id,
                                Title = a.Title,
                                DistrictId = model.id,
                                Country = model.Title,
                                Latitude = a.Latitude,
                                Longitude = a.Longitude
                            }).ToList() ?? new List<AttractionResponse>()
                        }).ToList() ?? new List<DistrictResponse>()
                    }).ToList() ?? new List<CityResponse>()
                }).ToList() ?? new List<RegionResponse>()
            };
        }

    }
}