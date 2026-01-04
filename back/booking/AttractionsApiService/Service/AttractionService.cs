using AttractionsApiService.Models;
using AttractionsApiService.Service.Interfaces;
using AttractionsApiService.View;
using Globals.Sevices;
using Microsoft.EntityFrameworkCore;

namespace AttractionsApiService.Services
{
    public class AttractionService : TableServiceBase<Attraction, AttractionContext>, IAttractionService
    {



        public async Task<List<AttractionResponse>> GetAttractionsByDistanceAsync(decimal latitude, decimal longitude, decimal distance)
        {
            using var db = new AttractionContext();
            
            double centerLat = (double)latitude;
            double centerLon = (double)longitude;
            double radiusMeters = (double)distance;
        
            const double EarthRadius = 6371000; // meters

            var attractions = await db.Attractions
                .Include(a => a.Images)
                .Where(a => a.Latitude != null && a.Longitude != null)
                .ToListAsync();

            var result = attractions
                .Where(a =>
                {
                    double lat = a.Latitude.Value;
                    double lon = a.Longitude.Value;

                    double dLat = (lat - centerLat) * Math.PI / 180.0;              //разница широт в радианах
                    double dLon = (lon - centerLon) * Math.PI / 180.0;              // разница долгот в радианах

                    double lat1 = centerLat * Math.PI / 180.0;                       //широта центра в радианах
                    double lat2 = lat * Math.PI / 180.0;                           //широта достопримечательности в радианах

                    double aHarv = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
                    double c = 2 * Math.Atan2(Math.Sqrt(aHarv), Math.Sqrt(1 - aHarv));
                    double distanceTo = EarthRadius * c;

                    return distanceTo <= radiusMeters;
                })
                .Select(a => AttractionResponse.MapToResponse(a, ""))
                .ToList();

            return result;
        }
    }
}
