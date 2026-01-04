using AttractionApiService.Models;
using AttractionApiService.View;
using Globals.Abstractions;

namespace AttractionApiService.Service.Interfaces
{
    public interface IAttractionService : IServiceBase<Attraction>
    {
        Task<List<AttractionResponse>> GetAttractionsByDistanceAsync(decimal latitude, decimal longitude, decimal distance);
    }
}
