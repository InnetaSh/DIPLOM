
using Globals.Abstractions;
using OfferApiService.Models.RentObject;

namespace OfferApiService.Services.Interfaces.RentObject
{
        public interface IRentObjService : IServiceBase<RentObj>
        {
            Task<List<RentObj>> GetByCityAsync(string cityName);
        }
}
