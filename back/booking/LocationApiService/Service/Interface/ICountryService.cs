
using Globals.Abstractions;
using LocationApiService.Models;

namespace LocationApiService.Service.Interfaces
{
    public interface ICountryService : IServiceBase<Country>
    {
        Task<List<Country>> GetEntitiesWithCodeAsync(params string[] includeProperties);
    }
}
