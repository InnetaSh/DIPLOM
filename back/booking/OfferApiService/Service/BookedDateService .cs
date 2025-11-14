using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using OfferApiService.Models;
using OfferApiService.Service.Interface;
using OfferApiService.View;


namespace OfferApiService.Services
{
    public class BookedDateService : TableServiceBase<BookedDate, OfferContext>, IBookedDateService
    {

    }
}


