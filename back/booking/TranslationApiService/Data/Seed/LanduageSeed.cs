using Microsoft.EntityFrameworkCore;
using TranslationApiService.Models;
using TranslationApiService.Models.Attraction;
using TranslationApiService.Models.Location;
using TranslationApiService.Models.Offer;

namespace TranslationApiService.Data.Seed
{
    public static class LanguageSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Языки
            modelBuilder.Entity<Language>().HasData(
                new Language { id = 1, Code = "en", Name = "English", IsEnabled = true },
                new Language { id = 2, Code = "ru", Name = "Russian", IsEnabled = true },
                new Language { id = 3, Code = "uk", Name = "Ukrainian", IsEnabled = true }
            );

            // Переводы стран
            modelBuilder.Entity<CountryTranslation>().HasData(
             // Ukraine
             new CountryTranslation { id = 1, EntityId = 1, Lang = "en", Title = "Ukraine" },
             new CountryTranslation { id = 2, EntityId = 1, Lang = "uk", Title = "Україна" },

             // United States
             new CountryTranslation { id = 3, EntityId = 2, Lang = "en", Title = "United States" },
             new CountryTranslation { id = 4, EntityId = 2, Lang = "uk", Title = "США" },

             // Germany
             new CountryTranslation { id = 5, EntityId = 3, Lang = "en", Title = "Germany" },
             new CountryTranslation { id = 6, EntityId = 3, Lang = "uk", Title = "Німеччина" },

             // France
             new CountryTranslation { id = 7, EntityId = 4, Lang = "en", Title = "France" },
             new CountryTranslation { id = 8, EntityId = 4, Lang = "uk", Title = "Франція" },

             // United Kingdom
             new CountryTranslation { id = 9, EntityId = 5, Lang = "en", Title = "United Kingdom" },
             new CountryTranslation { id = 10, EntityId = 5, Lang = "uk", Title = "Велика Британія" },

             // Spain
             new CountryTranslation { id = 11, EntityId = 6, Lang = "en", Title = "Spain" },
             new CountryTranslation { id = 12, EntityId = 6, Lang = "uk", Title = "Іспанія" },

             // Poland
             new CountryTranslation { id = 13, EntityId = 7, Lang = "en", Title = "Poland" },
             new CountryTranslation { id = 14, EntityId = 7, Lang = "uk", Title = "Польща" }
         );



            modelBuilder.Entity<RegionTranslation>().HasData(

             // =================== Україна ===================
             new RegionTranslation { id = 1, EntityId = 1, Lang = "en", Title = "Kyiv" },
             new RegionTranslation { id = 2, EntityId = 1, Lang = "uk", Title = "Київ" },

             new RegionTranslation { id = 3, EntityId = 2, Lang = "en", Title = "Zakarpattia Oblast" },
             new RegionTranslation { id = 4, EntityId = 2, Lang = "uk", Title = "Закарпатська область" },

             new RegionTranslation { id = 5, EntityId = 3, Lang = "en", Title = "Lviv Oblast" },
             new RegionTranslation { id = 6, EntityId = 3, Lang = "uk", Title = "Львівська область" },

             new RegionTranslation { id = 7, EntityId = 4, Lang = "en", Title = "Odesa Oblast" },
             new RegionTranslation { id = 8, EntityId = 4, Lang = "uk", Title = "Одеська область" },

             new RegionTranslation { id = 9, EntityId = 5, Lang = "en", Title = "Ternopil Oblast" },
             new RegionTranslation { id = 10, EntityId = 5, Lang = "uk", Title = "Тернопільська область" },

             new RegionTranslation { id = 11, EntityId = 6, Lang = "en", Title = "Ivano-Frankivsk Oblast" },
             new RegionTranslation { id = 12, EntityId = 6, Lang = "uk", Title = "Івано-Франківська область" },

             new RegionTranslation { id = 13, EntityId = 7, Lang = "en", Title = "Donetsk Oblast" },
             new RegionTranslation { id = 14, EntityId = 7, Lang = "uk", Title = "Донецька область" },

             new RegionTranslation { id = 15, EntityId = 8, Lang = "en", Title = "Zaporizhzhia Oblast" },
             new RegionTranslation { id = 16, EntityId = 8, Lang = "uk", Title = "Запорізька область" },

             new RegionTranslation { id = 17, EntityId = 9, Lang = "en", Title = "Chernihiv Oblast" },
             new RegionTranslation { id = 18, EntityId = 9, Lang = "uk", Title = "Чернігівська область" },

             new RegionTranslation { id = 19, EntityId = 10, Lang = "en", Title = "Khmelnytskyi Oblast" },
             new RegionTranslation { id = 20, EntityId = 10, Lang = "uk", Title = "Хмельницька область" },

             new RegionTranslation { id = 21, EntityId = 11, Lang = "en", Title = "Cherkasy Oblast" },
             new RegionTranslation { id = 22, EntityId = 11, Lang = "uk", Title = "Черкаська область" },

             new RegionTranslation { id = 23, EntityId = 12, Lang = "en", Title = "Lviv Oblast" },
             new RegionTranslation { id = 24, EntityId = 12, Lang = "uk", Title = "Львівська область" },

             new RegionTranslation { id = 25, EntityId = 13, Lang = "en", Title = "Kyiv Oblast" },
             new RegionTranslation { id = 26, EntityId = 13, Lang = "uk", Title = "Київська область" },

             new RegionTranslation { id = 27, EntityId = 14, Lang = "en", Title = "Poltava Oblast" },
             new RegionTranslation { id = 28, EntityId = 14, Lang = "uk", Title = "Полтавська область" },

             new RegionTranslation { id = 29, EntityId = 15, Lang = "en", Title = "Zakarpattia Oblast" },
             new RegionTranslation { id = 30, EntityId = 15, Lang = "uk", Title = "Закарпатська область" },

             new RegionTranslation { id = 31, EntityId = 16, Lang = "en", Title = "Volyn Oblast" },
             new RegionTranslation { id = 32, EntityId = 16, Lang = "uk", Title = "Волинська область" },

             new RegionTranslation { id = 33, EntityId = 17, Lang = "en", Title = "Dnipropetrovsk Oblast" },
             new RegionTranslation { id = 34, EntityId = 17, Lang = "uk", Title = "Дніпропетровська область" },

             new RegionTranslation { id = 35, EntityId = 18, Lang = "en", Title = "Ivano-Frankivsk Oblast" },
             new RegionTranslation { id = 36, EntityId = 18, Lang = "uk", Title = "Івано-Франківська область" },

             new RegionTranslation { id = 37, EntityId = 19, Lang = "en", Title = "Chernivtsi Oblast" },
             new RegionTranslation { id = 38, EntityId = 19, Lang = "uk", Title = "Чернівецька область" },

             new RegionTranslation { id = 39, EntityId = 20, Lang = "en", Title = "Khmelnytskyi Oblast" },
             new RegionTranslation { id = 40, EntityId = 20, Lang = "uk", Title = "Хмельницька область" },

             new RegionTranslation { id = 41, EntityId = 21, Lang = "en", Title = "Zakarpattia Oblast" },
             new RegionTranslation { id = 42, EntityId = 21, Lang = "uk", Title = "Закарпатська область" },

             new RegionTranslation { id = 43, EntityId = 22, Lang = "en", Title = "Cherkasy Oblast" },
             new RegionTranslation { id = 44, EntityId = 22, Lang = "uk", Title = "Черкаська область" },

             new RegionTranslation { id = 45, EntityId = 23, Lang = "en", Title = "Mykolaiv Oblast" },
             new RegionTranslation { id = 46, EntityId = 23, Lang = "uk", Title = "Миколаївська область" },

             new RegionTranslation { id = 47, EntityId = 24, Lang = "en", Title = "Kherson Oblast" },
             new RegionTranslation { id = 48, EntityId = 24, Lang = "uk", Title = "Херсонська область" },

             new RegionTranslation { id = 49, EntityId = 25, Lang = "en", Title = "Luhansk Oblast" },
             new RegionTranslation { id = 50, EntityId = 25, Lang = "uk", Title = "Луганська область" },

             new RegionTranslation { id = 51, EntityId = 26, Lang = "en", Title = "Rivne Oblast" },
             new RegionTranslation { id = 52, EntityId = 26, Lang = "uk", Title = "Рівненська область" },

             // =================== USA ===================
             new RegionTranslation { id = 53, EntityId = 27, Lang = "en", Title = "New York State" },
             new RegionTranslation { id = 54, EntityId = 27, Lang = "uk", Title = "Штат Нью-Йорк" },

             new RegionTranslation { id = 55, EntityId = 28, Lang = "en", Title = "California" },
             new RegionTranslation { id = 56, EntityId = 28, Lang = "uk", Title = "Каліфорнія" },

             new RegionTranslation { id = 57, EntityId = 29, Lang = "en", Title = "Illinois" },
             new RegionTranslation { id = 58, EntityId = 29, Lang = "uk", Title = "Іллінойс" },

             // =================== Germany ===================
             new RegionTranslation { id = 59, EntityId = 30, Lang = "en", Title = "Berlin" },
             new RegionTranslation { id = 60, EntityId = 30, Lang = "uk", Title = "Берлін" },

             new RegionTranslation { id = 61, EntityId = 31, Lang = "en", Title = "Bavaria" },
             new RegionTranslation { id = 62, EntityId = 31, Lang = "uk", Title = "Баварія" },

             new RegionTranslation { id = 63, EntityId = 32, Lang = "en", Title = "Hamburg" },
             new RegionTranslation { id = 64, EntityId = 32, Lang = "uk", Title = "Гамбург" },

             // =================== France ===================
             new RegionTranslation { id = 65, EntityId = 33, Lang = "en", Title = "Île-de-France" },
             new RegionTranslation { id = 66, EntityId = 33, Lang = "uk", Title = "Іль-де-Франс" },

             new RegionTranslation { id = 67, EntityId = 34, Lang = "en", Title = "Auvergne-Rhône-Alpes" },
             new RegionTranslation { id = 68, EntityId = 34, Lang = "uk", Title = "Овернь-Рона-Альпи" },

             new RegionTranslation { id = 69, EntityId = 35, Lang = "en", Title = "Provence-Alpes-Côte d'Azur" },
             new RegionTranslation { id = 70, EntityId = 35, Lang = "uk", Title = "Прованс-Альпи-Лазурний берег" },

             // =================== UK ===================
             new RegionTranslation { id = 71, EntityId = 36, Lang = "en", Title = "England (London)" },
             new RegionTranslation { id = 72, EntityId = 36, Lang = "uk", Title = "Англія (Лондон)" },

             new RegionTranslation { id = 73, EntityId = 37, Lang = "en", Title = "North West England" },
             new RegionTranslation { id = 74, EntityId = 37, Lang = "uk", Title = "Північно-Західна Англія" },

             new RegionTranslation { id = 75, EntityId = 38, Lang = "en", Title = "West Midlands" },
             new RegionTranslation { id = 76, EntityId = 38, Lang = "uk", Title = "Вест-Мідлендс" },

             // =================== Spain ===================
             new RegionTranslation { id = 77, EntityId = 39, Lang = "en", Title = "Community of Madrid" },
             new RegionTranslation { id = 78, EntityId = 39, Lang = "uk", Title = "Мадридська спільнота" },

             new RegionTranslation { id = 79, EntityId = 40, Lang = "en", Title = "Catalonia" },
             new RegionTranslation { id = 80, EntityId = 40, Lang = "uk", Title = "Каталонія" },

             new RegionTranslation { id = 81, EntityId = 41, Lang = "en", Title = "Valencian Community" },
             new RegionTranslation { id = 82, EntityId = 41, Lang = "uk", Title = "Валенсійська спільнота" },

             // =================== Poland ===================
             new RegionTranslation { id = 83, EntityId = 42, Lang = "en", Title = "Mazowieckie Voivodeship" },
             new RegionTranslation { id = 84, EntityId = 42, Lang = "uk", Title = "Мазовецьке воєводство" },

             new RegionTranslation { id = 85, EntityId = 43, Lang = "en", Title = "Lesser Poland Voivodeship" },
             new RegionTranslation { id = 86, EntityId = 43, Lang = "uk", Title = "Малопольське воєводство" },

             new RegionTranslation { id = 87, EntityId = 44, Lang = "en", Title = "Greater Poland Voivodeship" },
             new RegionTranslation { id = 88, EntityId = 44, Lang = "uk", Title = "Великопольське воєводство" }
         );



            modelBuilder.Entity<CityTranslation>().HasData(

            // =================== Україна ===================
            new CityTranslation { id = 1, EntityId = 1, Lang = "en", Title = "Kyiv" },
            new CityTranslation { id = 2, EntityId = 1, Lang = "uk", Title = "Київ" },

            new CityTranslation { id = 3, EntityId = 2, Lang = "en", Title = "Uzhhorod" },
            new CityTranslation { id = 4, EntityId = 2, Lang = "uk", Title = "Ужгород" },

            new CityTranslation { id = 5, EntityId = 3, Lang = "en", Title = "Lviv" },
            new CityTranslation { id = 6, EntityId = 3, Lang = "uk", Title = "Львів" },

            new CityTranslation { id = 7, EntityId = 4, Lang = "en", Title = "Odesa" },
            new CityTranslation { id = 8, EntityId = 4, Lang = "uk", Title = "Одеса" },

            new CityTranslation { id = 9, EntityId = 5, Lang = "en", Title = "Ternopil" },
            new CityTranslation { id = 10, EntityId = 5, Lang = "uk", Title = "Тернопіль" },

            new CityTranslation { id = 11, EntityId = 6, Lang = "en", Title = "Ivano-Frankivsk" },
            new CityTranslation { id = 12, EntityId = 6, Lang = "uk", Title = "Івано-Франківськ" },

            new CityTranslation { id = 13, EntityId = 7, Lang = "en", Title = "Donetsk" },
            new CityTranslation { id = 14, EntityId = 7, Lang = "uk", Title = "Донецьк" },

            new CityTranslation { id = 15, EntityId = 8, Lang = "en", Title = "Zaporizhzhia" },
            new CityTranslation { id = 16, EntityId = 8, Lang = "uk", Title = "Запоріжжя" },

            new CityTranslation { id = 17, EntityId = 9, Lang = "en", Title = "Chernihiv" },
            new CityTranslation { id = 18, EntityId = 9, Lang = "uk", Title = "Чернігів" },

            new CityTranslation { id = 19, EntityId = 10, Lang = "en", Title = "Khmelnytskyi" },
            new CityTranslation { id = 20, EntityId = 10, Lang = "uk", Title = "Хмельницький" },

            new CityTranslation { id = 21, EntityId = 11, Lang = "en", Title = "Cherkasy" },
            new CityTranslation { id = 22, EntityId = 11, Lang = "uk", Title = "Черкаси" },

            new CityTranslation { id = 23, EntityId = 12, Lang = "en", Title = "Poltava" },
            new CityTranslation { id = 24, EntityId = 12, Lang = "uk", Title = "Полтава" },

            new CityTranslation { id = 25, EntityId = 13, Lang = "en", Title = "Bila Tserkva" },
            new CityTranslation { id = 26, EntityId = 13, Lang = "uk", Title = "Біла Церква" },

            new CityTranslation { id = 27, EntityId = 14, Lang = "en", Title = "Mykolaiv" },
            new CityTranslation { id = 28, EntityId = 14, Lang = "uk", Title = "Миколаїв" },

            new CityTranslation { id = 29, EntityId = 15, Lang = "en", Title = "Kherson" },
            new CityTranslation { id = 30, EntityId = 15, Lang = "uk", Title = "Херсон" },

            new CityTranslation { id = 31, EntityId = 16, Lang = "en", Title = "Severodonetsk" },
            new CityTranslation { id = 32, EntityId = 16, Lang = "uk", Title = "Сєвєродонецьк" },

            new CityTranslation { id = 33, EntityId = 17, Lang = "en", Title = "Rivne" },
            new CityTranslation { id = 34, EntityId = 17, Lang = "uk", Title = "Рівне" },

            new CityTranslation { id = 35, EntityId = 18, Lang = "en", Title = "Lutsk" },
            new CityTranslation { id = 36, EntityId = 18, Lang = "uk", Title = "Луцьк" },

            new CityTranslation { id = 37, EntityId = 19, Lang = "en", Title = "Chernivtsi" },
            new CityTranslation { id = 38, EntityId = 19, Lang = "uk", Title = "Чернівці" },

            new CityTranslation { id = 39, EntityId = 20, Lang = "en", Title = "Zhytomyr" },
            new CityTranslation { id = 40, EntityId = 20, Lang = "uk", Title = "Житомир" },

            new CityTranslation { id = 41, EntityId = 21, Lang = "en", Title = "Sumy" },
            new CityTranslation { id = 42, EntityId = 21, Lang = "uk", Title = "Суми" },

            new CityTranslation { id = 43, EntityId = 22, Lang = "en", Title = "Kropyvnytskyi" },
            new CityTranslation { id = 44, EntityId = 22, Lang = "uk", Title = "Кропивницький" },

            new CityTranslation { id = 45, EntityId = 23, Lang = "en", Title = "Vinnytsia" },
            new CityTranslation { id = 46, EntityId = 23, Lang = "uk", Title = "Вінниця" },

            new CityTranslation { id = 47, EntityId = 24, Lang = "en", Title = "Kharkiv" },
            new CityTranslation { id = 48, EntityId = 24, Lang = "uk", Title = "Харків" },

            // =================== USA ===================
            new CityTranslation { id = 49, EntityId = 25, Lang = "en", Title = "New York" },
            new CityTranslation { id = 50, EntityId = 25, Lang = "uk", Title = "Нью-Йорк" },

            new CityTranslation { id = 51, EntityId = 26, Lang = "en", Title = "Los Angeles" },
            new CityTranslation { id = 52, EntityId = 26, Lang = "uk", Title = "Лос-Анджелес" },

            new CityTranslation { id = 53, EntityId = 27, Lang = "en", Title = "Chicago" },
            new CityTranslation { id = 54, EntityId = 27, Lang = "uk", Title = "Чикаго" },

            // =================== Germany ===================
            new CityTranslation { id = 55, EntityId = 28, Lang = "en", Title = "Berlin" },
            new CityTranslation { id = 56, EntityId = 28, Lang = "uk", Title = "Берлін" },

            new CityTranslation { id = 57, EntityId = 29, Lang = "en", Title = "Munich" },
            new CityTranslation { id = 58, EntityId = 29, Lang = "uk", Title = "Мюнхен" },

            new CityTranslation { id = 59, EntityId = 30, Lang = "en", Title = "Hamburg" },
            new CityTranslation { id = 60, EntityId = 30, Lang = "uk", Title = "Гамбург" },

            // =================== France ===================
            new CityTranslation { id = 61, EntityId = 31, Lang = "en", Title = "Paris" },
            new CityTranslation { id = 62, EntityId = 31, Lang = "uk", Title = "Париж" },

            new CityTranslation { id = 63, EntityId = 32, Lang = "en", Title = "Lyon" },
            new CityTranslation { id = 64, EntityId = 32, Lang = "uk", Title = "Ліон" },

            new CityTranslation { id = 65, EntityId = 33, Lang = "en", Title = "Marseille" },
            new CityTranslation { id = 66, EntityId = 33, Lang = "uk", Title = "Марсель" },

            // =================== UK ===================
            new CityTranslation { id = 67, EntityId = 34, Lang = "en", Title = "London" },
            new CityTranslation { id = 68, EntityId = 34, Lang = "uk", Title = "Лондон" },

            new CityTranslation { id = 69, EntityId = 35, Lang = "en", Title = "Manchester" },
            new CityTranslation { id = 70, EntityId = 35, Lang = "uk", Title = "Манчестер" },

            new CityTranslation { id = 71, EntityId = 36, Lang = "en", Title = "Birmingham" },
            new CityTranslation { id = 72, EntityId = 36, Lang = "uk", Title = "Бірмінгем" },

            // =================== Spain ===================
            new CityTranslation { id = 73, EntityId = 37, Lang = "en", Title = "Madrid" },
            new CityTranslation { id = 74, EntityId = 37, Lang = "uk", Title = "Мадрид" },

            new CityTranslation { id = 75, EntityId = 38, Lang = "en", Title = "Barcelona" },
            new CityTranslation { id = 76, EntityId = 38, Lang = "uk", Title = "Барселона" },

            new CityTranslation { id = 77, EntityId = 39, Lang = "en", Title = "Valencia" },
            new CityTranslation { id = 78, EntityId = 39, Lang = "uk", Title = "Валенсія" },

            // =================== Poland ===================
            new CityTranslation { id = 79, EntityId = 40, Lang = "en", Title = "Warsaw" },
            new CityTranslation { id = 80, EntityId = 40, Lang = "uk", Title = "Варшава" },

            new CityTranslation { id = 81, EntityId = 41, Lang = "en", Title = "Krakow" },
            new CityTranslation { id = 82, EntityId = 41, Lang = "uk", Title = "Краків" },

            new CityTranslation { id = 83, EntityId = 42, Lang = "en", Title = "Poznan" },
            new CityTranslation { id = 84, EntityId = 42, Lang = "uk", Title = "Познань" }
        );


