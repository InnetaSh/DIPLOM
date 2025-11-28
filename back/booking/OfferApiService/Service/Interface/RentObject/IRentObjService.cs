
using Globals.Abstractions;
using OfferApiService.Models.RentObject;

namespace OfferApiService.Services.Interfaces.RentObject
{
        public interface IRentObjService : IServiceBase<Models.RentObject.RentObject>
        {
            Task<List<Models.RentObject.RentObject>> GetByCityAsync(string cityName);
        }
}
