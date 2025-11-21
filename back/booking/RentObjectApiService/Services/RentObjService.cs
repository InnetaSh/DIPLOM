using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using RentObjectApiService.Models;
using RentObjectApiService.Services.Interfaces;
using RentObjectApiService.Services.Interfaces.RentObjectApiService.Services.Interfaces;


namespace RentObjectApiService.Services
{
    public class RentObjService : TableServiceBase<RentObj, RentObjectContext>, IRentObjService
    {
        public async Task<List<RentObj>> GetByCityAsync(string cityName)
        {
            using var db = new RentObjectContext();

            var apartments = await db.RentObjects
                .Include(r => r.City)
                .Include(r => r.Images)
                .Include(r => r.ParamCategories)
                .Where(r => r.City.Title.ToLower() == cityName.ToLower())
                .ToListAsync();

            return apartments; 
        }

    }
}
