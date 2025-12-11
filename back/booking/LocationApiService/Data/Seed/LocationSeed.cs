using LocationApiService.Models;
using Microsoft.EntityFrameworkCore;



namespace LocationApiService.Data.Seed
{
    public static class LocationSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {

            // Countries
            modelBuilder.Entity<Country>().HasData(
                  new Country { id = 1, Latitude = 39.8283, Longitude = -98.5795 }, // United States
                  new Country { id = 2, Latitude = 51.1657, Longitude = 10.4515 },  // Germany
                  new Country { id = 3, Latitude = 46.6034, Longitude = 1.8883 },   // France
                  new Country { id = 4, Latitude = 55.3781, Longitude = -3.4360 },  // United Kingdom
                  new Country { id = 5, Latitude = 40.4637, Longitude = -3.7492 },  // Spain
                  new Country { id = 6, Latitude = 51.9194, Longitude = 19.1451 }   // Poland
              );




            // Regions
            modelBuilder.Entity<Region>().HasData(
                 // USA
                 new Region { id = 1, CountryId = 1, Latitude = 42.1657, Longitude = -74.9481 },
                 new Region { id = 2, CountryId = 1, Latitude = 36.7783, Longitude = -119.4179 },
                 new Region { id = 3, CountryId = 1, Latitude = 40.6331, Longitude = -89.3985 },

                 // Germany
                 new Region { id = 4, CountryId = 2, Latitude = 52.5200, Longitude = 13.4050 },
                 new Region { id = 5, CountryId = 2, Latitude = 48.7904, Longitude = 11.4979 },
                 new Region { id = 6, CountryId = 2, Latitude = 53.5511, Longitude = 9.9937 },

                 // France
                 new Region { id = 7, CountryId = 3, Latitude = 48.8499, Longitude = 2.6370 },
                 new Region { id = 8, CountryId = 3, Latitude = 45.7640, Longitude = 4.8357 },
                 new Region { id = 9, CountryId = 3, Latitude = 43.9352, Longitude = 6.0679 },

                 // UK
                 new Region { id = 10, CountryId = 4, Latitude = 51.5074, Longitude = -0.1278 },
                 new Region { id = 11, CountryId = 4, Latitude = 53.4808, Longitude = -2.2426 },
                 new Region { id = 12, CountryId = 4, Latitude = 52.4862, Longitude = -1.8904 },

                 // Spain
                 new Region { id = 13, CountryId = 5, Latitude = 40.4168, Longitude = -3.7038 },
                 new Region { id = 14, CountryId = 5, Latitude = 41.3851, Longitude = 2.1734 },
                 new Region { id = 15, CountryId = 5, Latitude = 39.4699, Longitude = -0.3763 },

                 // Poland
                 new Region { id = 16, CountryId = 6, Latitude = 52.2297, Longitude = 21.0122 },
                 new Region { id = 17, CountryId = 6, Latitude = 50.0647, Longitude = 19.9450 },
                 new Region { id = 18, CountryId = 6, Latitude = 52.4064, Longitude = 16.9252 }
             );




