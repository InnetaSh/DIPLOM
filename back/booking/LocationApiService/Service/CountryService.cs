using Globals.Sevices;
using LocationApiService.Models;
using LocationApiService.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocationApiService.Services
{
    public class CountryService : TableServiceBase<Country, LocationContext>, ICountryService
    {
        public override async Task<List<Country>> GetEntitiesAsync(params string[] includeProperties)
        {
            using (var db = (LocationContext)Activator.CreateInstance(typeof(LocationContext)))
            {
                return await db.Countries
                    .Include(c => c.Regions)
                        .ThenInclude(r => r.Cities)
                            .ThenInclude(ci => ci.Districts)
                                .ThenInclude(d => d.Attractions)
                    .ToListAsync();
            }
        }

        public override async Task<Country> GetEntityAsync(int id, params string[] includeProperties)
        {
            using (var db = (LocationContext)Activator.CreateInstance(typeof(LocationContext)))
            {
                return await db.Countries
                    .Include(c => c.Regions)
                        .ThenInclude(r => r.Cities)
                            .ThenInclude(ci => ci.Districts)
                                .ThenInclude(d => d.Attractions)
                    .FirstOrDefaultAsync(c => c.id == id);
            }
        }
    }
}
