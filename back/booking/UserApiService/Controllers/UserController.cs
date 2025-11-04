using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using UserApiService.Models;
using UserApiService.Services.Interfaces;

namespace UserApiService.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService masterService)
        {
            _userService = masterService;
        }

        // GET: api/masters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllMasters()
        {
            var items = await _userService.GetEntitiesAsync();
            return Ok(items);
        }

        // GET: api/masters/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetMasterById(int id)
        {
            var item = await _userService.GetEntityAsync(id);

            if (item == null)
                return NotFound(new { message = "Master not found" });

            return Ok(item);
        }

        // POST: api/masters
        [HttpPost]
        public async Task<ActionResult<User>> CreateMaster([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var masterExists = await _userService.ExistsEntityAsync(user.id);
            if (masterExists)
                return NotFound(new { message = "Master alredy exist" });

            var result = await _userService.AddEntityAsync(user);

            if(result)
                return CreatedAtAction(nameof(GetMasterById), new { id = user.id }, user);
            else 
                return StatusCode(500, new { message = "Error creating master" });

        }


        //// PUT: api/masters/{id}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateMaster(int id, [FromBody] Master updatedMaster)
        //{
        //    if (id != updatedMaster.Id)
        //        return BadRequest(new { message = "ID in URL does not match ID in body" });

        //    var existingMaster = await _masterService.ExistsAsync(updatedMaster.Id);
        //    if (existingMaster == null)
        //        return NotFound(new { message = "Master not found" });

        //    var success = await _masterService.UpdateAsync(id, updatedMaster);
        //    if (!success)
        //        return StatusCode(500, new { message = "Error updating portfolio item" });

        //    return NoContent();
        //}





        //// DELETE: api/masters/{id}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMaster(int id)
        //{
        //    var existingMaster = await _masterService.ExistsAsync(id);
        //    if (existingMaster == null)
        //        return NotFound(new { message = "Master not found" });


        //    var success = await _masterService.DeleteAsync(id);
        //    if (!success)
        //        return StatusCode(500, new { message = "Error deleting master" });

        //    return NoContent();
        //}
    }
}
