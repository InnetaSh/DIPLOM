using Globals.Sevices;
using LocationApiService.Models;
using LocationApiService.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LocationApiService.Services
{
    public class CountryService : TableServiceBaseNew<Country, LocationContext>, ICountryService
    {

        public CountryService(LocationContext context, ILogger<CountryService> logger) : base(context, logger)
        {
        }

        public override async Task<List<Country>> GetEntitiesAsync(Predicate<Country>? additional = null, params string[] includeProperties)
        {
            _logger.LogInformation("Getting all countries with regions and cities");

            var countries = await _context.Countries
                .AsNoTracking()
                .Include(c => c.Regions)
                    .ThenInclude(r => r.Cities)
                .ToListAsync();

            _logger.LogInformation("Retrieved {Count} countries", countries.Count);

            return countries;
        }
        public  async Task<List<Country>> GetEntitiesWithCodeAsync(params string[] includeProperties)
        {

            _logger.LogInformation("Getting all countries without includes");

            var countries = await _context.Countries
                .AsNoTracking()
                .ToListAsync();

            _logger.LogInformation("Retrieved {Count} countries", countries.Count);

            return countries;

        }


        public override async Task<Country> GetEntityAsync(int id, Predicate<Country>? additional = null, params string[] includeProperties)
        {

            _logger.LogInformation("Getting country with id {CountryId}", id);

            var country = await _context.Countries
                .AsNoTracking()
                .Include(c => c.Regions)
                    .ThenInclude(r => r.Cities)
                        .ThenInclude(ci => ci.Districts)
                .FirstOrDefaultAsync(c => c.id == id);

            if (country == null)
            {
                _logger.LogWarning("Country with id {CountryId} not found", id);
                return null;
            }

            _logger.LogInformation("Country with id {CountryId} retrieved successfully", id);

            return country;
        }
    }
}
