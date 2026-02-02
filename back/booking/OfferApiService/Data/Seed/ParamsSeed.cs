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


                new ParamsCategory { id = 9, IsFilterable = false },  // зручності та послуги
                new ParamsCategory { id = 10, IsFilterable = false }, // вид на
                new ParamsCategory { id = 11, IsFilterable = false }  // власна ванна кімната
            );

            // Сиды параметров (ParamItem)
            modelBuilder.Entity<ParamItem>().HasData(
                // Тип розміщення / Type of accommodation
                new ParamItem { id = 1, CategoryId = 1 },
                new ParamItem {id = 2, CategoryId = 1 },
                new ParamItem {id = 3, CategoryId = 1 },
                new ParamItem {id = 4, CategoryId = 1 },
                new ParamItem {id = 5, CategoryId = 1 },
                new ParamItem { id = 6, CategoryId = 1 },
                new ParamItem { id = 7, CategoryId = 1 },

                // Зручності / Amenities
                new ParamItem {id = 8, CategoryId = 3 },
                new ParamItem { id = 9, CategoryId = 3 },
                new ParamItem { id = 10, CategoryId = 3 },
                new ParamItem { id = 11, CategoryId = 3 },
                new ParamItem { id = 12, CategoryId = 3 },
                new ParamItem { id = 13, CategoryId = 3 },
                new ParamItem { id = 14, CategoryId = 3 },
                new ParamItem { id = 15, CategoryId = 3 },
                new ParamItem { id = 16, CategoryId = 3 },

                 //Житло з/Housing with
                new ParamItem {id = 17, CategoryId = 4 },
                new ParamItem {id = 18, CategoryId = 4 },
                new ParamItem {id = 19, CategoryId = 4 },
                new ParamItem {id = 20, CategoryId = 4 },
                new ParamItem {id = 21, CategoryId = 4 },


                // "Оцінка об'єкту / Object evaluation

                new ParamItem {id = 22, CategoryId = 5 },
                new ParamItem {id = 23, CategoryId = 5 },
                new ParamItem {id = 24, CategoryId = 5 },
                new ParamItem {id = 25, CategoryId = 5 },


                // Відстань від центра / Distance from center

                new ParamItem {id = 26, CategoryId = 6 },
                new ParamItem {id = 27, CategoryId = 6 },
                new ParamItem {id = 28, CategoryId = 6 },


                //Правила бронювання / Booking rules

                new ParamItem {id = 29, CategoryId = 7 },
                new ParamItem {id = 30, CategoryId = 7 },
                new ParamItem {id = 31, CategoryId = 7 },
                new ParamItem {id = 32, CategoryId = 7 },


                // Ціни / Prices
                new ParamItem { id = 33, CategoryId = 2 },
                new ParamItem { id = 34, CategoryId = 2 },


                 // зручності та послуги
                new ParamItem { id = 35, CategoryId = 9, IsFilterable = false },
                new ParamItem { id = 36, CategoryId = 9, IsFilterable = false },
                new ParamItem { id = 37, CategoryId = 9, IsFilterable = false },
                new ParamItem { id = 38, CategoryId = 9, IsFilterable = false },
                new ParamItem { id = 39, CategoryId = 9, IsFilterable = false },
                new ParamItem { id = 40, CategoryId = 9, IsFilterable = false },
                new ParamItem { id = 41, CategoryId = 9, IsFilterable = false },
                new ParamItem { id = 42, CategoryId = 9, IsFilterable = false },
                new ParamItem { id = 43, CategoryId = 9, IsFilterable = false },
                new ParamItem { id = 44, CategoryId = 9, IsFilterable = false },
                new ParamItem { id = 45, CategoryId = 9, IsFilterable = false },
                new ParamItem { id = 46, CategoryId = 9, IsFilterable = false },
                new ParamItem { id = 47, CategoryId = 9, IsFilterable = false },
                new ParamItem { id = 48, CategoryId = 9, IsFilterable = false },
                new ParamItem { id = 49, CategoryId = 9, IsFilterable = false },


               // вид на
                new ParamItem { id = 50, CategoryId = 10, IsFilterable = false },
                new ParamItem { id = 51, CategoryId = 10, IsFilterable = false }
,

                // власна ванна кімната
                new ParamItem { id = 52, CategoryId = 11, IsFilterable = false },
                new ParamItem { id = 53, CategoryId = 11, IsFilterable = false },
                new ParamItem { id = 54, CategoryId = 11, IsFilterable = false },
                new ParamItem { id = 55, CategoryId = 11, IsFilterable = false },
                new ParamItem { id = 56, CategoryId = 11, IsFilterable = false }


            );

        }
    }
}
