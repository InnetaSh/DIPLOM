using Globals.Abstractions;
using Globals.Controllers;
using LocationApiService.Models;
using LocationApiService.Service.Interfaces;
using LocationApiService.View;
using Microsoft.AspNetCore.Mvc;

namespace LocationApiService.Controllers
{
    public class RegionController : EntityControllerBase<Region, RegionResponse, RegionRequest>
    {
        private readonly string _baseUrl;
        public RegionController(
            IRegionService regionService, 
            IRabbitMqService mqService, 
            IConfiguration configuration)
            : base(regionService, mqService)
        {
            //_baseUrl = configuration["AppSettings:BaseUrl"];
            _baseUrl = $"{configuration["HostUrl"] ?? "http://localhost"}:5001";
        }


        protected override Region MapToModel(RegionRequest request)
        {
            return RegionRequest.MapToModel(request);
        }


        protected override RegionResponse MapToResponse(Region model)
        {
            return RegionResponse.MapToResponse(model, _baseUrl);

        }
    }
}