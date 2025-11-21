using Globals.Abstractions;
using OfferApiService.Models;
using OfferApiService.Models.View;

namespace OfferApiService.Service.Interface
{
    public interface IOfferService : IServiceBase<Offer>
    {
        Task<List<OfferResponse>> GetMainAvailableOffers(string cityTitle, DateTime startDate, DateTime endDate, int bedroomsCount);
    }
}
