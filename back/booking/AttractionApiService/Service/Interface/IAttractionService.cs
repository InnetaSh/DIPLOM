using AttractionApiService.Models;
using AttractionContracts;
using Globals.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AttractionApiService.Service.Interfaces
{
    public interface IAttractionService : IServiceBaseNew<Attraction>
    {
        Task<List<AttractionResponse>> GetAttractionsByDistanceAsync(decimal latitude, decimal longitude, decimal distance);
        Task<List<Attraction>> GetAttractionByCityId([FromQuery] int cityId);
        Task<List<Attraction>> GetAttractionById([FromQuery] int id);
        void AddImage(AttractionImage img);
        AttractionImage DelImage(int imageId);
    }
}
