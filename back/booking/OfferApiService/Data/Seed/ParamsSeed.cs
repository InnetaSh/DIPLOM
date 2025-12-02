using Microsoft.EntityFrameworkCore;
using OfferApiService.Models.RentObject;
using OfferApiService.Models.RentObject.Enums;

namespace OfferApiService.Data.Seed
{
    public static class ParamsSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {

            // Countries
            modelBuilder.Entity<Country>().HasData(
                 new Country { id = 1, Title = "United States", Latitude = 39.8283, Longitude = -98.5795 },
                 new Country { id = 2, Title = "Germany", Latitude = 51.1657, Longitude = 10.4515 },
                 new Country { id = 3, Title = "France", Latitude = 46.6034, Longitude = 1.8883 },
                 new Country { id = 4, Title = "United Kingdom", Latitude = 55.3781, Longitude = -3.4360 },
                 new Country { id = 5, Title = "Spain", Latitude = 40.4637, Longitude = -3.7492 },
                 new Country { id = 6, Title = "Poland", Latitude = 51.9194, Longitude = 19.1451 }
             );


            // Cities with coordinates
            modelBuilder.Entity<City>().HasData(
                new City { id = 1, Title = "New York", CountryId = 1, Latitude = 40.7128, Longitude = -74.0060 },
                new City { id = 2, Title = "Los Angeles", CountryId = 1, Latitude = 34.0522, Longitude = -118.2437 },
                new City { id = 3, Title = "Chicago", CountryId = 1, Latitude = 41.8781, Longitude = -87.6298 },

                new City { id = 4, Title = "Berlin", CountryId = 2, Latitude = 52.5200, Longitude = 13.4050 },
                new City { id = 5, Title = "Munich", CountryId = 2, Latitude = 48.1351, Longitude = 11.5820 },
                new City { id = 6, Title = "Hamburg", CountryId = 2, Latitude = 53.5511, Longitude = 9.9937 },

                new City { id = 7, Title = "Paris", CountryId = 3, Latitude = 48.8566, Longitude = 2.3522 },
                new City { id = 8, Title = "Lyon", CountryId = 3, Latitude = 45.7640, Longitude = 4.8357 },
                new City { id = 9, Title = "Marseille", CountryId = 3, Latitude = 43.2965, Longitude = 5.3698 },

                new City { id = 10, Title = "London", CountryId = 4, Latitude = 51.5074, Longitude = -0.1278 },
                new City { id = 11, Title = "Manchester", CountryId = 4, Latitude = 53.4808, Longitude = -2.2426 },
                new City { id = 12, Title = "Birmingham", CountryId = 4, Latitude = 52.4862, Longitude = -1.8904 },

                new City { id = 13, Title = "Madrid", CountryId = 5, Latitude = 40.4168, Longitude = -3.7038 },
                new City { id = 14, Title = "Barcelona", CountryId = 5, Latitude = 41.3851, Longitude = 2.1734 },
                new City { id = 15, Title = "Valencia", CountryId = 5, Latitude = 39.4699, Longitude = -0.3763 },

                new City { id = 16, Title = "Warsaw", CountryId = 6, Latitude = 52.2297, Longitude = 21.0122 },
                new City { id = 17, Title = "Krakow", CountryId = 6, Latitude = 50.0647, Longitude = 19.9450 },
                new City { id = 18, Title = "Poznan", CountryId = 6, Latitude = 52.4064, Longitude = 16.9252 }
            );

