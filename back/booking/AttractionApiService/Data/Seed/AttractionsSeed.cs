using AttractionApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace AttractionApiService.Data.Seed
{
    public static class AttractionsSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //Attraction
            modelBuilder.Entity<Attraction>().HasData(
             // USA - New York
             new Attraction { id = 1, Latitude = 40.6892, Longitude = -74.0445, CountryId = 1, DistrictId = 1, RegionId = 1, CityId = 1, Address = "Attraction 1" },
             new Attraction { id = 2, Latitude = 40.7851, Longitude = -73.9683, CountryId = 1, DistrictId = 1, RegionId = 1, CityId = 1, Address = "Attraction 2" },
             new Attraction { id = 3, Latitude = 40.7580, Longitude = -73.9855, CountryId = 1, DistrictId = 1, RegionId = 1, CityId = 1, Address = "Attraction 3" },
             new Attraction { id = 4, Latitude = 40.7061, Longitude = -73.9969, CountryId = 1, DistrictId = 2, RegionId = 1, CityId = 1, Address = "Attraction 4" },
             new Attraction { id = 5, Latitude = 40.7484, Longitude = -73.9857, CountryId = 1, DistrictId = 3, RegionId = 1, CityId = 1, Address = "Attraction 5" },

             // USA - Los Angeles
             new Attraction { id = 6, Latitude = 34.1341, Longitude = -118.3215, CountryId = 1, DistrictId = 4, RegionId = 2, CityId = 2, Address = "Attraction 6" },
             new Attraction { id = 7, Latitude = 34.0094, Longitude = -118.4973, CountryId = 1, DistrictId = 5, RegionId = 2, CityId = 2, Address = "Attraction 7" },
             new Attraction { id = 8, Latitude = 34.1184, Longitude = -118.3004, CountryId = 1, DistrictId = 4, RegionId = 2, CityId = 2, Address = "Attraction 8" },
             new Attraction { id = 9, Latitude = 34.0780, Longitude = -118.4741, CountryId = 1, DistrictId = 5, RegionId = 2, CityId = 2, Address = "Attraction 9" },
             new Attraction { id = 10, Latitude = 33.9850, Longitude = -118.4695, CountryId = 1, DistrictId = 6, RegionId = 2, CityId = 2, Address = "Attraction 10" },

             // USA - Chicago
             new Attraction { id = 11, Latitude = 41.8826, Longitude = -87.6226, CountryId = 1, DistrictId = 7, RegionId = 3, CityId = 3, Address = "Attraction 11" },
             new Attraction { id = 12, Latitude = 41.8796, Longitude = -87.6237, CountryId = 1, DistrictId = 7, RegionId = 3, CityId = 3, Address = "Attraction 12" },
             new Attraction { id = 13, Latitude = 41.8917, Longitude = -87.6075, CountryId = 1, DistrictId = 8, RegionId = 3, CityId = 3, Address = "Attraction 13" },
             new Attraction { id = 14, Latitude = 41.8789, Longitude = -87.6359, CountryId = 1, DistrictId = 9, RegionId = 3, CityId = 3, Address = "Attraction 14" },
             new Attraction { id = 15, Latitude = 41.9210, Longitude = -87.6338, CountryId = 1, DistrictId = 8, RegionId = 3, CityId = 3, Address = "Attraction 15" },

             // Germany - Berlin
             new Attraction { id = 16, Latitude = 52.5163, Longitude = 13.3777, CountryId = 2, DistrictId = 10, RegionId = 4, CityId = 4, Address = "Attraction 16" },
             new Attraction { id = 17, Latitude = 52.5351, Longitude = 13.3903, CountryId = 2, DistrictId = 11, RegionId = 4, CityId = 4, Address = "Attraction 17" },
             new Attraction { id = 18, Latitude = 52.5169, Longitude = 13.4010, CountryId = 2, DistrictId = 10, RegionId = 4, CityId = 4, Address = "Attraction 18" },
             new Attraction { id = 19, Latitude = 52.5218, Longitude = 13.4132, CountryId = 2, DistrictId = 11, RegionId = 4, CityId = 4, Address = "Attraction 19" },
             new Attraction { id = 20, Latitude = 52.5076, Longitude = 13.3904, CountryId = 2, DistrictId = 12, RegionId = 4, CityId = 4, Address = "Attraction 20" },

             // Germany - Munich
             new Attraction { id = 21, Latitude = 48.1374, Longitude = 11.5755, CountryId = 2, DistrictId = 13, RegionId = 5, CityId = 5, Address = "Attraction 21" },
             new Attraction { id = 22, Latitude = 48.1593, Longitude = 11.6035, CountryId = 2, DistrictId = 14, RegionId = 5, CityId = 5, Address = "Attraction 22" },
             new Attraction { id = 23, Latitude = 48.1580, Longitude = 11.5031, CountryId = 2, DistrictId = 13, RegionId = 5, CityId = 5, Address = "Attraction 23" },
             new Attraction { id = 24, Latitude = 48.1769, Longitude = 11.5560, CountryId = 2, DistrictId = 14, RegionId = 5, CityId = 5, Address = "Attraction 24" },
             new Attraction { id = 25, Latitude = 48.1740, Longitude = 11.5560, CountryId = 2, DistrictId = 15, RegionId = 5, CityId = 5, Address = "Attraction 25" },

             // Germany - Hamburg
             new Attraction { id = 26, Latitude = 53.5436, Longitude = 9.9886, CountryId = 2, DistrictId = 16, RegionId = 6, CityId = 6, Address = "Attraction 26" },
             new Attraction { id = 27, Latitude = 53.5413, Longitude = 9.9666, CountryId = 2, DistrictId = 17, RegionId = 6, CityId = 6, Address = "Attraction 27" },
             new Attraction { id = 28, Latitude = 53.5413, Longitude = 9.9841, CountryId = 2, DistrictId = 16, RegionId = 6, CityId = 6, Address = "Attraction 28" },
             new Attraction { id = 29, Latitude = 53.5503, Longitude = 9.9729, CountryId = 2, DistrictId = 18, RegionId = 6, CityId = 6, Address = "Attraction 29" },
             new Attraction { id = 30, Latitude = 53.5496, Longitude = 9.9882, CountryId = 2, DistrictId = 16, RegionId = 6, CityId = 6, Address = "Attraction 30" },


            // France - Paris
            new Attraction { id = 31, Latitude = 48.8584, Longitude = 2.2945, CountryId = 3, DistrictId = 19, RegionId = 7, CityId = 7, Address = "Attraction 31" },
            new Attraction { id = 32, Latitude = 48.8606, Longitude = 2.3376, CountryId = 3, DistrictId = 20, RegionId = 7, CityId = 7, Address = "Attraction 32" },
            new Attraction { id = 33, Latitude = 48.8530, Longitude = 2.3499, CountryId = 3, DistrictId = 19, RegionId = 7, CityId = 7, Address = "Attraction 33" },
            new Attraction { id = 34, Latitude = 48.8867, Longitude = 2.3431, CountryId = 3, DistrictId = 19, RegionId = 7, CityId = 7, Address = "Attraction 34" },
            new Attraction { id = 35, Latitude = 48.8698, Longitude = 2.3070, CountryId = 3, DistrictId = 20, RegionId = 7, CityId = 7, Address = "Attraction 35" },

            // France - Lyon
            new Attraction { id = 36, Latitude = 45.7620, Longitude = 4.8221, CountryId = 3, DistrictId = 22, RegionId = 8, CityId = 8, Address = "Attraction 36" },
            new Attraction { id = 37, Latitude = 45.7793, Longitude = 4.8520, CountryId = 3, DistrictId = 23, RegionId = 8, CityId = 8, Address = "Attraction 37" },
            new Attraction { id = 38, Latitude = 45.7670, Longitude = 4.8270, CountryId = 3, DistrictId = 22, RegionId = 8, CityId = 8, Address = "Attraction 38" },
            new Attraction { id = 39, Latitude = 45.7670, Longitude = 4.8330, CountryId = 3, DistrictId = 23, RegionId = 8, CityId = 8, Address = "Attraction 39" },
            new Attraction { id = 40, Latitude = 45.7578, Longitude = 4.8320, CountryId = 3, DistrictId = 24, RegionId = 8, CityId = 8, Address = "Attraction 40" },

            // France - Marseille
            new Attraction { id = 41, Latitude = 43.2965, Longitude = 5.3698, CountryId = 3, DistrictId = 25, RegionId = 9, CityId = 9, Address = "Attraction 41" },
            new Attraction { id = 42, Latitude = 43.2961, Longitude = 5.3624, CountryId = 3, DistrictId = 26, RegionId = 9, CityId = 9, Address = "Attraction 42" },
            new Attraction { id = 43, Latitude = 43.2950, Longitude = 5.3270, CountryId = 3, DistrictId = 25, RegionId = 9, CityId = 9, Address = "Attraction 43" },
            new Attraction { id = 44, Latitude = 43.2960, Longitude = 5.3790, CountryId = 3, DistrictId = 26, RegionId = 9, CityId = 9, Address = "Attraction 44" },
            new Attraction { id = 45, Latitude = 43.2968, Longitude = 5.3892, CountryId = 3, DistrictId = 27, RegionId = 9, CityId = 9, Address = "Attraction 45" },

            // United Kingdom - London
            new Attraction { id = 46, Latitude = 51.5081, Longitude = -0.0759, CountryId = 4, DistrictId = 28, RegionId = 10, CityId = 10, Address = "Attraction 46" },
            new Attraction { id = 47, Latitude = 51.5014, Longitude = -0.1419, CountryId = 4, DistrictId = 29, RegionId = 10, CityId = 10, Address = "Attraction 47" },
            new Attraction { id = 48, Latitude = 51.5033, Longitude = -0.1195, CountryId = 4, DistrictId = 28, RegionId = 10, CityId = 10, Address = "Attraction 48" },
            new Attraction { id = 49, Latitude = 51.5194, Longitude = -0.1269, CountryId = 4, DistrictId = 30, RegionId = 10, CityId = 10, Address = "Attraction 49" },
            new Attraction { id = 50, Latitude = 51.5007, Longitude = -0.1246, CountryId = 4, DistrictId = 29, RegionId = 10, CityId = 10, Address = "Attraction 50" },

            // United Kingdom - Manchester
            new Attraction { id = 51, Latitude = 53.4631, Longitude = -2.2913, CountryId = 4, DistrictId = 31, RegionId = 11, CityId = 11, Address = "Attraction 51" },
            new Attraction { id = 52, Latitude = 53.4869, Longitude = -2.2466, CountryId = 4, DistrictId = 32, RegionId = 11, CityId = 11, Address = "Attraction 52" },
            new Attraction { id = 53, Latitude = 53.4772, Longitude = -2.2550, CountryId = 4, DistrictId = 31, RegionId = 11, CityId = 11, Address = "Attraction 53" },
            new Attraction { id = 54, Latitude = 53.4811, Longitude = -2.2461, CountryId = 4, DistrictId = 32, RegionId = 11, CityId = 11, Address = "Attraction 54" },
            new Attraction { id = 55, Latitude = 53.5485, Longitude = -2.2185, CountryId = 4, DistrictId = 33, RegionId = 11, CityId = 11, Address = "Attraction 55" },

            // United Kingdom - Birmingham
            new Attraction { id = 56, Latitude = 52.4797, Longitude = -1.9020, CountryId = 4, DistrictId = 34, RegionId = 12, CityId = 12, Address = "Attraction 56" },
            new Attraction { id = 57, Latitude = 52.4862, Longitude = -1.9470, CountryId = 4, DistrictId = 35, RegionId = 12, CityId = 12, Address = "Attraction 57" },
            new Attraction { id = 58, Latitude = 52.4626, Longitude = -1.8920, CountryId = 4, DistrictId = 36, RegionId = 12, CityId = 12, Address = "Attraction 58" },
            new Attraction { id = 59, Latitude = 52.4762, Longitude = -1.8931, CountryId = 4, DistrictId = 34, RegionId = 12, CityId = 12, Address = "Attraction 59" },
            new Attraction { id = 60, Latitude = 52.4786, Longitude = -1.9101, CountryId = 4, DistrictId = 35, RegionId = 12, CityId = 12, Address = "Attraction 60" },

            // Spain - Madrid
            new Attraction { id = 61, Latitude = 40.4179, Longitude = -3.7143, CountryId = 5, DistrictId = 37, RegionId = 13, CityId = 13, Address = "Attraction 61" },
            new Attraction { id = 62, Latitude = 40.4168, Longitude = -3.7038, CountryId = 5, DistrictId = 38, RegionId = 13, CityId = 13, Address = "Attraction 62" },
            new Attraction { id = 63, Latitude = 40.4155, Longitude = -3.7074, CountryId = 5, DistrictId = 37, RegionId = 13, CityId = 13, Address = "Attraction 63" },
            new Attraction { id = 64, Latitude = 40.4153, Longitude = -3.6846, CountryId = 5, DistrictId = 38, RegionId = 13, CityId = 13, Address = "Attraction 64" },
            new Attraction { id = 65, Latitude = 40.4240, Longitude = -3.7170, CountryId = 5, DistrictId = 39, RegionId = 13, CityId = 13, Address = "Attraction 65" },

            // Spain - Barcelona
            new Attraction { id = 66, Latitude = 41.4036, Longitude = 2.1744, CountryId = 5, DistrictId = 40, RegionId = 14, CityId = 14, Address = "Attraction 66" },
            new Attraction { id = 67, Latitude = 41.4145, Longitude = 2.1527, CountryId = 5, DistrictId = 41, RegionId = 14, CityId = 14, Address = "Attraction 67" },
            new Attraction { id = 68, Latitude = 41.3809, Longitude = 2.1730, CountryId = 5, DistrictId = 40, RegionId = 14, CityId = 14, Address = "Attraction 68" },
            new Attraction { id = 69, Latitude = 41.3917, Longitude = 2.1649, CountryId = 5, DistrictId = 41, RegionId = 14, CityId = 14, Address = "Attraction 69" },
            new Attraction { id = 70, Latitude = 41.3633, Longitude = 2.1583, CountryId = 5, DistrictId = 42, RegionId = 14, CityId = 14, Address = "Attraction 70" },

            // Spain - Valencia
            new Attraction { id = 71, Latitude = 39.4540, Longitude = -0.3510, CountryId = 5, DistrictId = 43, RegionId = 15, CityId = 15, Address = "Attraction 71" },
            new Attraction { id = 72, Latitude = 39.4753, Longitude = -0.3768, CountryId = 5, DistrictId = 44, RegionId = 15, CityId = 15, Address = "Attraction 72" },
            new Attraction { id = 73, Latitude = 39.4546, Longitude = -0.3415, CountryId = 5, DistrictId = 43, RegionId = 15, CityId = 15, Address = "Attraction 73" },
            new Attraction { id = 74, Latitude = 39.4699, Longitude = -0.3753, CountryId = 5, DistrictId = 44, RegionId = 15, CityId = 15, Address = "Attraction 74" },
            new Attraction { id = 75, Latitude = 39.4747, Longitude = -0.3763, CountryId = 5, DistrictId = 45, RegionId = 15, CityId = 15, Address = "Attraction 75" },

            // Poland - Warsaw
            new Attraction { id = 76, Latitude = 52.2450, Longitude = 21.0166, CountryId = 6, DistrictId = 46, RegionId = 16, CityId = 16, Address = "Attraction 76" },
            new Attraction { id = 77, Latitude = 52.2167, Longitude = 21.0333, CountryId = 6, DistrictId = 47, RegionId = 16, CityId = 16, Address = "Attraction 77" },
            new Attraction { id = 78, Latitude = 52.2319, Longitude = 21.0067, CountryId = 6, DistrictId = 46, RegionId = 16, CityId = 16, Address = "Attraction 78" },
            new Attraction { id = 79, Latitude = 52.2490, Longitude = 21.0122, CountryId = 6, DistrictId = 47, RegionId = 16, CityId = 16, Address = "Attraction 79" },
            new Attraction { id = 80, Latitude = 52.1919, Longitude = 21.0609, CountryId = 6, DistrictId = 48, RegionId = 16, CityId = 16, Address = "Attraction 80" },

            // Poland - Krakow
            new Attraction { id = 81, Latitude = 50.0614, Longitude = 19.9372, CountryId = 6, DistrictId = 49, RegionId = 17, CityId = 17, Address = "Attraction 81" },
            new Attraction { id = 82, Latitude = 50.0647, Longitude = 19.9450, CountryId = 6, DistrictId = 50, RegionId = 17, CityId = 17, Address = "Attraction 82" },
            new Attraction { id = 83, Latitude = 50.0677, Longitude = 19.9401, CountryId = 6, DistrictId = 49, RegionId = 17, CityId = 17, Address = "Attraction 83" },
            new Attraction { id = 84, Latitude = 50.0622, Longitude = 19.9367, CountryId = 6, DistrictId = 50, RegionId = 17, CityId = 17, Address = "Attraction 84" },
            new Attraction { id = 85, Latitude = 50.0590, Longitude = 19.9451, CountryId = 6, DistrictId = 51, RegionId = 17, CityId = 17, Address = "Attraction 85" },

            // Poland - Gdansk
            new Attraction { id = 86, Latitude = 54.3520, Longitude = 18.6466, CountryId = 6, DistrictId = 52, RegionId = 18, CityId = 18, Address = "Attraction 86" },
            new Attraction { id = 87, Latitude = 54.3510, Longitude = 18.6460, CountryId = 6, DistrictId = 53, RegionId = 18, CityId = 18, Address = "Attraction 87" },
            new Attraction { id = 88, Latitude = 54.3540, Longitude = 18.6500, CountryId = 6, DistrictId = 52, RegionId = 18, CityId = 18, Address = "Attraction 88" },
            new Attraction { id = 89, Latitude = 54.3480, Longitude = 18.6500, CountryId = 6, DistrictId = 53, RegionId = 18, CityId = 18, Address = "Attraction 89" },
            new Attraction { id = 90, Latitude = 54.3500, Longitude = 18.6450, CountryId = 6, DistrictId = 54, RegionId = 18, CityId = 18, Address = "Attraction 90" },


            // Poland - Poznan 
            new Attraction { id = 91, Latitude = 52.4230, Longitude = 16.8790, CountryId = 6, DistrictId = 55, RegionId = 19, CityId = 19, Address = "Attraction 91" },
            new Attraction { id = 92, Latitude = 52.4215, Longitude = 16.8775, CountryId = 6, DistrictId = 55, RegionId = 19, CityId = 19, Address = "Attraction 92" },
            new Attraction { id = 93, Latitude = 52.4240, Longitude = 16.8805, CountryId = 6, DistrictId = 56, RegionId = 19, CityId = 19, Address = "Attraction 93" },
            new Attraction { id = 94, Latitude = 52.4200, Longitude = 16.8760, CountryId = 6, DistrictId = 56, RegionId = 19, CityId = 19, Address = "Attraction 94" },
            new Attraction { id = 95, Latitude = 52.4250, Longitude = 16.8820, CountryId = 6, DistrictId = 57, RegionId = 19, CityId = 19, Address = "Attraction 95" },
            new Attraction { id = 96, Latitude = 52.4190, Longitude = 16.8750, CountryId = 6, DistrictId = 57, RegionId = 19, CityId = 19, Address = "Attraction 96" }
            );
        }
    }
}