            modelBuilder.Entity<DistrictTranslation>().HasData(

                // =================== УКРАЇНА ===================
                // Київ
                new DistrictTranslation { id = 1, EntityId = 1, Lang = "en", Title = "Shevchenkivskyi District" },
                new DistrictTranslation { id = 2, EntityId = 1, Lang = "uk", Title = "Шевченківський район" },
                new DistrictTranslation { id = 3, EntityId = 2, Lang = "en", Title = "Pecherskyi District" },
                new DistrictTranslation { id = 4, EntityId = 2, Lang = "uk", Title = "Печерський район" },
                new DistrictTranslation { id = 5, EntityId = 3, Lang = "en", Title = "Podilskyi District" },
                new DistrictTranslation { id = 6, EntityId = 3, Lang = "uk", Title = "Подільський район" },

                // Львів
                new DistrictTranslation { id = 7, EntityId = 4, Lang = "en", Title = "Halytskyi District" },
                new DistrictTranslation { id = 8, EntityId = 4, Lang = "uk", Title = "Галицький район" },
                new DistrictTranslation { id = 9, EntityId = 5, Lang = "en", Title = "Frankivskyi District" },
                new DistrictTranslation { id = 10, EntityId = 5, Lang = "uk", Title = "Франківський район" },
                new DistrictTranslation { id = 11, EntityId = 6, Lang = "en", Title = "Zaliznychnyi District" },
                new DistrictTranslation { id = 12, EntityId = 6, Lang = "uk", Title = "Залізничний район" }

            //    // Одеса
            //    new DistrictTranslation { id = 13, EntityId = 7, Lang = "en", Title = "Primorskyi District" },
            //    new DistrictTranslation { id = 14, EntityId = 7, Lang = "uk", Title = "Приморський район" },
            //    new DistrictTranslation { id = 15, EntityId = 8, Lang = "en", Title = "Malynovskyi District" },
            //    new DistrictTranslation { id = 16, EntityId = 8, Lang = "uk", Title = "Малиновський район" },
            //    new DistrictTranslation { id = 17, EntityId = 9, Lang = "en", Title = "Kyivskyi District" },
            //    new DistrictTranslation { id = 18, EntityId = 9, Lang = "uk", Title = "Київський район" },

            //    // Харків
            //    new DistrictTranslation { id = 19, EntityId = 10, Lang = "en", Title = "Kharkivskyi District" },
            //    new DistrictTranslation { id = 20, EntityId = 10, Lang = "uk", Title = "Харківський район" },
            //    new DistrictTranslation { id = 21, EntityId = 11, Lang = "en", Title = "Saltivskyi District" },
            //    new DistrictTranslation { id = 22, EntityId = 11, Lang = "uk", Title = "Салтівський район" },
            //    new DistrictTranslation { id = 23, EntityId = 12, Lang = "en", Title = "Osnovianskyi District" },
            //    new DistrictTranslation { id = 24, EntityId = 12, Lang = "uk", Title = "Основ'янський район" },

            //    // Дніпро
            //    new DistrictTranslation { id = 25, EntityId = 13, Lang = "en", Title = "Sobornyi District" },
            //    new DistrictTranslation { id = 26, EntityId = 13, Lang = "uk", Title = "Соборний район" },
            //    new DistrictTranslation { id = 27, EntityId = 14, Lang = "en", Title = "Shevchenkivskyi District" },
            //    new DistrictTranslation { id = 28, EntityId = 14, Lang = "uk", Title = "Шевченківський район" },
            //    new DistrictTranslation { id = 29, EntityId = 15, Lang = "en", Title = "Central District" },
            //    new DistrictTranslation { id = 30, EntityId = 15, Lang = "uk", Title = "Центральний район" },

            //    // Запоріжжя
            //    new DistrictTranslation { id = 31, EntityId = 16, Lang = "en", Title = "Zavodskyi District" },
            //    new DistrictTranslation { id = 32, EntityId = 16, Lang = "uk", Title = "Заводський район" },
            //    new DistrictTranslation { id = 33, EntityId = 17, Lang = "en", Title = "Oleksandrivskyi District" },
            //    new DistrictTranslation { id = 34, EntityId = 17, Lang = "uk", Title = "Олександрівський район" },
            //    new DistrictTranslation { id = 35, EntityId = 18, Lang = "en", Title = "Komunarskyi District" },
            //    new DistrictTranslation { id = 36, EntityId = 18, Lang = "uk", Title = "Комунарський район" },

            //    // Івано-Франківськ
            //    new DistrictTranslation { id = 37, EntityId = 19, Lang = "en", Title = "City Center" },
            //    new DistrictTranslation { id = 38, EntityId = 19, Lang = "uk", Title = "Центр міста" },
            //    new DistrictTranslation { id = 39, EntityId = 20, Lang = "en", Title = "Prykarpattia District" },
            //    new DistrictTranslation { id = 40, EntityId = 20, Lang = "uk", Title = "Прикарпатський район" },
            //    new DistrictTranslation { id = 41, EntityId = 21, Lang = "en", Title = "North District" },
            //    new DistrictTranslation { id = 42, EntityId = 21, Lang = "uk", Title = "Північний район" },

            //    // Чернівці
            //    new DistrictTranslation { id = 43, EntityId = 22, Lang = "en", Title = "City Center" },
            //    new DistrictTranslation { id = 44, EntityId = 22, Lang = "uk", Title = "Центр міста" },
            //    new DistrictTranslation { id = 45, EntityId = 23, Lang = "en", Title = "East District" },
            //    new DistrictTranslation { id = 46, EntityId = 23, Lang = "uk", Title = "Східний район" },
            //    new DistrictTranslation { id = 47, EntityId = 24, Lang = "en", Title = "South District" },
            //    new DistrictTranslation { id = 48, EntityId = 24, Lang = "uk", Title = "Південний район" },


            //// Рівне
            //new DistrictTranslation { id = 55, EntityId = 25, Lang = "en", Title = "Central" },
            //new DistrictTranslation { id = 56, EntityId = 25, Lang = "uk", Title = "Центр" },
            //new DistrictTranslation { id = 57, EntityId = 26, Lang = "en", Title = "East" },
            //new DistrictTranslation { id = 58, EntityId = 26, Lang = "uk", Title = "Схід" },
            //new DistrictTranslation { id = 59, EntityId = 27, Lang = "en", Title = "West" },
            //new DistrictTranslation { id = 60, EntityId = 27, Lang = "uk", Title = "Захід" },

            //// Вінниця
            //new DistrictTranslation { id = 61, EntityId = 28, Lang = "en", Title = "Central" },
            //new DistrictTranslation { id = 62, EntityId = 28, Lang = "uk", Title = "Центр" },
            //new DistrictTranslation { id = 63, EntityId = 29, Lang = "en", Title = "North" },
            //new DistrictTranslation { id = 64, EntityId = 29, Lang = "uk", Title = "Північ" },
            //new DistrictTranslation { id = 65, EntityId = 30, Lang = "en", Title = "South" },
            //new DistrictTranslation { id = 66, EntityId = 30, Lang = "uk", Title = "Південь" },

            //// Черкаси
            //new DistrictTranslation { id = 67, EntityId = 31, Lang = "en", Title = "Central" },
            //new DistrictTranslation { id = 68, EntityId = 31, Lang = "uk", Title = "Центр" },
            //new DistrictTranslation { id = 69, EntityId = 32, Lang = "en", Title = "North" },
            //new DistrictTranslation { id = 70, EntityId = 32, Lang = "uk", Title = "Північ" },
            //new DistrictTranslation { id = 71, EntityId = 33, Lang = "en", Title = "South" },
            //new DistrictTranslation { id = 72, EntityId = 33, Lang = "uk", Title = "Південь" },

            //// Полтава
            //new DistrictTranslation { id = 73, EntityId = 34, Lang = "en", Title = "Central" },
            //new DistrictTranslation { id = 74, EntityId = 34, Lang = "uk", Title = "Центр" },
            //new DistrictTranslation { id = 75, EntityId = 35, Lang = "en", Title = "North" },
            //new DistrictTranslation { id = 76, EntityId = 35, Lang = "uk", Title = "Північ" },
            //new DistrictTranslation { id = 77, EntityId = 36, Lang = "en", Title = "South" },
            //new DistrictTranslation { id = 78, EntityId = 36, Lang = "uk", Title = "Південь" },

            //// Кропивницький
            //new DistrictTranslation { id = 79, EntityId = 37, Lang = "en", Title = "Central" },
            //new DistrictTranslation { id = 80, EntityId = 37, Lang = "uk", Title = "Центр" },
            //new DistrictTranslation { id = 81, EntityId = 38, Lang = "en", Title = "East" },
            //new DistrictTranslation { id = 82, EntityId = 38, Lang = "uk", Title = "Схід" },
            //new DistrictTranslation { id = 83, EntityId = 39, Lang = "en", Title = "West" },
            //new DistrictTranslation { id = 84, EntityId = 39, Lang = "uk", Title = "Захід" },

            //// Миколаїв
            //new DistrictTranslation { id = 85, EntityId = 40, Lang = "en", Title = "Central" },
            //new DistrictTranslation { id = 86, EntityId = 40, Lang = "uk", Title = "Центр" },
            //new DistrictTranslation { id = 87, EntityId = 41, Lang = "en", Title = "North" },
            //new DistrictTranslation { id = 88, EntityId = 41, Lang = "uk", Title = "Північ" },
            //new DistrictTranslation { id = 89, EntityId = 42, Lang = "en", Title = "South" },
            //new DistrictTranslation { id = 90, EntityId = 42, Lang = "uk", Title = "Південь" },

            //// Херсон
            //new DistrictTranslation { id = 91, EntityId = 43, Lang = "en", Title = "Central" },
            //new DistrictTranslation { id = 92, EntityId = 43, Lang = "uk", Title = "Центр" },
            //new DistrictTranslation { id = 93, EntityId = 44, Lang = "en", Title = "North" },
            //new DistrictTranslation { id = 94, EntityId = 44, Lang = "uk", Title = "Північ" },
            //new DistrictTranslation { id = 95, EntityId = 45, Lang = "en", Title = "South" },
            //new DistrictTranslation { id = 96, EntityId = 45, Lang = "uk", Title = "Південь" },

            //// Луцьк
            //new DistrictTranslation { id = 97, EntityId = 46, Lang = "en", Title = "Central" },
            //new DistrictTranslation { id = 98, EntityId = 46, Lang = "uk", Title = "Центр" },
            //new DistrictTranslation { id = 99, EntityId = 47, Lang = "en", Title = "North" },
            //new DistrictTranslation { id = 100, EntityId = 47, Lang = "uk", Title = "Північ" },
            //new DistrictTranslation { id = 101, EntityId = 48, Lang = "en", Title = "South" },
            //new DistrictTranslation { id = 102, EntityId = 48, Lang = "uk", Title = "Південь" },
            //// =================== DistrictTranslation ===================

            //// New York
            //new DistrictTranslation { id = 103, EntityId = 49, Lang = "en", Title = "Manhattan" },
            //new DistrictTranslation { id = 104, EntityId = 49, Lang = "uk", Title = "Манхеттен" },
            //new DistrictTranslation { id = 105, EntityId = 50, Lang = "en", Title = "Brooklyn" },
            //new DistrictTranslation { id = 106, EntityId = 50, Lang = "uk", Title = "Бруклін" },
            //new DistrictTranslation { id = 107, EntityId = 51, Lang = "en", Title = "Queens" },
            //new DistrictTranslation { id = 108, EntityId = 51, Lang = "uk", Title = "Квінс" },

            //// Los Angeles
            //new DistrictTranslation { id = 109, EntityId = 52, Lang = "en", Title = "Hollywood" },
            //new DistrictTranslation { id = 110, EntityId = 52, Lang = "uk", Title = "Голлівуд" },
            //new DistrictTranslation { id = 111, EntityId = 53, Lang = "en", Title = "Downtown LA" },
            //new DistrictTranslation { id = 112, EntityId = 53, Lang = "uk", Title = "Центр ЛА" },
            //new DistrictTranslation { id = 113, EntityId = 54, Lang = "en", Title = "Santa Monica" },
            //new DistrictTranslation { id = 114, EntityId = 54, Lang = "uk", Title = "Санта-Моніка" },

            //// Chicago
            //new DistrictTranslation { id = 115, EntityId = 106, Lang = "en", Title = "Loop" },
            //new DistrictTranslation { id = 116, EntityId = 106, Lang = "uk", Title = "Луп" },
            //new DistrictTranslation { id = 117, EntityId = 107, Lang = "en", Title = "Lincoln Park" },
            //new DistrictTranslation { id = 118, EntityId = 107, Lang = "uk", Title = "Лінкольн-Парк" },
            //new DistrictTranslation { id = 119, EntityId = 108, Lang = "en", Title = "South Side" },
            //new DistrictTranslation { id = 120, EntityId = 108, Lang = "uk", Title = "Південна частина" },

            //// Berlin
            //new DistrictTranslation { id = 121, EntityId = 109, Lang = "en", Title = "Mitte" },
            //new DistrictTranslation { id = 122, EntityId = 109, Lang = "uk", Title = "Мітте" },
            //new DistrictTranslation { id = 123, EntityId = 110, Lang = "en", Title = "Charlottenburg" },
            //new DistrictTranslation { id = 124, EntityId = 110, Lang = "uk", Title = "Шарлоттенбург" },
            //new DistrictTranslation { id = 125, EntityId = 111, Lang = "en", Title = "Kreuzberg" },
            //new DistrictTranslation { id = 126, EntityId = 111, Lang = "uk", Title = "Кройцберг" },

            //// Munich
            //new DistrictTranslation { id = 127, EntityId = 112, Lang = "en", Title = "Altstadt" },
            //new DistrictTranslation { id = 128, EntityId = 112, Lang = "uk", Title = "Старе місто" },
            //new DistrictTranslation { id = 129, EntityId = 113, Lang = "en", Title = "Schwabing" },
            //new DistrictTranslation { id = 130, EntityId = 113, Lang = "uk", Title = "Швабінг" },
            //new DistrictTranslation { id = 131, EntityId = 114, Lang = "en", Title = "Maxvorstadt" },
            //new DistrictTranslation { id = 132, EntityId = 114, Lang = "uk", Title = "Максфорштадт" },

            //// Hamburg
            //new DistrictTranslation { id = 133, EntityId = 115, Lang = "en", Title = "Altstadt" },
            //new DistrictTranslation { id = 134, EntityId = 115, Lang = "uk", Title = "Старе місто" },
            //new DistrictTranslation { id = 135, EntityId = 116, Lang = "en", Title = "St. Pauli" },
            //new DistrictTranslation { id = 136, EntityId = 116, Lang = "uk", Title = "Санкт-Паулі" },
            //new DistrictTranslation { id = 137, EntityId = 117, Lang = "en", Title = "Altona" },
            //new DistrictTranslation { id = 138, EntityId = 117, Lang = "uk", Title = "Альтона" },

            //// Paris
            //new DistrictTranslation { id = 139, EntityId = 118, Lang = "en", Title = "Montmartre" },
            //new DistrictTranslation { id = 140, EntityId = 118, Lang = "uk", Title = "Монмартр" },
            //new DistrictTranslation { id = 141, EntityId = 119, Lang = "en", Title = "Latin Quarter" },
            //new DistrictTranslation { id = 142, EntityId = 119, Lang = "uk", Title = "Латинський квартал" },
            //new DistrictTranslation { id = 143, EntityId = 120, Lang = "en", Title = "Marais" },
            //new DistrictTranslation { id = 144, EntityId = 120, Lang = "uk", Title = "Маре" },

            //// Lyon
            //new DistrictTranslation { id = 145, EntityId = 121, Lang = "en", Title = "Presqu'île" },
            //new DistrictTranslation { id = 146, EntityId = 121, Lang = "uk", Title = "Преск’іль" },
            //new DistrictTranslation { id = 147, EntityId = 122, Lang = "en", Title = "Croix-Rousse" },
            //new DistrictTranslation { id = 148, EntityId = 122, Lang = "uk", Title = "Круа-Рус" },
            //new DistrictTranslation { id = 149, EntityId = 123, Lang = "en", Title = "Part-Dieu" },
            //new DistrictTranslation { id = 150, EntityId = 123, Lang = "uk", Title = "Пар-Дьє" },


            //// Marseille
            //new DistrictTranslation { id = 151, EntityId = 124, Lang = "en", Title = "Old Port" },
            //new DistrictTranslation { id = 152, EntityId = 124, Lang = "uk", Title = "Старий порт" },
            //new DistrictTranslation { id = 153, EntityId = 125, Lang = "en", Title = "Le Panier" },
            //new DistrictTranslation { id = 154, EntityId = 125, Lang = "uk", Title = "Ле Пан’є" },
            //new DistrictTranslation { id = 155, EntityId = 126, Lang = "en", Title = "La Joliette" },
            //new DistrictTranslation { id = 156, EntityId = 126, Lang = "uk", Title = "Ла Жольєт" },

            //// London
            //new DistrictTranslation { id = 157, EntityId = 127, Lang = "en", Title = "Camden" },
            //new DistrictTranslation { id = 158, EntityId = 127, Lang = "uk", Title = "Кемден" },
            //new DistrictTranslation { id = 159, EntityId = 128, Lang = "en", Title = "Westminster" },
            //new DistrictTranslation { id = 160, EntityId = 128, Lang = "uk", Title = "Вестмінстер" },
            //new DistrictTranslation { id = 161, EntityId = 129, Lang = "en", Title = "Greenwich" },
            //new DistrictTranslation { id = 162, EntityId = 129, Lang = "uk", Title = "Грінвіч" },

            //// Manchester
            //new DistrictTranslation { id = 163, EntityId = 130, Lang = "en", Title = "Salford" },
            //new DistrictTranslation { id = 164, EntityId = 130, Lang = "uk", Title = "Салфорд" },
            //new DistrictTranslation { id = 165, EntityId = 131, Lang = "en", Title = "Didsbury" },
            //new DistrictTranslation { id = 166, EntityId = 131, Lang = "uk", Title = "Дідсбері" },
            //new DistrictTranslation { id = 167, EntityId = 132, Lang = "en", Title = "Cheetham Hill" },
            //new DistrictTranslation { id = 168, EntityId = 132, Lang = "uk", Title = "Чітем-Гілл" },

            //// Birmingham
            //new DistrictTranslation { id = 169, EntityId = 133, Lang = "en", Title = "City Centre" },
            //new DistrictTranslation { id = 170, EntityId = 133, Lang = "uk", Title = "Центр міста" },
            //new DistrictTranslation { id = 171, EntityId = 134, Lang = "en", Title = "Edgbaston" },
            //new DistrictTranslation { id = 172, EntityId = 134, Lang = "uk", Title = "Еджбастон" },
            //new DistrictTranslation { id = 173, EntityId = 135, Lang = "en", Title = "Selly Oak" },
            //new DistrictTranslation { id = 174, EntityId = 135, Lang = "uk", Title = "Селлі-Оук" },

            //// Madrid
            //new DistrictTranslation { id = 175, EntityId = 136, Lang = "en", Title = "Centro" },
            //new DistrictTranslation { id = 176, EntityId = 136, Lang = "uk", Title = "Центро" },
            //new DistrictTranslation { id = 177, EntityId = 137, Lang = "en", Title = "Salamanca" },
            //new DistrictTranslation { id = 178, EntityId = 137, Lang = "uk", Title = "Саламанка" },
            //new DistrictTranslation { id = 179, EntityId = 138, Lang = "en", Title = "Chamartín" },
            //new DistrictTranslation { id = 180, EntityId = 138, Lang = "uk", Title = "Чамартін" },

            //// Barcelona
            //new DistrictTranslation { id = 181, EntityId = 139, Lang = "en", Title = "Eixample" },
            //new DistrictTranslation { id = 182, EntityId = 139, Lang = "uk", Title = "Ейшампле" },
            //new DistrictTranslation { id = 183, EntityId = 140, Lang = "en", Title = "Gràcia" },
            //new DistrictTranslation { id = 184, EntityId = 140, Lang = "uk", Title = "Грасія" },
            //new DistrictTranslation { id = 185, EntityId = 141, Lang = "en", Title = "Ciutat Vella" },
            //new DistrictTranslation { id = 186, EntityId = 141, Lang = "uk", Title = "С’юта Велья" },

            //// Valencia
            //new DistrictTranslation { id = 187, EntityId = 142, Lang = "en", Title = "El Carmen" },
            //new DistrictTranslation { id = 188, EntityId = 142, Lang = "uk", Title = "Ель Кармен" },
            //new DistrictTranslation { id = 189, EntityId = 143, Lang = "en", Title = "Ruzafa" },
            //new DistrictTranslation { id = 190, EntityId = 143, Lang = "uk", Title = "Русaфа" },
            //new DistrictTranslation { id = 191, EntityId = 144, Lang = "en", Title = "Benimaclet" },
            //new DistrictTranslation { id = 192, EntityId = 144, Lang = "uk", Title = "Бенімаcлет" },

            //// Warsaw
            //new DistrictTranslation { id = 193, EntityId = 145, Lang = "en", Title = "Śródmieście" },
            //new DistrictTranslation { id = 194, EntityId = 145, Lang = "uk", Title = "Шродмієстє" },
            //new DistrictTranslation { id = 195, EntityId = 146, Lang = "en", Title = "Praga-Północ" },
            //new DistrictTranslation { id = 196, EntityId = 146, Lang = "uk", Title = "Прага-Північ" },
            //new DistrictTranslation { id = 197, EntityId = 147, Lang = "en", Title = "Wola" },
            //new DistrictTranslation { id = 198, EntityId = 147, Lang = "uk", Title = "Воля" },

            //// Krakow
            //new DistrictTranslation { id = 199, EntityId = 148, Lang = "en", Title = "Old Town" },
            //new DistrictTranslation { id = 200, EntityId = 148, Lang = "uk", Title = "Старе місто" },
            //new DistrictTranslation { id = 201, EntityId = 149, Lang = "en", Title = "Kazimierz" },
            //new DistrictTranslation { id = 202, EntityId = 149, Lang = "uk", Title = "Казімєж" },
            //new DistrictTranslation { id = 203, EntityId = 150, Lang = "en", Title = "Podgórze" },
            //new DistrictTranslation { id = 204, EntityId = 150, Lang = "uk", Title = "Подгуже" },

            //// Poznan
            //new DistrictTranslation { id = 205, EntityId = 151, Lang = "en", Title = "Stare Miasto" },
            //new DistrictTranslation { id = 206, EntityId = 151, Lang = "uk", Title = "Старе місто" },
            //new DistrictTranslation { id = 207, EntityId = 152, Lang = "en", Title = "Grunwald" },
            //new DistrictTranslation { id = 208, EntityId = 152, Lang = "uk", Title = "Грюнвальд" },
            //new DistrictTranslation { id = 209, EntityId = 153, Lang = "en", Title = "Jeżyce" },
            //new DistrictTranslation { id = 210, EntityId = 153, Lang = "uk", Title = "Єжице" }

        );


