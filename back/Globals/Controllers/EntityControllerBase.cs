using Globals.Abstractions;
using Globals.EventBus;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Globals.Controllers
{
    public class EntityControllerBase : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IRabbitMqService _mqService;

        public EntityControllerBase(IHttpClientFactory clientFactory, IRabbitMqService mqService)
        {
            _clientFactory = clientFactory;
            _mqService = mqService;
        }

        public virtual async Task<IActionResult> Get<T>(string serviceName, string route, T msg) where T : RabbitMQMessageBase
        {
            var client = _clientFactory.CreateClient(serviceName);
            var response = await client.GetAsync(route);

            if (response.IsSuccessStatusCode)
            {
                _mqService.SendMessage(msg);
                var result = await response.Content.ReadFromJsonAsync<object>();
                return Ok(result);
            }

            return StatusCode((int)response.StatusCode);
        }

        public virtual async Task<IActionResult> Post<T, V>(string serviceName, string route, T request, V msg) where T: RequestBase where V : RabbitMQMessageBase
        {
            var client = _clientFactory.CreateClient(serviceName);
            var response = await client.PostAsJsonAsync(route, request);

            if (response.IsSuccessStatusCode)
            {
                _mqService.SendMessage(msg);
                var result = await response.Content.ReadFromJsonAsync<object>();
                return Ok(result);
            }

            return StatusCode((int)response.StatusCode);
        }

        //public virtual async Task<IActionResult> Del<T, V>(string serviceName, string route, T request, V msg) where T : RequestBase where V : RabbitMQMessageBase
        //{
        //    var client = _clientFactory.CreateClient(serviceName);
        //    //var response = await client.PutAsJsonAsync(route, request);
        //    var response = await client.DeleteFromJsonAsync(route, request);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        _mqService.SendMessage(msg);
        //        var result = await response.Content.ReadFromJsonAsync<object>();
        //        return Ok(result);
        //    }

        //    return StatusCode((int)response.StatusCode);
        //}
    }
}
