using Globals.Abstractions;
using Globals.EventBus;
using Globals.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Globals.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntityControllerBase<TModel, TResponse, TRequest> : ControllerBase
     where TModel : EntityBase, new()
     where TResponse : IBaseResponse , new()
     where TRequest : IBaseRequest, new()
    {
        protected readonly IServiceBase<TModel> _service;
        private readonly IRabbitMqService _mqService;

        public EntityControllerBase(IServiceBase<TModel> service, IRabbitMqService mqService)
        {
            _service = service;
            _mqService = mqService;
        }

        [HttpGet("get-all")]
        public virtual async Task<ActionResult<IEnumerable<TResponse>>> GetAll()
        {
            var items = await _service.GetEntitiesAsync();
            if (items == null || !items.Any())
                return NotFound(new { message = "No items found" });

            var responseList = items.Select(item => MapToResponse(item)).ToList();
            return Ok(responseList);
        }

        [HttpGet("get/{id}")]
        public virtual async Task<ActionResult<TResponse>> GetById(int id)
        {
            var item = await _service.GetEntityAsync(id);
            if (item == null)
                return NotFound(new { message = "Item not found" });

            return Ok(MapToResponse(item));
        }

        [HttpPost("create")]
        public virtual async Task<ActionResult<TResponse>> Create([FromBody] TRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = MapToModel(request);
            var result = await _service.AddEntityAsync(model);

            if (!result)
                return StatusCode(500, new { message = "Error creating item" });

            PublishMqEvent("Created", model);

            return CreatedAtAction(nameof(GetById), new { id = model.id }, MapToResponse(model));
        }

        [HttpPut("update/{id}")]
        public virtual async Task<IActionResult> Update(int id, [FromBody] TRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = MapToModel(request);
            if (GetModelId(model) != id)
                return BadRequest(new { message = "ID mismatch" });

            var exists = await _service.ExistsEntityAsync(id);
            if (!exists)
                return NotFound(new { message = "Item not found" });

            var success = await _service.UpdateEntityAsync(model);
            if (!success)
                return StatusCode(500, new { message = "Error updating item" });

            PublishMqEvent("Updated", model);

            return NoContent();
        }

        [HttpDelete("del/{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var exists = await _service.ExistsEntityAsync(id);
            if (!exists)
                return NotFound(new { message = "Item not found" });

            var success = await _service.DelEntityAsync(id);
            if (!success)
                return StatusCode(500, new { message = "Error deleting item" });

            PublishMqEvent("Deleted", new { id });

            return NoContent();
        }

        protected virtual void PublishMqEvent(string action, object data)
        {
            //string json = JsonSerializer.Serialize(data);

            //var message = new RabbitMQMessageBase(
            //    sender: GetType().Name,
            //    eventType: action,
            //    data: json
            //);

            //_mqService.SendMessage(message);
        }

        protected virtual TModel MapToModel(TRequest request) => new TModel();
        protected virtual TResponse MapToResponse(TModel model) => new TResponse();
        protected virtual int GetModelId(TModel model) => (int)model.GetType().GetProperty("id").GetValue(model);
    }

    public interface IBaseRequest { }

    public interface IBaseResponse { }

}