            // Attractions
            modelBuilder.Entity<Attraction>().HasData(
                // USA
                new Attraction { id = 1, CityId = 1, Name = "Statue of Liberty", Description = "Iconic national monument", Latitude = 40.6892, Longitude = -74.0445 },
                new Attraction { id = 2, CityId = 1, Name = "Central Park", Description = "Famous urban park", Latitude = 40.7851, Longitude = -73.9683 },
                new Attraction { id = 3, CityId = 1, Name = "Times Square", Description = "Major commercial intersection", Latitude = 40.7580, Longitude = -73.9855 },
                new Attraction { id = 4, CityId = 1, Name = "Empire State Building", Description = "102-story skyscraper", Latitude = 40.7484, Longitude = -73.9857 },
                new Attraction { id = 5, CityId = 1, Name = "Brooklyn Bridge", Description = "Historic bridge", Latitude = 40.7061, Longitude = -73.9969 },

                new Attraction { id = 6, CityId = 2, Name = "Hollywood Sign", Description = "Famous landmark", Latitude = 34.1341, Longitude = -118.3215 },
                new Attraction { id = 7, CityId = 2, Name = "Santa Monica Pier", Description = "Historic pier", Latitude = 34.0094, Longitude = -118.4973 },
                new Attraction { id = 8, CityId = 2, Name = "Griffith Observatory", Description = "Observatory with city views", Latitude = 34.1184, Longitude = -118.3004 },
                new Attraction { id = 9, CityId = 2, Name = "Getty Center", Description = "Art museum", Latitude = 34.0780, Longitude = -118.4741 },
                new Attraction { id = 10, CityId = 2, Name = "Venice Beach", Description = "Famous beach area", Latitude = 33.9850, Longitude = -118.4695 },

                new Attraction { id = 11, CityId = 3, Name = "Millennium Park", Description = "Public park with art installations", Latitude = 41.8826, Longitude = -87.6226 },
                new Attraction { id = 12, CityId = 3, Name = "Navy Pier", Description = "Pier with attractions and restaurants", Latitude = 41.8917, Longitude = -87.6075 },
                new Attraction { id = 13, CityId = 3, Name = "Willis Tower", Description = "Iconic skyscraper", Latitude = 41.8789, Longitude = -87.6359 },
                new Attraction { id = 14, CityId = 3, Name = "Art Institute of Chicago", Description = "Famous art museum", Latitude = 41.8796, Longitude = -87.6237 },
                new Attraction { id = 15, CityId = 3, Name = "Lincoln Park Zoo", Description = "Historic zoo", Latitude = 41.9210, Longitude = -87.6338 },

                // Germany
                new Attraction { id = 16, CityId = 4, Name = "Brandenburg Gate", Description = "Historic monument", Latitude = 52.5163, Longitude = 13.3777 },
                new Attraction { id = 17, CityId = 4, Name = "Berlin Wall Memorial", Description = "Remains of Berlin Wall", Latitude = 52.5351, Longitude = 13.3903 },
                new Attraction { id = 18, CityId = 4, Name = "Museum Island", Description = "Group of museums", Latitude = 52.5169, Longitude = 13.4010 },
                new Attraction { id = 19, CityId = 4, Name = "Alexanderplatz", Description = "Central square", Latitude = 52.5218, Longitude = 13.4132 },
                new Attraction { id = 20, CityId = 4, Name = "Checkpoint Charlie", Description = "Historic border crossing", Latitude = 52.5076, Longitude = 13.3904 },

                new Attraction { id = 21, CityId = 5, Name = "Marienplatz", Description = "Central square", Latitude = 48.1374, Longitude = 11.5755 },
                new Attraction { id = 22, CityId = 5, Name = "English Garden", Description = "Large public park", Latitude = 48.1593, Longitude = 11.6035 },
                new Attraction { id = 23, CityId = 5, Name = "Nymphenburg Palace", Description = "Historic palace", Latitude = 48.1580, Longitude = 11.5031 },
                new Attraction { id = 24, CityId = 5, Name = "BMW Museum", Description = "Automobile museum", Latitude = 48.1769, Longitude = 11.5560 },
                new Attraction { id = 25, CityId = 5, Name = "Olympiapark", Description = "Sports and entertainment complex", Latitude = 48.1740, Longitude = 11.5560 },

                new Attraction { id = 26, CityId = 6, Name = "Miniatur Wunderland", Description = "Largest model railway", Latitude = 53.5436, Longitude = 9.9886 },
                new Attraction { id = 27, CityId = 6, Name = "Port of Hamburg", Description = "Famous port area", Latitude = 53.5413, Longitude = 9.9666 },
                new Attraction { id = 28, CityId = 6, Name = "Elbphilharmonie", Description = "Concert hall", Latitude = 53.5413, Longitude = 9.9841 },
                new Attraction { id = 29, CityId = 6, Name = "St. Michael's Church", Description = "Historic church", Latitude = 53.5503, Longitude = 9.9729 },
                new Attraction { id = 30, CityId = 6, Name = "Speicherstadt", Description = "Warehouse district", Latitude = 53.5496, Longitude = 9.9882 },

                // France
                new Attraction { id = 31, CityId = 7, Name = "Eiffel Tower", Description = "Famous tower in Paris", Latitude = 48.8584, Longitude = 2.2945 },
                new Attraction { id = 32, CityId = 7, Name = "Louvre Museum", Description = "World famous museum", Latitude = 48.8606, Longitude = 2.3376 },
                new Attraction { id = 33, CityId = 7, Name = "Notre-Dame Cathedral", Description = "Historic cathedral", Latitude = 48.8530, Longitude = 2.3499 },
                new Attraction { id = 34, CityId = 7, Name = "Montmartre", Description = "Historic district", Latitude = 48.8867, Longitude = 2.3431 },
                new Attraction { id = 35, CityId = 7, Name = "Champs-Élysées", Description = "Famous avenue", Latitude = 48.8698, Longitude = 2.3070 },

                new Attraction { id = 36, CityId = 8, Name = "Basilica of Notre-Dame de Fourvière", Description = "Historic church", Latitude = 45.7620, Longitude = 4.8221 },
                new Attraction { id = 37, CityId = 8, Name = "Parc de la Tête d'Or", Description = "Large urban park", Latitude = 45.7793, Longitude = 4.8520 },
                new Attraction { id = 38, CityId = 8, Name = "Vieux Lyon", Description = "Historic district", Latitude = 45.7670, Longitude = 4.8270 },
                new Attraction { id = 39, CityId = 8, Name = "Musée des Beaux-Arts", Description = "Art museum", Latitude = 45.7670, Longitude = 4.8330 },
                new Attraction { id = 40, CityId = 8, Name = "Place Bellecour", Description = "City square", Latitude = 45.7578, Longitude = 4.8320 },

                new Attraction { id = 41, CityId = 9, Name = "Old Port of Marseille", Description = "Historic harbor area", Latitude = 43.2965, Longitude = 5.3698 },
                new Attraction { id = 42, CityId = 9, Name = "Basilique Notre-Dame de la Garde", Description = "Historic basilica", Latitude = 43.2961, Longitude = 5.3624 },
                new Attraction { id = 43, CityId = 9, Name = "Château d'If", Description = "Island fortress", Latitude = 43.2950, Longitude = 5.3270 },
                new Attraction { id = 44, CityId = 9, Name = "La Canebière", Description = "Historic street", Latitude = 43.2960, Longitude = 5.3790 },
                new Attraction { id = 45, CityId = 9, Name = "Palais Longchamp", Description = "Fountain and palace", Latitude = 43.2968, Longitude = 5.3892 },

                // United Kingdom
                new Attraction { id = 46, CityId = 10, Name = "Tower of London", Description = "Historic castle", Latitude = 51.5081, Longitude = -0.0759 },
                new Attraction { id = 47, CityId = 10, Name = "Buckingham Palace", Description = "Royal residence", Latitude = 51.5014, Longitude = -0.1419 },
                new Attraction { id = 48, CityId = 10, Name = "London Eye", Description = "Ferris wheel on Thames", Latitude = 51.5033, Longitude = -0.1195 },
                new Attraction { id = 49, CityId = 10, Name = "British Museum", Description = "Famous museum", Latitude = 51.5194, Longitude = -0.1269 },
                new Attraction { id = 50, CityId = 10, Name = "Big Ben", Description = "Iconic clock tower", Latitude = 51.5007, Longitude = -0.1246 },

                // Manchester
                new Attraction { id = 51, CityId = 11, Name = "Old Trafford", Description = "Football stadium", Latitude = 53.4631, Longitude = -2.2913 },
                new Attraction { id = 52, CityId = 11, Name = "Manchester Cathedral", Description = "Historic cathedral", Latitude = 53.4869, Longitude = -2.2466 },
                new Attraction { id = 53, CityId = 11, Name = "Museum of Science and Industry", Description = "Science museum", Latitude = 53.4772, Longitude = -2.2550 },
                new Attraction { id = 54, CityId = 11, Name = "John Rylands Library", Description = "Historic library", Latitude = 53.4811, Longitude = -2.2461 },
                new Attraction { id = 55, CityId = 11, Name = "Heaton Park", Description = "Large public park", Latitude = 53.5485, Longitude = -2.2185 },

                // Birmingham
                new Attraction { id = 56, CityId = 12, Name = "Birmingham Museum & Art Gallery", Description = "Art museum", Latitude = 52.4797, Longitude = -1.9020 },
                new Attraction { id = 57, CityId = 12, Name = "Cadbury World", Description = "Chocolate museum", Latitude = 52.4862, Longitude = -1.9470 },
                new Attraction { id = 58, CityId = 12, Name = "Birmingham Botanical Gardens", Description = "Historic gardens", Latitude = 52.4626, Longitude = -1.8920 },
                new Attraction { id = 59, CityId = 12, Name = "Thinktank, Birmingham Science Museum", Description = "Science museum", Latitude = 52.4762, Longitude = -1.8931 },
                new Attraction { id = 60, CityId = 12, Name = "Victoria Square", Description = "Public square", Latitude = 52.4786, Longitude = -1.9101 },

                // Spain
                new Attraction { id = 61, CityId = 13, Name = "Royal Palace of Madrid", Description = "Historic palace", Latitude = 40.4179, Longitude = -3.7143 },
                new Attraction { id = 62, CityId = 13, Name = "Puerta del Sol", Description = "Famous square", Latitude = 40.4168, Longitude = -3.7038 },
                new Attraction { id = 63, CityId = 13, Name = "Plaza Mayor", Description = "Historic square", Latitude = 40.4155, Longitude = -3.7074 },
                new Attraction { id = 64, CityId = 13, Name = "Retiro Park", Description = "Large city park", Latitude = 40.4153, Longitude = -3.6846 },
                new Attraction { id = 65, CityId = 13, Name = "Temple of Debod", Description = "Ancient Egyptian temple", Latitude = 40.4240, Longitude = -3.7170 },

                // Barcelona
                new Attraction { id = 66, CityId = 14, Name = "Sagrada Família", Description = "Famous basilica", Latitude = 41.4036, Longitude = 2.1744 },
                new Attraction { id = 67, CityId = 14, Name = "Park Güell", Description = "Public park with architecture", Latitude = 41.4145, Longitude = 2.1527 },
                new Attraction { id = 68, CityId = 14, Name = "La Rambla", Description = "Famous street", Latitude = 41.3809, Longitude = 2.1730 },
                new Attraction { id = 69, CityId = 14, Name = "Casa Batlló", Description = "Famous building", Latitude = 41.3917, Longitude = 2.1649 },
                new Attraction { id = 70, CityId = 14, Name = "Montjuïc", Description = "Historic hill", Latitude = 41.3633, Longitude = 2.1583 },

                // Valencia
                new Attraction { id = 71, CityId = 15, Name = "City of Arts and Sciences", Description = "Cultural complex", Latitude = 39.4540, Longitude = -0.3510 },
                new Attraction { id = 72, CityId = 15, Name = "Valencia Cathedral", Description = "Historic cathedral", Latitude = 39.4753, Longitude = -0.3768 },
                new Attraction { id = 73, CityId = 15, Name = "L'Oceanogràfic", Description = "Oceanarium", Latitude = 39.4546, Longitude = -0.3415 },
                new Attraction { id = 74, CityId = 15, Name = "Turia Gardens", Description = "Urban park", Latitude = 39.4699, Longitude = -0.3753 },
                new Attraction { id = 75, CityId = 15, Name = "La Lonja de la Seda", Description = "Historic building", Latitude = 39.4747, Longitude = -0.3763 },

                // Poland
                new Attraction { id = 76, CityId = 16, Name = "Royal Castle", Description = "Historic castle", Latitude = 52.2450, Longitude = 21.0166 },
                new Attraction { id = 77, CityId = 16, Name = "Łazienki Park", Description = "Urban park with palace", Latitude = 52.2167, Longitude = 21.0333 },
                new Attraction { id = 78, CityId = 16, Name = "Palace of Culture and Science", Description = "Tallest building in Warsaw", Latitude = 52.2319, Longitude = 21.0067 },
                new Attraction { id = 79, CityId = 16, Name = "Old Town Market Square", Description = "Historic square", Latitude = 52.2490, Longitude = 21.0122 },
                new Attraction { id = 80, CityId = 16, Name = "Wilanów Palace", Description = "Baroque palace", Latitude = 52.1919, Longitude = 21.0609 },

                // Kraków
                new Attraction { id = 81, CityId = 17, Name = "Wawel Castle", Description = "Historic castle", Latitude = 50.0540, Longitude = 19.9350 },
                new Attraction { id = 82, CityId = 17, Name = "Main Market Square", Description = "Historic square", Latitude = 50.0614, Longitude = 19.9360 },
                new Attraction { id = 83, CityId = 17, Name = "St. Mary's Basilica", Description = "Historic church", Latitude = 50.0610, Longitude = 19.9370 },
                new Attraction { id = 84, CityId = 17, Name = "Kazimierz District", Description = "Historic Jewish district", Latitude = 50.0500, Longitude = 19.9450 },
                new Attraction { id = 85, CityId = 17, Name = "Schindler's Factory", Description = "Historic museum", Latitude = 50.0510, Longitude = 19.9600 },

                // Poznań
                new Attraction { id = 86, CityId = 18, Name = "Old Market Square", Description = "Historic square", Latitude = 52.4084, Longitude = 16.9342 },
                new Attraction { id = 87, CityId = 18, Name = "Cathedral Island", Description = "Historic island", Latitude = 52.4087, Longitude = 16.9370 },
                new Attraction { id = 88, CityId = 18, Name = "Poznań Town Hall", Description = "Renaissance-style town hall", Latitude = 52.4089, Longitude = 16.9345 },
                new Attraction { id = 89, CityId = 18, Name = "Imperial Castle", Description = "Historic castle and cultural center", Latitude = 52.4095, Longitude = 16.9290 },
                new Attraction { id = 90, CityId = 18, Name = "Malta Lake", Description = "Popular recreational area with water sports", Latitude = 52.4025, Longitude = 16.9717 }



            );