            modelBuilder.Entity<AttractionTranslation>().HasData(

            // =================== Київ ===================
            // --- District 1 ---
            new AttractionTranslation { id = 1, EntityId = 1, Lang = "en", Title = "Sofia Square", Description = "Historic square with Saint Sophia Cathedral", Address = "Sofiiska Square, Kyiv" },
            new AttractionTranslation { id = 2, EntityId = 2, Lang = "en", Title = "Golden Gate", Description = "Ancient city gate and museum", Address = "Zoloti Vorota, Kyiv" },
            new AttractionTranslation { id = 3, EntityId = 3, Lang = "en", Title = "St. Michael's Square", Description = "Square with St. Michael's Golden-Domed Monastery", Address = "Mykhailivska Square, Kyiv" },
            new AttractionTranslation { id = 4, EntityId = 4, Lang = "en", Title = "Andriyivskyi Descent", Description = "Historic descent with art galleries and shops", Address = "Andriyivskyi Uzviz, Kyiv" },
            new AttractionTranslation { id = 5, EntityId = 5, Lang = "en", Title = "National Museum of History of Ukraine", Description = "Museum showcasing Ukrainian history", Address = "National Museum of History of Ukraine, Kyiv" },

            new AttractionTranslation { id = 6, EntityId = 1, Lang = "uk", Title = "Софійська площа", Description = "Історична площа із Софійським собором", Address = "Софійська площа, Київ" },
            new AttractionTranslation { id = 7, EntityId = 2, Lang = "uk", Title = "Золоті ворота", Description = "Старовинні міські ворота та музей", Address = "Золоті ворота, Київ" },
            new AttractionTranslation { id = 8, EntityId = 3, Lang = "uk", Title = "Михайлівська площа", Description = "Площа з Михайлівським Золотоверхим монастирем", Address = "Михайлівська площа, Київ" },
            new AttractionTranslation { id = 9, EntityId = 4, Lang = "uk", Title = "Андріївський узвіз", Description = "Історичний узвіз з художніми галереями та крамницями", Address = "Андріївський узвіз, Київ" },
            new AttractionTranslation { id = 10, EntityId = 5, Lang = "uk", Title = "Національний музей історії України", Description = "Музей, що демонструє історію України", Address = "Національний музей історії України, Київ" },

            // --- District 2 ---
            new AttractionTranslation { id = 11, EntityId = 6, Lang = "en", Title = "Shevchenko Park", Description = "Central city park with monuments and greenery", Address = "Shevchenko Park, Kyiv" },
            new AttractionTranslation { id = 12, EntityId = 7, Lang = "en", Title = "Kyiv University", Description = "Historic university in the heart of the city", Address = "Kyiv University, Kyiv" },
            new AttractionTranslation { id = 13, EntityId = 8, Lang = "en", Title = "Hryshko National Botanical Garden", Description = "Large botanical garden with diverse plant collections", Address = "Hryshko National Botanical Garden, Kyiv" },
            new AttractionTranslation { id = 14, EntityId = 9, Lang = "en", Title = "Kontraktova Square", Description = "Historic square in Podil district", Address = "Kontraktova Square, Kyiv" },
            new AttractionTranslation { id = 15, EntityId = 10, Lang = "en", Title = "St. Michael's Cathedral", Description = "Famous golden-domed cathedral in Kyiv", Address = "St. Michael's Cathedral, Kyiv" },

            new AttractionTranslation { id = 16, EntityId = 6, Lang = "uk", Title = "Парк Шевченка", Description = "Центральний парк міста з пам’ятниками та зеленими зонами", Address = "Парк Шевченка, Київ" },
            new AttractionTranslation { id = 17, EntityId = 7, Lang = "uk", Title = "Київський університет", Description = "Історичний університет у центрі міста", Address = "Київський університет, Київ" },
            new AttractionTranslation { id = 18, EntityId = 8, Lang = "uk", Title = "Ботанічний сад ім. Гришка", Description = "Великий ботанічний сад із різноманітними колекціями рослин", Address = "Ботанічний сад ім. Гришка, Київ" },
            new AttractionTranslation { id = 19, EntityId = 9, Lang = "uk", Title = "Контрактова площа", Description = "Історична площа в районі Поділ", Address = "Контрактова площа, Київ" },
            new AttractionTranslation { id = 20, EntityId = 10, Lang = "uk", Title = "Михайлівський собор", Description = "Відомий Золотоверхий собор у Києві", Address = "Михайлівський собор, Київ" },

            // --- District 3 ---
            new AttractionTranslation { id = 21, EntityId = 11, Lang = "en", Title = "Poshtova Square", Description = "Historic square near the Dnipro river", Address = "Poshtova Square, Kyiv" },
            new AttractionTranslation { id = 22, EntityId = 12, Lang = "en", Title = "Museum of the History of Kyiv", Description = "Museum showcasing the history of the city", Address = "Museum of the History of Kyiv, Kyiv" },
            new AttractionTranslation { id = 23, EntityId = 13, Lang = "en", Title = "Dnipro Embankment", Description = "Riverfront promenade along the Dnipro river", Address = "Dnipro Embankment, Kyiv" },
            new AttractionTranslation { id = 24, EntityId = 14, Lang = "en", Title = "Water Museum", Description = "Museum dedicated to water supply and technologies", Address = "Water Museum, Kyiv" },
            new AttractionTranslation { id = 25, EntityId = 15, Lang = "en", Title = "Paton Bridge", Description = "Famous bridge across the Dnipro river", Address = "Paton Bridge, Kyiv" },

            new AttractionTranslation { id = 26, EntityId = 11, Lang = "uk", Title = "Поштова площа", Description = "Історична площа біля річки Дніпро", Address = "Поштова площа, Київ" },
            new AttractionTranslation { id = 27, EntityId = 12, Lang = "uk", Title = "Музей історії Києва", Description = "Музей, що демонструє історію міста", Address = "Музей історії Києва, Київ" },
            new AttractionTranslation { id = 28, EntityId = 13, Lang = "uk", Title = "Набережна Дніпра", Description = "Прогулянкова набережна вздовж річки Дніпро", Address = "Набережна Дніпра, Київ" },
            new AttractionTranslation { id = 29, EntityId = 14, Lang = "uk", Title = "Музей води", Description = "Музей, присвячений водопостачанню та технологіям", Address = "Музей води, Київ" },
            new AttractionTranslation { id = 30, EntityId = 15, Lang = "uk", Title = "Міст Патона", Description = "Відомий міст через річку Дніпро", Address = "Міст Патона, Київ" },


            // =================== Ужгород ===================
            // --- District 4 ---
            new AttractionTranslation { id = 31, EntityId = 16, Lang = "en", Title = "Uzhgorod Castle", Description = "Historic castle overlooking the city", Address = "Uzhgorod Castle, Uzhgorod" },
            new AttractionTranslation { id = 32, EntityId = 17, Lang = "en", Title = "Uzhgorod Cathedral", Description = "Main cathedral of the city", Address = "Uzhgorod Cathedral, Uzhgorod" },
            new AttractionTranslation { id = 33, EntityId = 18, Lang = "en", Title = "UzhNU Botanical Garden", Description = "Botanical garden of Uzhgorod National University", Address = "UzhNU Botanical Garden, Uzhgorod" },
            new AttractionTranslation { id = 34, EntityId = 19, Lang = "en", Title = "Theatre Square", Description = "Central square with cafes and theaters", Address = "Theatre Square, Uzhgorod" },
            new AttractionTranslation { id = 35, EntityId = 20, Lang = "en", Title = "Museum of Folk Architecture of Zakarpattia", Description = "Open-air museum of traditional architecture", Address = "Museum of Folk Architecture of Zakarpattia, Uzhgorod" },

            new AttractionTranslation { id = 36, EntityId = 16, Lang = "uk", Title = "Ужгородський замок", Description = "Історичний замок із видом на місто", Address = "Ужгородський замок, Ужгород" },
            new AttractionTranslation { id = 37, EntityId = 17, Lang = "uk", Title = "Кафедральний собор Ужгорода", Description = "Головний собор міста", Address = "Кафедральний собор Ужгорода" },
            new AttractionTranslation { id = 38, EntityId = 18, Lang = "uk", Title = "Ботанічний сад УжНУ", Description = "Ботанічний сад Ужгородського національного університету", Address = "Ботанічний сад УжНУ, Ужгород" },
            new AttractionTranslation { id = 39, EntityId = 19, Lang = "uk", Title = "Площа Театральна", Description = "Центральна площа з кафе та театрами", Address = "Площа Театральна, Ужгород" },
            new AttractionTranslation { id = 40, EntityId = 20, Lang = "uk", Title = "Музей народної архітектури Закарпаття", Description = "Музей просто неба традиційної архітектури", Address = "Музей народної архітектури Закарпаття, Ужгород" },

            // =================== Львів ===================
            // --- District 7 ---
            new AttractionTranslation { id = 41, EntityId = 21, Lang = "en", Title = "Rynok Square", Description = "Historic central square of Lviv", Address = "Rynok Square, Lviv" },
            new AttractionTranslation { id = 42, EntityId = 22, Lang = "en", Title = "Lviv Opera", Description = "Famous opera house in Lviv", Address = "Lviv Opera, Lviv" },
            new AttractionTranslation { id = 43, EntityId = 23, Lang = "en", Title = "High Castle", Description = "Historic hill with panoramic city views", Address = "High Castle, Lviv" },
            new AttractionTranslation { id = 44, EntityId = 24, Lang = "en", Title = "Lviv Museum of History of Religion", Description = "Museum dedicated to religious history", Address = "Lviv Museum of History of Religion, Lviv" },
            new AttractionTranslation { id = 45, EntityId = 25, Lang = "en", Title = "Ivan Franko Park", Description = "City park named after the poet Ivan Franko", Address = "Ivan Franko Park, Lviv" },

            new AttractionTranslation { id = 46, EntityId = 21, Lang = "uk", Title = "Площа Ринок", Description = "Історична центральна площа Львова", Address = "Площа Ринок, Львів" },
            new AttractionTranslation { id = 47, EntityId = 22, Lang = "uk", Title = "Львівська опера", Description = "Відомий оперний театр Львова", Address = "Львівська опера, Львів" },
            new AttractionTranslation { id = 48, EntityId = 23, Lang = "uk", Title = "Високий замок", Description = "Історичний пагорб з панорамним видом на місто", Address = "Високий замок, Львів" },
            new AttractionTranslation { id = 49, EntityId = 24, Lang = "uk", Title = "Львівський музей історії релігії", Description = "Музей, присвячений історії релігії", Address = "Львівський музей історії релігії, Львів" },
            new AttractionTranslation { id = 50, EntityId = 25, Lang = "uk", Title = "Парк імені Івана Франка", Description = "Міський парк імені поета Івана Франка", Address = "Парк імені Івана Франка, Львів" },

            // =================== Одеса ===================
            // --- District 10 ---
            new AttractionTranslation { id = 51, EntityId = 26, Lang = "en", Title = "Deribasivska Street", Description = "Famous pedestrian street in Odesa", Address = "Deribasivska Street, Odesa" },
            new AttractionTranslation { id = 52, EntityId = 27, Lang = "en", Title = "Odesa Opera and Ballet Theatre", Description = "Historic opera house of Odesa", Address = "Odesa Opera and Ballet Theatre, Odesa" },
            new AttractionTranslation { id = 53, EntityId = 28, Lang = "en", Title = "Potemkin Stairs", Description = "Iconic giant stairway overlooking the harbor", Address = "Potemkin Stairs, Odesa" },
            new AttractionTranslation { id = 54, EntityId = 29, Lang = "en", Title = "Odesa Port", Description = "Major commercial and tourist port", Address = "Odesa Port, Odesa" },
            new AttractionTranslation { id = 55, EntityId = 30, Lang = "en", Title = "Primorsky Boulevard", Description = "Famous boulevard along the coastline", Address = "Primorsky Boulevard, Odesa" },

            new AttractionTranslation { id = 56, EntityId = 26, Lang = "uk", Title = "Вулиця Дерибасівська", Description = "Відома пішохідна вулиця Одеси", Address = "Дерибасівська вулиця, Одеса" },
            new AttractionTranslation { id = 57, EntityId = 27, Lang = "uk", Title = "Одеський театр опери та балету", Description = "Історичний оперний театр Одеси", Address = "Одеський театр опери та балету, Одеса" },
            new AttractionTranslation { id = 58, EntityId = 28, Lang = "uk", Title = "Потьомкінські сходи", Description = "Знакові сходи з видом на порт", Address = "Потьомкінські сходи, Одеса" },
            new AttractionTranslation { id = 59, EntityId = 29, Lang = "uk", Title = "Одеський порт", Description = "Великий комерційний та туристичний порт", Address = "Одеський порт, Одеса" },
            new AttractionTranslation { id = 60, EntityId = 30, Lang = "uk", Title = "Приморський бульвар", Description = "Відомий бульвар уздовж узбережжя", Address = "Приморський бульвар, Одеса" },

            // =================== Тернопіль ===================
            // --- District 13 ---
            new AttractionTranslation { id = 61, EntityId = 31, Lang = "en", Title = "Ternopil Castle", Description = "Historic castle in Ternopil", Address = "Ternopil Castle, Ternopil" },
            new AttractionTranslation { id = 62, EntityId = 32, Lang = "en", Title = "Ternopil Lake", Description = "Famous lake in the city center", Address = "Ternopil Lake, Ternopil" },
            new AttractionTranslation { id = 63, EntityId = 33, Lang = "en", Title = "Heroes of Euromaidan Square", Description = "Central square commemorating Euromaidan", Address = "Heroes of Euromaidan Square, Ternopil" },
            new AttractionTranslation { id = 64, EntityId = 34, Lang = "en", Title = "Museum of Education", Description = "Museum dedicated to the history of education", Address = "Museum of Education, Ternopil" },
            new AttractionTranslation { id = 65, EntityId = 35, Lang = "en", Title = "Dominican Church", Description = "Historic church in the city center", Address = "Dominican Church, Ternopil" },

            new AttractionTranslation { id = 66, EntityId = 31, Lang = "uk", Title = "Тернопільський замок", Description = "Історичний замок у Тернополі", Address = "Тернопільський замок, Тернопіль" },
            new AttractionTranslation { id = 67, EntityId = 32, Lang = "uk", Title = "Тернопільський став", Description = "Відоме озеро в центрі міста", Address = "Тернопільський став, Тернопіль" },
            new AttractionTranslation { id = 68, EntityId = 33, Lang = "uk", Title = "Площа Героїв Євромайдану", Description = "Центральна площа, присвячена подіям Євромайдану", Address = "Площа Героїв Євромайдану, Тернопіль" },
            new AttractionTranslation { id = 69, EntityId = 34, Lang = "uk", Title = "Музей освіти", Description = "Музей, присвячений історії освіти", Address = "Музей освіти, Тернопіль" },
            new AttractionTranslation { id = 70, EntityId = 35, Lang = "uk", Title = "Домініканський костел", Description = "Історичний костел у центрі міста", Address = "Домініканський костел, Тернопіль" },

            // =================== Миколаїв ===================
            // --- District 14 ---
            new AttractionTranslation { id = 71, EntityId = 36, Lang = "en", Title = "Mykolaiv Shipyard", Description = "Famous shipbuilding plant in Mykolaiv", Address = "Mykolaiv Shipyard, Mykolaiv" },
            new AttractionTranslation { id = 72, EntityId = 37, Lang = "en", Title = "Mykolaiv Zoo", Description = "City zoo with diverse animals", Address = "Mykolaiv Zoo, Mykolaiv" },
            new AttractionTranslation { id = 73, EntityId = 38, Lang = "en", Title = "Soborna Street", Description = "Central street in Mykolaiv", Address = "Soborna Street, Mykolaiv" },
            new AttractionTranslation { id = 74, EntityId = 39, Lang = "en", Title = "Catherine II Monument", Description = "Monument dedicated to Catherine the Great", Address = "Catherine II Monument, Mykolaiv" },
            new AttractionTranslation { id = 75, EntityId = 40, Lang = "en", Title = "Mykolaiv Regional Museum", Description = "Regional museum with historical exhibits", Address = "Mykolaiv Regional Museum, Mykolaiv" },

            new AttractionTranslation { id = 76, EntityId = 36, Lang = "uk", Title = "Миколаївський кораблебудівний завод", Description = "Відомий кораблебудівний завод у Миколаєві", Address = "Миколаївський кораблебудівний завод, Миколаїв" },
            new AttractionTranslation { id = 77, EntityId = 37, Lang = "uk", Title = "Миколаївський зоопарк", Description = "Міський зоопарк з різноманітними тваринами", Address = "Миколаївський зоопарк, Миколаїв" },
            new AttractionTranslation { id = 78, EntityId = 38, Lang = "uk", Title = "Вулиця Соборна", Description = "Центральна вулиця Миколаєва", Address = "Вулиця Соборна, Миколаїв" },
            new AttractionTranslation { id = 79, EntityId = 39, Lang = "uk", Title = "Пам’ятник Катерині II", Description = "Пам’ятник Катерині II", Address = "Пам’ятник Катерині II, Миколаїв" },
            new AttractionTranslation { id = 80, EntityId = 40, Lang = "uk", Title = "Миколаївський обласний краєзнавчий музей", Description = "Обласний музей з історичними експонатами", Address = "Миколаївський обласний краєзнавчий музей, Миколаїв" },

            // =================== Херсон ===================
            // --- District 15 ---
            new AttractionTranslation { id = 81, EntityId = 41, Lang = "en", Title = "Kherson Regional Museum", Description = "Regional museum with historical exhibits", Address = "Kherson Regional Museum, Kherson" },
            new AttractionTranslation { id = 82, EntityId = 42, Lang = "en", Title = "Kherson Sea Port", Description = "Major maritime port in Kherson", Address = "Kherson Sea Port, Kherson" },
            new AttractionTranslation { id = 83, EntityId = 43, Lang = "en", Title = "Holy Trinity Cathedral", Description = "Historic cathedral in Kherson", Address = "Holy Trinity Cathedral, Kherson" },
            new AttractionTranslation { id = 84, EntityId = 44, Lang = "en", Title = "Glory Park", Description = "Popular park in Kherson", Address = "Glory Park, Kherson" },
            new AttractionTranslation { id = 85, EntityId = 45, Lang = "en", Title = "Ushakova Street", Description = "Central street in Kherson", Address = "Ushakova Street, Kherson" },

            new AttractionTranslation { id = 86, EntityId = 41, Lang = "uk", Title = "Херсонський обласний краєзнавчий музей", Description = "Обласний музей з історичними експонатами", Address = "Херсонський обласний краєзнавчий музей, Херсон" },
            new AttractionTranslation { id = 87, EntityId = 42, Lang = "uk", Title = "Херсонський морський порт", Description = "Великий морський порт Херсона", Address = "Херсонський морський порт, Херсон" },
            new AttractionTranslation { id = 88, EntityId = 43, Lang = "uk", Title = "Кафедральний собор Святої Трійці", Description = "Історичний кафедральний собор у Херсоні", Address = "Кафедральний собор Святої Трійці, Херсон" },
            new AttractionTranslation { id = 89, EntityId = 44, Lang = "uk", Title = "Парк Слави", Description = "Популярний парк у Херсоні", Address = "Парк Слави, Херсон" },
            new AttractionTranslation { id = 90, EntityId = 45, Lang = "uk", Title = "Вулиця Ушакова", Description = "Центральна вулиця Херсона", Address = "Вулиця Ушакова, Херсон" },

            // =================== Луганськ (Сєвєродонецьк) ===================
            // --- District 16 ---
            new AttractionTranslation { id = 91, EntityId = 46, Lang = "en", Title = "Severodonetsk City Park", Description = "Central park in Severodonetsk", Address = "Severodonetsk City Park, Severodonetsk" },
            new AttractionTranslation { id = 92, EntityId = 47, Lang = "en", Title = "Severodonetsk Museum of Local History", Description = "Museum showcasing regional history", Address = "Severodonetsk Museum of Local History, Severodonetsk" },
            new AttractionTranslation { id = 93, EntityId = 48, Lang = "en", Title = "Peace Square", Description = "Main city square in Severodonetsk", Address = "Peace Square, Severodonetsk" },
            new AttractionTranslation { id = 94, EntityId = 49, Lang = "en", Title = "Severodonetsk Regional Theater", Description = "Local theater for performances and shows", Address = "Severodonetsk Regional Theater, Severodonetsk" },
            new AttractionTranslation { id = 95, EntityId = 50, Lang = "en", Title = "Mиру Street", Description = "Central street in Severodonetsk", Address = "Mиру Street, Severodonetsk" },

            new AttractionTranslation { id = 96, EntityId = 46, Lang = "uk", Title = "Сєвєродонецький міський парк", Description = "Центральний парк у Сєвєродонецьку", Address = "Сєвєродонецький міський парк, Сєвєродонецьк" },
            new AttractionTranslation { id = 97, EntityId = 47, Lang = "uk", Title = "Краєзнавчий музей Сєвєродонецька", Description = "Музей регіональної історії", Address = "Краєзнавчий музей Сєвєродонецька, Сєвєродонецьк" },
            new AttractionTranslation { id = 98, EntityId = 48, Lang = "uk", Title = "Площа Миру", Description = "Головна площа міста Сєвєродонецьк", Address = "Площа Миру, Сєвєродонецьк" },
            new AttractionTranslation { id = 99, EntityId = 49, Lang = "uk", Title = "Сєвєродонецький краєзнавчий театр", Description = "Місцевий театр для вистав та шоу", Address = "Сєвєродонецький краєзнавчий театр, Сєвєродонецьк" },
            new AttractionTranslation { id = 100, EntityId = 50, Lang = "uk", Title = "Вулиця Миру", Description = "Центральна вулиця Сєвєродонецька", Address = "Вулиця Миру, Сєвєродонецьк" },

            // =================== Рівне ===================
            // --- District 49 ---
            new AttractionTranslation { id = 101, EntityId = 51, Lang = "en", Title = "Rivne Regional Museum", Description = "Regional museum showcasing history", Address = "Rivne Regional Museum, Rivne" },
            new AttractionTranslation { id = 102, EntityId = 52, Lang = "en", Title = "Shevchenko Park", Description = "Popular park in Rivne", Address = "Shevchenko Park, Rivne" },
            new AttractionTranslation { id = 103, EntityId = 53, Lang = "en", Title = "Amber Museum", Description = "Museum dedicated to amber artifacts", Address = "Amber Museum, Rivne" },
            new AttractionTranslation { id = 104, EntityId = 54, Lang = "en", Title = "Independence Square", Description = "Central square of Rivne", Address = "Independence Square, Rivne" },
            new AttractionTranslation { id = 105, EntityId = 55, Lang = "en", Title = "Soborna Street", Description = "Central street in Rivne", Address = "Soborna Street, Rivne" },

            new AttractionTranslation { id = 106, EntityId = 51, Lang = "uk", Title = "Рівненський краєзнавчий музей", Description = "Обласний музей з історичними експонатами", Address = "Рівненський краєзнавчий музей, Рівне" },
            new AttractionTranslation { id = 107, EntityId = 52, Lang = "uk", Title = "Парк ім. Шевченка", Description = "Популярний парк у Рівному", Address = "Парк ім. Шевченка, Рівне" },
            new AttractionTranslation { id = 108, EntityId = 53, Lang = "uk", Title = "Музей бурштину", Description = "Музей, присвячений бурштиновим експонатам", Address = "Музей бурштину, Рівне" },
            new AttractionTranslation { id = 109, EntityId = 54, Lang = "uk", Title = "Площа Незалежності", Description = "Центральна площа Рівного", Address = "Площа Незалежності, Рівне" },
            new AttractionTranslation { id = 110, EntityId = 55, Lang = "uk", Title = "Вулиця Соборна", Description = "Центральна вулиця Рівного", Address = "Вулиця Соборна, Рівне" },

            // =================== Рівне (DistrictId = 50) ===================
            new AttractionTranslation { id = 111, EntityId = 56, Lang = "en", Title = "Rivne Academic Ukrainian Music and Drama Theater", Description = "Major theater in Rivne for drama and music performances", Address = "Rivne Academic Ukrainian Music and Drama Theater, Rivne" },
            new AttractionTranslation { id = 112, EntityId = 57, Lang = "en", Title = "Soborna Street", Description = "Central street in Rivne", Address = "Soborna Street, Rivne" },
            new AttractionTranslation { id = 113, EntityId = 58, Lang = "en", Title = "Rivne Regional Library", Description = "Main public library in Rivne", Address = "Rivne Regional Library, Rivne" },
            new AttractionTranslation { id = 114, EntityId = 59, Lang = "en", Title = "Youth Park", Description = "Popular park for recreation in Rivne", Address = "Youth Park, Rivne" },
            new AttractionTranslation { id = 115, EntityId = 60, Lang = "en", Title = "Rivne Puppet Theater", Description = "Regional theater for puppet shows", Address = "Rivne Puppet Theater, Rivne" },

            new AttractionTranslation { id = 116, EntityId = 56, Lang = "uk", Title = "Рівненський академічний український музично-драматичний театр", Description = "Головний театр Рівного для драматичних і музичних вистав", Address = "Рівненський академічний український музично-драматичний театр, Рівне" },
            new AttractionTranslation { id = 117, EntityId = 57, Lang = "uk", Title = "Вулиця Соборна", Description = "Центральна вулиця Рівного", Address = "Вулиця Соборна, Рівне" },
            new AttractionTranslation { id = 118, EntityId = 58, Lang = "uk", Title = "Рівненська обласна бібліотека", Description = "Головна публічна бібліотека Рівного", Address = "Рівненська обласна бібліотека, Рівне" },
            new AttractionTranslation { id = 119, EntityId = 59, Lang = "uk", Title = "Парк Молоді", Description = "Популярний парк для відпочинку у Рівному", Address = "Парк Молоді, Рівне" },
            new AttractionTranslation { id = 120, EntityId = 60, Lang = "uk", Title = "Рівненський академічний обласний театр ляльок", Description = "Обласний театр ляльок", Address = "Рівненський академічний обласний театр ляльок, Рівне" },

            // =================== Луцьк (DistrictId = 52) ===================
            new AttractionTranslation { id = 121, EntityId = 61, Lang = "en", Title = "Lubart's Castle", Description = "Historic castle in the center of Lutsk", Address = "Lubart's Castle, Lutsk" },
            new AttractionTranslation { id = 122, EntityId = 62, Lang = "en", Title = "Lesi Ukrainky Street", Description = "Main street in Lutsk", Address = "Lesi Ukrainky Street, Lutsk" },
            new AttractionTranslation { id = 123, EntityId = 63, Lang = "en", Title = "Lutsk Museum", Description = "Museum showcasing the history of Lutsk", Address = "Lutsk Museum, Lutsk" },
            new AttractionTranslation { id = 124, EntityId = 64, Lang = "en", Title = "Lesi Ukrainky Park", Description = "City park named after Lesia Ukrainka", Address = "Lesi Ukrainky Park, Lutsk" },
            new AttractionTranslation { id = 125, EntityId = 65, Lang = "en", Title = "Holy Trinity Cathedral", Description = "Historic cathedral in Lutsk", Address = "Holy Trinity Cathedral, Lutsk" },

            new AttractionTranslation { id = 126, EntityId = 61, Lang = "uk", Title = "Замок Любарта", Description = "Історичний замок у центрі Луцька", Address = "Замок Любарта, Луцьк" },
            new AttractionTranslation { id = 127, EntityId = 62, Lang = "uk", Title = "Вулиця Лесі Українки", Description = "Головна вулиця Луцька", Address = "Вулиця Лесі Українки, Луцьк" },
            new AttractionTranslation { id = 128, EntityId = 63, Lang = "uk", Title = "Луцький музей", Description = "Музей історії Луцька", Address = "Луцький музей, Луцьк" },
            new AttractionTranslation { id = 129, EntityId = 64, Lang = "uk", Title = "Парк імені Лесі Українки", Description = "Міський парк імені Лесі Українки", Address = "Парк імені Лесі Українки, Луцьк" },
            new AttractionTranslation { id = 130, EntityId = 65, Lang = "uk", Title = "Собор Святої Трійці", Description = "Історичний собор у Луцьку", Address = "Собор Святої Трійці, Луцьк" },

            // =================== Чернівці(DistrictId = 55) ===================
            // --- District 55 ---
            new AttractionTranslation { id = 131, EntityId = 66, Lang = "en", Title = "Yuriy Fedkovych Chernivtsi National University", Description = "Historic university in Chernivtsi", Address = "Yuriy Fedkovych Chernivtsi National University, Chernivtsi" },
            new AttractionTranslation { id = 132, EntityId = 67, Lang = "en", Title = "Olha Kobylianska Street", Description = "Famous street in Chernivtsi", Address = "Olha Kobylianska Street, Chernivtsi" },
            new AttractionTranslation { id = 133, EntityId = 68, Lang = "en", Title = "Central Square", Description = "Main square of Chernivtsi", Address = "Central Square, Chernivtsi" },
            new AttractionTranslation { id = 134, EntityId = 69, Lang = "en", Title = "Chernivtsi Regional Museum", Description = "Regional museum with historical exhibits", Address = "Chernivtsi Regional Museum, Chernivtsi" },
            new AttractionTranslation { id = 135, EntityId = 70, Lang = "en", Title = "Zhovtnevyi Park", Description = "Popular park in Chernivtsi", Address = "Zhovtnevyi Park, Chernivtsi" },

            new AttractionTranslation { id = 136, EntityId = 66, Lang = "uk", Title = "Чернівецький національний університет імені Юрія Федьковича", Description = "Історичний університет у Чернівцях", Address = "Чернівецький національний університет імені Юрія Федьковича, Чернівці" },
            new AttractionTranslation { id = 137, EntityId = 67, Lang = "uk", Title = "Вулиця Ольги Кобилянської", Description = "Відома вулиця Чернівців", Address = "Вулиця Ольги Кобилянської, Чернівці" },
            new AttractionTranslation { id = 138, EntityId = 68, Lang = "uk", Title = "Площа Центральна", Description = "Головна площа Чернівців", Address = "Площа Центральна, Чернівці" },
            new AttractionTranslation { id = 139, EntityId = 69, Lang = "uk", Title = "Чернівецький обласний краєзнавчий музей", Description = "Обласний музей з історичними експонатами", Address = "Чернівецький обласний краєзнавчий музей, Чернівці" },
            new AttractionTranslation { id = 140, EntityId = 70, Lang = "uk", Title = "Парк Жовтневий", Description = "Популярний парк у Чернівцях", Address = "Парк Жовтневий, Чернівці" },

            // =================== Житомир (DistrictId = 58) ===================
            new AttractionTranslation { id = 141, EntityId = 71, Lang = "en", Title = "Zhytomyr Museum of Cosmonautics", Description = "Museum dedicated to space exploration and cosmonautics", Address = "Zhytomyr Museum of Cosmonautics, Zhytomyr" },
            new AttractionTranslation { id = 142, EntityId = 72, Lang = "en", Title = "Mykhailivska Street", Description = "Central street in Zhytomyr", Address = "Mykhailivska Street, Zhytomyr" },
            new AttractionTranslation { id = 143, EntityId = 73, Lang = "en", Title = "Palace of Culture", Description = "Cultural center and event venue in Zhytomyr", Address = "Palace of Culture, Zhytomyr" },
            new AttractionTranslation { id = 144, EntityId = 74, Lang = "en", Title = "Holy Sophia Cathedral", Description = "Historic cathedral in Zhytomyr", Address = "Holy Sophia Cathedral, Zhytomyr" },
            new AttractionTranslation { id = 145, EntityId = 75, Lang = "en", Title = "Yuri Gagarin Park", Description = "Popular park named after Yuri Gagarin", Address = "Yuri Gagarin Park, Zhytomyr" },

            new AttractionTranslation { id = 146, EntityId = 71, Lang = "uk", Title = "Житомирський музей космонавтики", Description = "Музей, присвячений космічним дослідженням та космонавтиці", Address = "Житомирський музей космонавтики, Житомир" },
            new AttractionTranslation { id = 147, EntityId = 72, Lang = "uk", Title = "Вулиця Михайлівська", Description = "Центральна вулиця Житомира", Address = "Вулиця Михайлівська, Житомир" },
            new AttractionTranslation { id = 148, EntityId = 73, Lang = "uk", Title = "Палац Культури", Description = "Культурний центр та місце проведення заходів у Житомирі", Address = "Палац Культури, Житомир" },
            new AttractionTranslation { id = 149, EntityId = 74, Lang = "uk", Title = "Собор Святої Софії", Description = "Історичний собор у Житомирі", Address = "Собор Святої Софії, Житомир" },
            new AttractionTranslation { id = 150, EntityId = 75, Lang = "uk", Title = "Парк ім. Юрія Гагаріна", Description = "Популярний парк, названий на честь Юрія Гагаріна", Address = "Парк ім. Юрія Гагаріна, Житомир" },

            // =================== Житомир (DistrictId = 59) ===================
            new AttractionTranslation { id = 151, EntityId = 76, Lang = "en", Title = "Zhytomyr Regional Art Museum", Description = "Museum featuring regional and national art collections", Address = "Zhytomyr Regional Art Museum, Zhytomyr" },
            new AttractionTranslation { id = 152, EntityId = 77, Lang = "en", Title = "Kyivska Street", Description = "Central street in Zhytomyr", Address = "Kyivska Street, Zhytomyr" },
            new AttractionTranslation { id = 153, EntityId = 78, Lang = "en", Title = "Zhytomyr History Museum", Description = "Museum showcasing the history of Zhytomyr", Address = "Zhytomyr History Museum, Zhytomyr" },
            new AttractionTranslation { id = 154, EntityId = 79, Lang = "en", Title = "Zhytomyr Botanical Garden", Description = "Botanical garden with diverse plant collections", Address = "Zhytomyr Botanical Garden, Zhytomyr" },
            new AttractionTranslation { id = 155, EntityId = 80, Lang = "en", Title = "Polissya Stadium", Description = "Local sports stadium in Zhytomyr", Address = "Polissya Stadium, Zhytomyr" },

            new AttractionTranslation { id = 156, EntityId = 76, Lang = "uk", Title = "Житомирський обласний художній музей", Description = "Музей з регіональними та національними художніми колекціями", Address = "Житомирський обласний художній музей, Житомир" },
            new AttractionTranslation { id = 157, EntityId = 77, Lang = "uk", Title = "Вулиця Київська", Description = "Центральна вулиця Житомира", Address = "Вулиця Київська, Житомир" },
            new AttractionTranslation { id = 158, EntityId = 78, Lang = "uk", Title = "Музей історії міста Житомир", Description = "Музей, що демонструє історію Житомира", Address = "Музей історії міста Житомир, Житомир" },
            new AttractionTranslation { id = 159, EntityId = 79, Lang = "uk", Title = "Житомирський ботанічний сад", Description = "Ботанічний сад з різноманітними колекціями рослин", Address = "Житомирський ботанічний сад, Житомир" },
            new AttractionTranslation { id = 160, EntityId = 80, Lang = "uk", Title = "Стадіон 'Полісся'", Description = "Місцевий спортивний стадіон у Житомирі", Address = "Стадіон 'Полісся', Житомир" },

            // =================== Суми (DistrictId = 61) ===================
            new AttractionTranslation { id = 161, EntityId = 81, Lang = "en", Title = "Sumy Academic Drama and Musical Comedy Theater", Description = "Major theater for drama and musical performances in Sumy", Address = "Sumy Academic Drama and Musical Comedy Theater, Sumy" },
            new AttractionTranslation { id = 162, EntityId = 82, Lang = "en", Title = "Voskresenska Street", Description = "Central street in Sumy", Address = "Voskresenska Street, Sumy" },
            new AttractionTranslation { id = 163, EntityId = 83, Lang = "en", Title = "Sumy Regional Art Museum", Description = "Museum with regional art collections", Address = "Sumy Regional Art Museum, Sumy" },
            new AttractionTranslation { id = 164, EntityId = 84, Lang = "en", Title = "Kozhedub Park", Description = "Park named after famous pilot Kozhedub", Address = "Kozhedub Park, Sumy" },
            new AttractionTranslation { id = 165, EntityId = 85, Lang = "en", Title = "Sumy Regional Philharmonic", Description = "Philharmonic hall with concerts and events", Address = "Sumy Regional Philharmonic, Sumy" },

            new AttractionTranslation { id = 166, EntityId = 81, Lang = "uk", Title = "Сумський академічний театр драми та музичної комедії", Description = "Головний театр для драматичних та музичних вистав у Сумах", Address = "Сумський академічний театр драми та музичної комедії, Суми" },
            new AttractionTranslation { id = 167, EntityId = 82, Lang = "uk", Title = "Вулиця Воскресенська", Description = "Центральна вулиця Сум", Address = "Вулиця Воскресенська, Суми" },
            new AttractionTranslation { id = 168, EntityId = 83, Lang = "uk", Title = "Сумський обласний художній музей", Description = "Музей з регіональними художніми колекціями", Address = "Сумський обласний художній музей, Суми" },
            new AttractionTranslation { id = 169, EntityId = 84, Lang = "uk", Title = "Парк ім. Кожедуба", Description = "Парк, названий на честь відомого пілота Кожедуба", Address = "Парк ім. Кожедуба, Суми" },
            new AttractionTranslation { id = 170, EntityId = 85, Lang = "uk", Title = "Сумська обласна філармонія", Description = "Філармонія для концертів та заходів", Address = "Сумська обласна філармонія, Суми" },

            // =================== Кропивницький (DistrictId = 64) ===================
            new AttractionTranslation { id = 171, EntityId = 86, Lang = "en", Title = "Kropyvnytskyi Regional Art Museum", Description = "Museum showcasing regional and national art", Address = "Kropyvnytskyi Regional Art Museum, Kropyvnytskyi" },
            new AttractionTranslation { id = 172, EntityId = 87, Lang = "en", Title = "Velyka Perspektyvna Street", Description = "Main street in Kropyvnytskyi", Address = "Velyka Perspektyvna Street, Kropyvnytskyi" },
            new AttractionTranslation { id = 173, EntityId = 88, Lang = "en", Title = "Kropyvnytskyi Academic Theater named after M. Kropyvnytskyi", Description = "Historic theater for drama performances", Address = "Kropyvnytskyi Academic Theater, Kropyvnytskyi" },
            new AttractionTranslation { id = 174, EntityId = 89, Lang = "en", Title = "Kovalivskyi Park", Description = "Popular park in the city center", Address = "Kovalivskyi Park, Kropyvnytskyi" },
            new AttractionTranslation { id = 175, EntityId = 90, Lang = "en", Title = "Kropyvnytskyi History Museum", Description = "Museum showcasing the history of Kropyvnytskyi", Address = "Kropyvnytskyi History Museum, Kropyvnytskyi" },

            new AttractionTranslation { id = 176, EntityId = 86, Lang = "uk", Title = "Кіровоградський обласний художній музей", Description = "Музей з регіональними та національними художніми колекціями", Address = "Кіровоградський обласний художній музей, Кропивницький" },
            new AttractionTranslation { id = 177, EntityId = 87, Lang = "uk", Title = "Вулиця Велика Перспективна", Description = "Головна вулиця Кропивницького", Address = "Вулиця Велика Перспективна, Кропивницький" },
            new AttractionTranslation { id = 178, EntityId = 88, Lang = "uk", Title = "Кіровоградський академічний театр ім. М. Кропивницького", Description = "Історичний театр для драматичних вистав", Address = "Кіровоградський академічний театр, Кропивницький" },
            new AttractionTranslation { id = 179, EntityId = 89, Lang = "uk", Title = "Парк Ковалівський", Description = "Популярний парк у центрі міста", Address = "Парк Ковалівський, Кропивницький" },
            new AttractionTranslation { id = 180, EntityId = 90, Lang = "uk", Title = "Музей історії міста Кропивницький", Description = "Музей, що демонструє історію Кропивницького", Address = "Музей історії міста Кропивницький, Кропивницький" },

            // =================== Вінниця (DistrictId = 67) ===================
            new AttractionTranslation { id = 181, EntityId = 91, Lang = "en", Title = "Vinnytsia State Academic Musical Drama Theater named after Sadovsky", Description = "Theater for musical and dramatic performances", Address = "Vinnytsia State Academic Musical Drama Theater, Vinnytsia" },
            new AttractionTranslation { id = 182, EntityId = 92, Lang = "en", Title = "Soborna Street", Description = "Central street in Vinnytsia", Address = "Soborna Street, Vinnytsia" },
            new AttractionTranslation { id = 183, EntityId = 93, Lang = "en", Title = "Mykola Pirogov Museum-Estate", Description = "Museum dedicated to the famous surgeon and scientist Pirogov", Address = "Mykola Pirogov Museum-Estate, Vinnytsia" },
            new AttractionTranslation { id = 184, EntityId = 94, Lang = "en", Title = "Leontovych Park", Description = "Park named after composer Leontovych", Address = "Leontovych Park, Vinnytsia" },
            new AttractionTranslation { id = 185, EntityId = 95, Lang = "en", Title = "Vinnytsia Regional Museum", Description = "Museum featuring regional history and culture", Address = "Vinnytsia Regional Museum, Vinnytsia" },

            new AttractionTranslation { id = 186, EntityId = 91, Lang = "uk", Title = "Вінницький державний академічний музично-драматичний театр ім. Садовського", Description = "Театр для музичних та драматичних вистав", Address = "Вінницький державний академічний музично-драматичний театр, Вінниця" },
            new AttractionTranslation { id = 187, EntityId = 92, Lang = "uk", Title = "Вулиця Соборна", Description = "Центральна вулиця Вінниці", Address = "Вулиця Соборна, Вінниця" },
            new AttractionTranslation { id = 188, EntityId = 93, Lang = "uk", Title = "Музей-садиба Миколи Пирогова", Description = "Музей, присвячений відомому хірургу та вченому Пирогову", Address = "Музей-садиба Миколи Пирогова, Вінниця" },
            new AttractionTranslation { id = 189, EntityId = 94, Lang = "uk", Title = "Парк ім. Леонтовича", Description = "Парк, названий на честь композитора Леонтовича", Address = "Парк ім. Леонтовича, Вінниця" },
            new AttractionTranslation { id = 190, EntityId = 95, Lang = "uk", Title = "Вінницький обласний краєзнавчий музей", Description = "Музей з регіональної історії та культури", Address = "Вінницький обласний краєзнавчий музей, Вінниця" },

            // =================== Харків (DistrictId = 70) ===================
            new AttractionTranslation { id = 191, EntityId = 96, Lang = "en", Title = "Kharkiv National Academic Opera and Ballet Theater", Description = "Major venue for opera and ballet performances", Address = "Kharkiv National Academic Opera and Ballet Theater, Kharkiv" },
            new AttractionTranslation { id = 192, EntityId = 97, Lang = "en", Title = "Freedom Square", Description = "Central square in Kharkiv", Address = "Freedom Square, Kharkiv" },
            new AttractionTranslation { id = 193, EntityId = 98, Lang = "en", Title = "Kharkiv Art Museum", Description = "Museum featuring regional and national art", Address = "Kharkiv Art Museum, Kharkiv" },
            new AttractionTranslation { id = 194, EntityId = 99, Lang = "en", Title = "Gorky Park", Description = "Popular park in Kharkiv", Address = "Gorky Park, Kharkiv" },
            new AttractionTranslation { id = 195, EntityId = 100, Lang = "en", Title = "Kharkiv Historical Museum", Description = "Museum showcasing the history of Kharkiv", Address = "Kharkiv Historical Museum, Kharkiv" },

            new AttractionTranslation { id = 196, EntityId = 96, Lang = "uk", Title = "Харківський національний академічний театр опери та балету", Description = "Головний майданчик для оперних та балетних вистав", Address = "Харківський національний академічний театр опери та балету, Харків" },
            new AttractionTranslation { id = 197, EntityId = 97, Lang = "uk", Title = "Площа Свободи", Description = "Центральна площа Харкова", Address = "Площа Свободи, Харків" },
            new AttractionTranslation { id = 198, EntityId = 98, Lang = "uk", Title = "Харківський художній музей", Description = "Музей з регіональними та національними художніми колекціями", Address = "Харківський художній музей, Харків" },
            new AttractionTranslation { id = 199, EntityId = 99, Lang = "uk", Title = "Парк Горького", Description = "Популярний парк у Харкові", Address = "Парк Горького, Харків" },
            new AttractionTranslation { id = 200, EntityId = 100, Lang = "uk", Title = "Харківський історичний музей", Description = "Музей, що демонструє історію Харкова", Address = "Харківський історичний музей, Харків" },

            // =================== Харків (DistrictId = 71) ===================
            new AttractionTranslation { id = 201, EntityId = 101, Lang = "en", Title = "Kharkiv State Circus", Description = "Venue for circus performances and events", Address = "Kharkiv State Circus, Kharkiv" },
            new AttractionTranslation { id = 202, EntityId = 102, Lang = "en", Title = "Sumska Street", Description = "Main street in Kharkiv", Address = "Sumska Street, Kharkiv" },
            new AttractionTranslation { id = 203, EntityId = 103, Lang = "en", Title = "Kharkiv Planetarium", Description = "Planetarium with astronomy exhibitions and shows", Address = "Kharkiv Planetarium, Kharkiv" },
            new AttractionTranslation { id = 204, EntityId = 104, Lang = "en", Title = "Taras Shevchenko Park", Description = "Park named after the famous poet Shevchenko", Address = "Taras Shevchenko Park, Kharkiv" },
            new AttractionTranslation { id = 205, EntityId = 105, Lang = "en", Title = "Kharkiv Literary Museum", Description = "Museum dedicated to literary figures of Kharkiv", Address = "Kharkiv Literary Museum, Kharkiv" },

            new AttractionTranslation { id = 206, EntityId = 101, Lang = "uk", Title = "Харківський державний цирк", Description = "Майданчик для циркових вистав та заходів", Address = "Харківський державний цирк, Харків" },
            new AttractionTranslation { id = 207, EntityId = 102, Lang = "uk", Title = "Вулиця Сумська", Description = "Головна вулиця Харкова", Address = "Вулиця Сумська, Харків" },
            new AttractionTranslation { id = 208, EntityId = 103, Lang = "uk", Title = "Харківський планетарій", Description = "Планетарій з астрономічними виставками та шоу", Address = "Харківський планетарій, Харків" },
            new AttractionTranslation { id = 209, EntityId = 104, Lang = "uk", Title = "Парк імені Т.Г. Шевченка", Description = "Парк, названий на честь відомого поета Шевченка", Address = "Парк імені Т.Г. Шевченка, Харків" },
            new AttractionTranslation { id = 210, EntityId = 105, Lang = "uk", Title = "Харківський літературний музей", Description = "Музей, присвячений літературним діячам Харкова", Address = "Харківський літературний музей, Харків" }

            //    // --- New York ---
            //    new AttractionTranslation { id = 1, EntityId = 1, Lang = "en", Title = "Statue of Liberty", Description = "Iconic national monument" },
            //    new AttractionTranslation { id = 2, EntityId = 1, Lang = "ru", Title = "Статуя Свободы", Description = "Знаменитый национальный памятник" },
            //    new AttractionTranslation { id = 3, EntityId = 2, Lang = "en", Title = "Central Park", Description = "Famous urban park" },
            //    new AttractionTranslation { id = 4, EntityId = 2, Lang = "ru", Title = "Центральный парк", Description = "Известный городской парк" },
            //    new AttractionTranslation { id = 5, EntityId = 3, Lang = "en", Title = "Times Square", Description = "Major commercial intersection" },
            //    new AttractionTranslation { id = 6, EntityId = 3, Lang = "ru", Title = "Таймс-сквер", Description = "Крупная торговая площадь" },
            //    new AttractionTranslation { id = 7, EntityId = 4, Lang = "en", Title = "Brooklyn Bridge", Description = "Historic bridge" },
            //    new AttractionTranslation { id = 8, EntityId = 4, Lang = "ru", Title = "Бруклинский мост", Description = "Исторический мост" },
            //    new AttractionTranslation { id = 9, EntityId = 5, Lang = "en", Title = "Empire State Building", Description = "102-story skyscraper" },
            //    new AttractionTranslation { id = 10, EntityId = 5, Lang = "ru", Title = "Эмпайр-стейт-билдинг", Description = "102-этажный небоскрёб" },

            //    // --- Los Angeles ---
            //    new AttractionTranslation { id = 11, EntityId = 6, Lang = "en", Title = "Hollywood Sign", Description = "Famous landmark" },
            //    new AttractionTranslation { id = 12, EntityId = 6, Lang = "ru", Title = "Знак Голливуда", Description = "Знаковая достопримечательность" },
            //    new AttractionTranslation { id = 13, EntityId = 7, Lang = "en", Title = "Santa Monica Pier", Description = "Historic pier" },
            //    new AttractionTranslation { id = 14, EntityId = 7, Lang = "ru", Title = "Пирс Санта-Моники", Description = "Исторический пирс" },
            //    new AttractionTranslation { id = 15, EntityId = 8, Lang = "en", Title = "Griffith Observatory", Description = "Observatory with city views" },
            //    new AttractionTranslation { id = 16, EntityId = 8, Lang = "ru", Title = "Обсерватория Гриффита", Description = "Обсерватория с видом на город" },
            //    new AttractionTranslation { id = 17, EntityId = 9, Lang = "en", Title = "Getty Center", Description = "Art museum" },
            //    new AttractionTranslation { id = 18, EntityId = 9, Lang = "ru", Title = "Центр Гетти", Description = "Художественный музей" },
            //    new AttractionTranslation { id = 19, EntityId = 10, Lang = "en", Title = "Venice Beach", Description = "Famous beach area" },
            //    new AttractionTranslation { id = 20, EntityId = 10, Lang = "ru", Title = "Пляж Венеции", Description = "Знаменитый пляж" },

            //    // --- Chicago ---
            //    new AttractionTranslation { id = 21, EntityId = 11, Lang = "en", Title = "Millennium Park", Description = "Public park with art installations" },
            //    new AttractionTranslation { id = 22, EntityId = 11, Lang = "ru", Title = "Парк Тысячелетия", Description = "Общественный парк с арт-объектами" },
            //    new AttractionTranslation { id = 23, EntityId = 12, Lang = "en", Title = "Art Institute of Chicago", Description = "Famous art museum" },
            //    new AttractionTranslation { id = 24, EntityId = 12, Lang = "ru", Title = "Чикагский институт искусств", Description = "Известный художественный музей" },
            //    new AttractionTranslation { id = 25, EntityId = 13, Lang = "en", Title = "Navy Pier", Description = "Pier with attractions and restaurants" },
            //    new AttractionTranslation { id = 26, EntityId = 13, Lang = "ru", Title = "Нэйви-Пир", Description = "Пирс с аттракционами и ресторанами" },
            //    new AttractionTranslation { id = 27, EntityId = 14, Lang = "en", Title = "Willis Tower", Description = "Iconic skyscraper" },
            //    new AttractionTranslation { id = 28, EntityId = 14, Lang = "ru", Title = "Виллис-Тауэр", Description = "Знаковый небоскрёб" },
            //    new AttractionTranslation { id = 29, EntityId = 15, Lang = "en", Title = "Lincoln Park Zoo", Description = "Historic zoo" },
            //    new AttractionTranslation { id = 30, EntityId = 15, Lang = "ru", Title = "Зоопарк Линкольн-Парк", Description = "Исторический зоопарк" },

            //    // --- Germany ---
            //    new AttractionTranslation { id = 31, EntityId = 16, Lang = "en", Title = "Brandenburg Gate", Description = "Historic monument" },
            //    new AttractionTranslation { id = 32, EntityId = 16, Lang = "ru", Title = "Бранденбургские ворота", Description = "Исторический памятник" },
            //    new AttractionTranslation { id = 33, EntityId = 17, Lang = "en", Title = "Berlin Wall Memorial", Description = "Remains of Berlin Wall" },
            //    new AttractionTranslation { id = 34, EntityId = 17, Lang = "ru", Title = "Мемориал Берлинской стены", Description = "Остатки Берлинской стены" },
            //    new AttractionTranslation { id = 35, EntityId = 18, Lang = "en", Title = "Museum Island", Description = "Group of museums" },
            //    new AttractionTranslation { id = 36, EntityId = 18, Lang = "ru", Title = "Остров музеев", Description = "Группа музеев" },
            //    new AttractionTranslation { id = 37, EntityId = 19, Lang = "en", Title = "Alexanderplatz", Description = "Central square" },
            //    new AttractionTranslation { id = 38, EntityId = 19, Lang = "ru", Title = "Александерплац", Description = "Центральная площадь" },
            //    new AttractionTranslation { id = 39, EntityId = 20, Lang = "en", Title = "Checkpoint Charlie", Description = "Historic border crossing" },
            //    new AttractionTranslation { id = 40, EntityId = 20, Lang = "ru", Title = "Чекпойнт Чарли", Description = "Исторический пограничный переход" },

            //    // --- Germany (continued) ---
            //    new AttractionTranslation { id = 41, EntityId = 21, Lang = "en", Title = "Marienplatz", Description = "Central square" },
            //    new AttractionTranslation { id = 42, EntityId = 21, Lang = "ru", Title = "Мариенплац", Description = "Центральная площадь" },
            //    new AttractionTranslation { id = 43, EntityId = 22, Lang = "en", Title = "English Garden", Description = "Large public park" },
            //    new AttractionTranslation { id = 44, EntityId = 22, Lang = "ru", Title = "Английский сад", Description = "Большой городской парк" },
            //    new AttractionTranslation { id = 45, EntityId = 23, Lang = "en", Title = "Nymphenburg Palace", Description = "Historic palace" },
            //    new AttractionTranslation { id = 46, EntityId = 23, Lang = "ru", Title = "Дворец Нимфенбург", Description = "Исторический дворец" },
            //    new AttractionTranslation { id = 47, EntityId = 24, Lang = "en", Title = "BMW Museum", Description = "Automobile museum" },
            //    new AttractionTranslation { id = 48, EntityId = 24, Lang = "ru", Title = "Музей BMW", Description = "Музей автомобилей" },
            //    new AttractionTranslation { id = 49, EntityId = 25, Lang = "en", Title = "Olympiapark", Description = "Sports and entertainment complex" },
            //    new AttractionTranslation { id = 50, EntityId = 25, Lang = "ru", Title = "Олимпийский парк", Description = "Спортивный и развлекательный комплекс" },

            //    new AttractionTranslation { id = 51, EntityId = 26, Lang = "en", Title = "Miniatur Wunderland", Description = "Largest model railway" },
            //    new AttractionTranslation { id = 52, EntityId = 26, Lang = "ru", Title = "Миниатюрная страна чудес", Description = "Самая большая модель железной дороги" },
            //    new AttractionTranslation { id = 53, EntityId = 27, Lang = "en", Title = "Port of Hamburg", Description = "Famous port area" },
            //    new AttractionTranslation { id = 54, EntityId = 27, Lang = "ru", Title = "Гамбургский порт", Description = "Известная портовая зона" },
            //    new AttractionTranslation { id = 55, EntityId = 28, Lang = "en", Title = "Elbphilharmonie", Description = "Concert hall" },
            //    new AttractionTranslation { id = 56, EntityId = 28, Lang = "ru", Title = "Эльбская филармония", Description = "Концертный зал" },
            //    new AttractionTranslation { id = 57, EntityId = 29, Lang = "en", Title = "St. Michael's Church", Description = "Historic church" },
            //    new AttractionTranslation { id = 58, EntityId = 29, Lang = "ru", Title = "Церковь Св. Михаила", Description = "Историческая церковь" },
            //    new AttractionTranslation { id = 59, EntityId = 30, Lang = "en", Title = "Speicherstadt", Description = "Warehouse district" },
            //    new AttractionTranslation { id = 60, EntityId = 30, Lang = "ru", Title = "Спайхерштадт", Description = "Складской район" },

            //// --- France ---
            //    new AttractionTranslation { id = 61, EntityId = 31, Lang = "en", Title = "Eiffel Tower", Description = "Famous tower in Paris" },
            //    new AttractionTranslation { id = 62, EntityId = 31, Lang = "ru", Title = "Эйфелева башня", Description = "Знаменитая башня в Париже" },
            //    new AttractionTranslation { id = 63, EntityId = 32, Lang = "en", Title = "Louvre Museum", Description = "World famous museum" },
            //    new AttractionTranslation { id = 64, EntityId = 32, Lang = "ru", Title = "Лувр", Description = "Мировой известный музей" },
            //    new AttractionTranslation { id = 65, EntityId = 33, Lang = "en", Title = "Notre-Dame Cathedral", Description = "Historic cathedral" },
            //    new AttractionTranslation { id = 66, EntityId = 33, Lang = "ru", Title = "Собор Нотр-Дам", Description = "Исторический собор" },
            //    new AttractionTranslation { id = 67, EntityId = 34, Lang = "en", Title = "Montmartre", Description = "Historic district" },
            //    new AttractionTranslation { id = 68, EntityId = 34, Lang = "ru", Title = "Монмартр", Description = "Исторический район" },
            //    new AttractionTranslation { id = 69, EntityId = 35, Lang = "en", Title = "Champs-Élysées", Description = "Famous avenue" },
            //    new AttractionTranslation { id = 70, EntityId = 35, Lang = "ru", Title = "Елисейские поля", Description = "Знаменитая улица" },

            //    new AttractionTranslation { id = 71, EntityId = 36, Lang = "en", Title = "Basilica of Notre-Dame de Fourvière", Description = "Historic church" },
            //    new AttractionTranslation { id = 72, EntityId = 36, Lang = "ru", Title = "Базилика Нотр-Дам-де-Фурвьер", Description = "Историческая церковь" },
            //    new AttractionTranslation { id = 73, EntityId = 37, Lang = "en", Title = "Parc de la Tête d'Or", Description = "Large urban park" },
            //    new AttractionTranslation { id = 74, EntityId = 37, Lang = "ru", Title = "Парк Тет-д'Ор", Description = "Большой городской парк" },
            //    new AttractionTranslation { id = 75, EntityId = 38, Lang = "en", Title = "Vieux Lyon", Description = "Historic district" },
            //    new AttractionTranslation { id = 76, EntityId = 38, Lang = "ru", Title = "Старый Лион", Description = "Исторический район" },
            //    new AttractionTranslation { id = 77, EntityId = 39, Lang = "en", Title = "Musée des Beaux-Arts", Description = "Art museum" },
            //    new AttractionTranslation { id = 78, EntityId = 39, Lang = "ru", Title = "Музей изящных искусств", Description = "Художественный музей" },
            //    new AttractionTranslation { id = 79, EntityId = 40, Lang = "en", Title = "Place Bellecour", Description = "City square" },
            //    new AttractionTranslation { id = 80, EntityId = 40, Lang = "ru", Title = "Площадь Белькур", Description = "Городская площадь" },

            //    // --- France / Marseille ---
            //    new AttractionTranslation { id = 81, EntityId = 41, Lang = "en", Title = "Old Port of Marseille", Description = "Historic harbor area" },
            //    new AttractionTranslation { id = 82, EntityId = 41, Lang = "ru", Title = "Старый порт Марселя", Description = "Историческая портовая зона" },
            //    new AttractionTranslation { id = 83, EntityId = 42, Lang = "en", Title = "Basilique Notre-Dame de la Garde", Description = "Historic basilica" },
            //    new AttractionTranslation { id = 84, EntityId = 42, Lang = "ru", Title = "Базилика Нотр-Дам-де-ла-Гард", Description = "Историческая базилика" },
            //    new AttractionTranslation { id = 85, EntityId = 43, Lang = "en", Title = "Château d'If", Description = "Island fortress" },
            //    new AttractionTranslation { id = 86, EntityId = 43, Lang = "ru", Title = "Замок Иф", Description = "Островная крепость" },
            //    new AttractionTranslation { id = 87, EntityId = 44, Lang = "en", Title = "La Canebière", Description = "Historic street" },
            //    new AttractionTranslation { id = 88, EntityId = 44, Lang = "ru", Title = "Ля Канебиер", Description = "Историческая улица" },
            //    new AttractionTranslation { id = 89, EntityId = 45, Lang = "en", Title = "Palais Longchamp", Description = "Fountain and palace" },
            //    new AttractionTranslation { id = 90, EntityId = 45, Lang = "ru", Title = "Пале Лоншан", Description = "Фонтан и дворец" },

            //    // EntityId 46–50 (London)
            //    new AttractionTranslation { id = 91, EntityId = 46, Lang = "en", Title = "Tower of London", Description = "Historic castle and former prison" },
            //    new AttractionTranslation { id = 92, EntityId = 46, Lang = "ru", Title = "Тауэр", Description = "Исторический замок и бывшая тюрьма" },
            //    new AttractionTranslation { id = 93, EntityId = 47, Lang = "en", Title = "Buckingham Palace", Description = "Royal residence" },
            //    new AttractionTranslation { id = 94, EntityId = 47, Lang = "ru", Title = "Букингемский дворец", Description = "Королевская резиденция" },
            //    new AttractionTranslation { id = 95, EntityId = 48, Lang = "en", Title = "London Eye", Description = "Giant Ferris wheel" },
            //    new AttractionTranslation { id = 96, EntityId = 48, Lang = "ru", Title = "Лондонский глаз", Description = "Огромное колесо обозрения" },
            //    new AttractionTranslation { id = 97, EntityId = 49, Lang = "en", Title = "British Museum", Description = "World-famous museum" },
            //    new AttractionTranslation { id = 98, EntityId = 49, Lang = "ru", Title = "Британский музей", Description = "Знаменитый музей мира" },
            //    new AttractionTranslation { id = 99, EntityId = 50, Lang = "en", Title = "St. Paul's Cathedral", Description = "Famous cathedral" },
            //    new AttractionTranslation { id = 100, EntityId = 50, Lang = "ru", Title = "Собор Святого Павла", Description = "Знаменитый собор" },

            //    // EntityId 51–55 (Manchester)
            //    new AttractionTranslation { id = 101, EntityId = 51, Lang = "en", Title = "Old Trafford", Description = "Football stadium" },
            //    new AttractionTranslation { id = 102, EntityId = 51, Lang = "ru", Title = "Олд Траффорд", Description = "Футбольный стадион" },
            //    new AttractionTranslation { id = 103, EntityId = 52, Lang = "en", Title = "Manchester Cathedral", Description = "Historic cathedral" },
            //    new AttractionTranslation { id = 104, EntityId = 52, Lang = "ru", Title = "Манчестерский собор", Description = "Исторический собор" },
            //    new AttractionTranslation { id = 105, EntityId = 53, Lang = "en", Title = "John Rylands Library", Description = "Historic library" },
            //    new AttractionTranslation { id = 106, EntityId = 53, Lang = "ru", Title = "Библиотека Джона Райлэндса", Description = "Историческая библиотека" },
            //    new AttractionTranslation { id = 107, EntityId = 54, Lang = "en", Title = "Science and Industry Museum", Description = "Museum of science" },
            //    new AttractionTranslation { id = 108, EntityId = 54, Lang = "ru", Title = "Музей науки и промышленности", Description = "Музей науки" },
            //    new AttractionTranslation { id = 109, EntityId = 55, Lang = "en", Title = "Castlefield", Description = "Historic area with canals" },
            //    new AttractionTranslation { id = 110, EntityId = 55, Lang = "ru", Title = "Каслфилд", Description = "Исторический район с каналами" },

            //    // EntityId 56–60 (Birmingham)
            //    new AttractionTranslation { id = 111, EntityId = 56, Lang = "en", Title = "Birmingham Museum & Art Gallery", Description = "Art museum" },
            //    new AttractionTranslation { id = 112, EntityId = 56, Lang = "ru", Title = "Музей и художественная галерея Бирмингема", Description = "Художественный музей" },
            //    new AttractionTranslation { id = 113, EntityId = 57, Lang = "en", Title = "Cadbury World", Description = "Chocolate-themed attraction" },
            //    new AttractionTranslation { id = 114, EntityId = 57, Lang = "ru", Title = "Кэдбери Уорлд", Description = "Аттракцион о шоколаде" },
            //    new AttractionTranslation { id = 115, EntityId = 58, Lang = "en", Title = "Birmingham Botanical Gardens", Description = "Botanical gardens" },
            //    new AttractionTranslation { id = 116, EntityId = 58, Lang = "ru", Title = "Ботанические сады Бирмингема", Description = "Ботанические сады" },
            //    new AttractionTranslation { id = 117, EntityId = 59, Lang = "en", Title = "Thinktank Birmingham Science Museum", Description = "Science museum" },
            //    new AttractionTranslation { id = 118, EntityId = 59, Lang = "ru", Title = "Научный музей Тинктанк", Description = "Научный музей" },
            //    new AttractionTranslation { id = 119, EntityId = 60, Lang = "en", Title = "Jewellery Quarter", Description = "Historic jewelry district" },
            //    new AttractionTranslation { id = 120, EntityId = 60, Lang = "ru", Title = "Ювелирный квартал", Description = "Исторический ювелирный район" },

            //    // EntityId 61–65 (Madrid)
            //    new AttractionTranslation { id = 121, EntityId = 61, Lang = "en", Title = "Royal Palace of Madrid", Description = "Official residence of the Spanish royal family" },
            //    new AttractionTranslation { id = 122, EntityId = 61, Lang = "ru", Title = "Королевский дворец Мадрида", Description = "Официальная резиденция испанской королевской семьи" },
            //    new AttractionTranslation { id = 123, EntityId = 62, Lang = "en", Title = "Plaza Mayor", Description = "Historic city square" },
            //    new AttractionTranslation { id = 124, EntityId = 62, Lang = "ru", Title = "Пласа-Майор", Description = "Историческая городская площадь" },
            //    new AttractionTranslation { id = 125, EntityId = 63, Lang = "en", Title = "Puerta del Sol", Description = "Famous city square" },
            //    new AttractionTranslation { id = 126, EntityId = 63, Lang = "ru", Title = "Пуэрта-дель-Соль", Description = "Знаменитая городская площадь" },
            //    new AttractionTranslation { id = 127, EntityId = 64, Lang = "en", Title = "Retiro Park", Description = "Large public park" },
            //    new AttractionTranslation { id = 128, EntityId = 64, Lang = "ru", Title = "Парк Ретиро", Description = "Большой общественный парк" },
            //    new AttractionTranslation { id = 129, EntityId = 65, Lang = "en", Title = "Temple of Debod", Description = "Ancient Egyptian temple" },
            //    new AttractionTranslation { id = 130, EntityId = 65, Lang = "ru", Title = "Храм Дебод", Description = "Древний египетский храм" },

            //    // EntityId 66–70 (Barcelona)
            //    new AttractionTranslation { id = 131, EntityId = 66, Lang = "en", Title = "Sagrada Familia", Description = "Famous basilica by Gaudi" },
            //    new AttractionTranslation { id = 132, EntityId = 66, Lang = "ru", Title = "Саграда Фамилия", Description = "Знаменитая базилика Гауди" },
            //    new AttractionTranslation { id = 133, EntityId = 67, Lang = "en", Title = "Park Güell", Description = "Public park with Gaudi architecture" },
            //    new AttractionTranslation { id = 134, EntityId = 67, Lang = "ru", Title = "Парк Гуэль", Description = "Общественный парк с архитектурой Гауди" },
            //    new AttractionTranslation { id = 135, EntityId = 68, Lang = "en", Title = "Casa Batlló", Description = "Modernist building by Gaudi" },
            //    new AttractionTranslation { id = 136, EntityId = 68, Lang = "ru", Title = "Каса Бальо", Description = "Модернистское здание Гауди" },
            //    new AttractionTranslation { id = 137, EntityId = 69, Lang = "en", Title = "La Rambla", Description = "Famous street" },
            //    new AttractionTranslation { id = 138, EntityId = 69, Lang = "ru", Title = "Ла Рамбла", Description = "Знаменитая улица" },
            //    new AttractionTranslation { id = 139, EntityId = 70, Lang = "en", Title = "Gothic Quarter", Description = "Historic city center" },
            //    new AttractionTranslation { id = 140, EntityId = 70, Lang = "ru", Title = "Готический квартал", Description = "Исторический центр города" },

            //    // EntityId 71–75 (Valencia)
            //    new AttractionTranslation { id = 141, EntityId = 71, Lang = "en", Title = "City of Arts and Sciences", Description = "Modern architectural complex" },
            //    new AttractionTranslation { id = 142, EntityId = 71, Lang = "ru", Title = "Город искусств и наук", Description = "Современный архитектурный комплекс" },
            //    new AttractionTranslation { id = 143, EntityId = 72, Lang = "en", Title = "Valencia Cathedral", Description = "Historic cathedral" },
            //    new AttractionTranslation { id = 144, EntityId = 72, Lang = "ru", Title = "Собор Валенсии", Description = "Исторический собор" },
            //    new AttractionTranslation { id = 145, EntityId = 73, Lang = "en", Title = "Central Market", Description = "Historic market hall" },
            //    new AttractionTranslation { id = 146, EntityId = 73, Lang = "ru", Title = "Центральный рынок", Description = "Исторический рынок" },
            //    new AttractionTranslation { id = 147, EntityId = 74, Lang = "en", Title = "Turia Gardens", Description = "Public gardens in former riverbed" },
            //    new AttractionTranslation { id = 148, EntityId = 74, Lang = "ru", Title = "Сады Турия", Description = "Общественные сады на месте бывшего русла реки" },
            //    new AttractionTranslation { id = 149, EntityId = 75, Lang = "en", Title = "Silk Exchange", Description = "Historic building" },
            //    new AttractionTranslation { id = 150, EntityId = 75, Lang = "ru", Title = "Биржа шелка", Description = "Историческое здание" },

            //    // EntityId 76–80 (Warsaw)
            //    new AttractionTranslation { id = 151, EntityId = 76, Lang = "en", Title = "Old Town Warsaw", Description = "Historic city center" },
            //    new AttractionTranslation { id = 152, EntityId = 76, Lang = "ru", Title = "Старый город Варшавы", Description = "Исторический центр города" },
            //    new AttractionTranslation { id = 153, EntityId = 77, Lang = "en", Title = "Royal Castle", Description = "Historic royal residence" },
            //    new AttractionTranslation { id = 154, EntityId = 77, Lang = "ru", Title = "Королевский замок", Description = "Историческая королевская резиденция" },
            //    new AttractionTranslation { id = 155, EntityId = 78, Lang = "en", Title = "Palace of Culture and Science", Description = "Tall historic building" },
            //    new AttractionTranslation { id = 156, EntityId = 78, Lang = "ru", Title = "Дворец культуры и науки", Description = "Высокое историческое здание" },
            //    new AttractionTranslation { id = 157, EntityId = 79, Lang = "en", Title = "Łazienki Park", Description = "Large city park" },
            //    new AttractionTranslation { id = 158, EntityId = 79, Lang = "ru", Title = "Лазенки", Description = "Большой городской парк" },
            //    new AttractionTranslation { id = 159, EntityId = 80, Lang = "en", Title = "Warsaw Uprising Museum", Description = "Museum dedicated to WWII uprising" },
            //    new AttractionTranslation { id = 160, EntityId = 80, Lang = "ru", Title = "Музей Варшавского восстания", Description = "Музей, посвященный восстанию во Второй мировой" },

            //    // EntityId 81–85 (Krakow)
            //    new AttractionTranslation { id = 161, EntityId = 81, Lang = "en", Title = "Wawel Castle", Description = "Historic royal castle" },
            //    new AttractionTranslation { id = 162, EntityId = 81, Lang = "ru", Title = "Вавельский замок", Description = "Исторический королевский замок" },
            //    new AttractionTranslation { id = 163, EntityId = 82, Lang = "en", Title = "Main Market Square", Description = "Central city square" },
            //    new AttractionTranslation { id = 164, EntityId = 82, Lang = "ru", Title = "Главная рыночная площадь", Description = "Центральная площадь города" },
            //    new AttractionTranslation { id = 165, EntityId = 83, Lang = "en", Title = "St. Mary's Basilica", Description = "Famous historic church" },
            //    new AttractionTranslation { id = 166, EntityId = 83, Lang = "ru", Title = "Базилика Святой Марии", Description = "Знаменитая историческая церковь" },
            //    new AttractionTranslation { id = 167, EntityId = 84, Lang = "en", Title = "Kazimierz District", Description = "Historic Jewish quarter" },
            //    new AttractionTranslation { id = 168, EntityId = 84, Lang = "ru", Title = "Казимеж", Description = "Исторический еврейский квартал" },
            //    new AttractionTranslation { id = 169, EntityId = 85, Lang = "en", Title = "Schindler's Factory", Description = "Museum in former factory" },
            //    new AttractionTranslation { id = 170, EntityId = 85, Lang = "ru", Title = "Фабрика Шиндлера", Description = "Музей в бывшей фабрике" },

            //    // EntityId 86–90 (Gdansk)
            //    new AttractionTranslation { id = 171, EntityId = 86, Lang = "en", Title = "Old Town Gdansk", Description = "Historic city center" },
            //    new AttractionTranslation { id = 172, EntityId = 86, Lang = "ru", Title = "Старый город Гданьска", Description = "Исторический центр города" },
            //    new AttractionTranslation { id = 173, EntityId = 87, Lang = "en", Title = "St. Mary's Church", Description = "Large historic church" },
            //    new AttractionTranslation { id = 174, EntityId = 87, Lang = "ru", Title = "Базилика Святой Марии", Description = "Большая историческая церковь" },
            //    new AttractionTranslation { id = 175, EntityId = 88, Lang = "en", Title = "Neptune Fountain", Description = "Famous city fountain" },
            //    new AttractionTranslation { id = 176, EntityId = 88, Lang = "ru", Title = "Фонтан Нептуна", Description = "Знаменитый городской фонтан" },
            //    new AttractionTranslation { id = 177, EntityId = 89, Lang = "en", Title = "Long Market", Description = "Historic market street" },
            //    new AttractionTranslation { id = 178, EntityId = 89, Lang = "ru", Title = "Длинный рынок", Description = "Историческая торговая улица" },
            //    new AttractionTranslation { id = 179, EntityId = 90, Lang = "en", Title = "European Solidarity Centre", Description = "Museum and cultural center" },
            //    new AttractionTranslation { id = 180, EntityId = 90, Lang = "ru", Title = "Центр европейской солидарности", Description = "Музей и культурный центр" },

            //    // EntityId 91–95
            //    new AttractionTranslation { id = 181, EntityId = 91, Lang = "en", Title = "Old Market Square", Description = "Central square of Poznan" },
            //    new AttractionTranslation { id = 182, EntityId = 91, Lang = "ru", Title = "Старая рыночная площадь", Description = "Центральная площадь Познани" },
            //    new AttractionTranslation { id = 183, EntityId = 92, Lang = "en", Title = "Poznan Town Hall", Description = "Historic town hall" },
            //    new AttractionTranslation { id = 184, EntityId = 92, Lang = "ru", Title = "Ратуша Познани", Description = "Историческая ратуша" },
            //    new AttractionTranslation { id = 185, EntityId = 93, Lang = "en", Title = "St. Peter and Paul Cathedral", Description = "Historic cathedral" },
            //    new AttractionTranslation { id = 186, EntityId = 93, Lang = "ru", Title = "Кафедральный собор Святых Петра и Павла", Description = "Исторический собор" },
            //    new AttractionTranslation { id = 187, EntityId = 94, Lang = "en", Title = "Imperial Castle", Description = "Historic castle" },
            //    new AttractionTranslation { id = 188, EntityId = 94, Lang = "ru", Title = "Императорский замок", Description = "Исторический замок" },
            //    new AttractionTranslation { id = 189, EntityId = 95, Lang = "en", Title = "Citadel Park", Description = "Public park with monuments" },
            //    new AttractionTranslation { id = 190, EntityId = 95, Lang = "ru", Title = "Парк Цитадель", Description = "Общественный парк с памятниками" }

             );


