
using Globals.Abstractions;
using OfferApiService.Models.RentObjModel;

namespace OfferApiService.Services.Interfaces.RentObj
{
    public interface IRentObjService : IServiceBaseNew<RentObject>
    {
        Task<int> AddRentObjWithParamValuesAsync(RentObject rentObj);
    }
}
