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
                new Country { id = 1, Title = "United States", Latitude = 39.8283, Longitude = -98.5795 },
                new Country { id = 2, Title = "Germany", Latitude = 51.1657, Longitude = 10.4515 },
                new Country { id = 3, Title = "France", Latitude = 46.6034, Longitude = 1.8883 },
                new Country { id = 4, Title = "United Kingdom", Latitude = 55.3781, Longitude = -3.4360 },
                new Country { id = 5, Title = "Spain", Latitude = 40.4637, Longitude = -3.7492 },
                new Country { id = 6, Title = "Poland", Latitude = 51.9194, Longitude = 19.1451 }
            );



            // Regions
            modelBuilder.Entity<Region>().HasData(

                // USA
                new Region { id = 1, Title = "New York State", CountryId = 1, Latitude = 42.1657, Longitude = -74.9481 },
                new Region { id = 2, Title = "California", CountryId = 1, Latitude = 36.7783, Longitude = -119.4179 },
                new Region { id = 3, Title = "Illinois", CountryId = 1, Latitude = 40.6331, Longitude = -89.3985 },

                // Germany
                new Region { id = 4, Title = "Berlin Region", CountryId = 2, Latitude = 52.5200, Longitude = 13.4050 },
                new Region { id = 5, Title = "Bavaria", CountryId = 2, Latitude = 48.7904, Longitude = 11.4979 },
                new Region { id = 6, Title = "Hamburg Region", CountryId = 2, Latitude = 53.5511, Longitude = 9.9937 },

                // France
                new Region { id = 7, Title = "Île-de-France", CountryId = 3, Latitude = 48.8499, Longitude = 2.6370 },
                new Region { id = 8, Title = "Auvergne-Rhône-Alpes", CountryId = 3, Latitude = 45.7640, Longitude = 4.8357 },
                new Region { id = 9, Title = "Provence-Alpes-Côte d’Azur", CountryId = 3, Latitude = 43.9352, Longitude = 6.0679 },

                // UK
                new Region { id = 10, Title = "Greater London", CountryId = 4, Latitude = 51.5074, Longitude = -0.1278 },
                new Region { id = 11, Title = "Greater Manchester", CountryId = 4, Latitude = 53.4808, Longitude = -2.2426 },
                new Region { id = 12, Title = "West Midlands", CountryId = 4, Latitude = 52.4862, Longitude = -1.8904 },

                // Spain
                new Region { id = 13, Title = "Community of Madrid", CountryId = 5, Latitude = 40.4168, Longitude = -3.7038 },
                new Region { id = 14, Title = "Catalonia", CountryId = 5, Latitude = 41.3851, Longitude = 2.1734 },
                new Region { id = 15, Title = "Valencian Community", CountryId = 5, Latitude = 39.4699, Longitude = -0.3763 },

                // Poland
                new Region { id = 16, Title = "Masovian", CountryId = 6, Latitude = 52.2297, Longitude = 21.0122 },
                new Region { id = 17, Title = "Lesser Poland", CountryId = 6, Latitude = 50.0647, Longitude = 19.9450 },
                new Region { id = 18, Title = "Greater Poland", CountryId = 6, Latitude = 52.4064, Longitude = 16.9252 }
            );




            modelBuilder.Entity<City>().HasData(
                // USA
                new City { id = 1, Title = "New York", RegionId = 1, Latitude = 40.7128, Longitude = -74.0060 },
                new City { id = 2, Title = "Los Angeles", RegionId = 2, Latitude = 34.0522, Longitude = -118.2437 },
                new City { id = 3, Title = "Chicago", RegionId = 3, Latitude = 41.8781, Longitude = -87.6298 },

                // Germany
                new City { id = 4, Title = "Berlin", RegionId = 4, Latitude = 52.5200, Longitude = 13.4050 },
                new City { id = 5, Title = "Munich", RegionId = 5, Latitude = 48.1351, Longitude = 11.5820 },
                new City { id = 6, Title = "Hamburg", RegionId = 6, Latitude = 53.5511, Longitude = 9.9937 },

                // France
                new City { id = 7, Title = "Paris", RegionId = 7, Latitude = 48.8566, Longitude = 2.3522 },
                new City { id = 8, Title = "Lyon", RegionId = 8, Latitude = 45.7640, Longitude = 4.8357 },
                new City { id = 9, Title = "Marseille", RegionId = 9, Latitude = 43.2965, Longitude = 5.3698 },

                // UK
                new City { id = 10, Title = "London", RegionId = 10, Latitude = 51.5074, Longitude = -0.1278 },
                new City { id = 11, Title = "Manchester", RegionId = 11, Latitude = 53.4808, Longitude = -2.2426 },
                new City { id = 12, Title = "Birmingham", RegionId = 12, Latitude = 52.4862, Longitude = -1.8904 },

                // Spain
                new City { id = 13, Title = "Madrid", RegionId = 13, Latitude = 40.4168, Longitude = -3.7038 },
                new City { id = 14, Title = "Barcelona", RegionId = 14, Latitude = 41.3851, Longitude = 2.1734 },
                new City { id = 15, Title = "Valencia", RegionId = 15, Latitude = 39.4699, Longitude = -0.3763 },

                // Poland
                new City { id = 16, Title = "Warsaw", RegionId = 16, Latitude = 52.2297, Longitude = 21.0122 },
                new City { id = 17, Title = "Krakow", RegionId = 17, Latitude = 50.0647, Longitude = 19.9450 },
                new City { id = 18, Title = "Poznan", RegionId = 18, Latitude = 52.4064, Longitude = 16.9252 }
            );


            modelBuilder.Entity<District>().HasData(
                // --- New York ---
                new District { id = 1, Title = "Manhattan", CityId = 1, Latitude = 40.7831, Longitude = -73.9712 },
                new District { id = 2, Title = "Brooklyn", CityId = 1, Latitude = 40.6782, Longitude = -73.9442 },
                new District { id = 3, Title = "Queens", CityId = 1, Latitude = 40.7282, Longitude = -73.7949 },

                // --- Los Angeles ---
                new District { id = 4, Title = "Hollywood", CityId = 2, Latitude = 34.0928, Longitude = -118.3287 },
                new District { id = 5, Title = "Downtown", CityId = 2, Latitude = 34.0407, Longitude = -118.2468 },
                new District { id = 6, Title = "Beverly Hills", CityId = 2, Latitude = 34.0736, Longitude = -118.4004 },

                // --- Chicago ---
                new District { id = 7, Title = "The Loop", CityId = 3, Latitude = 41.8837, Longitude = -87.6325 },
                new District { id = 8, Title = "Lincoln Park", CityId = 3, Latitude = 41.9214, Longitude = -87.6513 },
                new District { id = 9, Title = "Hyde Park", CityId = 3, Latitude = 41.7943, Longitude = -87.5907 },

                // --- Berlin ---
                new District { id = 10, Title = "Mitte", CityId = 4, Latitude = 52.5200, Longitude = 13.4049 },
                new District { id = 11, Title = "Kreuzberg", CityId = 4, Latitude = 52.4990, Longitude = 13.4030 },
                new District { id = 12, Title = "Charlottenburg", CityId = 4, Latitude = 52.5167, Longitude = 13.3041 },

                // --- Munich ---
                new District { id = 13, Title = "Old Town – Lehel", CityId = 5, Latitude = 48.1374, Longitude = 11.5755 },
                new District { id = 14, Title = "Maxvorstadt", CityId = 5, Latitude = 48.1500, Longitude = 11.5670 },
                new District { id = 15, Title = "Schwabing", CityId = 5, Latitude = 48.1690, Longitude = 11.5800 },

                // --- Hamburg ---
                new District { id = 16, Title = "Altona", CityId = 6, Latitude = 53.5511, Longitude = 9.9410 },
                new District { id = 17, Title = "St. Pauli", CityId = 6, Latitude = 53.5565, Longitude = 9.9640 },
                new District { id = 18, Title = "Eimsbuettel", CityId = 6, Latitude = 53.5830, Longitude = 9.9650 },

                // --- Paris ---
                new District { id = 19, Title = "Montmartre", CityId = 7, Latitude = 48.8867, Longitude = 2.3431 },
                new District { id = 20, Title = "Latin Quarter", CityId = 7, Latitude = 48.8494, Longitude = 2.3470 },
                new District { id = 21, Title = "Le Marais", CityId = 7, Latitude = 48.8590, Longitude = 2.3622 },

                // --- Lyon ---
                new District { id = 22, Title = "Old Lyon", CityId = 8, Latitude = 45.7601, Longitude = 4.8260 },
                new District { id = 23, Title = "Presqu'Île", CityId = 8, Latitude = 45.7597, Longitude = 4.8330 },
                new District { id = 24, Title = "Croix-Rousse", CityId = 8, Latitude = 45.7764, Longitude = 4.8272 },

                // --- Marseille ---
                new District { id = 25, Title = "Le Panier", CityId = 9, Latitude = 43.2990, Longitude = 5.3710 },
                new District { id = 26, Title = "Old Port", CityId = 9, Latitude = 43.2963, Longitude = 5.3699 },
                new District { id = 27, Title = "La Castellane", CityId = 9, Latitude = 43.3220, Longitude = 5.3970 },

                // --- London ---
                new District { id = 28, Title = "Camden", CityId = 10, Latitude = 51.5390, Longitude = -0.1420 },
                new District { id = 29, Title = "Westminster", CityId = 10, Latitude = 51.4975, Longitude = -0.1357 },
                new District { id = 30, Title = "Greenwich", CityId = 10, Latitude = 51.4826, Longitude = 0.0077 },

                // --- Manchester ---
                new District { id = 31, Title = "Northern Quarter", CityId = 11, Latitude = 53.4840, Longitude = -2.2350 },
                new District { id = 32, Title = "Didsbury", CityId = 11, Latitude = 53.4160, Longitude = -2.2310 },
                new District { id = 33, Title = "Salford Quays", CityId = 11, Latitude = 53.4740, Longitude = -2.2920 },

                // --- Birmingham ---
                new District { id = 34, Title = "Edgbaston", CityId = 12, Latitude = 52.4550, Longitude = -1.9250 },
                new District { id = 35, Title = "Jewellery Quarter", CityId = 12, Latitude = 52.4896, Longitude = -1.9129 },
                new District { id = 36, Title = "Selly Oak", CityId = 12, Latitude = 52.4415, Longitude = -1.9369 },

                // --- Madrid ---
                new District { id = 37, Title = "Centro", CityId = 13, Latitude = 40.4167, Longitude = -3.7033 },
                new District { id = 38, Title = "Salamanca", CityId = 13, Latitude = 40.4297, Longitude = -3.6860 },
                new District { id = 39, Title = "Chamartin", CityId = 13, Latitude = 40.4589, Longitude = -3.6779 },

                // --- Barcelona ---
                new District { id = 40, Title = "Eixample", CityId = 14, Latitude = 41.3900, Longitude = 2.1650 },
                new District { id = 41, Title = "Gothic Quarter", CityId = 14, Latitude = 41.3833, Longitude = 2.1767 },
                new District { id = 42, Title = "Gracia", CityId = 14, Latitude = 41.4036, Longitude = 2.1566 },

                // --- Valencia ---
                new District { id = 43, Title = "Old Town", CityId = 15, Latitude = 39.4740, Longitude = -0.3763 },
                new District { id = 44, Title = "Ruzafa", CityId = 15, Latitude = 39.4640, Longitude = -0.3760 },
                new District { id = 45, Title = "El Cabanyal", CityId = 15, Latitude = 39.4700, Longitude = -0.3200 },

                // --- Warsaw ---
                new District { id = 46, Title = "City Centre", CityId = 16, Latitude = 52.2310, Longitude = 21.0122 },
                new District { id = 47, Title = "Wola", CityId = 16, Latitude = 52.2400, Longitude = 20.9800 },
                new District { id = 48, Title = "Praga North", CityId = 16, Latitude = 52.2550, Longitude = 21.0300 },

                // --- Krakow ---
                new District { id = 49, Title = "Old Town", CityId = 17, Latitude = 50.0614, Longitude = 19.9372 },
                new District { id = 50, Title = "Kazimierz", CityId = 17, Latitude = 50.0515, Longitude = 19.9440 },
                new District { id = 51, Title = "Podgorze", CityId = 17, Latitude = 50.0400, Longitude = 19.9500 },

                // --- Poznan ---
                new District { id = 52, Title = "Old Town", CityId = 18, Latitude = 52.4095, Longitude = 16.9319 },
                new District { id = 53, Title = "Lazarz", CityId = 18, Latitude = 52.3980, Longitude = 16.9030 },
                new District { id = 54, Title = "Wilda", CityId = 18, Latitude = 52.3930, Longitude = 16.9260 }
            );


                // Attractions
             modelBuilder.Entity<Attraction>().HasData(

                    // USA  
                    // --- New York (Districts 1–3) ---
                new Attraction { id = 1, DistrictId = 1, Title = "Statue of Liberty", Description = "Iconic national monument", Latitude = 40.6892, Longitude = -74.0445 },
                new Attraction { id = 2, DistrictId = 1, Title = "Central Park", Description = "Famous urban park", Latitude = 40.7851, Longitude = -73.9683 },
                new Attraction { id = 3, DistrictId = 1, Title = "Times Square", Description = "Major commercial intersection", Latitude = 40.7580, Longitude = -73.9855 },
                new Attraction { id = 4, DistrictId = 2, Title = "Brooklyn Bridge", Description = "Historic bridge", Latitude = 40.7061, Longitude = -73.9969 },
                new Attraction { id = 5, DistrictId = 3, Title = "Empire State Building", Description = "102-story skyscraper", Latitude = 40.7484, Longitude = -73.9857 },

                // --- Los Angeles (Districts 4–6) ---
                new Attraction { id = 6, DistrictId = 4, Title = "Hollywood Sign", Description = "Famous landmark", Latitude = 34.1341, Longitude = -118.3215 },
                new Attraction { id = 7, DistrictId = 5, Title = "Santa Monica Pier", Description = "Historic pier", Latitude = 34.0094, Longitude = -118.4973 },
                new Attraction { id = 8, DistrictId = 4, Title = "Griffith Observatory", Description = "Observatory with city views", Latitude = 34.1184, Longitude = -118.3004 },
                new Attraction { id = 9, DistrictId = 5, Title = "Getty Center", Description = "Art museum", Latitude = 34.0780, Longitude = -118.4741 },
                new Attraction { id = 10, DistrictId = 6, Title = "Venice Beach", Description = "Famous beach area", Latitude = 33.9850, Longitude = -118.4695 },

                // --- Chicago (Districts 7–9) ---
                new Attraction { id = 11, DistrictId = 7, Title = "Millennium Park", Description = "Public park with art installations", Latitude = 41.8826, Longitude = -87.6226 },
                new Attraction { id = 12, DistrictId = 7, Title = "Art Institute of Chicago", Description = "Famous art museum", Latitude = 41.8796, Longitude = -87.6237 },
                new Attraction { id = 13, DistrictId = 8, Title = "Navy Pier", Description = "Pier with attractions and restaurants", Latitude = 41.8917, Longitude = -87.6075 },
                new Attraction { id = 14, DistrictId = 9, Title = "Willis Tower", Description = "Iconic skyscraper", Latitude = 41.8789, Longitude = -87.6359 },
                new Attraction { id = 15, DistrictId = 8, Title = "Lincoln Park Zoo", Description = "Historic zoo", Latitude = 41.9210, Longitude = -87.6338 },


                            // Germany
                new Attraction { id = 16, DistrictId = 10, Title = "Brandenburg Gate", Description = "Historic monument", Latitude = 52.5163, Longitude = 13.3777 },
                new Attraction { id = 17, DistrictId = 11, Title = "Berlin Wall Memorial", Description = "Remains of Berlin Wall", Latitude = 52.5351, Longitude = 13.3903 },
                new Attraction { id = 18, DistrictId = 10, Title = "Museum Island", Description = "Group of museums", Latitude = 52.5169, Longitude = 13.4010 },
                new Attraction { id = 19, DistrictId = 11, Title = "Alexanderplatz", Description = "Central square", Latitude = 52.5218, Longitude = 13.4132 },
                new Attraction { id = 20, DistrictId = 12, Title = "Checkpoint Charlie", Description = "Historic border crossing", Latitude = 52.5076, Longitude = 13.3904 },

                new Attraction { id = 21, DistrictId = 13, Title = "Marienplatz", Description = "Central square", Latitude = 48.1374, Longitude = 11.5755 },
                new Attraction { id = 22, DistrictId = 14, Title = "English Garden", Description = "Large public park", Latitude = 48.1593, Longitude = 11.6035 },
                new Attraction { id = 23, DistrictId = 13, Title = "Nymphenburg Palace", Description = "Historic palace", Latitude = 48.1580, Longitude = 11.5031 },
                new Attraction { id = 24, DistrictId = 14, Title = "BMW Museum", Description = "Automobile museum", Latitude = 48.1769, Longitude = 11.5560 },
                new Attraction { id = 25, DistrictId = 15, Title = "Olympiapark", Description = "Sports and entertainment complex", Latitude = 48.1740, Longitude = 11.5560 },

                new Attraction { id = 26, DistrictId = 16, Title = "Miniatur Wunderland", Description = "Largest model railway", Latitude = 53.5436, Longitude = 9.9886 },
                new Attraction { id = 27, DistrictId = 17, Title = "Port of Hamburg", Description = "Famous port area", Latitude = 53.5413, Longitude = 9.9666 },
                new Attraction { id = 28, DistrictId = 16, Title = "Elbphilharmonie", Description = "Concert hall", Latitude = 53.5413, Longitude = 9.9841 },
                new Attraction { id = 29, DistrictId = 18, Title = "St. Michael's Church", Description = "Historic church", Latitude = 53.5503, Longitude = 9.9729 },
                new Attraction { id = 30, DistrictId = 16, Title = "Speicherstadt", Description = "Warehouse district", Latitude = 53.5496, Longitude = 9.9882 },


                // France
                new Attraction { id = 31, DistrictId = 19, Title = "Eiffel Tower", Description = "Famous tower in Paris", Latitude = 48.8584, Longitude = 2.2945 },
                new Attraction { id = 32, DistrictId = 20, Title = "Louvre Museum", Description = "World famous museum", Latitude = 48.8606, Longitude = 2.3376 },
                new Attraction { id = 33, DistrictId = 19, Title = "Notre-Dame Cathedral", Description = "Historic cathedral", Latitude = 48.8530, Longitude = 2.3499 },
                new Attraction { id = 34, DistrictId = 19, Title = "Montmartre", Description = "Historic district", Latitude = 48.8867, Longitude = 2.3431 },
                new Attraction { id = 35, DistrictId = 20, Title = "Champs-Élysées", Description = "Famous avenue", Latitude = 48.8698, Longitude = 2.3070 },

                new Attraction { id = 36, DistrictId = 22, Title = "Basilica of Notre-Dame de Fourvière", Description = "Historic church", Latitude = 45.7620, Longitude = 4.8221 },
                new Attraction { id = 37, DistrictId = 23, Title = "Parc de la Tête d'Or", Description = "Large urban park", Latitude = 45.7793, Longitude = 4.8520 },
                new Attraction { id = 38, DistrictId = 22, Title = "Vieux Lyon", Description = "Historic district", Latitude = 45.7670, Longitude = 4.8270 },
                new Attraction { id = 39, DistrictId = 23, Title = "Musée des Beaux-Arts", Description = "Art museum", Latitude = 45.7670, Longitude = 4.8330 },
                new Attraction { id = 40, DistrictId = 24, Title = "Place Bellecour", Description = "City square", Latitude = 45.7578, Longitude = 4.8320 },

                new Attraction { id = 41, DistrictId = 25, Title = "Old Port of Marseille", Description = "Historic harbor area", Latitude = 43.2965, Longitude = 5.3698 },
                new Attraction { id = 42, DistrictId = 26, Title = "Basilique Notre-Dame de la Garde", Description = "Historic basilica", Latitude = 43.2961, Longitude = 5.3624 },
                new Attraction { id = 43, DistrictId = 25, Title = "Château d'If", Description = "Island fortress", Latitude = 43.2950, Longitude = 5.3270 },
                new Attraction { id = 44, DistrictId = 26, Title = "La Canebière", Description = "Historic street", Latitude = 43.2960, Longitude = 5.3790 },
                new Attraction { id = 45, DistrictId = 27, Title = "Palais Longchamp", Description = "Fountain and palace", Latitude = 43.2968, Longitude = 5.3892 },


                // United Kingdom
                // London
                new Attraction { id = 46, DistrictId = 28, Title = "Tower of London", Description = "Historic castle", Latitude = 51.5081, Longitude = -0.0759 },
                new Attraction { id = 47, DistrictId = 29, Title = "Buckingham Palace", Description = "Royal residence", Latitude = 51.5014, Longitude = -0.1419 },
                new Attraction { id = 48, DistrictId = 28, Title = "London Eye", Description = "Ferris wheel on Thames", Latitude = 51.5033, Longitude = -0.1195 },
                new Attraction { id = 49, DistrictId = 30, Title = "British Museum", Description = "Famous museum", Latitude = 51.5194, Longitude = -0.1269 },
                new Attraction { id = 50, DistrictId = 29, Title = "Big Ben", Description = "Iconic clock tower", Latitude = 51.5007, Longitude = -0.1246 },

                // Manchester
                new Attraction { id = 51, DistrictId = 31, Title = "Old Trafford", Description = "Football stadium", Latitude = 53.4631, Longitude = -2.2913 },
                new Attraction { id = 52, DistrictId = 32, Title = "Manchester Cathedral", Description = "Historic cathedral", Latitude = 53.4869, Longitude = -2.2466 },
                new Attraction { id = 53, DistrictId = 31, Title = "Museum of Science and Industry", Description = "Science museum", Latitude = 53.4772, Longitude = -2.2550 },
                new Attraction { id = 54, DistrictId = 32, Title = "John Rylands Library", Description = "Historic library", Latitude = 53.4811, Longitude = -2.2461 },
                new Attraction { id = 55, DistrictId = 33, Title = "Heaton Park", Description = "Large public park", Latitude = 53.5485, Longitude = -2.2185 },


                // Birmingham
                new Attraction { id = 56, DistrictId = 34, Title = "Birmingham Museum & Art Gallery", Description = "Art museum", Latitude = 52.4797, Longitude = -1.9020 },
                new Attraction { id = 57, DistrictId = 35, Title = "Cadbury World", Description = "Chocolate museum", Latitude = 52.4862, Longitude = -1.9470 },
                new Attraction { id = 58, DistrictId = 36, Title = "Birmingham Botanical Gardens", Description = "Historic gardens", Latitude = 52.4626, Longitude = -1.8920 },
                new Attraction { id = 59, DistrictId = 34, Title = "Thinktank, Birmingham Science Museum", Description = "Science museum", Latitude = 52.4762, Longitude = -1.8931 },
                new Attraction { id = 60, DistrictId = 35, Title = "Victoria Square", Description = "Public square", Latitude = 52.4786, Longitude = -1.9101 },

                // Spain
                // Madrid
                new Attraction { id = 61, DistrictId = 37, Title = "Royal Palace of Madrid", Description = "Historic palace", Latitude = 40.4179, Longitude = -3.7143 },
                new Attraction { id = 62, DistrictId = 38, Title = "Puerta del Sol", Description = "Famous square", Latitude = 40.4168, Longitude = -3.7038 },
                new Attraction { id = 63, DistrictId = 37, Title = "Plaza Mayor", Description = "Historic square", Latitude = 40.4155, Longitude = -3.7074 },
                new Attraction { id = 64, DistrictId = 38, Title = "Retiro Park", Description = "Large city park", Latitude = 40.4153, Longitude = -3.6846 },
                new Attraction { id = 65, DistrictId = 39, Title = "Temple of Debod", Description = "Ancient Egyptian temple", Latitude = 40.4240, Longitude = -3.7170 },

                // Barcelona
                new Attraction { id = 66, DistrictId = 40, Title = "Sagrada Família", Description = "Famous basilica", Latitude = 41.4036, Longitude = 2.1744 },
                new Attraction { id = 67, DistrictId = 41, Title = "Park Güell", Description = "Public park with architecture", Latitude = 41.4145, Longitude = 2.1527 },
                new Attraction { id = 68, DistrictId = 40, Title = "La Rambla", Description = "Famous street", Latitude = 41.3809, Longitude = 2.1730 },
                new Attraction { id = 69, DistrictId = 41, Title = "Casa Batlló", Description = "Famous building", Latitude = 41.3917, Longitude = 2.1649 },
                new Attraction { id = 70, DistrictId = 42, Title = "Montjuïc", Description = "Historic hill", Latitude = 41.3633, Longitude = 2.1583 },

                // Valencia
                new Attraction { id = 71, DistrictId = 43, Title = "City of Arts and Sciences", Description = "Cultural complex", Latitude = 39.4540, Longitude = -0.3510 },
                new Attraction { id = 72, DistrictId = 44, Title = "Valencia Cathedral", Description = "Historic cathedral", Latitude = 39.4753, Longitude = -0.3768 },
                new Attraction { id = 73, DistrictId = 43, Title = "L'Oceanogràfic", Description = "Oceanarium", Latitude = 39.4546, Longitude = -0.3415 },
                new Attraction { id = 74, DistrictId = 44, Title = "Turia Gardens", Description = "Urban park", Latitude = 39.4699, Longitude = -0.3753 },
                new Attraction { id = 75, DistrictId = 45, Title = "La Lonja de la Seda", Description = "Historic building", Latitude = 39.4747, Longitude = -0.3763 },

                // Poland
                // Poland
                // Warsaw
                new Attraction { id = 76, DistrictId = 46, Title = "Royal Castle", Description = "Historic castle", Latitude = 52.2450, Longitude = 21.0166 },
                new Attraction { id = 77, DistrictId = 47, Title = "Łazienki Park", Description = "Urban park with palace", Latitude = 52.2167, Longitude = 21.0333 },
                new Attraction { id = 78, DistrictId = 46, Title = "Palace of Culture and Science", Description = "Tallest building in Warsaw", Latitude = 52.2319, Longitude = 21.0067 },
                new Attraction { id = 79, DistrictId = 47, Title = "Old Town Market Square", Description = "Historic square", Latitude = 52.2490, Longitude = 21.0122 },
                new Attraction { id = 80, DistrictId = 48, Title = "Wilanów Palace", Description = "Baroque palace", Latitude = 52.1919, Longitude = 21.0609 },

                // Kraków
                new Attraction { id = 81, DistrictId = 49, Title = "Wawel Castle", Description = "Historic castle", Latitude = 50.0540, Longitude = 19.9350 },
                new Attraction { id = 82, DistrictId = 50, Title = "Main Market Square", Description = "Historic square", Latitude = 50.0614, Longitude = 19.9360 },
                new Attraction { id = 83, DistrictId = 49, Title = "St. Mary's Basilica", Description = "Historic church", Latitude = 50.0610, Longitude = 19.9370 },
                new Attraction { id = 84, DistrictId = 50, Title = "Kazimierz District", Description = "Historic Jewish district", Latitude = 50.0500, Longitude = 19.9450 },
                new Attraction { id = 85, DistrictId = 51, Title = "Schindler's Factory", Description = "Historic museum", Latitude = 50.0510, Longitude = 19.9600 },

                // Poznań
                new Attraction { id = 86, DistrictId = 52, Title = "Old Market Square", Description = "Historic square", Latitude = 52.4084, Longitude = 16.9342 },
                new Attraction { id = 87, DistrictId = 53, Title = "Cathedral Island", Description = "Historic island", Latitude = 52.4087, Longitude = 16.9370 },
                new Attraction { id = 88, DistrictId = 52, Title = "Poznań Town Hall", Description = "Renaissance-style town hall", Latitude = 52.4089, Longitude = 16.9345 },
                new Attraction { id = 89, DistrictId = 53, Title = "Imperial Castle", Description = "Historic castle and cultural center", Latitude = 52.4095, Longitude = 16.9290 },
                new Attraction { id = 90, DistrictId = 54, Title = "Malta Lake", Description = "Popular recreational area with water sports", Latitude = 52.4025, Longitude = 16.9717 }
              );
        }
    }
}
