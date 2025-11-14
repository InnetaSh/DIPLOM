//using Microsoft.AspNetCore.Identity.Data;
//using Microsoft.AspNetCore.Mvc;
//using RentObjectApiService.Models;
//using RentObjectApiService.Services;
//using RentObjectApiService.Services.Interfaces;
//using RentObjectApiService.View;
//using System.Diagnostics.Metrics;

//namespace RentObjectApiService.Controllers
//{

//    [ApiController]
//    [Route("api/[controller]")]
//    public class CityController : ControllerBase
//    {
//        private readonly ICityService _cityService;

//        public CityController(ICityService cityService)
//        {
//            _cityService = cityService;
//        }

//        // GET: api/cities
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<CityResponse>>> GetAllCity()
//        {
//            var items = await _cityService.GetEntitiesAsync();
//            if (items == null || !items.Any())
//                return NotFound(new { message = "No cities found" });

//            var responseList = items.Select(item => new CityResponse
//            {
//                id = item.id,
//                Title = item.Title,
//                CountryId = item.CountryId,
//                Country = item.Country,
//                RentObjs = item.RentObjs?.Select(ro => new RentObjResponse
//                {
//                    Id = ro.id,
//                    Title = ro.Title
//                }).ToList()
//            }).ToList();

//            return Ok(responseList);
//        }



//        // GET: api/city/{id}
//        [HttpGet("{id}")]
//        public async Task<ActionResult<CityResponse>> GetCityById(GetByIdRequest request)
//        {
//            var item = await _cityService.GetEntityAsync(request.id);
//            if (item == null)
//                return NotFound(new { message = "City not found" });

//            var response = new CityResponse
//            {
//                id = item.id,
//                Title = item.Title,
//                CountryId = item.CountryId,
//                Country = item.Country,
//                RentObjs = item.RentObjs?.Select(ro => new RentObjResponse
//                {
//                    Id = ro.id,
//                    Title = ro.Title
//                }).ToList()
//            };

//            return Ok(response);
//        }

//        // POST: api/city
//        [HttpPost]
//        public async Task<ActionResult<CityResponse>> CreateCity([FromBody] CityRequest request)
//        {
//            if (!ModelState.IsValid)
//                return BadRequest(ModelState);

//            var cityExists = await _cityService.ExistsEntityAsync(request.id);
//            if (cityExists)
//                return NotFound(new { message = "City alredy exist" });

//            var city = new City
//            {
//                id = request.id,
//                Title = request.Title,
//                CountryId = request.CountryId,
//                Country = request.Country,
//                RentObjs = request.RentObjs
//            };

//            var result = await _cityService.AddEntityAsync(city);

//            if (!result)
//                return StatusCode(500, new { message = "Error creating user" });
//            var response = new CityResponse
//            {
//                id = request.id,
//                Title = request.Title,
//                CountryId = request.CountryId,
//                Country = request.Country,
//                RentObjs = request.RentObjs?.Select(ro => new RentObjResponse
//                {
//                    Id = ro.id,
//                    Title = ro.Title
//                }).ToList()
//            };

//            return CreatedAtAction(nameof(GetCityById), new { id = city.id }, response);

//        }


//        // PUT: api/city/{id}
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateCity(int id, [FromBody] CityRequest request)
//        {
//            if (id != request.id)
//                return BadRequest(new { message = "ID in URL does not match ID in body" });

//            var cityEntity = await _cityService.GetEntityAsync(id);
//            if (cityEntity == null)
//                return NotFound(new { message = "City not found" });

   

//            var success = await _cityService.UpdateEntityAsync(cityEntity);
//            if (!success)
//                return StatusCode(500, new { message = "Error updating city" });

//            return NoContent();
//        }


//        // DELETE: api/city/{id}
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteUser(DeleteRequest deleteRequest)
//        {
//            var existingMaster = await _cityService.ExistsEntityAsync(deleteRequest.id);
//            if (existingMaster == null)
//                return NotFound(new { message = "City not found" });


//            var success = await _cityService.DelEntityAsync(deleteRequest.id);
//            if (!success)
//                return StatusCode(500, new { message = "Error deleting master" });

//            return NoContent();
//        }
//    }
//}