            modelBuilder.Entity<City>().HasData(
                // USA
                new City { id = 1, RegionId = 1, Latitude = 40.7128, Longitude = -74.0060 },
                new City { id = 2, RegionId = 2, Latitude = 34.0522, Longitude = -118.2437 },
                new City { id = 3, RegionId = 3, Latitude = 41.8781, Longitude = -87.6298 },

                // Germany
                new City { id = 4, RegionId = 4, Latitude = 52.5200, Longitude = 13.4050 },
                new City { id = 5, RegionId = 5, Latitude = 48.1351, Longitude = 11.5820 },
                new City { id = 6, RegionId = 6, Latitude = 53.5511, Longitude = 9.9937 },

                // France
                new City { id = 7, RegionId = 7, Latitude = 48.8566, Longitude = 2.3522 },
                new City { id = 8, RegionId = 8, Latitude = 45.7640, Longitude = 4.8357 },
                new City { id = 9, RegionId = 9, Latitude = 43.2965, Longitude = 5.3698 },

                // UK
                new City { id = 10, RegionId = 10, Latitude = 51.5074, Longitude = -0.1278 },
                new City { id = 11, RegionId = 11, Latitude = 53.4808, Longitude = -2.2426 },
                new City { id = 12, RegionId = 12, Latitude = 52.4862, Longitude = -1.8904 },

                // Spain
                new City { id = 13, RegionId = 13, Latitude = 40.4168, Longitude = -3.7038 },
                new City { id = 14, RegionId = 14, Latitude = 41.3851, Longitude = 2.1734 },
                new City { id = 15, RegionId = 15, Latitude = 39.4699, Longitude = -0.3763 },

                // Poland
                new City { id = 16, RegionId = 16, Latitude = 52.2297, Longitude = 21.0122 },
                new City { id = 17, RegionId = 17, Latitude = 50.0647, Longitude = 19.9450 },
                new City { id = 18, RegionId = 18, Latitude = 52.4064, Longitude = 16.9252 }
            );



