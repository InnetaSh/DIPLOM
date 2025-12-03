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

        [HttpGet("get-by-district/{id}")]
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


        [HttpGet("get-by-city/{id}")]
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


        [HttpGet("get-cities/{countryId}")]
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


        [HttpGet("get-all-cities-with-country")]
        public async Task<ActionResult<IEnumerable<CityResponse>>> GetAllCitiesWithCountry()
        {
            var countries = await _service.GetEntitiesAsync();

            var cities = countries
                .SelectMany(country => country.Regions, (country, region) => new { country, region })
                .SelectMany(cr => cr.region.Cities, (cr, city) => new
                {
                    city,
                    region = cr.region,
                    country = cr.country
                })
                .Select(x => new CityResponse
                {
                    id = x.city.id,
                    Title = x.city.Title,
                    RegionId = x.region.id,
                    //RegionTitle = x.region.Title,       // добавляем название региона
                   // CountryId = x.country.id,
                   // CountryTitle = x.country.Title,     // добавляем название страны
                    Latitude = x.city.Latitude,
                    Longitude = x.city.Longitude
                })
                .ToList();

            if (!cities.Any())
                return NotFound(new { message = "No cities found" });

            return Ok(cities);
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