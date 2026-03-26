using Globals.Sevices;
using TranslationApiService.Models;
using TranslationApiService.Models.Offer;
using TranslationApiService.Service.Offer.Interface;


namespace TranslationApiService.Service.Offer
{
    public class OfferService : TranslationServiceBase<OfferTranslation, TranslationContext>, IOfferService
    {
        public OfferService(TranslationContext context, ILogger<OfferService> logger) : base(context, logger)
        {
        }
    }
}