            modelBuilder.Entity<District>().HasData(
                 // --- New York ---
                 new District { id = 1, CityId = 1, Latitude = 40.7831, Longitude = -73.9712 },
                 new District { id = 2, CityId = 1, Latitude = 40.6782, Longitude = -73.9442 },
                 new District { id = 3, CityId = 1, Latitude = 40.7282, Longitude = -73.7949 },

                 // --- Los Angeles ---
                 new District { id = 4, CityId = 2, Latitude = 34.0928, Longitude = -118.3287 },
                 new District { id = 5, CityId = 2, Latitude = 34.0407, Longitude = -118.2468 },
                 new District { id = 6, CityId = 2, Latitude = 34.0736, Longitude = -118.4004 },

                 // --- Chicago ---
                 new District { id = 7, CityId = 3, Latitude = 41.8837, Longitude = -87.6325 },
                 new District { id = 8, CityId = 3, Latitude = 41.9214, Longitude = -87.6513 },
                 new District { id = 9, CityId = 3, Latitude = 41.7943, Longitude = -87.5907 },

                 // --- Berlin ---
                 new District { id = 10, CityId = 4, Latitude = 52.5200, Longitude = 13.4049 },
                 new District { id = 11, CityId = 4, Latitude = 52.4990, Longitude = 13.4030 },
                 new District { id = 12, CityId = 4, Latitude = 52.5167, Longitude = 13.3041 },

                 // --- Munich ---
                 new District { id = 13, CityId = 5, Latitude = 48.1374, Longitude = 11.5755 },
                 new District { id = 14, CityId = 5, Latitude = 48.1500, Longitude = 11.5670 },
                 new District { id = 15, CityId = 5, Latitude = 48.1690, Longitude = 11.5800 },

                 // --- Hamburg ---
                 new District { id = 16, CityId = 6, Latitude = 53.5511, Longitude = 9.9410 },
                 new District { id = 17, CityId = 6, Latitude = 53.5565, Longitude = 9.9640 },
                 new District { id = 18, CityId = 6, Latitude = 53.5830, Longitude = 9.9650 },

                 // --- Paris ---
                 new District { id = 19, CityId = 7, Latitude = 48.8867, Longitude = 2.3431 },
                 new District { id = 20, CityId = 7, Latitude = 48.8494, Longitude = 2.3470 },
                 new District { id = 21, CityId = 7, Latitude = 48.8590, Longitude = 2.3622 },

                 // --- Lyon ---
                 new District { id = 22, CityId = 8, Latitude = 45.7601, Longitude = 4.8260 },
                 new District { id = 23, CityId = 8, Latitude = 45.7597, Longitude = 4.8330 },
                 new District { id = 24, CityId = 8, Latitude = 45.7764, Longitude = 4.8272 },

                 // --- Marseille ---
                 new District { id = 25, CityId = 9, Latitude = 43.2990, Longitude = 5.3710 },
                 new District { id = 26, CityId = 9, Latitude = 43.2963, Longitude = 5.3699 },
                 new District { id = 27, CityId = 9, Latitude = 43.3220, Longitude = 5.3970 },

                 // --- London ---
                 new District { id = 28, CityId = 10, Latitude = 51.5390, Longitude = -0.1420 },
                 new District { id = 29, CityId = 10, Latitude = 51.4975, Longitude = -0.1357 },
                 new District { id = 30, CityId = 10, Latitude = 51.4826, Longitude = 0.0077 },

                 // --- Manchester ---
                 new District { id = 31, CityId = 11, Latitude = 53.4840, Longitude = -2.2350 },
                 new District { id = 32, CityId = 11, Latitude = 53.4160, Longitude = -2.2310 },
                 new District { id = 33, CityId = 11, Latitude = 53.4740, Longitude = -2.2920 },

                 // --- Birmingham ---
                 new District { id = 34, CityId = 12, Latitude = 52.4550, Longitude = -1.9250 },
                 new District { id = 35, CityId = 12, Latitude = 52.4896, Longitude = -1.9129 },
                 new District { id = 36, CityId = 12, Latitude = 52.4415, Longitude = -1.9369 },

                 // --- Madrid ---
                 new District { id = 37, CityId = 13, Latitude = 40.4167, Longitude = -3.7033 },
                 new District { id = 38, CityId = 13, Latitude = 40.4297, Longitude = -3.6860 },
                 new District { id = 39, CityId = 13, Latitude = 40.4589, Longitude = -3.6779 },

                 // --- Barcelona ---
                 new District { id = 40, CityId = 14, Latitude = 41.3900, Longitude = 2.1650 },
                 new District { id = 41, CityId = 14, Latitude = 41.3833, Longitude = 2.1767 },
                 new District { id = 42, CityId = 14, Latitude = 41.4036, Longitude = 2.1566 },

                 // --- Valencia ---
                 new District { id = 43, CityId = 15, Latitude = 39.4740, Longitude = -0.3763 },
                 new District { id = 44, CityId = 15, Latitude = 39.4640, Longitude = -0.3760 },
                 new District { id = 45, CityId = 15, Latitude = 39.4700, Longitude = -0.3200 },

                 // --- Warsaw ---
                 new District { id = 46, CityId = 16, Latitude = 52.2310, Longitude = 21.0122 },
                 new District { id = 47, CityId = 16, Latitude = 52.2400, Longitude = 20.9800 },
                 new District { id = 48, CityId = 16, Latitude = 52.2550, Longitude = 21.0300 },

                 // --- Krakow ---
                 new District { id = 49, CityId = 17, Latitude = 50.0614, Longitude = 19.9372 },
                 new District { id = 50, CityId = 17, Latitude = 50.0515, Longitude = 19.9440 },
                 new District { id = 51, CityId = 17, Latitude = 50.0400, Longitude = 19.9500 },

                 // --- Poznan ---
                 new District { id = 52, CityId = 18, Latitude = 52.4095, Longitude = 16.9319 },
                 new District { id = 53, CityId = 18, Latitude = 52.3980, Longitude = 16.9030 },
                 new District { id = 54, CityId = 18, Latitude = 52.3930, Longitude = 16.9260 }
             );