            // Сиды категорий
            modelBuilder.Entity<ParamsCategory>().HasData(
                new ParamsCategory { id = 1, Title = "General" },
                new ParamsCategory { id = 2, Title = "Building" },
                new ParamsCategory { id = 3, Title = "Location" },
                new ParamsCategory { id = 4, Title = "Outdoors" },
                new ParamsCategory { id = 5, Title = "Services" },
                new ParamsCategory { id = 6, Title = "Food & Drink" },
                new ParamsCategory { id = 7, Title = "Wellness & Recreation" },
                new ParamsCategory { id = 8, Title = "Room Facilities" },
                new ParamsCategory { id = 9, Title = "Beds & Sleeping" },
                new ParamsCategory { id = 10, Title = "Kitchen" },
                new ParamsCategory { id = 11, Title = "Bathroom" },
                new ParamsCategory { id = 12, Title = "Safety" }


            );

            // Сиды параметров (ParamItem)
            modelBuilder.Entity<ParamItem>().HasData(
                // General
                new ParamItem { id = 1, CategoryId = 1, Title = "Free WiFi", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 2, CategoryId = 1, Title = "Non‑smoking rooms", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 3, CategoryId = 1, Title = "Air conditioning", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 4, CategoryId = 1, Title = "Heating", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 5, CategoryId = 1, Title = "Pets allowed", ValueType = ParamValueType.Boolean },

                // Building
                new ParamItem { id = 6, CategoryId = 2, Title = "Elevator", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 7, CategoryId = 2, Title = "24‑hour front desk", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 8, CategoryId = 2, Title = "Security", ValueType = ParamValueType.Boolean },

                // Location
                new ParamItem { id = 9, CategoryId = 3, Title = "Parking", ValueType = ParamValueType.Boolean },

                // Outdoors
                new ParamItem { id = 10, CategoryId = 4, Title = "Garden", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 11, CategoryId = 4, Title = "Terrace", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 12, CategoryId = 4, Title = "BBQ / Picnic area", ValueType = ParamValueType.Boolean },

                // Services
                new ParamItem { id = 13, CategoryId = 5, Title = "Airport shuttle", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 14, CategoryId = 5, Title = "Laundry", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 15, CategoryId = 5, Title = "Dry cleaning", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 16, CategoryId = 5, Title = "Concierge", ValueType = ParamValueType.Boolean },

                // Food & Drink
                new ParamItem { id = 17, CategoryId = 6, Title = "Restaurant", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 18, CategoryId = 6, Title = "Bar", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 19, CategoryId = 6, Title = "Breakfast included", ValueType = ParamValueType.Boolean },

                // Wellness & Recreation
                new ParamItem { id = 20, CategoryId = 7, Title = "Fitness center", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 21, CategoryId = 7, Title = "Sauna", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 22, CategoryId = 7, Title = "Outdoor pool", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 23, CategoryId = 7, Title = "Indoor pool", ValueType = ParamValueType.Boolean },

                // Room Facilities
                new ParamItem { id = 24, CategoryId = 8, Title = "Shower", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 25, CategoryId = 8, Title = "Bathtub", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 26, CategoryId = 8, Title = "Hair dryer", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 27, CategoryId = 8, Title = "TV", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 28, CategoryId = 8, Title = "Minibar", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 29, CategoryId = 8, Title = "Safe", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 30, CategoryId = 8, Title = "City view", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 31, CategoryId = 8, Title = "Quiet street view", ValueType = ParamValueType.Boolean },

                // Beds & Sleeping
                new ParamItem { id = 32, CategoryId = 9, Title = "Double bed", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 33, CategoryId = 9, Title = "Sofa bed", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 34, CategoryId = 9, Title = "Both double and sofa bed", ValueType = ParamValueType.Boolean },



                //distance from center
                new ParamItem { id = 35, CategoryId = 3, Title = "Distance from center (km)", ValueType = ParamValueType.Double },
                new ParamItem { id = 36, CategoryId = 3, Title = "Distance to airport (km)", ValueType = ParamValueType.Double },
                new ParamItem { id = 37, CategoryId = 3, Title = "Distance to metro (km)", ValueType = ParamValueType.Double },
                new ParamItem { id = 38, CategoryId = 3, Title = "Distance to beach (km)", ValueType = ParamValueType.Double },

             
                new ParamItem { id = 39, CategoryId = 8, Title = "City view", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 40, CategoryId = 8, Title = "Quiet street view", ValueType = ParamValueType.Boolean },

                new ParamItem { id = 41, CategoryId = 8, Title = "Air purifier", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 42, CategoryId = 8, Title = "Desk / Workspace", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 43, CategoryId = 8, Title = "Flat-screen TV", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 44, CategoryId = 8, Title = "Streaming services (Netflix)", ValueType = ParamValueType.Boolean },

                // Beds & Sleeping - counts
                new ParamItem { id = 45, CategoryId = 9, Title = "Single bed", ValueType = ParamValueType.Int },
                new ParamItem { id = 46, CategoryId = 9, Title = "Double bed", ValueType = ParamValueType.Int },
                new ParamItem { id = 47, CategoryId = 9, Title = "Queen size bed", ValueType = ParamValueType.Int },
                new ParamItem { id = 48, CategoryId = 9, Title = "King size bed", ValueType = ParamValueType.Int },
                new ParamItem { id = 49, CategoryId = 9, Title = "Sofa bed", ValueType = ParamValueType.Int },
                new ParamItem { id = 50, CategoryId = 9, Title = "Bunk bed", ValueType = ParamValueType.Int },
                new ParamItem { id = 51, CategoryId = 9, Title = "Baby crib", ValueType = ParamValueType.Int },
                new ParamItem { id = 52, CategoryId = 9, Title = "Child bed", ValueType = ParamValueType.Int },

                // Kitchen

                new ParamItem { id = 53, CategoryId = 10, Title = "Kitchen", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 54, CategoryId = 10, Title = "Refrigerator", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 55, CategoryId = 10, Title = "Microwave", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 56, CategoryId = 10, Title = "Stovetop", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 57, CategoryId = 10, Title = "Dishwasher", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 58, CategoryId = 10, Title = "Kitchenware", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 59, CategoryId = 10, Title = "Electric kettle", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 60, CategoryId = 10, Title = "Coffee machine", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 61, CategoryId = 10, Title = "Toaster", ValueType = ParamValueType.Boolean },

                // Bathroom
                new ParamItem { id = 62, CategoryId = 11, Title = "Shampoo", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 63, CategoryId = 11, Title = "Soap", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 64, CategoryId = 11, Title = "Towels", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 65, CategoryId = 11, Title = "Hot water", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 66, CategoryId = 11, Title = "Washing machine", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 67, CategoryId = 11, Title = "Dryer", ValueType = ParamValueType.Boolean },

                // Safety
                new ParamItem { id = 68, CategoryId = 12, Title = "Smoke detector", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 69, CategoryId = 12, Title = "Fire extinguisher", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 70, CategoryId = 12, Title = "First aid kit", ValueType = ParamValueType.Boolean },
                new ParamItem { id = 71, CategoryId = 12, Title = "Exterior security cameras", ValueType = ParamValueType.Boolean }






            );
        }
    }
}
