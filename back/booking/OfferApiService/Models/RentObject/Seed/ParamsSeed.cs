using Microsoft.EntityFrameworkCore;
using OfferApiService.Models.RentObject;
using OfferApiService.Models.RentObject.Enums;

namespace OfferApiService.Data.Seeds
{
    public static class ParamsSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Сиды категорий
            modelBuilder.Entity<ParamsCategory>().HasData(
                new ParamsCategory { id = 1, Title = "General" },
                new ParamsCategory { id = 2, Title = "Building" },
                new ParamsCategory { id = 3, Title = "Location" },
                new ParamsCategory { id = 4, Title = "Outdoors" },
                new ParamsCategory { id = 5, Title = "Services" },
                new ParamsCategory { id = 6, Title = "Food & Drink" },
                new ParamsCategory { id = 7, Title = "Wellness & Recreation" },
                new ParamsCategory { id = 8, Title = "Room Facilities" }
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
                new ParamItem { id = 29, CategoryId = 8, Title = "Safe", ValueType = ParamValueType.Boolean }
            );
        }
    }
}
