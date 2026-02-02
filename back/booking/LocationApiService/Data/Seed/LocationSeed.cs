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
               new Country { id = 1, Latitude = 48.3794, Longitude = 31.1656 },  // Ukraine
               new Country { id = 2, Latitude = 39.8283, Longitude = -98.5795 }, // United States
               new Country { id = 3, Latitude = 51.1657, Longitude = 10.4515 },  // Germany
               new Country { id = 4, Latitude = 46.6034, Longitude = 1.8883 },   // France
               new Country { id = 5, Latitude = 55.3781, Longitude = -3.4360 },  // United Kingdom
               new Country { id = 6, Latitude = 40.4637, Longitude = -3.7492 },  // Spain
               new Country { id = 7, Latitude = 51.9194, Longitude = 19.1451 }   // Poland
           );


            // Regions
            modelBuilder.Entity<Region>().HasData(
            // =================== Украина ===================
            new Region { id = 1, CountryId = 1, Latitude = 50.4501, Longitude = 30.5234 }, // Київ
            new Region { id = 2, CountryId = 1, Latitude = 48.6196, Longitude = 22.2879 }, // Закарпатська
            new Region { id = 3, CountryId = 1, Latitude = 49.8397, Longitude = 24.0297 }, // Львівська
            new Region { id = 4, CountryId = 1, Latitude = 46.4825, Longitude = 30.7233 }, // Одеська
            new Region { id = 5, CountryId = 1, Latitude = 49.5535, Longitude = 25.5948 }, // Тернопільська
            new Region { id = 6, CountryId = 1, Latitude = 48.9226, Longitude = 24.7111 }, // Івано-Франківська
            new Region { id = 7, CountryId = 1, Latitude = 48.7460, Longitude = 37.5853 }, // Донецька
            new Region { id = 8, CountryId = 1, Latitude = 47.8388, Longitude = 35.1396 }, // Запорізька
            new Region { id = 9, CountryId = 1, Latitude = 50.9077, Longitude = 34.7981 }, // Чернігівська
            new Region { id = 10, CountryId = 1, Latitude = 49.5883, Longitude = 34.5514 }, // Хмельницька
            new Region { id = 11, CountryId = 1, Latitude = 49.2331, Longitude = 28.4682 }, // Черкаська
            new Region { id = 12, CountryId = 1, Latitude = 49.4451, Longitude = 32.0598 }, // Полтавська
            new Region { id = 13, CountryId = 1, Latitude = 50.2915, Longitude = 30.4999 }, // Київська
            new Region { id = 14, CountryId = 1, Latitude = 46.9750, Longitude = 31.9946 }, // Миколаївська
            new Region { id = 15, CountryId = 1, Latitude = 46.4900, Longitude = 30.7326 }, // Херсонська
            new Region { id = 16, CountryId = 1, Latitude = 48.4623, Longitude = 35.0462 }, // Луганська
            new Region { id = 17, CountryId = 1, Latitude = 48.6187, Longitude = 26.2516 }, // Рівненська
            new Region { id = 18, CountryId = 1, Latitude = 49.8282, Longitude = 23.9422 }, // Волинська
            new Region { id = 19, CountryId = 1, Latitude = 48.1546, Longitude = 23.5657 }, // Чернівецька
            new Region { id = 20, CountryId = 1, Latitude = 50.0000, Longitude = 32.0000 }, // Житомирська
            new Region { id = 21, CountryId = 1, Latitude = 50.0050, Longitude = 36.2310 }, // Сумська
            new Region { id = 22, CountryId = 1, Latitude = 48.5000, Longitude = 32.2600 }, // Кіровоградська
            new Region { id = 23, CountryId = 1, Latitude = 49.2330, Longitude = 28.4680 }, // Вінницька
            new Region { id = 24, CountryId = 1, Latitude = 50.0050, Longitude = 36.2310 },  // Харківська

             // =================== США ===================
             new Region { id = 27, CountryId = 2, Latitude = 42.1657, Longitude = -74.9481 },
             new Region { id = 28, CountryId = 2, Latitude = 36.7783, Longitude = -119.4179 },
             new Region { id = 29, CountryId = 2, Latitude = 40.6331, Longitude = -89.3985 },

             // =================== Германия ===================
             new Region { id = 30, CountryId = 3, Latitude = 52.5200, Longitude = 13.4050 },
             new Region { id = 31, CountryId = 3, Latitude = 48.7904, Longitude = 11.4979 },
             new Region { id = 32, CountryId = 3, Latitude = 53.5511, Longitude = 9.9937 },

             // =================== Франция ===================
             new Region { id = 33, CountryId = 4, Latitude = 48.8499, Longitude = 2.6370 },
             new Region { id = 34, CountryId = 4, Latitude = 45.7640, Longitude = 4.8357 },
             new Region { id = 35, CountryId = 4, Latitude = 43.9352, Longitude = 6.0679 },

             // =================== UK ===================
             new Region { id = 36, CountryId = 5, Latitude = 51.5074, Longitude = -0.1278 },
             new Region { id = 37, CountryId = 5, Latitude = 53.4808, Longitude = -2.2426 },
             new Region { id = 38, CountryId = 5, Latitude = 52.4862, Longitude = -1.8904 },

             // =================== Spain ===================
             new Region { id = 39, CountryId = 6, Latitude = 40.4168, Longitude = -3.7038 },
             new Region { id = 40, CountryId = 6, Latitude = 41.3851, Longitude = 2.1734 },
             new Region { id = 41, CountryId = 6, Latitude = 39.4699, Longitude = -0.3763 },

             // =================== Poland ===================
             new Region { id = 42, CountryId = 7, Latitude = 52.2297, Longitude = 21.0122 },
             new Region { id = 43, CountryId = 7, Latitude = 50.0647, Longitude = 19.9450 },
             new Region { id = 44, CountryId = 7, Latitude = 52.4064, Longitude = 16.9252 }
         );




            modelBuilder.Entity<City>().HasData(
                       // =================== Украина ===================
            new City { id = 1, RegionId = 1, Latitude = 50.4501, Longitude = 30.5234, ImageUrl = "images/cities/Kyiv.jpg" }, // Київ
            new City { id = 2, RegionId = 2, Latitude = 48.6196, Longitude = 22.2879, ImageUrl = "images/cities/Uzhhorod.jpg" }, // Закарпатська
            new City { id = 3, RegionId = 3, Latitude = 49.8397, Longitude = 24.0297, ImageUrl = "images/cities/Lviv.jpg" }, // Львівська
            new City { id = 4, RegionId = 4, Latitude = 46.4825, Longitude = 30.7233, ImageUrl = "images/cities/Odesa.jpg" }, // Одеська
            new City { id = 5, RegionId = 5, Latitude = 49.5535, Longitude = 25.5948, ImageUrl = "images/cities/Ternopil.jpg" }, // Тернопільська
            new City { id = 6, RegionId = 6, Latitude = 48.9226, Longitude = 24.7111, ImageUrl = "images/cities/Ivano-Frankivsk.jpg" }, // Івано-Франківська
            new City { id = 7, RegionId = 7, Latitude = 48.7460, Longitude = 37.5853, ImageUrl = "images/cities/Donetsk.jpg" }, // Донецька
            new City { id = 8, RegionId = 8, Latitude = 47.8388, Longitude = 35.1396, ImageUrl = "images/cities/Zaporizhzhia.jpg" }, // Запорізька
            new City { id = 9, RegionId = 9, Latitude = 50.9077, Longitude = 34.7981, ImageUrl = "images/cities/Chernihiv.jpg" }, // Чернігівська
            new City { id = 10, RegionId = 10, Latitude = 49.5883, Longitude = 34.5514, ImageUrl = "images/cities/Khmelnytskyi.jpg" }, // Хмельницька
            new City { id = 11, RegionId = 11, Latitude = 49.2331, Longitude = 28.4682, ImageUrl = "images/cities/Cherkasy.jpg" }, // Черкаська
            new City { id = 12, RegionId = 12, Latitude = 49.4451, Longitude = 32.0598, ImageUrl = "images/cities/Poltava.jpg" }, // Полтавська
            new City { id = 13, RegionId = 13, Latitude = 50.2915, Longitude = 30.4999, ImageUrl = "images/cities/Bila-Tserkva.jpg" }, // Київська
            new City { id = 14, RegionId = 14, Latitude = 46.9750, Longitude = 31.9946, ImageUrl = "images/cities/Mykolaiv.jpg" }, // Миколаївська
            new City { id = 15, RegionId = 15, Latitude = 46.4900, Longitude = 30.7326, ImageUrl = "images/cities/Kherson.jpg" }, // Херсонська
            new City { id = 16, RegionId = 16, Latitude = 48.4623, Longitude = 35.0462, ImageUrl = "images/cities/Severodonetsk.jpg" }, // Луганська
            new City { id = 17, RegionId = 17, Latitude = 48.6187, Longitude = 26.2516, ImageUrl = "images/cities/Rivne.jpg" }, // Рівненська
            new City { id = 18, RegionId = 18, Latitude = 49.8282, Longitude = 23.9422, ImageUrl = "images/cities/Lutsk.jpg" }, // Волинська
            new City { id = 19, RegionId = 19, Latitude = 48.1546, Longitude = 23.5657, ImageUrl = "images/cities/Chernivtsi.jpg" }, // Чернівецька
            new City { id = 20, RegionId = 20, Latitude = 50.0000, Longitude = 32.0000, ImageUrl = "images/cities/Zhytomyr.jpg" }, // Житомирська
            new City { id = 21, RegionId = 21, Latitude = 50.0050, Longitude = 36.2310, ImageUrl = "images/cities/Sumy.jpg" }, // Сумська
            new City { id = 22, RegionId = 22, Latitude = 48.5000, Longitude = 32.2600, ImageUrl = "images/cities/Kropyvnytskyi.jpg" }, // Кіровоградська
            new City { id = 23, RegionId = 23, Latitude = 49.2330, Longitude = 28.4680, ImageUrl = "images/cities/Vinnytsia.jpg" }, // Вінницька
            new City { id = 24, RegionId = 24, Latitude = 50.0050, Longitude = 36.2310, ImageUrl = "images/cities/Kharkiv.jpg" }, // Харківська

             // =================== USA ===================
             new City { id = 25, RegionId = 25, Latitude = 40.7128, Longitude = -74.0060 },
             new City { id = 26, RegionId = 26, Latitude = 34.0522, Longitude = -118.2437 },
             new City { id = 27, RegionId = 27, Latitude = 41.8781, Longitude = -87.6298 },

             // =================== Germany ===================
             new City { id = 28, RegionId = 28, Latitude = 52.5200, Longitude = 13.4050 },
             new City { id = 29, RegionId = 29, Latitude = 48.1351, Longitude = 11.5820 },
             new City { id = 30, RegionId = 30, Latitude = 53.5511, Longitude = 9.9937 },

             // =================== France ===================
             new City { id = 31, RegionId = 31, Latitude = 48.8566, Longitude = 2.3522 },
             new City { id = 32, RegionId = 32, Latitude = 45.7640, Longitude = 4.8357 },
             new City { id = 33, RegionId = 33, Latitude = 43.2965, Longitude = 5.3698 },

             // =================== UK ===================
             new City { id = 34, RegionId = 34, Latitude = 51.5074, Longitude = -0.1278 },
             new City { id = 35, RegionId = 35, Latitude = 53.4808, Longitude = -2.2426 },
             new City { id = 36, RegionId = 36, Latitude = 52.4862, Longitude = -1.8904 },

             // =================== Spain ===================
             new City { id = 37, RegionId = 37, Latitude = 40.4168, Longitude = -3.7038 },
             new City { id = 38, RegionId = 38, Latitude = 41.3851, Longitude = 2.1734 },
             new City { id = 39, RegionId = 39, Latitude = 39.4699, Longitude = -0.3763 },

             // =================== Poland ===================
             new City { id = 40, RegionId = 40, Latitude = 52.2297, Longitude = 21.0122 },
             new City { id = 41, RegionId = 41, Latitude = 50.0647, Longitude = 19.9450 },
             new City { id = 42, RegionId = 42, Latitude = 52.4064, Longitude = 16.9252 }
         );


            modelBuilder.Entity<District>().HasData(
            // =================== Украина ===================
            // Київ
            new District { id = 1, CityId = 1, Latitude = 50.4501, Longitude = 30.5234 },
            new District { id = 2, CityId = 1, Latitude = 50.4547, Longitude = 30.5238 },
            new District { id = 3, CityId = 1, Latitude = 50.4470, Longitude = 30.5180 },

            // Ужгород
            new District { id = 4, CityId = 2, Latitude = 48.6196, Longitude = 22.2879 },
            new District { id = 5, CityId = 2, Latitude = 48.6220, Longitude = 22.2900 },
            new District { id = 6, CityId = 2, Latitude = 48.6150, Longitude = 22.2850 },

            // Львів
            new District { id = 7, CityId = 3, Latitude = 49.8397, Longitude = 24.0297 },
            new District { id = 8, CityId = 3, Latitude = 49.8420, Longitude = 24.0310 },
            new District { id = 9, CityId = 3, Latitude = 49.8360, Longitude = 24.0250 },

            // Оdesa
            new District { id = 10, CityId = 4, Latitude = 46.4825, Longitude = 30.7233 },
            new District { id = 11, CityId = 4, Latitude = 46.4850, Longitude = 30.7280 },
            new District { id = 12, CityId = 4, Latitude = 46.4780, Longitude = 30.7180 },

            // Тернопіль
            new District { id = 13, CityId = 5, Latitude = 49.5535, Longitude = 25.5948 },
            new District { id = 14, CityId = 5, Latitude = 49.5560, Longitude = 25.5980 },
            new District { id = 15, CityId = 5, Latitude = 49.5500, Longitude = 25.5900 },

            // Івано-Франківськ
            new District { id = 16, CityId = 6, Latitude = 48.9226, Longitude = 24.7111 },
            new District { id = 17, CityId = 6, Latitude = 48.9300, Longitude = 24.7200 },
            new District { id = 18, CityId = 6, Latitude = 48.9150, Longitude = 24.7000 },

            // Донецьк
            new District { id = 19, CityId = 7, Latitude = 48.7460, Longitude = 37.5853 },
            new District { id = 20, CityId = 7, Latitude = 48.7500, Longitude = 37.5900 },
            new District { id = 21, CityId = 7, Latitude = 48.7400, Longitude = 37.5800 },

            // Запоріжжя
            new District { id = 22, CityId = 8, Latitude = 47.8388, Longitude = 35.1396 },
            new District { id = 23, CityId = 8, Latitude = 47.8450, Longitude = 35.1450 },
            new District { id = 24, CityId = 8, Latitude = 47.8300, Longitude = 35.1300 },

            // Чернігів
            new District { id = 25, CityId = 9, Latitude = 50.9077, Longitude = 34.7981 },
            new District { id = 26, CityId = 9, Latitude = 50.9100, Longitude = 34.8000 },
            new District { id = 27, CityId = 9, Latitude = 50.9050, Longitude = 34.7950 },

            // Хмельницький
            new District { id = 28, CityId = 10, Latitude = 49.5883, Longitude = 34.5514 },
            new District { id = 29, CityId = 10, Latitude = 49.5900, Longitude = 34.5550 },
            new District { id = 30, CityId = 10, Latitude = 49.5850, Longitude = 34.5450 },

            // Черкаси
            new District { id = 31, CityId = 11, Latitude = 49.2331, Longitude = 28.4682 },
            new District { id = 32, CityId = 11, Latitude = 49.2350, Longitude = 28.4700 },
            new District { id = 33, CityId = 11, Latitude = 49.2300, Longitude = 28.4650 },

            // Полтава
            new District { id = 34, CityId = 12, Latitude = 49.4451, Longitude = 32.0598 },
            new District { id = 35, CityId = 12, Latitude = 49.4500, Longitude = 32.0650 },
            new District { id = 36, CityId = 12, Latitude = 49.4400, Longitude = 32.0500 },

            // Київська (Біла Церква)
            new District { id = 37, CityId = 13, Latitude = 50.2915, Longitude = 30.4999 },
            new District { id = 38, CityId = 13, Latitude = 50.2950, Longitude = 30.5050 },
            new District { id = 39, CityId = 13, Latitude = 50.2880, Longitude = 30.4950 },

            // Миколаїв
            new District { id = 40, CityId = 14, Latitude = 46.9750, Longitude = 31.9946 },
            new District { id = 41, CityId = 14, Latitude = 46.9800, Longitude = 32.0000 },
            new District { id = 42, CityId = 14, Latitude = 46.9700, Longitude = 31.9900 },

            // Херсон
            new District { id = 43, CityId = 15, Latitude = 46.4900, Longitude = 30.7326 },
            new District { id = 44, CityId = 15, Latitude = 46.4950, Longitude = 30.7400 },
            new District { id = 45, CityId = 15, Latitude = 46.4850, Longitude = 30.7250 },

            // Луганськ (Сєвєродонецьк)
            new District { id = 46, CityId = 16, Latitude = 48.4623, Longitude = 35.0462 },
            new District { id = 47, CityId = 16, Latitude = 48.4650, Longitude = 35.0500 },
            new District { id = 48, CityId = 16, Latitude = 48.4600, Longitude = 35.0400 },

            // Рівне
            new District { id = 49, CityId = 17, Latitude = 48.6187, Longitude = 26.2516 },
            new District { id = 50, CityId = 17, Latitude = 48.6200, Longitude = 26.2550 },
            new District { id = 51, CityId = 17, Latitude = 48.6150, Longitude = 26.2450 },

            // Луцьк
            new District { id = 52, CityId = 18, Latitude = 49.8282, Longitude = 23.9422 },
            new District { id = 53, CityId = 18, Latitude = 49.8300, Longitude = 23.9450 },
            new District { id = 54, CityId = 18, Latitude = 49.8250, Longitude = 23.9350 },

            // Чернівці
            new District { id = 55, CityId = 19, Latitude = 48.1546, Longitude = 23.5657 },
            new District { id = 56, CityId = 19, Latitude = 48.1570, Longitude = 23.5700 },
            new District { id = 57, CityId = 19, Latitude = 48.1500, Longitude = 23.5600 },

            // Житомир
            new District { id = 58, CityId = 20, Latitude = 50.0000, Longitude = 32.0000 },
            new District { id = 59, CityId = 20, Latitude = 50.0030, Longitude = 32.0050 },
            new District { id = 60, CityId = 20, Latitude = 49.9950, Longitude = 31.9950 },

            // Суми
            new District { id = 61, CityId = 21, Latitude = 50.0050, Longitude = 36.2310 },
            new District { id = 62, CityId = 21, Latitude = 50.0100, Longitude = 36.2350 },
            new District { id = 63, CityId = 21, Latitude = 50.0000, Longitude = 36.2250 },

            // Кропивницький
            new District { id = 64, CityId = 22, Latitude = 48.5000, Longitude = 32.2600 },
            new District { id = 65, CityId = 22, Latitude = 48.5050, Longitude = 32.2650 },
            new District { id = 66, CityId = 22, Latitude = 48.4950, Longitude = 32.2550 },

            // Вінниця
            new District { id = 67, CityId = 23, Latitude = 49.2330, Longitude = 28.4680 },
            new District { id = 68, CityId = 23, Latitude = 49.2350, Longitude = 28.4700 },
            new District { id = 69, CityId = 23, Latitude = 49.2300, Longitude = 28.4650 },

            // Харків
            new District { id = 70, CityId = 24, Latitude = 50.0050, Longitude = 36.2310 },
            new District { id = 71, CityId = 24, Latitude = 50.0100, Longitude = 36.2350 },
            new District { id = 72, CityId = 24, Latitude = 50.0000, Longitude = 36.2250 },

            // =================== USA ===================
            // New York
            new District { id = 49, CityId = 17, Latitude = 40.7831, Longitude = -73.9712 },
             new District { id = 50, CityId = 17, Latitude = 40.6782, Longitude = -73.9442 },
             new District { id = 51, CityId = 17, Latitude = 40.7282, Longitude = -73.7949 },

             // Los Angeles
             new District { id = 52, CityId = 18, Latitude = 34.0928, Longitude = -118.3287 },
             new District { id = 53, CityId = 18, Latitude = 34.0407, Longitude = -118.2468 },
             new District { id = 54, CityId = 18, Latitude = 34.0736, Longitude = -118.4004 },
            // --- Chicago ---
            new District { id = 106, CityId = 22, Latitude = 41.8837, Longitude = -87.6325 },
            new District { id = 107, CityId = 22, Latitude = 41.9214, Longitude = -87.6513 },
            new District { id = 108, CityId = 22, Latitude = 41.7943, Longitude = -87.5907 },

            // --- Berlin ---
            new District { id = 109, CityId = 23, Latitude = 52.5200, Longitude = 13.4049 },
            new District { id = 110, CityId = 23, Latitude = 52.4990, Longitude = 13.4030 },
            new District { id = 111, CityId = 23, Latitude = 52.5167, Longitude = 13.3041 },

            // --- Munich ---
            new District { id = 112, CityId = 24, Latitude = 48.1374, Longitude = 11.5755 },
            new District { id = 113, CityId = 24, Latitude = 48.1500, Longitude = 11.5670 },
            new District { id = 114, CityId = 24, Latitude = 48.1690, Longitude = 11.5800 },

            // --- Hamburg ---
            new District { id = 115, CityId = 25, Latitude = 53.5511, Longitude = 9.9410 },
            new District { id = 116, CityId = 25, Latitude = 53.5565, Longitude = 9.9640 },
            new District { id = 117, CityId = 25, Latitude = 53.5830, Longitude = 9.9650 },

            // --- Paris ---
            new District { id = 118, CityId = 26, Latitude = 48.8867, Longitude = 2.3431 },
            new District { id = 119, CityId = 26, Latitude = 48.8494, Longitude = 2.3470 },
            new District { id = 120, CityId = 26, Latitude = 48.8590, Longitude = 2.3622 },

            // --- Lyon ---
            new District { id = 121, CityId = 27, Latitude = 45.7601, Longitude = 4.8260 },
            new District { id = 122, CityId = 27, Latitude = 45.7597, Longitude = 4.8330 },
            new District { id = 123, CityId = 27, Latitude = 45.7764, Longitude = 4.8272 },

            // --- Marseille ---
            new District { id = 124, CityId = 28, Latitude = 43.2990, Longitude = 5.3710 },
            new District { id = 125, CityId = 28, Latitude = 43.2963, Longitude = 5.3699 },
            new District { id = 126, CityId = 28, Latitude = 43.3220, Longitude = 5.3970 },

            // --- London ---
            new District { id = 127, CityId = 29, Latitude = 51.5390, Longitude = -0.1420 },
            new District { id = 128, CityId = 29, Latitude = 51.4975, Longitude = -0.1357 },
            new District { id = 129, CityId = 29, Latitude = 51.4826, Longitude = 0.0077 },

            // --- Manchester ---
            new District { id = 130, CityId = 30, Latitude = 53.4840, Longitude = -2.2350 },
            new District { id = 131, CityId = 30, Latitude = 53.4160, Longitude = -2.2310 },
            new District { id = 132, CityId = 30, Latitude = 53.4740, Longitude = -2.2920 },

            // --- Birmingham ---
            new District { id = 133, CityId = 31, Latitude = 52.4550, Longitude = -1.9250 },
            new District { id = 134, CityId = 31, Latitude = 52.4896, Longitude = -1.9129 },
            new District { id = 135, CityId = 31, Latitude = 52.4415, Longitude = -1.9369 },

            // --- Madrid ---
            new District { id = 136, CityId = 32, Latitude = 40.4167, Longitude = -3.7033 },
            new District { id = 137, CityId = 32, Latitude = 40.4297, Longitude = -3.6860 },
            new District { id = 138, CityId = 32, Latitude = 40.4589, Longitude = -3.6779 },

            // --- Barcelona ---
            new District { id = 139, CityId = 33, Latitude = 41.3900, Longitude = 2.1650 },
            new District { id = 140, CityId = 33, Latitude = 41.3833, Longitude = 2.1767 },
            new District { id = 141, CityId = 33, Latitude = 41.4036, Longitude = 2.1566 },

            // --- Valencia ---
            new District { id = 142, CityId = 34, Latitude = 39.4740, Longitude = -0.3763 },
            new District { id = 143, CityId = 34, Latitude = 39.4640, Longitude = -0.3760 },
            new District { id = 144, CityId = 34, Latitude = 39.4700, Longitude = -0.3200 },

            // --- Warsaw ---
            new District { id = 145, CityId = 35, Latitude = 52.2310, Longitude = 21.0122 },
            new District { id = 146, CityId = 35, Latitude = 52.2400, Longitude = 20.9800 },
            new District { id = 147, CityId = 35, Latitude = 52.2550, Longitude = 21.0300 },

            // --- Krakow ---
            new District { id = 148, CityId = 36, Latitude = 50.0614, Longitude = 19.9372 },
            new District { id = 149, CityId = 36, Latitude = 50.0515, Longitude = 19.9440 },
            new District { id = 150, CityId = 36, Latitude = 50.0400, Longitude = 19.9500 },

            // --- Poznan ---
            new District { id = 151, CityId = 37, Latitude = 52.4095, Longitude = 16.9319 },
            new District { id = 152, CityId = 37, Latitude = 52.3980, Longitude = 16.9030 },
            new District { id = 153, CityId = 37, Latitude = 52.3930, Longitude = 16.9260 }


            );



        }
    }
}
