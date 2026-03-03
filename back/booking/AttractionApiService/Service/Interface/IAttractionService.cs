using AttractionApiService.Models;
using AttractionApiService.View;
using Globals.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AttractionApiService.Service.Interfaces
{
    public interface IAttractionService : IServiceBase<Attraction>
    {
        Task<List<AttractionResponse>> GetAttractionsByDistanceAsync(decimal latitude, decimal longitude, decimal distance);
        Task<List<Attraction>> GetAttractionByCityId([FromQuery] int cityId);
        Task<List<Attraction>> GetAttractionById([FromQuery] int id);
    }
}
