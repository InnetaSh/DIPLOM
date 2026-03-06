using Globals.Sevices;
using TranslationApiService.Models;
using TranslationApiService.Models.Offer;
using TranslationApiService.Service.Offer.Interface;




namespace TranslationApiService.Service.Offer
{
    public class ParamItemService : TranslationServiceBase<ParamItemTranslation, TranslationContext>, IParamItemService
    {
        public ParamItemService(TranslationContext context, ILogger<ParamItemService> logger) : base(context, logger)
        {
        }
    }
}