            // Сиды категорий с переводами
            modelBuilder.Entity<ParamsCategoryTranslation>().HasData(
                new ParamsCategoryTranslation { id = 1, EntityId = 1, Lang = "en", Title = "Type of accommodation" },
                new ParamsCategoryTranslation { id = 2, EntityId = 1, Lang = "uk", Title = "Тип розміщення" },

                new ParamsCategoryTranslation { id = 3, EntityId = 2, Lang = "en", Title = "Prices" },
                new ParamsCategoryTranslation { id = 4, EntityId = 2, Lang = "uk", Title = "Ціни" },

                new ParamsCategoryTranslation { id = 5, EntityId = 3, Lang = "en", Title = "Amenities" },
                new ParamsCategoryTranslation { id = 6, EntityId = 3, Lang = "uk", Title = "Зручності" },

                new ParamsCategoryTranslation { id = 7, EntityId = 4, Lang = "en", Title = "Housing with" },
                new ParamsCategoryTranslation { id = 8, EntityId = 4, Lang = "uk", Title = "Житло з" },

                new ParamsCategoryTranslation { id = 9, EntityId = 5, Lang = "en", Title = "Object evaluation" },
                new ParamsCategoryTranslation { id = 10, EntityId = 5, Lang = "uk", Title = "Оцінка об'єкту" },

                new ParamsCategoryTranslation { id = 11, EntityId = 6, Lang = "en", Title = "Distance from the center" },
                new ParamsCategoryTranslation { id = 12, EntityId = 6, Lang = "uk", Title = "Відстань від центра" },

                new ParamsCategoryTranslation { id = 13, EntityId = 7, Lang = "en", Title = "Booking rules" },
                new ParamsCategoryTranslation { id = 14, EntityId = 7, Lang = "uk", Title = "Правила бронювання" },

                new ParamsCategoryTranslation { id = 15, EntityId = 8, Lang = "en", Title = "Area" },
                new ParamsCategoryTranslation { id = 16, EntityId = 8, Lang = "uk", Title = "Район" },

                new ParamsCategoryTranslation { id = 17, EntityId = 9, Lang = "en", Title = "Amenities and Services" },
                new ParamsCategoryTranslation { id = 18, EntityId = 9, Lang = "uk", Title = "Зручності та послуги" },

                new ParamsCategoryTranslation { id = 19, EntityId = 10, Lang = "en", Title = "View" },
                new ParamsCategoryTranslation { id = 20, EntityId = 10, Lang = "uk", Title = "Вид на" },

                new ParamsCategoryTranslation { id = 21, EntityId = 11, Lang = "en", Title = "Private Bathroom" },
                new ParamsCategoryTranslation { id = 22, EntityId = 11, Lang = "uk", Title = "Власна ванна кімната" }

            );


