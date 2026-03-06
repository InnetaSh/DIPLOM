using AttractionApiService.Mappers;
using AttractionApiService.Models;
using AttractionApiService.Service.Interfaces;
using AttractionContracts;
using Globals.Sevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AttractionApiService.Service
{
    public class AttractionService : TableServiceBaseNew<Attraction, AttractionContext>, IAttractionService
    {
        public AttractionService(AttractionContext context, ILogger<AttractionService> logger) : base(context, logger)
        {
        }

        //==================================================================================================================
        public async Task<List<Attraction>> GetAttractionByCityId([FromQuery] int cityId)
        {
            try
            {
                //using var db = new AttractionContext();

                var attractions = await _context.Attractions
                    .Include(a => a.Images) 
                    .Where(a => a.CityId == cityId)
                    .ToListAsync();

                return (attractions);
                  
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception message: " + ex.Message);
                Console.WriteLine("Stack trace: " + ex.StackTrace);
                throw;
            }
        }


        //==================================================================================================================


        public async Task<List<Attraction>> GetAttractionById([FromQuery] int id)
        {
            try
            {
               // using var db = new AttractionContext();

                var attractions = await _context.Attractions
                     .AsNoTracking()
                    .Where(a => a.id == id)
                    .ToListAsync();

                return attractions;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception message: " + ex.Message);
                Console.WriteLine("Stack trace: " + ex.StackTrace);
                throw;
            }
        }
        //==================================================================================================================

        public async Task<List<AttractionResponse>> GetAttractionsByDistanceAsync(decimal latitude, decimal longitude, decimal distance)
        {
            //using var db = new AttractionContext();
            
            double centerLat = (double)latitude;
            double centerLon = (double)longitude;
            double radiusMeters = (double)distance;
        
            const double EarthRadius = 6371000; // meters

            var attractions = await _context.Attractions
                 .AsNoTracking()
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
                .Select(a => AttractionMapper.MapToResponse(a, ""))
                .ToList();

            return result;
        }


        public void AddImage(AttractionImage img)
        {
            _context.AttractionImages.Add(img);
            _context.SaveChanges();
        }

        public AttractionImage DelImage(int imageId)
        {
            var img = _context.AttractionImages.FirstOrDefault(i => i.id == imageId);
            if (img == null) return null;

            _context.AttractionImages.Remove(img);
            _context.SaveChanges();
            return img;
        }
    }
}
