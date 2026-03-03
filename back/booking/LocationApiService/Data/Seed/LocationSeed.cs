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
               new Country { id = 1, Latitude = 48.3794, Longitude = 31.1656, CountryCode = "+380" },  // Ukraine
               new Country { id = 2, Latitude = 39.8283, Longitude = -98.5795, CountryCode = "+1" }, // United States
               new Country { id = 3, Latitude = 51.1657, Longitude = 10.4515, CountryCode = "+49" },  // Germany
               new Country { id = 4, Latitude = 46.6034, Longitude = 1.8883, CountryCode = "+33" },   // France
               new Country { id = 5, Latitude = 55.3781, Longitude = -3.4360, CountryCode = "+44" },  // United Kingdom
               new Country { id = 6, Latitude = 40.4637, Longitude = -3.7492, CountryCode = "+34" },  // Spain
               new Country { id = 7, Latitude = 51.9194, Longitude = 19.1451, CountryCode = "+48" }   // Poland
           );


            // Regions
            modelBuilder.Entity<Region>().HasData(
            // =================== Украина ===================
            new Region { id = 1, CountryId = 1, Latitude = 50.4501, Longitude = 30.5234 }, // Київ
            new Region { id = 2, CountryId = 1, Latitude = 49.2331, Longitude = 28.4682 }, // Вінницька
            new Region { id = 3, CountryId = 1, Latitude = 50.7472, Longitude = 25.3254 }, // Волинська
            new Region { id = 4, CountryId = 1, Latitude = 48.4647, Longitude = 35.0462 }, // Дніпропетровська
            new Region { id = 5, CountryId = 1, Latitude = 48.0159, Longitude = 37.8029 }, // Донецька
            new Region { id = 6, CountryId = 1, Latitude = 50.2547, Longitude = 28.6587 }, // Житомирська
            new Region { id = 7, CountryId = 1, Latitude = 48.6196, Longitude = 22.2879 }, // Закарпатська
            new Region { id = 8, CountryId = 1, Latitude = 47.8388, Longitude = 35.1396 }, // Запорізька
            new Region { id = 9, CountryId = 1, Latitude = 48.9226, Longitude = 24.7111 }, // Івано-Франківська
            new Region { id = 10, CountryId = 1, Latitude = 50.2915, Longitude = 30.4999 }, // Київська
            new Region { id = 11, CountryId = 1, Latitude = 48.5072, Longitude = 32.2623 }, // Кіровоградська
            new Region { id = 12, CountryId = 1, Latitude = 48.6187, Longitude = 39.3050 }, // Луганська
            new Region { id = 13, CountryId = 1, Latitude = 49.8397, Longitude = 24.0297 }, // Львівська
            new Region { id = 14, CountryId = 1, Latitude = 46.9750, Longitude = 31.9946 }, // Миколаївська
            new Region { id = 15, CountryId = 1, Latitude = 46.4825, Longitude = 30.7233 }, // Одеська
            new Region { id = 16, CountryId = 1, Latitude = 49.5883, Longitude = 34.5514 }, // Полтавська
            new Region { id = 17, CountryId = 1, Latitude = 50.6236, Longitude = 26.2270 }, // Рівненська
            new Region { id = 18, CountryId = 1, Latitude = 50.9077, Longitude = 34.7981 }, // Сумська
            new Region { id = 19, CountryId = 1, Latitude = 49.5535, Longitude = 25.5948 }, // Тернопільська
            new Region { id = 20, CountryId = 1, Latitude = 50.0000, Longitude = 36.2310 }, // Харківська
            new Region { id = 21, CountryId = 1, Latitude = 46.6354, Longitude = 32.6169 }, // Херсонська
            new Region { id = 22, CountryId = 1, Latitude = 49.4211, Longitude = 26.9965 }, // Хмельницька
            new Region { id = 23, CountryId = 1, Latitude = 49.4444, Longitude = 32.0598 }, // Черкаська
            new Region { id = 24, CountryId = 1, Latitude = 48.2915, Longitude = 25.9403 }, // Чернівецька
            new Region { id = 25, CountryId = 1, Latitude = 51.5055, Longitude = 31.2849 }, // Чернігівська

             // =================== США ===================
             new Region { id = 27, CountryId = 2, Latitude = 42.1657, Longitude = -74.9481 },//Штат Нью-Йорк
             new Region { id = 28, CountryId = 2, Latitude = 36.7783, Longitude = -119.4179 },//Каліфорнія
             new Region { id = 29, CountryId = 2, Latitude = 40.6331, Longitude = -89.3985 },//Іллінойс

             // =================== Германия ===================
             new Region { id = 30, CountryId = 3, Latitude = 52.5200, Longitude = 13.4050 },//Берлін
             new Region { id = 31, CountryId = 3, Latitude = 48.7904, Longitude = 11.4979 },//Баварія
             new Region { id = 32, CountryId = 3, Latitude = 53.5511, Longitude = 9.9937 },//Гамбург

             // =================== Франция ===================
             new Region { id = 33, CountryId = 4, Latitude = 48.8499, Longitude = 2.6370 },//Іль-де-Франс
             new Region { id = 34, CountryId = 4, Latitude = 45.7640, Longitude = 4.8357 },//Овернь-Рона-Альпи
             new Region { id = 35, CountryId = 4, Latitude = 43.9352, Longitude = 6.0679 },//Прованс-Альпи-Лазурний берег

             // =================== UK ===================
             new Region { id = 36, CountryId = 5, Latitude = 51.5074, Longitude = -0.1278 },//Англія (Лондон)
             new Region { id = 37, CountryId = 5, Latitude = 53.4808, Longitude = -2.2426 },//Північно-Західна Англія
             new Region { id = 38, CountryId = 5, Latitude = 52.4862, Longitude = -1.8904 },//Вест-Мідлендс

             // =================== Spain ===================
             new Region { id = 39, CountryId = 6, Latitude = 40.4168, Longitude = -3.7038 },//Мадридська спільнота
             new Region { id = 40, CountryId = 6, Latitude = 41.3851, Longitude = 2.1734 },//Каталонія
             new Region { id = 41, CountryId = 6, Latitude = 39.4699, Longitude = -0.3763 },//Валенсійська спільнота

             // =================== Poland ===================
             new Region { id = 42, CountryId = 7, Latitude = 52.2297, Longitude = 21.0122 },//Мазовецьке воєводство
             new Region { id = 43, CountryId = 7, Latitude = 50.0647, Longitude = 19.9450 },//Малопольське воєводство
             new Region { id = 44, CountryId = 7, Latitude = 52.4064, Longitude = 16.9252 }//Великопольське воєводство
         );




            modelBuilder.Entity<City>().HasData(
          // =================== Украина ===================

          //Kyiv
          new City
          {
              id = 1,
              RegionId = 1,
              Latitude = 50.4501,
              Longitude = 30.5234,
              PostCode = "01001",
              IsTop = true,
              Slug= "Kyiv",
              ImageUrl_Main = "images/Kyiv/cities/Kyiv.jpg",
              ImageUrl_1 = "images/Kyiv/cities/Kyiv_1.jpg",
              ImageUrl_2 = "images/Kyiv/cities/Kyiv_2.jpg",
              ImageUrl_3 = "images/Kyiv/cities/Kyiv_3.jpg",
          },
            // Винниця
            new City
            {
                id = 2,
                RegionId = 2, 
                Latitude = 49.2331,
                Longitude = 28.4682,
                PostCode = "21000",
                IsTop = false,
                Slug = "Vinnytsia",
                ImageUrl_Main = "images/cities/Vinnytsia/Vinnytsia.jpg",
                ImageUrl_1 = "images/cities/Vinnytsia/Vinnytsia_1.jpg",
                ImageUrl_2 = "images/cities/Vinnytsia/Vinnytsia_2.jpg",
                ImageUrl_3 = "images/cities/Vinnytsia/Vinnytsia_3.jpg",

            },

              // Жмеринка
              new City
              {
                  id = 3,
                  RegionId = 2, 
                  Latitude = 49.0436,
                  Longitude = 28.0211,
                  PostCode = "23000",
                  IsTop = false,
                  Slug = "Zhmerinka",
                  ImageUrl_Main = "images/cities/Zhmerinka.jpg",
                  ImageUrl_1 = "images/cities/Zhmerinka_1.jpg",
                  ImageUrl_2 = "images/cities/Zhmerinka_2.jpg",
                  ImageUrl_3 = "images/cities/Zhmerinka_3.jpg",
              },

            // Могилів-Подільський
            new City
            {
                id = 4,
                RegionId = 2, 
                Latitude = 48.4333,
                Longitude = 27.7667,
                PostCode = "24000",
                IsTop = false,
                Slug = "MohylivPodilskyi",
                ImageUrl_Main = "images/cities/MohylivPodilskyi.jpg",
                ImageUrl_1 = "images/cities/MohylivPodilskyi_1.jpg",
                ImageUrl_2 = "images/cities/MohylivPodilskyi_2.jpg",
                ImageUrl_3 = "images/cities/MohylivPodilskyi_3.jpg",
            },

            // Луцьк
            new City
            {
                id = 6,
                RegionId = 3, // Волынская область
                Latitude = 50.7472,
                Longitude = 25.3254,
                PostCode = "43000",
                IsTop = false,
                Slug = "Lutsk",
                ImageUrl_Main = "images/cities/Lutsk/Lutsk.jpg",
                ImageUrl_1 = "images/cities/Lutsk/Lutsk_1.jpg",
                ImageUrl_2 = "images/cities/Lutsk/Lutsk_2.jpg",
                ImageUrl_3 = "images/cities/Lutsk/Lutsk_3.jpg",
            },

            // Ковель
            new City
            {
                id = 7,
                RegionId = 3, // Волынская область
                Latitude = 51.2156,
                Longitude = 24.7114,
                PostCode = "45000",
                IsTop = false,
                Slug = "Kovel",
                ImageUrl_Main = "images/cities/Kovel.jpg",
                ImageUrl_1 = "images/cities/Kovel_1.jpg",
                ImageUrl_2 = "images/cities/Kovel_2.jpg",
                ImageUrl_3 = "images/cities/Kovel_3.jpg",
            },

            // Дніпро
            new City
            {
                id = 8,
                RegionId = 4, // Дніпропетровська область
                Latitude = 48.4647,
                Longitude = 35.0462,
                PostCode = "49000",
                IsTop = true,
                Slug = "Dnipro",
                ImageUrl_Main = "images/cities/Dnipro/Dnipro.jpg",
                ImageUrl_1 = "images/cities/Dnipro/Dnipro_1.jpg",
                ImageUrl_2 = "images/cities/Dnipro/Dnipro_2.jpg",
                ImageUrl_3 = "images/cities/Dnipro/Dnipro_3.jpg",
            },

                // Кривий Ріг
            new City
            {
                id = 9,
                RegionId = 4,
                Latitude = 47.9105,
                Longitude = 33.3918,
                PostCode = "50000",
                IsTop = false,
                Slug = "KryvyiRih",
                ImageUrl_Main = "images/cities/KryvyiRih.jpg",
                ImageUrl_1 = "images/cities/KryvyiRih_1.jpg",
                ImageUrl_2 = "images/cities/KryvyiRih_2.jpg",
                ImageUrl_3 = "images/cities/KryvyiRih_3.jpg",
            },

            // Кам’янське
            new City
            {
                id = 10,
                RegionId = 4,
                Latitude = 48.5160,
                Longitude = 33.6178,
                PostCode = "51900",
                IsTop = false,
                Slug = "Kamianske",
                ImageUrl_Main = "images/cities/Kamianske.jpg",
                ImageUrl_1 = "images/cities/Kamianske_1.jpg",
                ImageUrl_2 = "images/cities/Kamianske_2.jpg",
                ImageUrl_3 = "images/cities/Kamianske_3.jpg",
            },

            // Нікополь
            new City
            {
                id = 11,
                RegionId = 4,
                Latitude = 47.5667,
                Longitude = 34.4000,
                PostCode = "53200",
                IsTop = false,
                Slug = "Nikopol",
                ImageUrl_Main = "images/cities/Nikopol.jpg",
                ImageUrl_1 = "images/cities/Nikopol_1.jpg",
                ImageUrl_2 = "images/cities/Nikopol_2.jpg",
                ImageUrl_3 = "images/cities/Nikopol_3.jpg",
            },



            // Донецьк
            new City
            {
                id = 17,
                RegionId = 5, // Донецька область
                Latitude = 48.0159,
                Longitude = 37.8029,
                PostCode = "83000",
                IsTop = false,
                Slug = "Donetsk",
                ImageUrl_Main = "images/cities/Donetsk.jpg",
                ImageUrl_1 = "images/cities/Donetsk_1.jpg",
                ImageUrl_2 = "images/cities/Donetsk_2.jpg",
                ImageUrl_3 = "images/cities/Donetsk_3.jpg",
            },

            // Слов’янськ
            new City
            {
                id = 18,
                RegionId = 5,
                Latitude = 48.8618,
                Longitude = 37.6226,
                PostCode = "84100",
                IsTop = false,
                Slug = "Sloviansk",
                ImageUrl_Main = "images/cities/Sloviansk.jpg",
                ImageUrl_1 = "images/cities/Sloviansk_1.jpg",
                ImageUrl_2 = "images/cities/Sloviansk_2.jpg",
                ImageUrl_3 = "images/cities/Sloviansk_3.jpg",
            },

            // Краматорськ
            new City
            {
                id = 19,
                RegionId = 5,
                Latitude = 48.7230,
                Longitude = 37.5685,
                PostCode = "84300",
                IsTop = false,
                Slug = "Kramatorsk",
                ImageUrl_Main = "images/cities/Kramatorsk.jpg",
                ImageUrl_1 = "images/cities/Kramatorsk_1.jpg",
                ImageUrl_2 = "images/cities/Kramatorsk_2.jpg",
                ImageUrl_3 = "images/cities/Kramatorsk_3.jpg",
            },
            // Житомир
            new City
            {
                id = 20,
                RegionId = 6, // Житомирська область
                Latitude = 50.2547,
                Longitude = 28.6587,
                PostCode = "10000",
                IsTop = true,
                Slug = "Zhytomyr",
                ImageUrl_Main = "images/cities/Zhytomyr.jpg",
                ImageUrl_1 = "images/cities/Zhytomyr_1.jpg",
                ImageUrl_2 = "images/cities/Zhytomyr_2.jpg",
                ImageUrl_3 = "images/cities/Zhytomyr_3.jpg",
            },

            // Бердичів
            new City
            {
                id = 21,
                RegionId = 6,
                Latitude = 49.8943,
                Longitude = 28.6022,
                PostCode = "13300",
                IsTop = false,
                Slug = "Berdychiv",
                ImageUrl_Main = "images/cities/Berdychiv.jpg",
                ImageUrl_1 = "images/cities/Berdychiv_1.jpg",
                ImageUrl_2 = "images/cities/Berdychiv_2.jpg",
                ImageUrl_3 = "images/cities/Berdychiv_3.jpg",
            },

            // Коростень
            new City
            {
                id = 22,
                RegionId = 6,
                Latitude = 50.9523,
                Longitude = 28.6567,
                PostCode = "11500",
                IsTop = false,
                Slug = "Korosten",
                ImageUrl_Main = "images/cities/Korosten.jpg",
                ImageUrl_1 = "images/cities/Korosten_1.jpg",
                ImageUrl_2 = "images/cities/Korosten_2.jpg",
                ImageUrl_3 = "images/cities/Korosten_3.jpg",
            },

            // Новоград-Волинський (Звягель)
            new City
            {
                id = 23,
                RegionId = 6,
                Latitude = 50.6192,
                Longitude = 28.6575,
                PostCode = "11000",
                IsTop = false,
                Slug = "NovohradVolynskyi",
                ImageUrl_Main = "images/cities/NovohradVolynskyi.jpg",
                ImageUrl_1 = "images/cities/NovohradVolynskyi_1.jpg",
                ImageUrl_2 = "images/cities/NovohradVolynskyi_2.jpg",
                ImageUrl_3 = "images/cities/NovohradVolynskyi_3.jpg",
            },
            // Ужгород
            new City
            {
                id = 24,
                RegionId = 7, // Закарпатська область
                Latitude = 48.6208,
                Longitude = 22.2879,
                PostCode = "88000",
                IsTop = true,
                Slug = "Uzhhorod",
                ImageUrl_Main = "images/cities/Uzhhorod/Uzhhorod.jpg",
                ImageUrl_1 = "images/cities/Uzhhorod/Uzhhorod_1.jpg",
                ImageUrl_2 = "images/cities/Uzhhorod/Uzhhorod_2.jpg",
                ImageUrl_3 = "images/cities/Uzhhorod/Uzhhorod_3.jpg",
            },

            // Мукачево
            new City
            {
                id = 25,
                RegionId = 7,
                Latitude = 48.4460,
                Longitude = 22.7179,
                PostCode = "89600",
                IsTop = false,
                Slug = "Mukachevo",
                ImageUrl_Main = "images/cities/Mukachevo.jpg",
                ImageUrl_1 = "images/cities/Mukachevo_1.jpg",
                ImageUrl_2 = "images/cities/Mukachevo_2.jpg",
                ImageUrl_3 = "images/cities/Mukachevo_3.jpg",
            },

            // Хуст
            new City
            {
                id = 26,
                RegionId = 7,
                Latitude = 48.2700,
                Longitude = 23.3000,
                PostCode = "90400",
                IsTop = false,
                Slug = "Khust",
                ImageUrl_Main = "images/cities/Khust.jpg",
                ImageUrl_1 = "images/cities/Khust_1.jpg",
                ImageUrl_2 = "images/cities/Khust_2.jpg",
                ImageUrl_3 = "images/cities/Khust_3.jpg",
            },

            // Берегове
            new City
            {
                id = 27,
                RegionId = 7,
                Latitude = 48.2086,
                Longitude = 22.6394,
                PostCode = "90200",
                IsTop = false,
                Slug = "Berehove",
                ImageUrl_Main = "images/cities/Berehove.jpg",
                ImageUrl_1 = "images/cities/Berehove_1.jpg",
                ImageUrl_2 = "images/cities/Berehove_2.jpg",
                ImageUrl_3 = "images/cities/Berehove_3.jpg",
            },
            // Запоріжжя
            new City
            {
                id = 28,
                RegionId =8, // Запорізька область
                Latitude = 47.8388,
                Longitude = 35.1396,
                PostCode = "69000",
                IsTop = false,
                Slug = "Zaporizhzhia",
                ImageUrl_Main = "images/cities/Zaporizhzhia/Zaporizhzhia.jpg",
                ImageUrl_1 = "images/cities/Zaporizhzhia/Zaporizhzhia_1.jpg",
                ImageUrl_2 = "images/cities/Zaporizhzhia/Zaporizhzhia_2.jpg",
                ImageUrl_3 = "images/cities/Zaporizhzhia/Zaporizhzhia_3.jpg",
            },

            // Мелітополь
            new City
            {
                id = 29,
                RegionId = 8,
                Latitude = 46.8386,
                Longitude = 35.3629,
                PostCode = "72300",
                IsTop = false,
                Slug = "Melitopol",
                ImageUrl_Main = "images/cities/Melitopol.jpg",
                ImageUrl_1 = "images/cities/Melitopol_1.jpg",
                ImageUrl_2 = "images/cities/Melitopol_2.jpg",
                ImageUrl_3 = "images/cities/Melitopol_3.jpg",
            },

            // Бердянськ
            new City
            {
                id = 30,
                RegionId = 8,
                Latitude = 46.7569,
                Longitude = 36.8125,
                PostCode = "71100",
                IsTop = false,
                Slug = "Berdiansk",
                ImageUrl_Main = "images/cities/Berdiansk.jpg",
                ImageUrl_1 = "images/cities/Berdiansk_1.jpg",
                ImageUrl_2 = "images/cities/Berdiansk_2.jpg",
                ImageUrl_3 = "images/cities/Berdiansk_3.jpg",
            },

            // Енергодар
            new City
            {
                id = 31,
                RegionId = 8,
                Latitude = 47.5000,
                Longitude = 34.6500,
                PostCode = "71300",
                IsTop = false,
                Slug = "Enerhodar",
                ImageUrl_Main = "images/cities/Enerhodar.jpg",
                ImageUrl_1 = "images/cities/Enerhodar_1.jpg",
                ImageUrl_2 = "images/cities/Enerhodar_2.jpg",
                ImageUrl_3 = "images/cities/Enerhodar_3.jpg",
            },
            // Івано-Франківськ
            new City
            {
                id = 32,
                RegionId = 9, // Івано-Франківська область
                Latitude = 48.9214,
                Longitude = 24.7097,
                PostCode = "76000",
                IsTop = true,
                Slug = "IvanoFrankivsk",
                ImageUrl_Main = "images/cities/IvanoFrankivsk/IvanoFrankivsk.jpg",
                ImageUrl_1 = "images/cities/IvanoFrankivsk/IvanoFrankivsk_1.jpg",
                ImageUrl_2 = "images/cities/IvanoFrankivsk/IvanoFrankivsk_2.jpg",
                ImageUrl_3 = "images/cities/IvanoFrankivsk/IvanoFrankivsk_3.jpg",
            },

            // Калуш
            new City
            {
                id = 33,
                RegionId = 9,
                Latitude = 49.0061,
                Longitude = 24.3619,
                PostCode = "77300",
                IsTop = false,
                Slug = "Kalush",
                ImageUrl_Main = "images/cities/Kalush.jpg",
                ImageUrl_1 = "images/cities/Kalush_1.jpg",
                ImageUrl_2 = "images/cities/Kalush_2.jpg",
                ImageUrl_3 = "images/cities/Kalush_3.jpg",
            },

            // Коломия
            new City
            {
                id = 34,
                RegionId = 9,
                Latitude = 48.5314,
                Longitude = 25.0380,
                PostCode = "78200",
                IsTop = false,
                Slug = "Kolomyia",
                ImageUrl_Main = "images/cities/Kolomyia.jpg",
                ImageUrl_1 = "images/cities/Kolomyia_1.jpg",
                ImageUrl_2 = "images/cities/Kolomyia_2.jpg",
                ImageUrl_3 = "images/cities/Kolomyia_3.jpg",
            },
                // Яремче
                new City
            {
                id = 35,
                RegionId = 9,
                Latitude = 48.4500,
                Longitude = 24.5569,
                PostCode = "78500",
                IsTop = true,
                Slug = "Yaremche",
                ImageUrl_Main = "images/cities/Yaremche/Yaremche.jpg",
                ImageUrl_1 = "images/cities/Yaremche/Yaremche_1.jpg",
                ImageUrl_2 = "images/cities/Yaremche/Yaremche_2.jpg",
                ImageUrl_3 = "images/cities/Yaremche/Yaremche_3.jpg",
                },

            // Буковель
            new City
            {
                id = 36,
                RegionId = 9,
                Latitude = 48.3833,
                Longitude = 24.4333,
                PostCode = "78593",
                IsTop = true,
                Slug = "Bukovel",
                ImageUrl_Main = "images/cities/Bukovel/Bukovel.jpg",
                ImageUrl_1 = "images/cities/Bukovel/Bukovel_1.jpg",
                ImageUrl_2 = "images/cities/Bukovel/Bukovel_2.jpg",
                ImageUrl_3 = "images/cities/Bukovel/Bukovel_3.jpg",
            },

            // Біла Церква
            new City
            {
                id = 37,
                RegionId = 10, // Київська область
                Latitude = 49.7940,
                Longitude = 30.1158,
                PostCode = "09100",
                IsTop = true,
                Slug = "BilaTserkva",
                ImageUrl_Main = "images/cities/BilaTserkva/BilaTserkva.jpg",
                ImageUrl_1 = "images/cities/BilaTserkva/BilaTserkva_1.jpg",
                ImageUrl_2 = "images/cities/BilaTserkva/BilaTserkva_2.jpg",
                ImageUrl_3 = "images/cities/BilaTserkva/BilaTserkva_3.jpg",
            },

            // Бориспіль
            new City
            {
                id = 38,
                RegionId = 10,
                Latitude = 50.3419,
                Longitude = 30.9839,
                PostCode = "08300",
                IsTop = false,
                Slug = "Boryspil",
                ImageUrl_Main = "images/cities/Boryspil.jpg",
                ImageUrl_1 = "images/cities/Boryspil_1.jpg",
                ImageUrl_2 = "images/cities/Boryspil_2.jpg",
                ImageUrl_3 = "images/cities/Boryspil_3.jpg",
            },

            // Бровари
            new City
            {
                id = 39,
                RegionId = 10,
                Latitude = 50.5187,
                Longitude = 30.7841,
                PostCode = "07400",
                IsTop = false,
                Slug = "Brovary",
                ImageUrl_Main = "images/cities/Brovary.jpg",
                ImageUrl_1 = "images/cities/Brovary_1.jpg",
                ImageUrl_2 = "images/cities/Brovary_2.jpg",
                ImageUrl_3 = "images/cities/Brovary_3.jpg",
            },

            // Ірпінь
            new City
            {
                id = 40,
                RegionId = 10,
                Latitude = 50.5215,
                Longitude = 30.2646,
                PostCode = "08200",
                IsTop = false,
                Slug = "Irpin",
                ImageUrl_Main = "images/cities/Irpin.jpg",
                ImageUrl_1 = "images/cities/Irpin_1.jpg",
                ImageUrl_2 = "images/cities/Irpin_2.jpg",
                ImageUrl_3 = "images/cities/Irpin_3.jpg",
            },

            // Буча
            new City
            {
                id = 41,
                RegionId = 10,
                Latitude = 50.5511,
                Longitude = 30.2567,
                PostCode = "08292",
                IsTop = false,
                Slug = "Bucha",
                ImageUrl_Main = "images/cities/Bucha.jpg",
                ImageUrl_1 = "images/cities/Bucha_1.jpg",
                ImageUrl_2 = "images/cities/Bucha_2.jpg",
                ImageUrl_3 = "images/cities/Bucha_3.jpg",
            },
            // Кропивницький
            new City
            {
                id = 42,
                RegionId = 11, // Кіровоградська область
                Latitude = 48.5070,
                Longitude = 32.2623,
                PostCode = "25000",
                IsTop = false,
                Slug = "Kropyvnytskyi",
                ImageUrl_Main = "images/cities/Kropyvnytskyi.jpg",
                ImageUrl_1 = "images/cities/Kropyvnytskyi_1.jpg",
                ImageUrl_2 = "images/cities/Kropyvnytskyi_2.jpg",
                ImageUrl_3 = "images/cities/Kropyvnytskyi_3.jpg",
            },

            // Олександрія
            new City
            {
                id = 43,
                RegionId = 11,
                Latitude = 48.6667,
                Longitude = 32.6333,
                PostCode = "28000",
                IsTop = false,
                Slug = "Oleksandriya",
                ImageUrl_Main = "images/cities/Oleksandriya.jpg",
                ImageUrl_1 = "images/cities/Oleksandriya_1.jpg",
                ImageUrl_2 = "images/cities/Oleksandriya_2.jpg",
                ImageUrl_3 = "images/cities/Oleksandriya_3.jpg",
            },

            // Світловодськ
            new City
            {
                id = 44,
                RegionId = 11,
                Latitude = 48.7537,
                Longitude = 32.2823,
                PostCode = "27500",
                IsTop = false,
                Slug = "Svitlovodsk",
                ImageUrl_Main = "images/cities/Svitlovodsk.jpg",
                ImageUrl_1 = "images/cities/Svitlovodsk_1.jpg",
                ImageUrl_2 = "images/cities/Svitlovodsk_2.jpg",
                ImageUrl_3 = "images/cities/Svitlovodsk_3.jpg",
            },

            // Знам’янка
            new City
            {
                id = 45,
                RegionId = 11,
                Latitude = 48.5246,
                Longitude = 32.2599,
                PostCode = "27400",
                IsTop = false,
                Slug = "Znamianka",
                ImageUrl_Main = "images/cities/Znamianka.jpg",
                ImageUrl_1 = "images/cities/Znamianka_1.jpg",
                ImageUrl_2 = "images/cities/Znamianka_2.jpg",
                ImageUrl_3 = "images/cities/Znamianka_3.jpg",
            },
            // Лисичанськ
            new City
            {
                id = 46,
                RegionId = 12, // Луганська область
                Latitude = 48.9239,
                Longitude = 38.4433,
                PostCode = "93100",
                IsTop = false,
                Slug = "Lysychansk",
                ImageUrl_Main = "images/cities/Lysychansk.jpg",
                ImageUrl_1 = "images/cities/Lysychansk_1.jpg",
                ImageUrl_2 = "images/cities/Lysychansk_2.jpg",
                ImageUrl_3 = "images/cities/Lysychansk_3.jpg",
            },

            // Сєвєродонецьк
            new City
            {
                id = 47,
                RegionId = 12,
                Latitude = 48.9470,
                Longitude = 38.4840,
                PostCode = "93400",
                IsTop = false,
                Slug = "Severodonetsk",
                ImageUrl_Main = "images/cities/Severodonetsk.jpg",
                ImageUrl_1 = "images/cities/Severodonetsk_1.jpg",
                ImageUrl_2 = "images/cities/Severodonetsk_2.jpg",
                ImageUrl_3 = "images/cities/Severodonetsk_3.jpg",

            },

            // Алчевськ
            new City
            {
                id = 48,
                RegionId = 12,
                Latitude = 48.9033,
                Longitude = 38.7417,
                PostCode = "94100",
                IsTop = false,
                Slug = "Alchevsk",
                ImageUrl_Main = "images/cities/Alchevsk.jpg",
                ImageUrl_1 = "images/cities/Alchevsk_1.jpg",
                ImageUrl_2 = "images/cities/Alchevsk_2.jpg",
                ImageUrl_3 = "images/cities/Alchevsk_3.jpg",
            },

            // Краматорськ
            new City
            {
                id = 49,
                RegionId = 12,
                Latitude = 48.7236,
                Longitude = 37.5671,
                PostCode = "84300",
                IsTop = false,
                Slug = "Kramatorsk",
                ImageUrl_Main = "images/cities/Kramatorsk.jpg",
                ImageUrl_1 = "images/cities/Kramatorsk_1.jpg",
                ImageUrl_2 = "images/cities/Kramatorsk_2.jpg",
                ImageUrl_3 = "images/cities/Kramatorsk_3.jpg",
            },
            // Львів
            new City
            {
                id = 50,
                RegionId = 13, // Львівська область
                Latitude = 49.8397,
                Longitude = 24.0297,
                PostCode = "79000",
                IsTop = true,
                Slug = "Lviv",
                ImageUrl_Main = "images/cities/Lviv/Lviv.jpg",
                ImageUrl_1 = "images/cities/Lviv/Lviv_1.jpg",
                ImageUrl_2 = "images/cities/Lviv/Lviv_2.jpg",
                ImageUrl_3 = "images/cities/Lviv/Lviv_3.jpg",
            },

            // Дрогобич
            new City
            {
                id = 51,
                RegionId = 13,
                Latitude = 49.3500,
                Longitude = 23.5000,
                PostCode = "82100",
                IsTop = false,
                Slug = "Drohobych",
                ImageUrl_Main = "images/cities/Drohobych.jpg",
                ImageUrl_1 = "images/cities/Drohobych_1.jpg",
                ImageUrl_2 = "images/cities/Drohobych_2.jpg",
                ImageUrl_3 = "images/cities/Drohobych_3.jpg",
            },

            // Червоноград
            new City
            {
                id = 52,
                RegionId = 13,
                Latitude = 50.3200,
                Longitude = 24.2000,
                PostCode = "80100",
                IsTop = false,
                Slug = "Chervonohrad",
                ImageUrl_Main = "images/cities/Chervonohrad.jpg",
                ImageUrl_1 = "images/cities/Chervonohrad_1.jpg",
                ImageUrl_2 = "images/cities/Chervonohrad_2.jpg",
                ImageUrl_3 = "images/cities/Chervonohrad_3.jpg",
            },

            // Стрий
            new City
            {
                id = 53,
                RegionId = 13,
                Latitude = 49.2600,
                Longitude = 23.8500,
                PostCode = "82400",
                IsTop = false,
                Slug = "Stryi",
                ImageUrl_Main = "images/cities/Stryi.jpg",
                ImageUrl_1 = "images/cities/Stryi_1.jpg",
                ImageUrl_2 = "images/cities/Stryi_2.jpg",
                ImageUrl_3 = "images/cities/Stryi_3.jpg",
            },

            // Трускавець
            new City
            {
                id = 54,
                RegionId = 13,
                Latitude = 49.2789,
                Longitude = 23.5026,
                PostCode = "82200",
                IsTop = true,
                Slug = "Truskavets",
                ImageUrl_Main = "images/cities/Truskavets/Truskavets.jpg",
                ImageUrl_1 = "images/cities/Truskavets/Truskavets_1.jpg",
                ImageUrl_2 = "images/cities/Truskavets/Truskavets_2.jpg",
                ImageUrl_3 = "images/cities/Truskavets/Truskavets_3.jpg",
            },
            // Миколаїв
            new City
            {
                id = 55,
                RegionId = 14, // Миколаївська область
                Latitude = 46.9750,
                Longitude = 31.9946,
                PostCode = "54000",
                IsTop = true,
                Slug = "Mykolaiv",
                ImageUrl_Main = "images/cities/Mykolaiv/Mykolaiv.jpg",
                ImageUrl_1 = "images/cities/Mykolaiv/Mykolaiv_1.jpg",
                ImageUrl_2 = "images/cities/Mykolaiv/Mykolaiv_2.jpg",
                ImageUrl_3 = "images/cities/Mykolaiv/Mykolaiv_3.jpg",
            },

            // Одеса
            new City
            {
                id = 56,
                RegionId = 15, // Одеська область
                Latitude = 46.4825,
                Longitude = 30.7233,
                PostCode = "65000",
                IsTop = true,
                Slug = "Odesa",
                ImageUrl_Main = "images/cities/Odesa/Odesa.jpg",
                ImageUrl_1 = "images/cities/Odesa/Odesa_1.jpg",
                ImageUrl_2 = "images/cities/Odesa/Odesa_2.jpg",
                ImageUrl_3 = "images/cities/Odesa/Odesa_3.jpg",
            },

            // Ізмаїл
            new City
            {
                id = 57,
                RegionId = 15,
                Latitude = 45.3400,
                Longitude = 28.8400,
                PostCode = "68600",
                IsTop = false,
                Slug = "Izmail",
                ImageUrl_Main = "images/cities/Izmail.jpg",
                ImageUrl_1 = "images/cities/Izmail_1.jpg",
                ImageUrl_2 = "images/cities/Izmail_2.jpg",
                ImageUrl_3 = "images/cities/Izmail_3.jpg",
            },

            // Чорноморськ
            new City
            {
                id = 58,
                RegionId = 15,
                Latitude = 46.3133,
                Longitude = 30.6453,
                PostCode = "68000",
                IsTop = true,
                Slug = "Chornomorsk",
                ImageUrl_Main = "images/cities/Chornomorsk.jpg",
                ImageUrl_1 = "images/cities/Chornomorsk_1.jpg",
                ImageUrl_2 = "images/cities/Chornomorsk_2.jpg",
                ImageUrl_3 = "images/cities/Chornomorsk_3.jpg",
            },

            // Білгород-Дністровський
            new City
            {
                id = 59,
                RegionId = 15,
                Latitude = 46.1972,
                Longitude = 30.3558,
                PostCode = "67700",
                IsTop = false,
                Slug = "BilhorodDnistrovskyi",
                ImageUrl_Main = "images/cities/BilhorodDnistrovskyi.jpg",
                ImageUrl_1 = "images/cities/BilhorodDnistrovskyi_1.jpg",
                ImageUrl_2 = "images/cities/BilhorodDnistrovskyi_2.jpg",
                ImageUrl_3 = "images/cities/BilhorodDnistrovskyi_3.jpg",
            },

            // Подільськ
            new City
            {
                id = 60,
                RegionId = 15,
                Latitude = 46.3600,
                Longitude = 29.5300,
                PostCode = "66300",
                IsTop = false,
                Slug = "Podilsk",
                ImageUrl_Main = "images/cities/Podilsk.jpg",
                ImageUrl_1 = "images/cities/Podilsk_1.jpg",
                ImageUrl_2 = "images/cities/Podilsk_2.jpg",
                ImageUrl_3 = "images/cities/Podilsk_3.jpg",
            },
            // Полтава
            new City
            {
                id = 61,
                RegionId = 16, // Полтавська область
                Latitude = 49.5883,
                Longitude = 34.5514,
                PostCode = "36000",
                IsTop = false,
                Slug = "Poltava",
                ImageUrl_Main = "images/cities/Poltava.jpg",
                ImageUrl_1 = "images/cities/Poltava_1.jpg",
                ImageUrl_2 = "images/cities/Poltava_2.jpg",
                ImageUrl_3 = "images/cities/Poltava_3.jpg",
            },

            // Кременчук
            new City
            {
                id = 62,
                RegionId = 16,
                Latitude = 49.0681,
                Longitude = 33.4168,
                PostCode = "39600",
                IsTop = false,
                Slug = "Kremenchuk",
                ImageUrl_Main = "images/cities/Kremenchuk.jpg",
                ImageUrl_1 = "images/cities/Kremenchuk_1.jpg",
                ImageUrl_2 = "images/cities/Kremenchuk_2.jpg",
                ImageUrl_3 = "images/cities/Kremenchuk_3.jpg",
            },

            // Миргород
            new City
            {
                id = 63,
                RegionId = 16,
                Latitude = 49.9886,
                Longitude = 33.6169,
                PostCode = "37600",
                IsTop = false,
                Slug = "Myrhorod",
                ImageUrl_Main = "images/cities/Myrhorod.jpg",
                ImageUrl_1 = "images/cities/Myrhorod_1.jpg",
                ImageUrl_2 = "images/cities/Myrhorod_2.jpg",
                ImageUrl_3 = "images/cities/Myrhorod_3.jpg",
            },

            // Лубни
            new City
            {
                id = 64,
                RegionId = 16,
                Latitude = 50.0090,
                Longitude = 33.1080,
                PostCode = "37500",
                IsTop = false,
                Slug = "Lubny",
                ImageUrl_Main = "images/cities/Lubny.jpg",
                ImageUrl_1 = "images/cities/Lubny_1.jpg",
                ImageUrl_2 = "images/cities/Lubny_2.jpg",
                ImageUrl_3 = "images/cities/Lubny_3.jpg",
            },

            // Рівне
            new City
            {
                id = 65,
                RegionId = 17, // Рівненська область
                Latitude = 50.6199,
                Longitude = 26.2516,
                PostCode = "33000",
                IsTop = true,
                Slug = "Rivne",
                ImageUrl_Main = "images/cities/Rivne/Rivne.jpg",
                ImageUrl_1 = "images/cities/Rivne/Rivne_1.jpg",
                ImageUrl_2 = "images/cities/Rivne/Rivne_2.jpg",
                ImageUrl_3 = "images/cities/Rivne/Rivne_3.jpg",
            },

            // Дубно
            new City
            {
                id = 66,
                RegionId = 17,
                Latitude = 50.2590,
                Longitude = 25.7000,
                PostCode = "35600",
                IsTop = false,
                Slug = "Dubno",
                ImageUrl_Main = "images/cities/Dubno.jpg",
                ImageUrl_1 = "images/cities/Dubno_1.jpg",
                ImageUrl_2 = "images/cities/Dubno_2.jpg",
                ImageUrl_3 = "images/cities/Dubno_3.jpg",
            },

            // Вараш
            new City
            {
                id = 67,
                RegionId = 17,
                Latitude = 51.2930,
                Longitude = 26.5140,
                PostCode = "34500",
                IsTop = false,
                Slug = "Varash",
                ImageUrl_Main = "images/cities/Varash.jpg",
                ImageUrl_1 = "images/cities/Varash_1.jpg",
                ImageUrl_2 = "images/cities/Varash_2.jpg",
                ImageUrl_3 = "images/cities/Varash_3.jpg",
            },

            // Острог
            new City
            {
                id = 68,
                RegionId = 17,
                Latitude = 50.5075,
                Longitude = 26.4813,
                PostCode = "35800",
                IsTop = false,
                Slug = "Ostroh",
                ImageUrl_Main = "images/cities/Ostroh.jpg",
                ImageUrl_1 = "images/cities/Ostroh_1.jpg",
                ImageUrl_2 = "images/cities/Ostroh_2.jpg",
                ImageUrl_3 = "images/cities/Ostroh_3.jpg",
            },
            // Суми
            new City
            {
                id = 69,
                RegionId = 18, // Сумська область
                Latitude = 50.9077,
                Longitude = 34.7981,
                PostCode = "40000",
                IsTop = false,
                Slug = "Sumy",
                ImageUrl_Main = "images/cities/Sumy.jpg",
                ImageUrl_1 = "images/cities/Sumy_1.jpg",
                ImageUrl_2 = "images/cities/Sumy_2.jpg",
                ImageUrl_3 = "images/cities/Sumy_3.jpg",
            },

            // Конотоп
            new City
            {
                id = 70,
                RegionId = 18,
                Latitude = 51.2370,
                Longitude = 33.2130,
                PostCode = "41600",
                IsTop = false,
                Slug = "Konotop",
                ImageUrl_Main = "images/cities/Konotop.jpg",
                ImageUrl_1 = "images/cities/Konotop_1.jpg",
                ImageUrl_2 = "images/cities/Konotop_2.jpg",
                ImageUrl_3 = "images/cities/Konotop_3.jpg",
            },

            // Охтирка
            new City
            {
                id = 71,
                RegionId = 18,
                Latitude = 50.3010,
                Longitude = 34.8730,
                PostCode = "42700",
                IsTop = false,
                Slug = "Okhtyrka",
                ImageUrl_Main = "images/cities/Okhtyrka.jpg",
                ImageUrl_1 = "images/cities/Okhtyrka_1.jpg",
                ImageUrl_2 = "images/cities/Okhtyrka_2.jpg",
                ImageUrl_3 = "images/cities/Okhtyrka_3.jpg",
            },

            // Шостка
            new City
            {
                id = 72,
                RegionId = 18,
                Latitude = 51.8700,
                Longitude = 33.4800,
                PostCode = "41000",
                IsTop = false,
                Slug = "Shostka",
                ImageUrl_Main = "images/cities/Shostka.jpg",
                ImageUrl_1 = "images/cities/Shostka_1.jpg",
                ImageUrl_2 = "images/cities/Shostka_2.jpg",
                ImageUrl_3 = "images/cities/Shostka_3.jpg",
            },

            // Тернопіль
            new City
            {
                id = 73,
                RegionId = 19, // Тернопільська область
                Latitude = 49.5535,
                Longitude = 25.5948,
                PostCode = "46000",
                IsTop = true,
                Slug = "Ternopil",
                ImageUrl_Main = "images/cities/Ternopil.jpg",
                ImageUrl_1 = "images/cities/Ternopil_1.jpg",
                ImageUrl_2 = "images/cities/Ternopil_2.jpg",
                ImageUrl_3 = "images/cities/Ternopil_3.jpg",
            },

            // Чортків
            new City
            {
                id = 74,
                RegionId = 19,
                Latitude = 49.0230,
                Longitude = 25.7950,
                PostCode = "48500",
                IsTop = false,
                Slug = "Chortkiv",
                ImageUrl_Main = "images/cities/Chortkiv.jpg",
                ImageUrl_1 = "images/cities/Chortkiv_1.jpg",
                ImageUrl_2 = "images/cities/Chortkiv_2.jpg",
                ImageUrl_3 = "images/cities/Chortkiv_3.jpg",
            },

            // Кременець
            new City
            {
                id = 75,
                RegionId = 19,
                Latitude = 50.0960,
                Longitude = 25.4140,
                PostCode = "47000",
                IsTop = false,
                Slug = "Kremenets",
                ImageUrl_Main = "images/cities/Kremenets.jpg",
                ImageUrl_1 = "images/cities/Kremenets_1.jpg",
                ImageUrl_2 = "images/cities/Kremenets_2.jpg",
                ImageUrl_3 = "images/cities/Kremenets_3.jpg",
            },
            // Харків
            new City
            {
                id = 76,
                RegionId = 20, // Харківська область
                Latitude = 50.0057,
                Longitude = 36.2310,
                PostCode = "61000",
                IsTop = true,
                Slug = "Kharkiv",
                ImageUrl_Main = "images/cities/Kharkiv/Kharkiv.jpg",
                ImageUrl_1 = "images/cities/Kharkiv/Kharkiv_1.jpg",
                ImageUrl_2 = "images/cities/Kharkiv/Kharkiv_2.jpg",
                ImageUrl_3 = "images/cities/Kharkiv/Kharkiv_3.jpg",
            },

            // Ізюм
            new City
            {
                id = 77,
                RegionId = 20,
                Latitude = 49.2090,
                Longitude = 37.2710,
                PostCode = "63800",
                IsTop = false,
                Slug = "Izium",
                ImageUrl_Main = "images/cities/Izium.jpg",
                ImageUrl_1 = "images/cities/Izium_1.jpg",
                ImageUrl_2 = "images/cities/Izium_2.jpg",
                ImageUrl_3 = "images/cities/Izium_3.jpg",
            },

            // Лозова
            new City
            {
                id = 78,
                RegionId = 20,
                Latitude = 49.0120,
                Longitude = 36.5060,
                PostCode = "61100",
                IsTop = false,
                Slug = "Lozova",
                ImageUrl_Main = "images/cities/Lozova.jpg",
                ImageUrl_1 = "images/cities/Lozova_1.jpg",
                ImageUrl_2 = "images/cities/Lozova_2.jpg",
                ImageUrl_3 = "images/cities/Lozova_3.jpg",
            },

            // Чугуїв
            new City
            {
                id = 79,
                RegionId = 20,
                Latitude = 49.8820,
                Longitude = 36.7080,
                PostCode = "63500",
                IsTop = false,
                Slug = "Chuhuiv",
                ImageUrl_Main = "images/cities/Chuhuiv.jpg",
                ImageUrl_1 = "images/cities/Chuhuiv_1.jpg",
                ImageUrl_2 = "images/cities/Chuhuiv_2.jpg",
                ImageUrl_3 = "images/cities/Chuhuiv_3.jpg",
            },

            // Херсон
            new City
            {
                id = 80,
                RegionId = 21, // Херсонська область
                Latitude = 46.6354,
                Longitude = 32.6169,
                PostCode = "73000",
                IsTop = true,
                Slug = "Kherson",
                ImageUrl_Main = "images/cities/Kherson/Kherson.jpg",
                ImageUrl_1 = "images/cities/Kherson/Kherson_1.jpg",
                ImageUrl_2 = "images/cities/Kherson/Kherson_2.jpg",
                ImageUrl_3 = "images/cities/Kherson/Kherson_3.jpg",
            },

            // Нова Каховка
            new City
            {
                id = 81,
                RegionId = 21,
                Latitude = 46.7540,
                Longitude = 33.3740,
                PostCode = "74900",
                IsTop = false,
                Slug = "NovaKakhovka",
                ImageUrl_Main = "images/cities/NovaKakhovka.jpg",
                ImageUrl_1 = "images/cities/NovaKakhovka_1.jpg",
                ImageUrl_2 = "images/cities/NovaKakhovka_2.jpg",
                ImageUrl_3 = "images/cities/NovaKakhovka_3.jpg",
            },

            // Каховка
            new City
            {
                id = 82,
                RegionId = 21,
                Latitude = 46.7510,
                Longitude = 33.3700,
                PostCode = "74901",
                IsTop = false,
                Slug = "Kakhovka",
                ImageUrl_Main = "images/cities/Kakhovka.jpg",
                ImageUrl_1 = "images/cities/Kakhovka_1.jpg",
                ImageUrl_2 = "images/cities/Kakhovka_2.jpg",
                ImageUrl_3 = "images/cities/Kakhovka_3.jpg",
            },
            // Хмельницький
            new City
            {
                id = 83,
                RegionId = 22, // Хмельницька область
                Latitude = 49.4220,
                Longitude = 26.9960,
                PostCode = "29000",
                IsTop = true,
                Slug = "Khmelnytskyi",
                ImageUrl_Main = "images/cities/Khmelnytskyi/Khmelnytskyi.jpg",
                ImageUrl_1 = "images/cities/Khmelnytskyi/Khmelnytskyi_1.jpg",
                ImageUrl_2 = "images/cities/Khmelnytskyi/Khmelnytskyi_2.jpg",
                ImageUrl_3 = "images/cities/Khmelnytskyi/Khmelnytskyi_3.jpg",
            },

            // Кам’янець-Подільський
            new City
            {
                id = 84,
                RegionId = 22,
                Latitude = 48.6830,
                Longitude = 26.5830,
                PostCode = "32300",
                IsTop = true,
                Slug = "KamianetsPodilskyi",
                ImageUrl_Main = "images/cities/KamianetsPodilskyi.jpg",
                ImageUrl_1 = "images/cities/KamianetsPodilskyi_1.jpg",
                ImageUrl_2 = "images/cities/KamianetsPodilskyi_2.jpg",
                ImageUrl_3 = "images/cities/KamianetsPodilskyi_3.jpg",
            },

            // Шепетівка
            new City
            {
                id = 85,
                RegionId = 22,
                Latitude = 50.1850,
                Longitude = 27.0730,
                PostCode = "30400",
                IsTop = false,
                Slug = "Shepetivka",
                ImageUrl_Main = "images/cities/Shepetivka.jpg",
                ImageUrl_1 = "images/cities/Shepetivka_1.jpg",
                ImageUrl_2 = "images/cities/Shepetivka_2.jpg",
                ImageUrl_3 = "images/cities/Shepetivka_3.jpg",
            },

            // Черкаси
            new City
            {
                id = 86,
                RegionId = 23, // Черкаська область
                Latitude = 49.4444,
                Longitude = 32.0598,
                PostCode = "18000",
                IsTop = true,
                Slug = "Cherkasy",
                ImageUrl_Main = "images/cities/Cherkasy/Cherkasy.jpg",
                ImageUrl_1 = "images/cities/Cherkasy/Cherkasy_1.jpg",
                ImageUrl_2 = "images/cities/Cherkasy/Cherkasy_2.jpg",
                ImageUrl_3 = "images/cities/Cherkasy/Cherkasy_3.jpg",
            },

            // Умань
            new City
            {
                id = 87,
                RegionId = 23,
                Latitude = 48.7520,
                Longitude = 30.2190,
                PostCode = "20300",
                IsTop = true,
                Slug = "Uman",
                ImageUrl_Main = "images/cities/Uman.jpg",
                ImageUrl_1 = "images/cities/Uman_1.jpg",
                ImageUrl_2 = "images/cities/Uman_2.jpg",
                ImageUrl_3 = "images/cities/Uman_3.jpg",
            },

            // Сміла
            new City
            {
                id = 88,
                RegionId = 23,
                Latitude = 49.2260,
                Longitude = 31.8750,
                PostCode = "20700",
                IsTop = false,
                Slug = "Smila",
                ImageUrl_Main = "images/cities/Smila.jpg",
                ImageUrl_1 = "images/cities/Smila_1.jpg",
                ImageUrl_2 = "images/cities/Smila_2.jpg",
                ImageUrl_3 = "images/cities/Smila_3.jpg",
            },
            // Чернівці
            new City
            {
                id = 89,
                RegionId = 24, // Чернівецька область
                Latitude = 48.2915,
                Longitude = 25.9403,
                PostCode = "58000",
                IsTop = true,
                Slug = "Chernivtsi",
                ImageUrl_Main = "images/cities/Chernivtsi/Chernivtsi.jpg",
                ImageUrl_1 = "images/cities/Chernivtsi/Chernivtsi_1.jpg",
                ImageUrl_2 = "images/cities/Chernivtsi/Chernivtsi_2.jpg",
                ImageUrl_3 = "images/cities/Chernivtsi/Chernivtsi_3.jpg",
            },

            // Хотин
            new City
            {
                id = 90,
                RegionId = 24,
                Latitude = 48.4920,
                Longitude = 26.4960,
                PostCode = "60000",
                IsTop = false,
                Slug = "Khotyn",
                ImageUrl_Main = "images/cities/KyiKhotynv.jpg",
                ImageUrl_1 = "images/cities/Khotyn_1.jpg",
                ImageUrl_2 = "images/cities/Khotyn_2.jpg",
                ImageUrl_3 = "images/cities/Khotyn_3.jpg",
            },

            // Новодністровськ
            new City
            {
                id = 91,
                RegionId = 24,
                Latitude = 48.5660,
                Longitude = 26.7990,
                PostCode = "60200",
                IsTop = false,
                Slug = "Novodnistrovsk",
                ImageUrl_Main = "images/cities/Novodnistrovsk.jpg",
                ImageUrl_1 = "images/cities/Novodnistrovsk_1.jpg",
                ImageUrl_2 = "images/cities/Novodnistrovsk_2.jpg",
                ImageUrl_3 = "images/cities/Novodnistrovsk_3.jpg",
            },

            // Чернігів
            new City
            {
                id = 92,
                RegionId = 25, // Чернігівська область
                Latitude = 51.5055,
                Longitude = 31.2849,
                PostCode = "14000",
                IsTop = true,
                Slug = "Chernihiv",
                ImageUrl_Main = "images/cities/Chernihiv/Chernihiv.jpg",
                ImageUrl_1 = "images/cities/Chernihiv/Chernihiv_1.jpg",
                ImageUrl_2 = "images/cities/Chernihiv/Chernihiv_2.jpg",
                ImageUrl_3 = "images/cities/Chernihiv/Chernihiv_3.jpg",
            },

            // Ніжин
            new City
            {
                id = 93,
                RegionId = 25,
                Latitude = 51.0485,
                Longitude = 31.9666,
                PostCode = "16600",
                IsTop = false,
                Slug = "Nizhyn",
                ImageUrl_Main = "images/cities/Nizhyn.jpg",
                ImageUrl_1 = "images/cities/Nizhyn_1.jpg",
                ImageUrl_2 = "images/cities/Nizhyn_2.jpg",
                ImageUrl_3 = "images/cities/Nizhyn_3.jpg",
            },

            // Прилуки
            new City
            {
                id = 94,
                RegionId = 25,
                Latitude = 50.5940,
                Longitude = 32.3600,
                PostCode = "17500",
                IsTop = false,
                Slug = "Pryluky",
                ImageUrl_Main = "images/cities/Pryluky.jpg",
                ImageUrl_1 = "images/cities/Pryluky_1.jpg",
                ImageUrl_2 = "images/cities/Pryluky_2.jpg",
                ImageUrl_3 = "images/cities/Pryluky_3.jpg",
            },
            // =================== USA ===================

            new City
            {
                id = 95,
                RegionId = 28, // New York
                Latitude = 40.7128,
                Longitude = -74.0060,
                PostCode = "10001",
                IsTop = true,
                Slug = "NewYork",
                ImageUrl_Main = "images/cities/NewYork.jpg",
                ImageUrl_1 = "images/cities/NewYork_1.jpg",
                ImageUrl_2 = "images/cities/NewYork_2.jpg",
                ImageUrl_3 = "images/cities/NewYork_3.jpg",
            },
            new City
            {
                id = 96,
                RegionId = 28, // Лос-Анджелес
                Latitude = 34.0522,
                Longitude = -118.2437,
                PostCode = "90001",
                IsTop = true,
                Slug = "LosAngeles",
                ImageUrl_Main = "images/cities/LosAngeles.jpg",
                ImageUrl_1 = "images/cities/LosAngeles_1.jpg",
                ImageUrl_2 = "images/cities/LosAngeles_2.jpg",
                ImageUrl_3 = "images/cities/LosAngeles_3.jpg",
            },
            new City
            {
                id = 97,
                RegionId = 28, // Chicago
                Latitude = 41.8781,
                Longitude = -87.6298,
                PostCode = "60601",
                IsTop = true,
                Slug = "Chicago",
                ImageUrl_Main = "images/cities/Chicago.jpg",
                ImageUrl_1 = "images/cities/Chicago_1.jpg",
                ImageUrl_2 = "images/cities/Chicago_2.jpg",
                ImageUrl_3 = "images/cities/Chicago_3.jpg",
            },
            new City
            {
                id = 98,
                RegionId = 29, // Берлін
                Latitude = 52.5200,
                Longitude = 13.4050,
                PostCode = "10115",
                IsTop = true,
                Slug = "Berlin",
                ImageUrl_Main = "images/cities/KyBerliniv.jpg",
                ImageUrl_1 = "images/cities/Berlin_1.jpg",
                ImageUrl_2 = "images/cities/Berlin_2.jpg",
                ImageUrl_3 = "images/cities/Berlin_3.jpg",
            },
            new City
            {
                id = 99,
                RegionId = 29, // Мюнхен
                Latitude = 48.1351,
                Longitude = 11.5820,
                PostCode = "80331",
                IsTop = true,
                Slug = "Munich",
                ImageUrl_Main = "images/cities/Munich.jpg",
                ImageUrl_1 = "images/cities/Munich_1.jpg",
                ImageUrl_2 = "images/cities/Munich_2.jpg",
                ImageUrl_3 = "images/cities/Munich_3.jpg",
            },

            new City
            {
                id = 100,
                RegionId = 29, // Гамбург
                Latitude = 53.5511,
                Longitude = 9.9937,
                PostCode = "20095",
                IsTop = true,
                Slug = "Hamburg",
                ImageUrl_Main = "images/cities/Hamburg.jpg",
                ImageUrl_1 = "images/cities/Hamburg_1.jpg",
                ImageUrl_2 = "images/cities/Hamburg_2.jpg",
                ImageUrl_3 = "images/cities/Hamburg_3.jpg",
            },
            new City
            {
                id = 101,
                RegionId = 30, // Париж
                Latitude = 48.8566,
                Longitude = 2.3522,
                PostCode = "75000",
                IsTop = true,
                Slug = "Paris",
                ImageUrl_Main = "images/cities/Paris.jpg",
                ImageUrl_1 = "images/cities/Paris_1.jpg",
                ImageUrl_2 = "images/cities/Paris_2.jpg",
                ImageUrl_3 = "images/cities/Paris_3.jpg",
            },
            new City
            {
                id = 102,
                RegionId = 30, // Ліон
                Latitude = 45.7640,
                Longitude = 4.8357,
                PostCode = "69000",
                IsTop = true,
                Slug = "Lyon",
                ImageUrl_Main = "images/cities/Lyon.jpg",
                ImageUrl_1 = "images/cities/Lyon_1.jpg",
                ImageUrl_2 = "images/cities/Lyon_2.jpg",
                ImageUrl_3 = "images/cities/Lyon_3.jpg",
            },
            new City
            {
                id = 103,
                RegionId = 30, // Марсель
                Latitude = 43.2965,
                Longitude = 5.3698,
                PostCode = "13000",
                IsTop = true,
                Slug = "Marseille",
                ImageUrl_Main = "images/cities/Marseille.jpg",
                ImageUrl_1 = "images/cities/Marseille_1.jpg",
                ImageUrl_2 = "images/cities/Marseille_2.jpg",
                ImageUrl_3 = "images/cities/Marseille_3.jpg",
            },
            new City
            {
                id = 104,
                RegionId = 31, // Лондон
                Latitude = 51.5074,
                Longitude = -0.1278,
                PostCode = "EC1A",
                IsTop = true,
                Slug = "London",
                ImageUrl_Main = "images/cities/London.jpg",
                ImageUrl_1 = "images/cities/London_1.jpg",
                ImageUrl_2 = "images/cities/London_2.jpg",
                ImageUrl_3 = "images/cities/London_3.jpg",
            },
            new City
            {
                id = 105,
                RegionId = 31, // Манчестер
                Latitude = 53.4808,
                Longitude = -2.2426,
                PostCode = "M1",
                IsTop = true,
                Slug = "Manchester",
                ImageUrl_Main = "images/cities/Manchester.jpg",
                ImageUrl_1 = "images/cities/Manchester_1.jpg",
                ImageUrl_2 = "images/cities/Manchester_2.jpg",
                ImageUrl_3 = "images/cities/Manchester_3.jpg",
            },
            new City
            {
                id = 106,
                RegionId = 31, // Бірмінгем
                Latitude = 52.4862,
                Longitude = -1.8904,
                PostCode = "B1",
                IsTop = true,
                Slug = "Birmingham",
                ImageUrl_Main = "images/cities/Birmingham.jpg",
                ImageUrl_1 = "images/cities/Birmingham_1.jpg",
                ImageUrl_2 = "images/cities/Birmingham_2.jpg",
                ImageUrl_3 = "images/cities/Birmingham_3.jpg",
            },
            new City
            {
                id = 107,
                RegionId = 32, // Мадрид
                Latitude = 40.4168,
                Longitude = -3.7038,
                PostCode = "28001",
                IsTop = true,
                Slug = "Madrid",
                ImageUrl_Main = "images/cities/Madrid.jpg",
                ImageUrl_1 = "images/cities/Madrid_1.jpg",
                ImageUrl_2 = "images/cities/Madrid_2.jpg",
                ImageUrl_3 = "images/cities/Madrid_3.jpg",
            },
            new City
            {
                id = 108,
                RegionId = 32, // Barcelona
                Latitude = 41.3851,
                Longitude = 2.1734,
                PostCode = "08001",
                IsTop = true,
                Slug = "Barcelona",
                ImageUrl_Main = "images/cities/Barcelona.jpg",
                ImageUrl_1 = "images/cities/Barcelona_1.jpg",
                ImageUrl_2 = "images/cities/Barcelona_2.jpg",
                ImageUrl_3 = "images/cities/Barcelona_3.jpg",
            },
            new City
            {
                id = 109,
                RegionId = 32, // Валенсія
                Latitude = 39.4699,
                Longitude = -0.3763,
                PostCode = "46001",
                IsTop = true,
                Slug = "Valencia",
                ImageUrl_Main = "images/cities/Valencia.jpg",
                ImageUrl_1 = "images/cities/Valencia_1.jpg",
                ImageUrl_2 = "images/cities/Valencia_2.jpg",
                ImageUrl_3 = "images/cities/Valencia_3.jpg",
            },
            new City
            {
                id = 110,
                RegionId = 33, // Варшава
                Latitude = 52.2297,
                Longitude = 21.0122,
                PostCode = "00-001",
                IsTop = true,

                Slug = "Warsaw",
                ImageUrl_Main = "images/cities/Warsaw.jpg",
                ImageUrl_1 = "images/cities/Warsaw_1.jpg",
                ImageUrl_2 = "images/cities/Warsaw_2.jpg",
                ImageUrl_3 = "images/cities/Warsaw_3.jpg",
            },
            new City
            {
                id = 111,
                RegionId = 33, // Краків
                Latitude = 50.0647,
                Longitude = 19.9450,
                PostCode = "31-001",
                IsTop = true,
                Slug = "Krakow",
                ImageUrl_Main = "images/cities/Krakow.jpg",
                ImageUrl_1 = "images/cities/Krakow_1.jpg",
                ImageUrl_2 = "images/cities/Krakow_2.jpg",
                ImageUrl_3 = "images/cities/Krakow_3.jpg",
            },
            new City
            {
                id = 112,
                RegionId = 33, // Познань
                Latitude = 52.4064,
                Longitude = 16.9252,
                PostCode = "60-001",
                IsTop = true,
                Slug = "Poznan",
                ImageUrl_Main = "images/cities/Poznan.jpg",
                ImageUrl_1 = "images/cities/Poznan_1.jpg",
                ImageUrl_2 = "images/cities/Poznan_2.jpg",
                ImageUrl_3 = "images/cities/Poznan_3.jpg",
            }

         );


            //modelBuilder.Entity<District>().HasData(
            //// =================== Украина ===================
            //// Київ
            //new District { id = 1, CityId = 1, Latitude = 50.4501, Longitude = 30.5234 },
            //new District { id = 2, CityId = 1, Latitude = 50.4547, Longitude = 30.5238 },
            //new District { id = 3, CityId = 1, Latitude = 50.4470, Longitude = 30.5180 },

            //// Ужгород
            //new District { id = 4, CityId = 2, Latitude = 48.6196, Longitude = 22.2879 },
            //new District { id = 5, CityId = 2, Latitude = 48.6220, Longitude = 22.2900 },
            //new District { id = 6, CityId = 2, Latitude = 48.6150, Longitude = 22.2850 },

            //// Львів
            //new District { id = 7, CityId = 3, Latitude = 49.8397, Longitude = 24.0297 },
            //new District { id = 8, CityId = 3, Latitude = 49.8420, Longitude = 24.0310 },
            //new District { id = 9, CityId = 3, Latitude = 49.8360, Longitude = 24.0250 },

            //// Оdesa
            //new District { id = 10, CityId = 4, Latitude = 46.4825, Longitude = 30.7233 },
            //new District { id = 11, CityId = 4, Latitude = 46.4850, Longitude = 30.7280 },
            //new District { id = 12, CityId = 4, Latitude = 46.4780, Longitude = 30.7180 },

            //// Тернопіль
            //new District { id = 13, CityId = 5, Latitude = 49.5535, Longitude = 25.5948 },
            //new District { id = 14, CityId = 5, Latitude = 49.5560, Longitude = 25.5980 },
            //new District { id = 15, CityId = 5, Latitude = 49.5500, Longitude = 25.5900 },

            //// Івано-Франківськ
            //new District { id = 16, CityId = 6, Latitude = 48.9226, Longitude = 24.7111 },
            //new District { id = 17, CityId = 6, Latitude = 48.9300, Longitude = 24.7200 },
            //new District { id = 18, CityId = 6, Latitude = 48.9150, Longitude = 24.7000 },

            //// Донецьк
            //new District { id = 19, CityId = 7, Latitude = 48.7460, Longitude = 37.5853 },
            //new District { id = 20, CityId = 7, Latitude = 48.7500, Longitude = 37.5900 },
            //new District { id = 21, CityId = 7, Latitude = 48.7400, Longitude = 37.5800 },

            //// Запоріжжя
            //new District { id = 22, CityId = 8, Latitude = 47.8388, Longitude = 35.1396 },
            //new District { id = 23, CityId = 8, Latitude = 47.8450, Longitude = 35.1450 },
            //new District { id = 24, CityId = 8, Latitude = 47.8300, Longitude = 35.1300 },

            //// Чернігів
            //new District { id = 25, CityId = 9, Latitude = 50.9077, Longitude = 34.7981 },
            //new District { id = 26, CityId = 9, Latitude = 50.9100, Longitude = 34.8000 },
            //new District { id = 27, CityId = 9, Latitude = 50.9050, Longitude = 34.7950 },

            //// Хмельницький
            //new District { id = 28, CityId = 10, Latitude = 49.5883, Longitude = 34.5514 },
            //new District { id = 29, CityId = 10, Latitude = 49.5900, Longitude = 34.5550 },
            //new District { id = 30, CityId = 10, Latitude = 49.5850, Longitude = 34.5450 },

            //// Черкаси
            //new District { id = 31, CityId = 11, Latitude = 49.2331, Longitude = 28.4682 },
            //new District { id = 32, CityId = 11, Latitude = 49.2350, Longitude = 28.4700 },
            //new District { id = 33, CityId = 11, Latitude = 49.2300, Longitude = 28.4650 },

            //// Полтава
            //new District { id = 34, CityId = 12, Latitude = 49.4451, Longitude = 32.0598 },
            //new District { id = 35, CityId = 12, Latitude = 49.4500, Longitude = 32.0650 },
            //new District { id = 36, CityId = 12, Latitude = 49.4400, Longitude = 32.0500 },

            //// Київська (Біла Церква)
            //new District { id = 37, CityId = 13, Latitude = 50.2915, Longitude = 30.4999 },
            //new District { id = 38, CityId = 13, Latitude = 50.2950, Longitude = 30.5050 },
            //new District { id = 39, CityId = 13, Latitude = 50.2880, Longitude = 30.4950 },

            //// Миколаїв
            //new District { id = 40, CityId = 14, Latitude = 46.9750, Longitude = 31.9946 },
            //new District { id = 41, CityId = 14, Latitude = 46.9800, Longitude = 32.0000 },
            //new District { id = 42, CityId = 14, Latitude = 46.9700, Longitude = 31.9900 },

            //// Херсон
            //new District { id = 43, CityId = 15, Latitude = 46.4900, Longitude = 30.7326 },
            //new District { id = 44, CityId = 15, Latitude = 46.4950, Longitude = 30.7400 },
            //new District { id = 45, CityId = 15, Latitude = 46.4850, Longitude = 30.7250 },

            //// Луганськ (Сєвєродонецьк)
            //new District { id = 46, CityId = 16, Latitude = 48.4623, Longitude = 35.0462 },
            //new District { id = 47, CityId = 16, Latitude = 48.4650, Longitude = 35.0500 },
            //new District { id = 48, CityId = 16, Latitude = 48.4600, Longitude = 35.0400 },

            //// Рівне
            //new District { id = 49, CityId = 17, Latitude = 48.6187, Longitude = 26.2516 },
            //new District { id = 50, CityId = 17, Latitude = 48.6200, Longitude = 26.2550 },
            //new District { id = 51, CityId = 17, Latitude = 48.6150, Longitude = 26.2450 },

            //// Луцьк
            //new District { id = 52, CityId = 18, Latitude = 49.8282, Longitude = 23.9422 },
            //new District { id = 53, CityId = 18, Latitude = 49.8300, Longitude = 23.9450 },
            //new District { id = 54, CityId = 18, Latitude = 49.8250, Longitude = 23.9350 },

            //// Чернівці
            //new District { id = 55, CityId = 19, Latitude = 48.1546, Longitude = 23.5657 },
            //new District { id = 56, CityId = 19, Latitude = 48.1570, Longitude = 23.5700 },
            //new District { id = 57, CityId = 19, Latitude = 48.1500, Longitude = 23.5600 },

            //// Житомир
            //new District { id = 58, CityId = 20, Latitude = 50.0000, Longitude = 32.0000 },
            //new District { id = 59, CityId = 20, Latitude = 50.0030, Longitude = 32.0050 },
            //new District { id = 60, CityId = 20, Latitude = 49.9950, Longitude = 31.9950 },

            //// Суми
            //new District { id = 61, CityId = 21, Latitude = 50.0050, Longitude = 36.2310 },
            //new District { id = 62, CityId = 21, Latitude = 50.0100, Longitude = 36.2350 },
            //new District { id = 63, CityId = 21, Latitude = 50.0000, Longitude = 36.2250 },

            //// Кропивницький
            //new District { id = 64, CityId = 22, Latitude = 48.5000, Longitude = 32.2600 },
            //new District { id = 65, CityId = 22, Latitude = 48.5050, Longitude = 32.2650 },
            //new District { id = 66, CityId = 22, Latitude = 48.4950, Longitude = 32.2550 },

            //// Вінниця
            //new District { id = 67, CityId = 23, Latitude = 49.2330, Longitude = 28.4680 },
            //new District { id = 68, CityId = 23, Latitude = 49.2350, Longitude = 28.4700 },
            //new District { id = 69, CityId = 23, Latitude = 49.2300, Longitude = 28.4650 },

            //// Харків
            //new District { id = 70, CityId = 24, Latitude = 50.0050, Longitude = 36.2310 },
            //new District { id = 71, CityId = 24, Latitude = 50.0100, Longitude = 36.2350 },
            //new District { id = 72, CityId = 24, Latitude = 50.0000, Longitude = 36.2250 },

            //// =================== USA ===================
            //// New York
            //new District { id = 73, CityId = 25, Latitude = 40.7831, Longitude = -73.9712 },
            // new District { id = 74, CityId = 25, Latitude = 40.6782, Longitude = -73.9442 },
            // new District { id = 75, CityId = 25, Latitude = 40.7282, Longitude = -73.7949 },

            // // Los Angeles
            // new District { id = 76, CityId = 26, Latitude = 34.0928, Longitude = -118.3287 },
            // new District { id = 77, CityId = 26, Latitude = 34.0407, Longitude = -118.2468 },
            // new District { id = 78, CityId = 26, Latitude = 34.0736, Longitude = -118.4004 },
            //// --- Chicago ---
            //new District { id = 79, CityId = 27, Latitude = 41.8837, Longitude = -87.6325 },
            //new District { id = 80, CityId = 27, Latitude = 41.9214, Longitude = -87.6513 },
            //new District { id = 81, CityId = 27, Latitude = 41.7943, Longitude = -87.5907 },

            //// --- Berlin ---
            //new District { id = 109, CityId = 28, Latitude = 52.5200, Longitude = 13.4049 },
            //new District { id = 110, CityId = 28, Latitude = 52.4990, Longitude = 13.4030 },
            //new District { id = 111, CityId = 28, Latitude = 52.5167, Longitude = 13.3041 },

            //// --- Munich ---
            //new District { id = 112, CityId = 29, Latitude = 48.1374, Longitude = 11.5755 },
            //new District { id = 113, CityId = 29, Latitude = 48.1500, Longitude = 11.5670 },
            //new District { id = 114, CityId = 29, Latitude = 48.1690, Longitude = 11.5800 },

            //// --- Hamburg ---
            //new District { id = 115, CityId = 30, Latitude = 53.5511, Longitude = 9.9410 },
            //new District { id = 116, CityId = 30, Latitude = 53.5565, Longitude = 9.9640 },
            //new District { id = 117, CityId = 30, Latitude = 53.5830, Longitude = 9.9650 },

            //// --- Paris ---
            //new District { id = 118, CityId = 31, Latitude = 48.8867, Longitude = 2.3431 },
            //new District { id = 119, CityId = 31, Latitude = 48.8494, Longitude = 2.3470 },
            //new District { id = 120, CityId = 31, Latitude = 48.8590, Longitude = 2.3622 },

            //// --- Lyon ---
            //new District { id = 121, CityId = 32, Latitude = 45.7601, Longitude = 4.8260 },
            //new District { id = 122, CityId = 32, Latitude = 45.7597, Longitude = 4.8330 },
            //new District { id = 123, CityId = 32, Latitude = 45.7764, Longitude = 4.8272 },

            //// --- Marseille ---
            //new District { id = 124, CityId = 33, Latitude = 43.2990, Longitude = 5.3710 },
            //new District { id = 125, CityId = 33, Latitude = 43.2963, Longitude = 5.3699 },
            //new District { id = 126, CityId = 33, Latitude = 43.3220, Longitude = 5.3970 },

            //// --- London ---
            //new District { id = 127, CityId = 34, Latitude = 51.5390, Longitude = -0.1420 },
            //new District { id = 128, CityId = 34, Latitude = 51.4975, Longitude = -0.1357 },
            //new District { id = 129, CityId = 34, Latitude = 51.4826, Longitude = 0.0077 },

            //// --- Manchester ---
            //new District { id = 130, CityId = 35, Latitude = 53.4840, Longitude = -2.2350 },
            //new District { id = 131, CityId = 35, Latitude = 53.4160, Longitude = -2.2310 },
            //new District { id = 132, CityId = 35, Latitude = 53.4740, Longitude = -2.2920 },

            //// --- Birmingham ---
            //new District { id = 133, CityId = 36, Latitude = 52.4550, Longitude = -1.9250 },
            //new District { id = 134, CityId = 36, Latitude = 52.4896, Longitude = -1.9129 },
            //new District { id = 135, CityId = 36, Latitude = 52.4415, Longitude = -1.9369 },

            //// --- Madrid ---
            //new District { id = 136, CityId = 37, Latitude = 40.4167, Longitude = -3.7033 },
            //new District { id = 137, CityId = 37, Latitude = 40.4297, Longitude = -3.6860 },
            //new District { id = 138, CityId = 37, Latitude = 40.4589, Longitude = -3.6779 },

            //// --- Barcelona ---
            //new District { id = 139, CityId = 38, Latitude = 41.3900, Longitude = 2.1650 },
            //new District { id = 140, CityId = 38, Latitude = 41.3833, Longitude = 2.1767 },
            //new District { id = 141, CityId = 38, Latitude = 41.4036, Longitude = 2.1566 },

            //// --- Valencia ---
            //new District { id = 142, CityId = 39, Latitude = 39.4740, Longitude = -0.3763 },
            //new District { id = 143, CityId = 39, Latitude = 39.4640, Longitude = -0.3760 },
            //new District { id = 144, CityId = 39, Latitude = 39.4700, Longitude = -0.3200 },

            //// --- Warsaw ---
            //new District { id = 145, CityId = 40, Latitude = 52.2310, Longitude = 21.0122 },
            //new District { id = 146, CityId = 40, Latitude = 52.2400, Longitude = 20.9800 },
            //new District { id = 147, CityId = 40, Latitude = 52.2550, Longitude = 21.0300 },

            //// --- Krakow ---
            //new District { id = 148, CityId = 41, Latitude = 50.0614, Longitude = 19.9372 },
            //new District { id = 149, CityId = 41, Latitude = 50.0515, Longitude = 19.9440 },
            //new District { id = 150, CityId = 41, Latitude = 50.0400, Longitude = 19.9500 },

            //// --- Poznan ---
            //new District { id = 151, CityId = 42, Latitude = 52.4095, Longitude = 16.9319 },
            //new District { id = 152, CityId = 42, Latitude = 52.3980, Longitude = 16.9030 },
            //new District { id = 153, CityId = 42, Latitude = 52.3930, Longitude = 16.9260 }


            //);



        }
    }
}
