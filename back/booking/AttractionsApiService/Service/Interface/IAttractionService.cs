using AttractionsApiService.Models;
using AttractionsApiService.View;
using Globals.Abstractions;

namespace AttractionsApiService.Service.Interfaces
{
    public interface IAttractionService : IServiceBase<Attraction>
    {

        Task<List<AttractionResponse>> GetAttractionsByDistanceAsync(decimal latitude, decimal longitude, decimal distance);
    }
}
