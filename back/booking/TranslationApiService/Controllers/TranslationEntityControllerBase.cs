using Globals.Abstractions;
using Globals.EventBus;
using Globals.Models;
using Globals.Sevices;
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
using TranslationApiService.Models;

namespace Globals.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TranslationEntityControllerBase<TModel, TResponse, TRequest> : ControllerBase
     where TModel : TranslationEntityBase, new()
     where TResponse : IBaseResponse , new()
     where TRequest : IBaseRequest, new()
    {
        protected readonly ITranslationServiceBase<TModel> _service;
        private readonly IRabbitMqService _mqService;

        public TranslationEntityControllerBase(
            ITranslationServiceBase<TModel> service,
            IRabbitMqService mqService
            )
        {
            _service = service;
            _mqService = mqService;
        }

        [HttpGet("get-all-translations/{lang}")]
        public virtual async Task<ActionResult<IEnumerable<TResponse>>> GetAll(string lang)
        {
            var items = await _service.GetEntitiesAsync(lang);
            if (items == null || !items.Any())
                return NotFound(new { message = "No items found" });

            var responseList = items.Select(item => MapToResponse(item)).ToList();
            return Ok(responseList);
        }


        [HttpGet("get-translations/{EntityId}/{lang}")]
        public virtual async Task<ActionResult<TResponse>> GetById(int EntityId, string lang)
        {
            var item = await _service.GetEntityAsync(EntityId, lang);
            if (item == null)
                return NotFound(new { message = "Item not found" });

            return Ok(MapToResponse(item));
        }


        [HttpPost("create-translations")]
        public virtual async Task<ActionResult<TResponse>> Create([FromBody] TRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = MapToModel(request);
            var result = await _service.AddEntityAsync(model);

            if (!result)
                return StatusCode(500, new { message = "Error creating item" });

            PublishMqEvent("Created", model);

            return CreatedAtAction(nameof(GetById),
                 new { EntityId = model.EntityId, lang = model.Lang },
                 MapToResponse(model)
             );
        }

        [HttpPut("update-translations/{EntityId}/{lang}")]
        public virtual async Task<IActionResult> Update(int EntityId, string lang, [FromBody] TRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var model = MapToModel(request);
            if (model.EntityId != EntityId || model.Lang != lang)
                return BadRequest(new { message = "EntityId or Lang mismatch" });


            var exists = await _service.ExistsEntityAsync(EntityId, lang);
            if (!exists)
                return NotFound(new { message = "Item not found" });

            var success = await _service.UpdateEntityAsync(model);
            if (!success)
                return StatusCode(500, new { message = "Error updating item" });

            PublishMqEvent("Updated", model);

            return NoContent();
        }



        [HttpDelete("del-translations/{EntityId}/{lang}")]
        public virtual async Task<IActionResult> Delete(int EntityId, string lang)
        {
            var exists = await _service.ExistsEntityAsync(EntityId, lang);
            if (!exists)
                return NotFound(new { message = "Item not found" });

            var success = await _service.DelEntityAsync(EntityId, lang);
            if (!success)
                return StatusCode(500, new { message = "Error deleting item" });

            PublishMqEvent("Deleted", new { EntityId, lang });

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
