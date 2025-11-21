using Globals.Sevices;
using Microsoft.EntityFrameworkCore;
using RentObjectApiService.Models;
using RentObjectApiService.Services.Interfaces;
using RentObjectApiService.View;

namespace RentObjectApiService.Services
{
    public class CityService : TableServiceBase<City, RentObjectContext>, ICityService
    {
        
    }
}
