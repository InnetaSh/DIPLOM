using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using OfferApiService.Models;
using OfferApiService.Models.RentObject;


namespace OfferApiService.Services.Interfaces.RentObject
{
    public class RentObjService : TableServiceBase<RentObj, OfferContext>, IRentObjService
    {
        public async Task<List<RentObj>> GetByCityAsync(string cityName)
        {
            using var db = new OfferContext();

            var apartments = await db.RentObjects
                .Include(r => r.City)
                .Include(r => r.Images)
                //.Include(r => r.ParamCategories)
                .Where(r => r.City.Title.ToLower() == cityName.ToLower())
                .ToListAsync();

            return apartments; 
        }

    }
}
