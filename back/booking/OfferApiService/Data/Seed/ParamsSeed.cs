using Microsoft.EntityFrameworkCore;
using OfferApiService.Models.RentObjModel;

namespace OfferApiService.Data.Seed
{
    public static class ParamsSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {

            // Сиды категорий
            modelBuilder.Entity<ParamsCategory>().HasData(
                new ParamsCategory { id = 1 },
                new ParamsCategory { id = 2 },
                new ParamsCategory { id = 3 },
                new ParamsCategory { id = 4 },
                new ParamsCategory { id = 5 },
                new ParamsCategory { id = 6 },
                new ParamsCategory { id = 7 },
                new ParamsCategory { id = 8 },
                new ParamsCategory { id = 9 },
                new ParamsCategory { id = 10 },
                new ParamsCategory { id = 11 },
                new ParamsCategory { id = 12 }


            );

            // Сиды параметров (ParamItem)
            modelBuilder.Entity<ParamItem>().HasData(
                // General
                new ParamItem { id = 1, CategoryId = 1 },
                new ParamItem {id = 2, CategoryId = 1 },
                new ParamItem {id = 3, CategoryId = 1 },
                new ParamItem {id = 4, CategoryId = 1 },
                new ParamItem {id = 5, CategoryId = 1 },

                // Building
                new ParamItem {id = 6, CategoryId = 2 },
                new ParamItem {id = 7, CategoryId = 2 },
                new ParamItem {id = 8, CategoryId = 2 },

                // Location
                new ParamItem {id = 9, CategoryId = 3 },

                // Outdoors
                new ParamItem {id = 10, CategoryId = 4 },
                new ParamItem {id = 11, CategoryId = 4 },
                new ParamItem {id = 12, CategoryId = 4 },

                // Services
                new ParamItem {id = 13, CategoryId = 5 },
                new ParamItem {id = 14, CategoryId = 5 },
                new ParamItem {id = 15, CategoryId = 5 },
                new ParamItem {id = 16, CategoryId = 5 },

                // Food & Drink
                new ParamItem {id = 17, CategoryId = 6 },
                new ParamItem {id = 18, CategoryId = 6 },
                new ParamItem {id = 19, CategoryId = 6 },

                // Wellness & Recreation
                new ParamItem {id = 20, CategoryId = 7 },
                new ParamItem {id = 21, CategoryId = 7 },
                new ParamItem {id = 22, CategoryId = 7 },
                new ParamItem {id = 23, CategoryId = 7 },

                // Room Facilities
                new ParamItem {id = 24, CategoryId = 8 },
                new ParamItem {id = 25, CategoryId = 8 },
                new ParamItem {id = 26, CategoryId = 8 },
                new ParamItem {id = 27, CategoryId = 8 },
                new ParamItem {id = 28, CategoryId = 8 },
                new ParamItem {id = 29, CategoryId = 8 },
                new ParamItem {id = 30, CategoryId = 8 },
                new ParamItem {id = 31, CategoryId = 8 },

                // Beds & Sleeping
                new ParamItem {id = 32, CategoryId = 9 },
                new ParamItem {id = 33, CategoryId = 9 },
                new ParamItem {id = 34, CategoryId = 9 },

                // Distance from center
                new ParamItem {id = 35, CategoryId = 3 },
                new ParamItem {id = 36, CategoryId = 3 },
                new ParamItem {id = 37, CategoryId = 3 },
                new ParamItem {id = 38, CategoryId = 3 },

                // Room Facilities extended
                new ParamItem {id = 39, CategoryId = 8 },
                new ParamItem {id = 40, CategoryId = 8 },
                new ParamItem {id = 41, CategoryId = 8 },
                new ParamItem {id = 42, CategoryId = 8 },
                new ParamItem {id = 43, CategoryId = 8 },
                new ParamItem {id = 44, CategoryId = 8 },

                // Beds & Sleeping - counts
                new ParamItem {id = 45, CategoryId = 9 },
                new ParamItem {id = 46, CategoryId = 9 },
                new ParamItem {id = 47, CategoryId = 9 },
                new ParamItem {id = 48, CategoryId = 9 },
                new ParamItem {id = 49, CategoryId = 9 },
                new ParamItem {id = 50, CategoryId = 9 },
                new ParamItem {id = 51, CategoryId = 9 },
                new ParamItem {id = 52, CategoryId = 9 },

                // Kitchen
                new ParamItem {id = 53, CategoryId = 10 },
                new ParamItem {id = 54, CategoryId = 10 },
                new ParamItem {id = 55, CategoryId = 10 },
                new ParamItem {id = 56, CategoryId = 10 },
                new ParamItem {id = 57, CategoryId = 10 },
                new ParamItem {id = 58, CategoryId = 10 },
                new ParamItem {id = 59, CategoryId = 10 },
                new ParamItem {id = 60, CategoryId = 10 },
                new ParamItem {id = 61, CategoryId = 10 },

                // Bathroom
                new ParamItem {id = 62, CategoryId = 11 },
                new ParamItem {id = 63, CategoryId = 11 },
                new ParamItem {id = 64, CategoryId = 11 },
                new ParamItem {id = 65, CategoryId = 11 },
                new ParamItem {id = 66, CategoryId = 11 },
                new ParamItem {id = 67, CategoryId = 11 },

                // Safety
                new ParamItem {id = 68, CategoryId = 12 },
                new ParamItem {id = 69, CategoryId = 12 },
                new ParamItem {id = 70, CategoryId = 12 },
                new ParamItem {id = 71, CategoryId = 12 }
            );

        }
    }
}
