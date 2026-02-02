using OfferApiService.View.RentObj;
using System.Net.Http;
using System.Text.Json;

namespace OfferApiService.Controllers
{
    public class Helper
    {

        //==============расчет расстояния по ширине и долготе===============
        public static double CalculateDistanceMeters(double? lat1, double? lon1, double? lat2, double? lon2)
        {
            const double R = 6371000; // радиус Земли в метрах

            if (lat1 != null && lat1 != null)
            {
                var dLat = ToRadians((double)lat2 - (double)lat1);
                var dLon = ToRadians((double)lon2 - (double)lon1);

                double a =
                    Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(ToRadians((double)lat1)) *
                    Math.Cos(ToRadians((double)lat2)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

                double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

                return R * c;
            }
            return 0;
        }

        private static double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
