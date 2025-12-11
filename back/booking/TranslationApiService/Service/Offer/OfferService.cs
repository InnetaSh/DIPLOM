using Globals.Sevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

using System.Net.Http.Json;
using TranslationApiService.Models;
using TranslationApiService.Models.Offer;
using TranslationApiService.Service.Offer.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace TranslationApiService.Service.Offer
{
    public class OfferService : TranslationServiceBase<OfferTranslation, TranslationContext>, IOfferService
    {
        
     
    }
}