            //Attraction
            modelBuilder.Entity<Attraction>().HasData(
                // USA - New York
                new Attraction { id = 1, Latitude = 40.6892, Longitude = -74.0445, CountryId = 1, DistrictId = 1, RegionId = 1, CityId = 1 },
                new Attraction { id = 2, Latitude = 40.7851, Longitude = -73.9683, CountryId = 1, DistrictId = 1, RegionId = 1, CityId = 1 },
                new Attraction { id = 3, Latitude = 40.7580, Longitude = -73.9855, CountryId = 1, DistrictId = 1, RegionId = 1, CityId = 1 },
                new Attraction { id = 4, Latitude = 40.7061, Longitude = -73.9969, CountryId = 1, DistrictId = 2, RegionId = 1, CityId = 1 },
                new Attraction { id = 5, Latitude = 40.7484, Longitude = -73.9857, CountryId = 1, DistrictId = 3, RegionId = 1, CityId = 1 },

                // USA - Los Angeles
                new Attraction { id = 6, Latitude = 34.1341, Longitude = -118.3215, CountryId = 1, DistrictId = 4, RegionId = 2, CityId = 2 },
                new Attraction { id = 7, Latitude = 34.0094, Longitude = -118.4973, CountryId = 1, DistrictId = 5, RegionId = 2, CityId = 2 },
                new Attraction { id = 8, Latitude = 34.1184, Longitude = -118.3004, CountryId = 1, DistrictId = 4, RegionId = 2, CityId = 2 },
                new Attraction { id = 9, Latitude = 34.0780, Longitude = -118.4741, CountryId = 1, DistrictId = 5, RegionId = 2, CityId = 2 },
                new Attraction { id = 10, Latitude = 33.9850, Longitude = -118.4695, CountryId = 1, DistrictId = 6, RegionId = 2, CityId = 2 },

                // USA - Chicago
                new Attraction { id = 11, Latitude = 41.8826, Longitude = -87.6226, CountryId = 1, DistrictId = 7, RegionId = 3, CityId = 3 },
                new Attraction { id = 12, Latitude = 41.8796, Longitude = -87.6237, CountryId = 1, DistrictId = 7, RegionId = 3, CityId = 3 },
                new Attraction { id = 13, Latitude = 41.8917, Longitude = -87.6075, CountryId = 1, DistrictId = 8, RegionId = 3, CityId = 3 },
                new Attraction { id = 14, Latitude = 41.8789, Longitude = -87.6359, CountryId = 1, DistrictId = 9, RegionId = 3, CityId = 3 },
                new Attraction { id = 15, Latitude = 41.9210, Longitude = -87.6338, CountryId = 1, DistrictId = 8, RegionId = 3, CityId = 3 },

                // Germany - Berlin
                new Attraction { id = 16, Latitude = 52.5163, Longitude = 13.3777, CountryId = 2, DistrictId = 10, RegionId = 4, CityId = 4 },
                new Attraction { id = 17, Latitude = 52.5351, Longitude = 13.3903, CountryId = 2, DistrictId = 11, RegionId = 4, CityId = 4 },
                new Attraction { id = 18, Latitude = 52.5169, Longitude = 13.4010, CountryId = 2, DistrictId = 10, RegionId = 4, CityId = 4 },
                new Attraction { id = 19, Latitude = 52.5218, Longitude = 13.4132, CountryId = 2, DistrictId = 11, RegionId = 4, CityId = 4 },
                new Attraction { id = 20, Latitude = 52.5076, Longitude = 13.3904, CountryId = 2, DistrictId = 12, RegionId = 4, CityId = 4 },

                // Germany - Munich
                new Attraction { id = 21, Latitude = 48.1374, Longitude = 11.5755, CountryId = 2, DistrictId = 13, RegionId = 5, CityId = 5 },
                new Attraction { id = 22, Latitude = 48.1593, Longitude = 11.6035, CountryId = 2, DistrictId = 14, RegionId = 5, CityId = 5 },
                new Attraction { id = 23, Latitude = 48.1580, Longitude = 11.5031, CountryId = 2, DistrictId = 13, RegionId = 5, CityId = 5 },
                new Attraction { id = 24, Latitude = 48.1769, Longitude = 11.5560, CountryId = 2, DistrictId = 14, RegionId = 5, CityId = 5 },
                new Attraction { id = 25, Latitude = 48.1740, Longitude = 11.5560, CountryId = 2, DistrictId = 15, RegionId = 5, CityId = 5 },

                // Germany - Hamburg
                new Attraction { id = 26, Latitude = 53.5436, Longitude = 9.9886, CountryId = 2, DistrictId = 16, RegionId = 6, CityId = 6 },
                new Attraction { id = 27, Latitude = 53.5413, Longitude = 9.9666, CountryId = 2, DistrictId = 17, RegionId = 6, CityId = 6 },
                new Attraction { id = 28, Latitude = 53.5413, Longitude = 9.9841, CountryId = 2, DistrictId = 16, RegionId = 6, CityId = 6 },
                new Attraction { id = 29, Latitude = 53.5503, Longitude = 9.9729, CountryId = 2, DistrictId = 18, RegionId = 6, CityId = 6 },
                new Attraction { id = 30, Latitude = 53.5496, Longitude = 9.9882, CountryId = 2, DistrictId = 16, RegionId = 6, CityId = 6 },

                // France - Paris
                new Attraction { id = 31, Latitude = 48.8584, Longitude = 2.2945, CountryId = 3, DistrictId = 19, RegionId = 7, CityId = 7 },
                new Attraction { id = 32, Latitude = 48.8606, Longitude = 2.3376, CountryId = 3, DistrictId = 20, RegionId = 7, CityId = 7 },
                new Attraction { id = 33, Latitude = 48.8530, Longitude = 2.3499, CountryId = 3, DistrictId = 19, RegionId = 7, CityId = 7 },
                new Attraction { id = 34, Latitude = 48.8867, Longitude = 2.3431, CountryId = 3, DistrictId = 19, RegionId = 7, CityId = 7 },
                new Attraction { id = 35, Latitude = 48.8698, Longitude = 2.3070, CountryId = 3, DistrictId = 20, RegionId = 7, CityId = 7 },

                // France - Lyon
                new Attraction { id = 36, Latitude = 45.7620, Longitude = 4.8221, CountryId = 3, DistrictId = 22, RegionId = 8, CityId = 8 },
                new Attraction { id = 37, Latitude = 45.7793, Longitude = 4.8520, CountryId = 3, DistrictId = 23, RegionId = 8, CityId = 8 },
                new Attraction { id = 38, Latitude = 45.7670, Longitude = 4.8270, CountryId = 3, DistrictId = 22, RegionId = 8, CityId = 8 },
                new Attraction { id = 39, Latitude = 45.7670, Longitude = 4.8330, CountryId = 3, DistrictId = 23, RegionId = 8, CityId = 8 },
                new Attraction { id = 40, Latitude = 45.7578, Longitude = 4.8320, CountryId = 3, DistrictId = 24, RegionId = 8, CityId = 8 },

                // France - Marseille
                new Attraction { id = 41, Latitude = 43.2965, Longitude = 5.3698, CountryId = 3, DistrictId = 25, RegionId = 9, CityId = 9 },
                new Attraction { id = 42, Latitude = 43.2961, Longitude = 5.3624, CountryId = 3, DistrictId = 26, RegionId = 9, CityId = 9 },
                new Attraction { id = 43, Latitude = 43.2950, Longitude = 5.3270, CountryId = 3, DistrictId = 25, RegionId = 9, CityId = 9 },
                new Attraction { id = 44, Latitude = 43.2960, Longitude = 5.3790, CountryId = 3, DistrictId = 26, RegionId = 9, CityId = 9 },
                new Attraction { id = 45, Latitude = 43.2968, Longitude = 5.3892, CountryId = 3, DistrictId = 27, RegionId = 9, CityId = 9 },

                // United Kingdom - London
                new Attraction { id = 46, Latitude = 51.5081, Longitude = -0.0759, CountryId = 4, DistrictId = 28, RegionId = 10, CityId = 10 },
                new Attraction { id = 47, Latitude = 51.5014, Longitude = -0.1419, CountryId = 4, DistrictId = 29, RegionId = 10, CityId = 10 },
                new Attraction { id = 48, Latitude = 51.5033, Longitude = -0.1195, CountryId = 4, DistrictId = 28, RegionId = 10, CityId = 10 },
                new Attraction { id = 49, Latitude = 51.5194, Longitude = -0.1269, CountryId = 4, DistrictId = 30, RegionId = 10, CityId = 10 },
                new Attraction { id = 50, Latitude = 51.5007, Longitude = -0.1246, CountryId = 4, DistrictId = 29, RegionId = 10, CityId = 10 },

                // United Kingdom - Manchester
                new Attraction { id = 51, Latitude = 53.4631, Longitude = -2.2913, CountryId = 4, DistrictId = 31, RegionId = 11, CityId = 11 },
                new Attraction { id = 52, Latitude = 53.4869, Longitude = -2.2466, CountryId = 4, DistrictId = 32, RegionId = 11, CityId = 11 },
                new Attraction { id = 53, Latitude = 53.4772, Longitude = -2.2550, CountryId = 4, DistrictId = 31, RegionId = 11, CityId = 11 },
                new Attraction { id = 54, Latitude = 53.4811, Longitude = -2.2461, CountryId = 4, DistrictId = 32, RegionId = 11, CityId = 11 },
                new Attraction { id = 55, Latitude = 53.5485, Longitude = -2.2185, CountryId = 4, DistrictId = 33, RegionId = 11, CityId = 11 },

                // United Kingdom - Birmingham
                new Attraction { id = 56, Latitude = 52.4797, Longitude = -1.9020, CountryId = 4, DistrictId = 34, RegionId = 12, CityId = 12 },
                new Attraction { id = 57, Latitude = 52.4862, Longitude = -1.9470, CountryId = 4, DistrictId = 35, RegionId = 12, CityId = 12 },
                new Attraction { id = 58, Latitude = 52.4626, Longitude = -1.8920, CountryId = 4, DistrictId = 36, RegionId = 12, CityId = 12 },
                new Attraction { id = 59, Latitude = 52.4762, Longitude = -1.8931, CountryId = 4, DistrictId = 34, RegionId = 12, CityId = 12 },
                new Attraction { id = 60, Latitude = 52.4786, Longitude = -1.9101, CountryId = 4, DistrictId = 35, RegionId = 12, CityId = 12 },

                // Spain - Madrid
                new Attraction { id = 61, Latitude = 40.4179, Longitude = -3.7143, CountryId = 5, DistrictId = 37, RegionId = 13, CityId = 13 },
                new Attraction { id = 62, Latitude = 40.4168, Longitude = -3.7038, CountryId = 5, DistrictId = 38, RegionId = 13, CityId = 13 },
                new Attraction { id = 63, Latitude = 40.4155, Longitude = -3.7074, CountryId = 5, DistrictId = 37, RegionId = 13, CityId = 13 },
                new Attraction { id = 64, Latitude = 40.4153, Longitude = -3.6846, CountryId = 5, DistrictId = 38, RegionId = 13, CityId = 13 },
                new Attraction { id = 65, Latitude = 40.4240, Longitude = -3.7170, CountryId = 5, DistrictId = 39, RegionId = 13, CityId = 13 },

                // Spain - Barcelona
                new Attraction { id = 66, Latitude = 41.4036, Longitude = 2.1744, CountryId = 5, DistrictId = 40, RegionId = 14, CityId = 14 },
                new Attraction { id = 67, Latitude = 41.4145, Longitude = 2.1527, CountryId = 5, DistrictId = 41, RegionId = 14, CityId = 14 },
                new Attraction { id = 68, Latitude = 41.3809, Longitude = 2.1730, CountryId = 5, DistrictId = 40, RegionId = 14, CityId = 14 },
                new Attraction { id = 69, Latitude = 41.3917, Longitude = 2.1649, CountryId = 5, DistrictId = 41, RegionId = 14, CityId = 14 },
                new Attraction { id = 70, Latitude = 41.3633, Longitude = 2.1583, CountryId = 5, DistrictId = 42, RegionId = 14, CityId = 14 },

                // Spain - Valencia
                new Attraction { id = 71, Latitude = 39.4540, Longitude = -0.3510, CountryId = 5, DistrictId = 43, RegionId = 15, CityId = 15 },
                new Attraction { id = 72, Latitude = 39.4753, Longitude = -0.3768, CountryId = 5, DistrictId = 44, RegionId = 15, CityId = 15 },
                new Attraction { id = 73, Latitude = 39.4546, Longitude = -0.3415, CountryId = 5, DistrictId = 43, RegionId = 15, CityId = 15 },
                new Attraction { id = 74, Latitude = 39.4699, Longitude = -0.3753, CountryId = 5, DistrictId = 44, RegionId = 15, CityId = 15 },
                new Attraction { id = 75, Latitude = 39.4747, Longitude = -0.3763, CountryId = 5, DistrictId = 45, RegionId = 15, CityId = 15 },

                // Poland - Warsaw
                new Attraction { id = 76, Latitude = 52.2450, Longitude = 21.0166, CountryId = 6, DistrictId = 46, RegionId = 16, CityId = 16 },
                new Attraction { id = 77, Latitude = 52.2167, Longitude = 21.0333, CountryId = 6, DistrictId = 47, RegionId = 16, CityId = 16 },
                new Attraction { id = 78, Latitude = 52.2319, Longitude = 21.0067, CountryId = 6, DistrictId = 46, RegionId = 16, CityId = 16 },
                new Attraction { id = 79, Latitude = 52.2490, Longitude = 21.0122, CountryId = 6, DistrictId = 47, RegionId = 16, CityId = 16 },
                new Attraction { id = 80, Latitude = 52.1919, Longitude = 21.0609, CountryId = 6, DistrictId = 48, RegionId = 16, CityId = 16 },

                // Poland - Krakow
                new Attraction { id = 81, Latitude = 50.0614, Longitude = 19.9372, CountryId = 6, DistrictId = 49, RegionId = 17, CityId = 17 },
                new Attraction { id = 82, Latitude = 50.0647, Longitude = 19.9450, CountryId = 6, DistrictId = 50, RegionId = 17, CityId = 17 },
                new Attraction { id = 83, Latitude = 50.0677, Longitude = 19.9401, CountryId = 6, DistrictId = 49, RegionId = 17, CityId = 17 },
                new Attraction { id = 84, Latitude = 50.0622, Longitude = 19.9367, CountryId = 6, DistrictId = 50, RegionId = 17, CityId = 17 },
                new Attraction { id = 85, Latitude = 50.0590, Longitude = 19.9451, CountryId = 6, DistrictId = 51, RegionId = 17, CityId = 17 },

                // Poland - Gdansk
                new Attraction { id = 86, Latitude = 54.3520, Longitude = 18.6466, CountryId = 6, DistrictId = 52, RegionId = 18, CityId = 18 },
                new Attraction { id = 87, Latitude = 54.3510, Longitude = 18.6460, CountryId = 6, DistrictId = 53, RegionId = 18, CityId = 18 },
                new Attraction { id = 88, Latitude = 54.3540, Longitude = 18.6500, CountryId = 6, DistrictId = 52, RegionId = 18, CityId = 18 },
                new Attraction { id = 89, Latitude = 54.3480, Longitude = 18.6500, CountryId = 6, DistrictId = 53, RegionId = 18, CityId = 18 },
                new Attraction { id = 90, Latitude = 54.3500, Longitude = 18.6450, CountryId = 6, DistrictId = 54, RegionId = 18, CityId = 18 }
            );
        }
    }
}