            // Сиды параметров с переводами
            modelBuilder.Entity<ParamItemTranslation>().HasData(
               // Тип розміщення / Type of accommodation
                new ParamItemTranslation { id = 1, EntityId = 1, Lang = "en", Title = "Hotel" },
                new ParamItemTranslation { id = 2, EntityId = 1, Lang = "uk", Title = "Готель" },

                new ParamItemTranslation { id = 3, EntityId = 2, Lang = "en", Title = "Hostel" },
                new ParamItemTranslation { id = 4, EntityId = 2, Lang = "uk", Title = "Хостел" },

                new ParamItemTranslation { id = 5, EntityId = 3, Lang = "en", Title = "Studio" },
                new ParamItemTranslation { id = 6, EntityId = 3, Lang = "uk", Title = "Студія" },

                new ParamItemTranslation { id = 7, EntityId = 4, Lang = "en", Title = "Apartment / Flat" },
                new ParamItemTranslation { id = 8, EntityId = 4, Lang = "uk", Title = "Апартаменти / Квартира" },

                new ParamItemTranslation { id = 9, EntityId = 5, Lang = "en", Title = "Private house" },
                new ParamItemTranslation { id = 10, EntityId = 5, Lang = "uk", Title = "Приватний будинок" },

                new ParamItemTranslation { id = 11, EntityId = 6, Lang = "en", Title = "Room" },
                new ParamItemTranslation { id = 12, EntityId = 6, Lang = "uk", Title = "Кімната" },


                    // Зручності / Amenities
                new ParamItemTranslation { id = 15, EntityId = 8, Lang = "en", Title = "Wi-Fi" },
                new ParamItemTranslation { id = 16, EntityId = 8, Lang = "uk", Title = "Wi-Fi" },

                new ParamItemTranslation { id = 17, EntityId = 9, Lang = "en", Title = "Air conditioning" },
                new ParamItemTranslation { id = 18, EntityId = 9, Lang = "uk", Title = "Кондиціонер" },

                new ParamItemTranslation { id = 19, EntityId = 10, Lang = "en", Title = "TV" },
                new ParamItemTranslation { id = 20, EntityId = 10, Lang = "uk", Title = "Телевізор" },

                new ParamItemTranslation { id = 21, EntityId = 11, Lang = "en", Title = "Work desk" },
                new ParamItemTranslation { id = 22, EntityId = 11, Lang = "uk", Title = "Робочий стіл" },

                new ParamItemTranslation { id = 23, EntityId = 12, Lang = "en", Title = "Pets allowed" },
                new ParamItemTranslation { id = 24, EntityId = 12, Lang = "uk", Title = "Можна з тваринами" },

                new ParamItemTranslation { id = 25, EntityId = 13, Lang = "en", Title = "Free parking" },
                new ParamItemTranslation { id = 26, EntityId = 13, Lang = "uk", Title = "Безкоштовна парковка" },

                new ParamItemTranslation { id = 27, EntityId = 14, Lang = "en", Title = "Washing machine" },
                new ParamItemTranslation { id = 28, EntityId = 14, Lang = "uk", Title = "Пральна машина" },

                new ParamItemTranslation { id = 29, EntityId = 15, Lang = "en", Title = "Iron" },
                new ParamItemTranslation { id = 30, EntityId = 15, Lang = "uk", Title = "Праска" },

                new ParamItemTranslation { id = 31, EntityId = 16, Lang = "en", Title = "Electric kettle" },
                new ParamItemTranslation { id = 32, EntityId = 16, Lang = "uk", Title = "Електричний чайник" },


              //Житло з/Housing with
                new ParamItemTranslation { id = 33, EntityId = 17, Lang = "en", Title = "Balcony" },
                new ParamItemTranslation { id = 34, EntityId = 17, Lang = "uk", Title = "Балкон" },

                new ParamItemTranslation { id = 35, EntityId = 18, Lang = "en", Title = "Terrace" },
                new ParamItemTranslation { id = 36, EntityId = 18, Lang = "uk", Title = "Тераса" },

                new ParamItemTranslation { id = 37, EntityId = 19, Lang = "en", Title = "Kitchen" },
                new ParamItemTranslation { id = 38, EntityId = 19, Lang = "uk", Title = "Кухня" },

                new ParamItemTranslation { id = 39, EntityId = 20, Lang = "en", Title = "Single bed" },
                new ParamItemTranslation { id = 40, EntityId = 20, Lang = "uk", Title = "Односпальне" },

                new ParamItemTranslation { id = 41, EntityId = 21, Lang = "en", Title = "Double bed" },
                new ParamItemTranslation { id = 42, EntityId = 21, Lang = "uk", Title = "Двоспальне" },



                // "Оцінка об'єкту / Object evaluation

                new ParamItemTranslation { id = 43, EntityId = 22, Lang = "en", Title = "Pretty good 5+" },
                new ParamItemTranslation { id = 44, EntityId = 22, Lang = "uk", Title = "Досить чудово 5+" },

                new ParamItemTranslation { id = 45, EntityId = 23, Lang = "en", Title = "Good 7+" },
                new ParamItemTranslation { id = 46, EntityId = 23, Lang = "uk", Title = "Добре 7+" },

                new ParamItemTranslation { id = 47, EntityId = 24, Lang = "en", Title = "Excellent 9+" },
                new ParamItemTranslation { id = 48, EntityId = 24, Lang = "uk", Title = "Чудово 9+" },

                new ParamItemTranslation { id = 49, EntityId = 25, Lang = "en", Title = "Very good 8+" },
                new ParamItemTranslation { id = 50, EntityId = 25, Lang = "uk", Title = "Дуже добре 8+" },


                // Відстань від центра / Distance from center

                new ParamItemTranslation { id = 51, EntityId = 26, Lang = "en", Title = "Less than 1 km" },
                new ParamItemTranslation { id = 52, EntityId = 26, Lang = "uk", Title = "Менше 1 км" },

                new ParamItemTranslation { id = 53, EntityId = 27, Lang = "en", Title = "Less than 3 km" },
                new ParamItemTranslation { id = 54, EntityId = 27, Lang = "uk", Title = "Менше 3 км" },

                new ParamItemTranslation { id = 55, EntityId = 28, Lang = "en", Title = "Less than 5 km" },
                new ParamItemTranslation { id = 56, EntityId = 28, Lang = "uk", Title = "Менше 5 км" },


                //Правила бронювання / Booking rules

                new ParamItemTranslation { id = 57, EntityId = 29, Lang = "en", Title = "Free cancellation" },
                new ParamItemTranslation { id = 58, EntityId = 29, Lang = "uk", Title = "Безкоштовне скасування" },

                new ParamItemTranslation { id = 59, EntityId = 30, Lang = "en", Title = "Pay now" },
                new ParamItemTranslation { id = 60, EntityId = 30, Lang = "uk", Title = "Оплата зараз" },

                new ParamItemTranslation { id = 61, EntityId = 31, Lang = "en", Title = "Pay at the property before arrival" },
                new ParamItemTranslation { id = 62, EntityId = 31, Lang = "uk", Title = "Оплата помешканню перед приїздом" },

                new ParamItemTranslation { id = 63, EntityId = 32, Lang = "en", Title = "Pay on site" },
                new ParamItemTranslation { id = 64, EntityId = 32, Lang = "uk", Title = "Оплата на місці" },


                //Район / Area

                // Ціни / Prices
                new ParamItemTranslation { id = 65, EntityId = 33, Lang = "en", Title = "From" },
                new ParamItemTranslation { id = 66, EntityId = 33, Lang = "uk", Title = "Від" },

                new ParamItemTranslation { id = 67, EntityId = 34, Lang = "en", Title = "To" },
                new ParamItemTranslation { id = 68, EntityId = 34, Lang = "uk", Title = "До" },


               // зручності та послуги

                new ParamItemTranslation { id = 69, EntityId = 35, Lang = "en", Title = "Wooden or parquet floor" },
                new ParamItemTranslation { id = 70, EntityId = 35, Lang = "uk", Title = "Дерев'яна або паркетна підлога" },

                new ParamItemTranslation { id = 71, EntityId = 36, Lang = "en", Title = "Bed linen" },
                new ParamItemTranslation { id = 72, EntityId = 36, Lang = "uk", Title = "Білизна" },

                new ParamItemTranslation { id = 73, EntityId = 37, Lang = "en", Title = "Socket near the bed" },
                new ParamItemTranslation { id = 74, EntityId = 37, Lang = "uk", Title = "Розетка біля ліжка" },

                new ParamItemTranslation { id = 75, EntityId = 38, Lang = "en", Title = "Desk" },
                new ParamItemTranslation { id = 76, EntityId = 38, Lang = "uk", Title = "Робочий стіл" },

                new ParamItemTranslation { id = 77, EntityId = 39, Lang = "en", Title = "Television" },
                new ParamItemTranslation { id = 78, EntityId = 39, Lang = "uk", Title = "Телевізор" },

                new ParamItemTranslation { id = 79, EntityId = 40, Lang = "en", Title = "Ironing equipment" },
                new ParamItemTranslation { id = 80, EntityId = 40, Lang = "uk", Title = "Праcувальне приладдя" },

                new ParamItemTranslation { id = 81, EntityId = 41, Lang = "en", Title = "Coffee maker / kettle" },
                new ParamItemTranslation { id = 82, EntityId = 41, Lang = "uk", Title = "Кавоварка/чайник" },

                new ParamItemTranslation { id = 83, EntityId = 42, Lang = "en", Title = "Iron" },
                new ParamItemTranslation { id = 84, EntityId = 42, Lang = "uk", Title = "Праска" },

                new ParamItemTranslation { id = 85, EntityId = 43, Lang = "en", Title = "Heating" },
                new ParamItemTranslation { id = 86, EntityId = 43, Lang = "uk", Title = "Опалення" },

                new ParamItemTranslation { id = 87, EntityId = 44, Lang = "en", Title = "Television with flat screen" },
                new ParamItemTranslation { id = 88, EntityId = 44, Lang = "uk", Title = "Телевізор із плоским екраном" },

                new ParamItemTranslation { id = 89, EntityId = 45, Lang = "en", Title = "Electric kettle" },
                new ParamItemTranslation { id = 90, EntityId = 45, Lang = "uk", Title = "Електричний чайник" },

                new ParamItemTranslation { id = 91, EntityId = 46, Lang = "en", Title = "Cable channels" },
                new ParamItemTranslation { id = 92, EntityId = 46, Lang = "uk", Title = "Кабельні канали" },

                new ParamItemTranslation { id = 93, EntityId = 47, Lang = "en", Title = "Wardrobe or closet" },
                new ParamItemTranslation { id = 94, EntityId = 47, Lang = "uk", Title = "Шафа або гардероб" },

                new ParamItemTranslation { id = 95, EntityId = 48, Lang = "en", Title = "Stairs for access to upper floors" },
                new ParamItemTranslation { id = 96, EntityId = 48, Lang = "uk", Title = "Сходи для доступу до верхніх поверхів" },

                new ParamItemTranslation { id = 97, EntityId = 49, Lang = "en", Title = "Clothes hanger" },
                new ParamItemTranslation { id = 98, EntityId = 49, Lang = "uk", Title = "Вішалка для одягу" },

                // вид на
                new ParamItemTranslation { id = 99, EntityId = 50, Lang = "en", Title = "View of landmarks" },
                new ParamItemTranslation { id = 100, EntityId = 50, Lang = "uk", Title = "Вид на визначні пам'ятки" },

                new ParamItemTranslation { id = 101, EntityId = 51, Lang = "en", Title = "City view" },
                new ParamItemTranslation { id = 102, EntityId = 51, Lang = "uk", Title = "Вид на місто" },

               // власна ванна кімната
                new ParamItemTranslation { id = 103, EntityId = 52, Lang = "en", Title = "Toilet" },
                new ParamItemTranslation { id = 104, EntityId = 52, Lang = "uk", Title = "Туалет" },

                new ParamItemTranslation { id = 105, EntityId = 53, Lang = "en", Title = "Bathtub or shower" },
                new ParamItemTranslation { id = 106, EntityId = 53, Lang = "uk", Title = "Ванна чи душ" },

                new ParamItemTranslation { id = 107, EntityId = 54, Lang = "en", Title = "Towels" },
                new ParamItemTranslation { id = 108, EntityId = 54, Lang = "uk", Title = "Рушники" },

                new ParamItemTranslation { id = 109, EntityId = 55, Lang = "en", Title = "Hairdryer" },
                new ParamItemTranslation { id = 110, EntityId = 55, Lang = "uk", Title = "Фен" },

                new ParamItemTranslation { id = 111, EntityId = 56, Lang = "en", Title = "Toilet paper" },
                new ParamItemTranslation { id = 112, EntityId = 56, Lang = "uk", Title = "Папір туалетний" }

            );


        }
    }
}
