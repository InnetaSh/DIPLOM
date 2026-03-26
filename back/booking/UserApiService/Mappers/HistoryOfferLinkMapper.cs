using UserApiService.Models;
using UserContracts;
using UserContracts.Enums;

namespace UserApiService.Mappers
{
    public static class HistoryOfferLinkMapper
    {
        
        public static HistoryOfferLinkResponse MapToResponse(HistoryOfferLink model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return new HistoryOfferLinkResponse
            {
                Id = model.Id,
                ClientId = model.ClientId,
                OfferId = model.OfferId,
                IsFavorites = model.IsFavorites,
               
            };
        }
    }
}
