using Microsoft.EntityFrameworkCore;
using TranslationApiService.Models;
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
                 // United States
                 new CountryTranslation { id = 1, EntityId = 1, Lang = "en", Title = "United States" },
                 new CountryTranslation { id = 2, EntityId = 1, Lang = "ru", Title = "США" },
                 new CountryTranslation { id = 3, EntityId = 1, Lang = "uk", Title = "США" },

                 // Germany
                 new CountryTranslation { id = 4, EntityId = 2, Lang = "en", Title = "Germany" },
                 new CountryTranslation { id = 5, EntityId = 2, Lang = "ru", Title = "Германия" },
                 new CountryTranslation { id = 6, EntityId = 2, Lang = "uk", Title = "Німеччина" },

                 // France
                 new CountryTranslation { id = 7, EntityId = 3, Lang = "en", Title = "France" },
                 new CountryTranslation { id = 8, EntityId = 3, Lang = "ru", Title = "Франция" },
                 new CountryTranslation { id = 9, EntityId = 3, Lang = "uk", Title = "Франція" },

                 // United Kingdom
                 new CountryTranslation { id = 10, EntityId = 4, Lang = "en", Title = "United Kingdom" },
                 new CountryTranslation { id = 11, EntityId = 4, Lang = "ru", Title = "Великобритания" },
                 new CountryTranslation { id = 12, EntityId = 4, Lang = "uk", Title = "Велика Британія" },

                 // Spain
                 new CountryTranslation { id = 13, EntityId = 5, Lang = "en", Title = "Spain" },
                 new CountryTranslation { id = 14, EntityId = 5, Lang = "ru", Title = "Испания" },
                 new CountryTranslation { id = 15, EntityId = 5, Lang = "uk", Title = "Іспанія" },

                 // Poland
                 new CountryTranslation { id = 16, EntityId = 6, Lang = "en", Title = "Poland" },
                 new CountryTranslation { id = 17, EntityId = 6, Lang = "ru", Title = "Польша" },
                 new CountryTranslation { id = 18, EntityId = 6, Lang = "uk", Title = "Польща" }
             );


            modelBuilder.Entity<RegionTranslation>().HasData(
                // USA
                new RegionTranslation { id = 1, EntityId = 1, Lang = "en", Title = "New York State" },
                new RegionTranslation { id = 2, EntityId = 1, Lang = "ru", Title = "Штат Нью-Йорк" },
                new RegionTranslation { id = 3, EntityId = 1, Lang = "uk", Title = "Штат Нью-Йорк" },

                new RegionTranslation { id = 4, EntityId = 2, Lang = "en", Title = "California" },
                new RegionTranslation { id = 5, EntityId = 2, Lang = "ru", Title = "Калифорния" },
                new RegionTranslation { id = 6, EntityId = 2, Lang = "uk", Title = "Каліфорнія" },

                new RegionTranslation { id = 7, EntityId = 3, Lang = "en", Title = "Illinois" },
                new RegionTranslation { id = 8, EntityId = 3, Lang = "ru", Title = "Иллинойс" },
                new RegionTranslation { id = 9, EntityId = 3, Lang = "uk", Title = "Іллінойс" },

                // Germany
                new RegionTranslation { id = 10, EntityId = 4, Lang = "en", Title = "Berlin Region" },
                new RegionTranslation { id = 11, EntityId = 4, Lang = "ru", Title = "Регион Берлин" },
                new RegionTranslation { id = 12, EntityId = 4, Lang = "uk", Title = "Регіон Берлін" },

                new RegionTranslation { id = 13, EntityId = 5, Lang = "en", Title = "Bavaria" },
                new RegionTranslation { id = 14, EntityId = 5, Lang = "ru", Title = "Бавария" },
                new RegionTranslation { id = 15, EntityId = 5, Lang = "uk", Title = "Баварія" },

                new RegionTranslation { id = 16, EntityId = 6, Lang = "en", Title = "Hamburg Region" },
                new RegionTranslation { id = 17, EntityId = 6, Lang = "ru", Title = "Регион Гамбург" },
                new RegionTranslation { id = 18, EntityId = 6, Lang = "uk", Title = "Регіон Гамбург" },

                // France
                new RegionTranslation { id = 19, EntityId = 7, Lang = "en", Title = "Île-de-France" },
                new RegionTranslation { id = 20, EntityId = 7, Lang = "ru", Title = "Иль-де-Франс" },
                new RegionTranslation { id = 21, EntityId = 7, Lang = "uk", Title = "Іль-де-Франс" },

                new RegionTranslation { id = 22, EntityId = 8, Lang = "en", Title = "Auvergne-Rhône-Alpes" },
                new RegionTranslation { id = 23, EntityId = 8, Lang = "ru", Title = "Овернь-Рона-Альпы" },
                new RegionTranslation { id = 24, EntityId = 8, Lang = "uk", Title = "Овернь-Рона-Альпи" },

                new RegionTranslation { id = 25, EntityId = 9, Lang = "en", Title = "Provence-Alpes-Côte d’Azur" },
                new RegionTranslation { id = 26, EntityId = 9, Lang = "ru", Title = "Прованс-Альпы-Лазурный берег" },
                new RegionTranslation { id = 27, EntityId = 9, Lang = "uk", Title = "Прованс-Альпи-Лазурний берег" },

                // UK
                new RegionTranslation { id = 28, EntityId = 10, Lang = "en", Title = "Greater London" },
                new RegionTranslation { id = 29, EntityId = 10, Lang = "ru", Title = "Большой Лондон" },
                new RegionTranslation { id = 30, EntityId = 10, Lang = "uk", Title = "Великий Лондон" },

                new RegionTranslation { id = 31, EntityId = 11, Lang = "en", Title = "Greater Manchester" },
                new RegionTranslation { id = 32, EntityId = 11, Lang = "ru", Title = "Большой Манчестер" },
                new RegionTranslation { id = 33, EntityId = 11, Lang = "uk", Title = "Великий Манчестер" },

                new RegionTranslation { id = 34, EntityId = 12, Lang = "en", Title = "West Midlands" },
                new RegionTranslation { id = 35, EntityId = 12, Lang = "ru", Title = "Уэст-Мидлендс" },
                new RegionTranslation { id = 36, EntityId = 12, Lang = "uk", Title = "Вест-Мідлендс" },

                // Spain
                new RegionTranslation { id = 37, EntityId = 13, Lang = "en", Title = "Community of Madrid" },
                new RegionTranslation { id = 38, EntityId = 13, Lang = "ru", Title = "Сообщество Мадрид" },
                new RegionTranslation { id = 39, EntityId = 13, Lang = "uk", Title = "Спільнота Мадрид" },

                new RegionTranslation { id = 40, EntityId = 14, Lang = "en", Title = "Catalonia" },
                new RegionTranslation { id = 41, EntityId = 14, Lang = "ru", Title = "Каталония" },
                new RegionTranslation { id = 42, EntityId = 14, Lang = "uk", Title = "Каталонія" },

                new RegionTranslation { id = 43, EntityId = 15, Lang = "en", Title = "Valencian Community" },
                new RegionTranslation { id = 44, EntityId = 15, Lang = "ru", Title = "Валенсийское сообщество" },
                new RegionTranslation { id = 45, EntityId = 15, Lang = "uk", Title = "Валенсійська спільнота" },

                // Poland
                new RegionTranslation { id = 46, EntityId = 16, Lang = "en", Title = "Masovian" },
                new RegionTranslation { id = 47, EntityId = 16, Lang = "ru", Title = "Мазовецкое" },
                new RegionTranslation { id = 48, EntityId = 16, Lang = "uk", Title = "Мазовецьке" },

                new RegionTranslation { id = 49, EntityId = 17, Lang = "en", Title = "Lesser Poland" },
                new RegionTranslation { id = 50, EntityId = 17, Lang = "ru", Title = "Малопольское" },
                new RegionTranslation { id = 51, EntityId = 17, Lang = "uk", Title = "Малопольське" },

                new RegionTranslation { id = 52, EntityId = 18, Lang = "en", Title = "Greater Poland" },
                new RegionTranslation { id = 53, EntityId = 18, Lang = "ru", Title = "Великопольское" },
                new RegionTranslation { id = 54, EntityId = 18, Lang = "uk", Title = "Великопольське" }
            );

            modelBuilder.Entity<CityTranslation>().HasData(
                // USA
                new CityTranslation { id = 1, EntityId = 1, Lang = "en", Title = "New York" },
                new CityTranslation { id = 2, EntityId = 1, Lang = "ru", Title = "Нью-Йорк" },
                new CityTranslation { id = 3, EntityId = 1, Lang = "uk", Title = "Нью-Йорк" },

                new CityTranslation { id = 4, EntityId = 2, Lang = "en", Title = "Los Angeles" },
                new CityTranslation { id = 5, EntityId = 2, Lang = "ru", Title = "Лос-Анджелес" },
                new CityTranslation { id = 6, EntityId = 2, Lang = "uk", Title = "Лос-Анджелес" },

                new CityTranslation { id = 7, EntityId = 3, Lang = "en", Title = "Chicago" },
                new CityTranslation { id = 8, EntityId = 3, Lang = "ru", Title = "Чикаго" },
                new CityTranslation { id = 9, EntityId = 3, Lang = "uk", Title = "Чикаго" },

                // Germany
                new CityTranslation { id = 10, EntityId = 4, Lang = "en", Title = "Berlin" },
                new CityTranslation { id = 11, EntityId = 4, Lang = "ru", Title = "Берлин" },
                new CityTranslation { id = 12, EntityId = 4, Lang = "uk", Title = "Берлін" },

                new CityTranslation { id = 13, EntityId = 5, Lang = "en", Title = "Munich" },
                new CityTranslation { id = 14, EntityId = 5, Lang = "ru", Title = "Мюнхен" },
                new CityTranslation { id = 15, EntityId = 5, Lang = "uk", Title = "Мюнхен" },

                new CityTranslation { id = 16, EntityId = 6, Lang = "en", Title = "Hamburg" },
                new CityTranslation { id = 17, EntityId = 6, Lang = "ru", Title = "Гамбург" },
                new CityTranslation { id = 18, EntityId = 6, Lang = "uk", Title = "Гамбург" },

                // France
                new CityTranslation { id = 19, EntityId = 7, Lang = "en", Title = "Paris" },
                new CityTranslation { id = 20, EntityId = 7, Lang = "ru", Title = "Париж" },
                new CityTranslation { id = 21, EntityId = 7, Lang = "uk", Title = "Париж" },

                new CityTranslation { id = 22, EntityId = 8, Lang = "en", Title = "Lyon" },
                new CityTranslation { id = 23, EntityId = 8, Lang = "ru", Title = "Лион" },
                new CityTranslation { id = 24, EntityId = 8, Lang = "uk", Title = "Ліон" },

                new CityTranslation { id = 25, EntityId = 9, Lang = "en", Title = "Marseille" },
                new CityTranslation { id = 26, EntityId = 9, Lang = "ru", Title = "Марсель" },
                new CityTranslation { id = 27, EntityId = 9, Lang = "uk", Title = "Марсель" },

                // UK
                new CityTranslation { id = 28, EntityId = 10, Lang = "en", Title = "London" },
                new CityTranslation { id = 29, EntityId = 10, Lang = "ru", Title = "Лондон" },
                new CityTranslation { id = 30, EntityId = 10, Lang = "uk", Title = "Лондон" },

                new CityTranslation { id = 31, EntityId = 11, Lang = "en", Title = "Manchester" },
                new CityTranslation { id = 32, EntityId = 11, Lang = "ru", Title = "Манчестер" },
                new CityTranslation { id = 33, EntityId = 11, Lang = "uk", Title = "Манчестер" },

                new CityTranslation { id = 34, EntityId = 12, Lang = "en", Title = "Birmingham" },
                new CityTranslation { id = 35, EntityId = 12, Lang = "ru", Title = "Бирмингем" },
                new CityTranslation { id = 36, EntityId = 12, Lang = "uk", Title = "Бірмінгем" },

                // Spain
                new CityTranslation { id = 37, EntityId = 13, Lang = "en", Title = "Madrid" },
                new CityTranslation { id = 38, EntityId = 13, Lang = "ru", Title = "Мадрид" },
                new CityTranslation { id = 39, EntityId = 13, Lang = "uk", Title = "Мадрид" },

                new CityTranslation { id = 40, EntityId = 14, Lang = "en", Title = "Barcelona" },
                new CityTranslation { id = 41, EntityId = 14, Lang = "ru", Title = "Барселона" },
                new CityTranslation { id = 42, EntityId = 14, Lang = "uk", Title = "Барселона" },

                new CityTranslation { id = 43, EntityId = 15, Lang = "en", Title = "Valencia" },
                new CityTranslation { id = 44, EntityId = 15, Lang = "ru", Title = "Валенсия" },
                new CityTranslation { id = 45, EntityId = 15, Lang = "uk", Title = "Валенсія" },

                // Poland
                new CityTranslation { id = 46, EntityId = 16, Lang = "en", Title = "Warsaw" },
                new CityTranslation { id = 47, EntityId = 16, Lang = "ru", Title = "Варшава" },
                new CityTranslation { id = 48, EntityId = 16, Lang = "uk", Title = "Варшава" },

                new CityTranslation { id = 49, EntityId = 17, Lang = "en", Title = "Krakow" },
                new CityTranslation { id = 50, EntityId = 17, Lang = "ru", Title = "Краков" },
                new CityTranslation { id = 51, EntityId = 17, Lang = "uk", Title = "Краків" },

                new CityTranslation { id = 52, EntityId = 18, Lang = "en", Title = "Poznan" },
                new CityTranslation { id = 53, EntityId = 18, Lang = "ru", Title = "Познань" },
                new CityTranslation { id = 54, EntityId = 18, Lang = "uk", Title = "Познань" }
            );


            modelBuilder.Entity<DistrictTranslation>().HasData(
                 // --- New York ---
                 new DistrictTranslation { id = 1, EntityId = 1, Lang = "en", Title = "Manhattan" },
                 new DistrictTranslation { id = 2, EntityId = 1, Lang = "ru", Title = "Манхэттен" },
                 new DistrictTranslation { id = 3, EntityId = 1, Lang = "uk", Title = "Манхеттен" },

                 new DistrictTranslation { id = 4, EntityId = 2, Lang = "en", Title = "Brooklyn" },
                 new DistrictTranslation { id = 5, EntityId = 2, Lang = "ru", Title = "Бруклин" },
                 new DistrictTranslation { id = 6, EntityId = 2, Lang = "uk", Title = "Бруклін" },

                 new DistrictTranslation { id = 7, EntityId = 3, Lang = "en", Title = "Queens" },
                 new DistrictTranslation { id = 8, EntityId = 3, Lang = "ru", Title = "Куинс" },
                 new DistrictTranslation { id = 9, EntityId = 3, Lang = "uk", Title = "Квінс" },

                 // --- Los Angeles ---
                 new DistrictTranslation { id = 10, EntityId = 4, Lang = "en", Title = "Hollywood" },
                 new DistrictTranslation { id = 11, EntityId = 4, Lang = "ru", Title = "Голливуд" },
                 new DistrictTranslation { id = 12, EntityId = 4, Lang = "uk", Title = "Голлівуд" },

                 new DistrictTranslation { id = 13, EntityId = 5, Lang = "en", Title = "Downtown" },
                 new DistrictTranslation { id = 14, EntityId = 5, Lang = "ru", Title = "Даунтаун" },
                 new DistrictTranslation { id = 15, EntityId = 5, Lang = "uk", Title = "Довнтаун" },

                 new DistrictTranslation { id = 16, EntityId = 6, Lang = "en", Title = "Beverly Hills" },
                 new DistrictTranslation { id = 17, EntityId = 6, Lang = "ru", Title = "Беверли-Хиллз" },
                 new DistrictTranslation { id = 18, EntityId = 6, Lang = "uk", Title = "Беверлі-Хіллз" },

                 // --- Chicago ---
                 new DistrictTranslation { id = 19, EntityId = 7, Lang = "en", Title = "The Loop" },
                 new DistrictTranslation { id = 20, EntityId = 7, Lang = "ru", Title = "Деловой район" },
                 new DistrictTranslation { id = 21, EntityId = 7, Lang = "uk", Title = "Діловий район" },

                 new DistrictTranslation { id = 22, EntityId = 8, Lang = "en", Title = "Lincoln Park" },
                 new DistrictTranslation { id = 23, EntityId = 8, Lang = "ru", Title = "Линкольн-Парк" },
                 new DistrictTranslation { id = 24, EntityId = 8, Lang = "uk", Title = "Лінкольн-Парк" },

                 new DistrictTranslation { id = 25, EntityId = 9, Lang = "en", Title = "Hyde Park" },
                 new DistrictTranslation { id = 26, EntityId = 9, Lang = "ru", Title = "Хайд-Парк" },
                 new DistrictTranslation { id = 27, EntityId = 9, Lang = "uk", Title = "Гайд-Парк" },

                 // --- Berlin ---
                 new DistrictTranslation { id = 28, EntityId = 10, Lang = "en", Title = "Mitte" },
                 new DistrictTranslation { id = 29, EntityId = 10, Lang = "ru", Title = "Митте" },
                 new DistrictTranslation { id = 30, EntityId = 10, Lang = "uk", Title = "Мітте" },

                 new DistrictTranslation { id = 31, EntityId = 11, Lang = "en", Title = "Kreuzberg" },
                 new DistrictTranslation { id = 32, EntityId = 11, Lang = "ru", Title = "Кройцберг" },
                 new DistrictTranslation { id = 33, EntityId = 11, Lang = "uk", Title = "Кройцберг" },

                 new DistrictTranslation { id = 34, EntityId = 12, Lang = "en", Title = "Charlottenburg" },
                 new DistrictTranslation { id = 35, EntityId = 12, Lang = "ru", Title = "Шарлоттенбург" },
                 new DistrictTranslation { id = 36, EntityId = 12, Lang = "uk", Title = "Шарлоттенбург" },

                 // --- Munich ---
                 new DistrictTranslation { id = 37, EntityId = 13, Lang = "en", Title = "Old Town – Lehel" },
                 new DistrictTranslation { id = 38, EntityId = 13, Lang = "ru", Title = "Старый город – Лехель" },
                 new DistrictTranslation { id = 39, EntityId = 13, Lang = "uk", Title = "Старе місто – Лехель" },

                 new DistrictTranslation { id = 40, EntityId = 14, Lang = "en", Title = "Maxvorstadt" },
                 new DistrictTranslation { id = 41, EntityId = 14, Lang = "ru", Title = "Максворштадт" },
                 new DistrictTranslation { id = 42, EntityId = 14, Lang = "uk", Title = "Максворштадт" },

                 new DistrictTranslation { id = 43, EntityId = 15, Lang = "en", Title = "Schwabing" },
                 new DistrictTranslation { id = 44, EntityId = 15, Lang = "ru", Title = "Швабинг" },
                 new DistrictTranslation { id = 45, EntityId = 15, Lang = "uk", Title = "Швабінг" },

                 // --- Hamburg ---
                 new DistrictTranslation { id = 46, EntityId = 16, Lang = "en", Title = "Altona" },
                 new DistrictTranslation { id = 47, EntityId = 16, Lang = "ru", Title = "Альтона" },
                 new DistrictTranslation { id = 48, EntityId = 16, Lang = "uk", Title = "Альтона" },

                 new DistrictTranslation { id = 49, EntityId = 17, Lang = "en", Title = "St. Pauli" },
                 new DistrictTranslation { id = 50, EntityId = 17, Lang = "ru", Title = "Санкт-Паули" },
                 new DistrictTranslation { id = 51, EntityId = 17, Lang = "uk", Title = "Санкт-Паулі" },

                 new DistrictTranslation { id = 52, EntityId = 18, Lang = "en", Title = "Eimsbuettel" },
                 new DistrictTranslation { id = 53, EntityId = 18, Lang = "ru", Title = "Айнсбюттель" },
                 new DistrictTranslation { id = 54, EntityId = 18, Lang = "uk", Title = "Айнсбюттель" }

             );


            modelBuilder.Entity<AttractionTranslation>().HasData(
                // --- New York ---
                new AttractionTranslation { id = 1, EntityId = 1, Lang = "en", Title = "Statue of Liberty", Description = "Iconic national monument" },
                new AttractionTranslation { id = 2, EntityId = 1, Lang = "ru", Title = "Статуя Свободы", Description = "Знаменитый национальный памятник" },
                new AttractionTranslation { id = 3, EntityId = 2, Lang = "en", Title = "Central Park", Description = "Famous urban park" },
                new AttractionTranslation { id = 4, EntityId = 2, Lang = "ru", Title = "Центральный парк", Description = "Известный городской парк" },
                new AttractionTranslation { id = 5, EntityId = 3, Lang = "en", Title = "Times Square", Description = "Major commercial intersection" },
                new AttractionTranslation { id = 6, EntityId = 3, Lang = "ru", Title = "Таймс-сквер", Description = "Крупная торговая площадь" },
                new AttractionTranslation { id = 7, EntityId = 4, Lang = "en", Title = "Brooklyn Bridge", Description = "Historic bridge" },
                new AttractionTranslation { id = 8, EntityId = 4, Lang = "ru", Title = "Бруклинский мост", Description = "Исторический мост" },
                new AttractionTranslation { id = 9, EntityId = 5, Lang = "en", Title = "Empire State Building", Description = "102-story skyscraper" },
                new AttractionTranslation { id = 10, EntityId = 5, Lang = "ru", Title = "Эмпайр-стейт-билдинг", Description = "102-этажный небоскрёб" },

                // --- Los Angeles ---
                new AttractionTranslation { id = 11, EntityId = 6, Lang = "en", Title = "Hollywood Sign", Description = "Famous landmark" },
                new AttractionTranslation { id = 12, EntityId = 6, Lang = "ru", Title = "Знак Голливуда", Description = "Знаковая достопримечательность" },
                new AttractionTranslation { id = 13, EntityId = 7, Lang = "en", Title = "Santa Monica Pier", Description = "Historic pier" },
                new AttractionTranslation { id = 14, EntityId = 7, Lang = "ru", Title = "Пирс Санта-Моники", Description = "Исторический пирс" },
                new AttractionTranslation { id = 15, EntityId = 8, Lang = "en", Title = "Griffith Observatory", Description = "Observatory with city views" },
                new AttractionTranslation { id = 16, EntityId = 8, Lang = "ru", Title = "Обсерватория Гриффита", Description = "Обсерватория с видом на город" },
                new AttractionTranslation { id = 17, EntityId = 9, Lang = "en", Title = "Getty Center", Description = "Art museum" },
                new AttractionTranslation { id = 18, EntityId = 9, Lang = "ru", Title = "Центр Гетти", Description = "Художественный музей" },
                new AttractionTranslation { id = 19, EntityId = 10, Lang = "en", Title = "Venice Beach", Description = "Famous beach area" },
                new AttractionTranslation { id = 20, EntityId = 10, Lang = "ru", Title = "Пляж Венеции", Description = "Знаменитый пляж" },

                // --- Chicago ---
                new AttractionTranslation { id = 21, EntityId = 11, Lang = "en", Title = "Millennium Park", Description = "Public park with art installations" },
                new AttractionTranslation { id = 22, EntityId = 11, Lang = "ru", Title = "Парк Тысячелетия", Description = "Общественный парк с арт-объектами" },
                new AttractionTranslation { id = 23, EntityId = 12, Lang = "en", Title = "Art Institute of Chicago", Description = "Famous art museum" },
                new AttractionTranslation { id = 24, EntityId = 12, Lang = "ru", Title = "Чикагский институт искусств", Description = "Известный художественный музей" },
                new AttractionTranslation { id = 25, EntityId = 13, Lang = "en", Title = "Navy Pier", Description = "Pier with attractions and restaurants" },
                new AttractionTranslation { id = 26, EntityId = 13, Lang = "ru", Title = "Нэйви-Пир", Description = "Пирс с аттракционами и ресторанами" },
                new AttractionTranslation { id = 27, EntityId = 14, Lang = "en", Title = "Willis Tower", Description = "Iconic skyscraper" },
                new AttractionTranslation { id = 28, EntityId = 14, Lang = "ru", Title = "Виллис-Тауэр", Description = "Знаковый небоскрёб" },
                new AttractionTranslation { id = 29, EntityId = 15, Lang = "en", Title = "Lincoln Park Zoo", Description = "Historic zoo" },
                new AttractionTranslation { id = 30, EntityId = 15, Lang = "ru", Title = "Зоопарк Линкольн-Парк", Description = "Исторический зоопарк" },

                // --- Germany ---
                new AttractionTranslation { id = 31, EntityId = 16, Lang = "en", Title = "Brandenburg Gate", Description = "Historic monument" },
                new AttractionTranslation { id = 32, EntityId = 16, Lang = "ru", Title = "Бранденбургские ворота", Description = "Исторический памятник" },
                new AttractionTranslation { id = 33, EntityId = 17, Lang = "en", Title = "Berlin Wall Memorial", Description = "Remains of Berlin Wall" },
                new AttractionTranslation { id = 34, EntityId = 17, Lang = "ru", Title = "Мемориал Берлинской стены", Description = "Остатки Берлинской стены" },
                new AttractionTranslation { id = 35, EntityId = 18, Lang = "en", Title = "Museum Island", Description = "Group of museums" },
                new AttractionTranslation { id = 36, EntityId = 18, Lang = "ru", Title = "Остров музеев", Description = "Группа музеев" },
                new AttractionTranslation { id = 37, EntityId = 19, Lang = "en", Title = "Alexanderplatz", Description = "Central square" },
                new AttractionTranslation { id = 38, EntityId = 19, Lang = "ru", Title = "Александерплац", Description = "Центральная площадь" },
                new AttractionTranslation { id = 39, EntityId = 20, Lang = "en", Title = "Checkpoint Charlie", Description = "Historic border crossing" },
                new AttractionTranslation { id = 40, EntityId = 20, Lang = "ru", Title = "Чекпойнт Чарли", Description = "Исторический пограничный переход" },

                // --- Germany (continued) ---
                new AttractionTranslation { id = 41, EntityId = 21, Lang = "en", Title = "Marienplatz", Description = "Central square" },
                new AttractionTranslation { id = 42, EntityId = 21, Lang = "ru", Title = "Мариенплац", Description = "Центральная площадь" },
                new AttractionTranslation { id = 43, EntityId = 22, Lang = "en", Title = "English Garden", Description = "Large public park" },
                new AttractionTranslation { id = 44, EntityId = 22, Lang = "ru", Title = "Английский сад", Description = "Большой городской парк" },
                new AttractionTranslation { id = 45, EntityId = 23, Lang = "en", Title = "Nymphenburg Palace", Description = "Historic palace" },
                new AttractionTranslation { id = 46, EntityId = 23, Lang = "ru", Title = "Дворец Нимфенбург", Description = "Исторический дворец" },
                new AttractionTranslation { id = 47, EntityId = 24, Lang = "en", Title = "BMW Museum", Description = "Automobile museum" },
                new AttractionTranslation { id = 48, EntityId = 24, Lang = "ru", Title = "Музей BMW", Description = "Музей автомобилей" },
                new AttractionTranslation { id = 49, EntityId = 25, Lang = "en", Title = "Olympiapark", Description = "Sports and entertainment complex" },
                new AttractionTranslation { id = 50, EntityId = 25, Lang = "ru", Title = "Олимпийский парк", Description = "Спортивный и развлекательный комплекс" },

                new AttractionTranslation { id = 51, EntityId = 26, Lang = "en", Title = "Miniatur Wunderland", Description = "Largest model railway" },
                new AttractionTranslation { id = 52, EntityId = 26, Lang = "ru", Title = "Миниатюрная страна чудес", Description = "Самая большая модель железной дороги" },
                new AttractionTranslation { id = 53, EntityId = 27, Lang = "en", Title = "Port of Hamburg", Description = "Famous port area" },
                new AttractionTranslation { id = 54, EntityId = 27, Lang = "ru", Title = "Гамбургский порт", Description = "Известная портовая зона" },
                new AttractionTranslation { id = 55, EntityId = 28, Lang = "en", Title = "Elbphilharmonie", Description = "Concert hall" },
                new AttractionTranslation { id = 56, EntityId = 28, Lang = "ru", Title = "Эльбская филармония", Description = "Концертный зал" },
                new AttractionTranslation { id = 57, EntityId = 29, Lang = "en", Title = "St. Michael's Church", Description = "Historic church" },
                new AttractionTranslation { id = 58, EntityId = 29, Lang = "ru", Title = "Церковь Св. Михаила", Description = "Историческая церковь" },
                new AttractionTranslation { id = 59, EntityId = 30, Lang = "en", Title = "Speicherstadt", Description = "Warehouse district" },
                new AttractionTranslation { id = 60, EntityId = 30, Lang = "ru", Title = "Спайхерштадт", Description = "Складской район" },

            // --- France ---
                new AttractionTranslation { id = 61, EntityId = 31, Lang = "en", Title = "Eiffel Tower", Description = "Famous tower in Paris" },
                new AttractionTranslation { id = 62, EntityId = 31, Lang = "ru", Title = "Эйфелева башня", Description = "Знаменитая башня в Париже" },
                new AttractionTranslation { id = 63, EntityId = 32, Lang = "en", Title = "Louvre Museum", Description = "World famous museum" },
                new AttractionTranslation { id = 64, EntityId = 32, Lang = "ru", Title = "Лувр", Description = "Мировой известный музей" },
                new AttractionTranslation { id = 65, EntityId = 33, Lang = "en", Title = "Notre-Dame Cathedral", Description = "Historic cathedral" },
                new AttractionTranslation { id = 66, EntityId = 33, Lang = "ru", Title = "Собор Нотр-Дам", Description = "Исторический собор" },
                new AttractionTranslation { id = 67, EntityId = 34, Lang = "en", Title = "Montmartre", Description = "Historic district" },
                new AttractionTranslation { id = 68, EntityId = 34, Lang = "ru", Title = "Монмартр", Description = "Исторический район" },
                new AttractionTranslation { id = 69, EntityId = 35, Lang = "en", Title = "Champs-Élysées", Description = "Famous avenue" },
                new AttractionTranslation { id = 70, EntityId = 35, Lang = "ru", Title = "Елисейские поля", Description = "Знаменитая улица" },

                new AttractionTranslation { id = 71, EntityId = 36, Lang = "en", Title = "Basilica of Notre-Dame de Fourvière", Description = "Historic church" },
                new AttractionTranslation { id = 72, EntityId = 36, Lang = "ru", Title = "Базилика Нотр-Дам-де-Фурвьер", Description = "Историческая церковь" },
                new AttractionTranslation { id = 73, EntityId = 37, Lang = "en", Title = "Parc de la Tête d'Or", Description = "Large urban park" },
                new AttractionTranslation { id = 74, EntityId = 37, Lang = "ru", Title = "Парк Тет-д'Ор", Description = "Большой городской парк" },
                new AttractionTranslation { id = 75, EntityId = 38, Lang = "en", Title = "Vieux Lyon", Description = "Historic district" },
                new AttractionTranslation { id = 76, EntityId = 38, Lang = "ru", Title = "Старый Лион", Description = "Исторический район" },
                new AttractionTranslation { id = 77, EntityId = 39, Lang = "en", Title = "Musée des Beaux-Arts", Description = "Art museum" },
                new AttractionTranslation { id = 78, EntityId = 39, Lang = "ru", Title = "Музей изящных искусств", Description = "Художественный музей" },
                new AttractionTranslation { id = 79, EntityId = 40, Lang = "en", Title = "Place Bellecour", Description = "City square" },
                new AttractionTranslation { id = 80, EntityId = 40, Lang = "ru", Title = "Площадь Белькур", Description = "Городская площадь" },

                // --- France / Marseille ---
                new AttractionTranslation { id = 81, EntityId = 41, Lang = "en", Title = "Old Port of Marseille", Description = "Historic harbor area" },
                new AttractionTranslation { id = 82, EntityId = 41, Lang = "ru", Title = "Старый порт Марселя", Description = "Историческая портовая зона" },
                new AttractionTranslation { id = 83, EntityId = 42, Lang = "en", Title = "Basilique Notre-Dame de la Garde", Description = "Historic basilica" },
                new AttractionTranslation { id = 84, EntityId = 42, Lang = "ru", Title = "Базилика Нотр-Дам-де-ла-Гард", Description = "Историческая базилика" },
                new AttractionTranslation { id = 85, EntityId = 43, Lang = "en", Title = "Château d'If", Description = "Island fortress" },
                new AttractionTranslation { id = 86, EntityId = 43, Lang = "ru", Title = "Замок Иф", Description = "Островная крепость" },
                new AttractionTranslation { id = 87, EntityId = 44, Lang = "en", Title = "La Canebière", Description = "Historic street" },
                new AttractionTranslation { id = 88, EntityId = 44, Lang = "ru", Title = "Ля Канебиер", Description = "Историческая улица" },
                new AttractionTranslation { id = 89, EntityId = 45, Lang = "en", Title = "Palais Longchamp", Description = "Fountain and palace" },
                new AttractionTranslation { id = 90, EntityId = 45, Lang = "ru", Title = "Пале Лоншан", Description = "Фонтан и дворец" }

             );


            // Сиды категорий с переводами
            modelBuilder.Entity<ParamsCategoryTranslation>().HasData(
                new ParamsCategoryTranslation { id = 1, EntityId = 1, Lang = "en", Title = "General" },
                new ParamsCategoryTranslation { id = 2, EntityId = 1, Lang = "ru", Title = "Общее" },

                new ParamsCategoryTranslation { id = 3, EntityId = 2, Lang = "en", Title = "Building" },
                new ParamsCategoryTranslation { id = 4, EntityId = 2, Lang = "ru", Title = "Здание" },

                new ParamsCategoryTranslation { id = 5, EntityId = 3, Lang = "en", Title = "Location" },
                new ParamsCategoryTranslation { id = 6, EntityId = 3, Lang = "ru", Title = "Расположение" },

                new ParamsCategoryTranslation { id = 7, EntityId = 4, Lang = "en", Title = "Outdoors" },
                new ParamsCategoryTranslation { id = 8, EntityId = 4, Lang = "ru", Title = "На улице" },

                new ParamsCategoryTranslation { id = 9, EntityId = 5, Lang = "en", Title = "Services" },
                new ParamsCategoryTranslation { id = 10, EntityId = 5, Lang = "ru", Title = "Услуги" },

                new ParamsCategoryTranslation { id = 11, EntityId = 6, Lang = "en", Title = "Food & Drink" },
                new ParamsCategoryTranslation { id = 12, EntityId = 6, Lang = "ru", Title = "Еда и напитки" },

                new ParamsCategoryTranslation { id = 13, EntityId = 7, Lang = "en", Title = "Wellness & Recreation" },
                new ParamsCategoryTranslation { id = 14, EntityId = 7, Lang = "ru", Title = "Здоровье и отдых" },

                new ParamsCategoryTranslation { id = 15, EntityId = 8, Lang = "en", Title = "Room Facilities" },
                new ParamsCategoryTranslation { id = 16, EntityId = 8, Lang = "ru", Title = "Удобства в номере" },

                new ParamsCategoryTranslation { id = 17, EntityId = 9, Lang = "en", Title = "Beds & Sleeping" },
                new ParamsCategoryTranslation { id = 18, EntityId = 9, Lang = "ru", Title = "Кровати и спальные места" },

                new ParamsCategoryTranslation { id = 19, EntityId = 10, Lang = "en", Title = "Kitchen" },
                new ParamsCategoryTranslation { id = 20, EntityId = 10, Lang = "ru", Title = "Кухня" },

                new ParamsCategoryTranslation { id = 21, EntityId = 11, Lang = "en", Title = "Bathroom" },
                new ParamsCategoryTranslation { id = 22, EntityId = 11, Lang = "ru", Title = "Ванная комната" },

                new ParamsCategoryTranslation { id = 23, EntityId = 12, Lang = "en", Title = "Safety" },
                new ParamsCategoryTranslation { id = 24, EntityId = 12, Lang = "ru", Title = "Безопасность" }
            );


            // Сиды параметров с переводами
            modelBuilder.Entity<ParamItemTranslation>().HasData(
                // General
                new ParamItemTranslation { id = 1, EntityId = 1, Lang = "en", Title = "Free WiFi" },
                new ParamItemTranslation { id = 2, EntityId = 1, Lang = "ru", Title = "Бесплатный WiFi" },

                new ParamItemTranslation { id = 3, EntityId = 2, Lang = "en", Title = "Non‑smoking rooms" },
                new ParamItemTranslation { id = 4, EntityId = 2, Lang = "ru", Title = "Номера для некурящих" },

                new ParamItemTranslation { id = 5, EntityId = 3, Lang = "en", Title = "Air conditioning" },
                new ParamItemTranslation { id = 6, EntityId = 3, Lang = "ru", Title = "Кондиционер" },

                new ParamItemTranslation { id = 7, EntityId = 4, Lang = "en", Title = "Heating" },
                new ParamItemTranslation { id = 8, EntityId = 4, Lang = "ru", Title = "Отопление" },

                new ParamItemTranslation { id = 9, EntityId = 5, Lang = "en", Title = "Pets allowed" },
                new ParamItemTranslation { id = 10, EntityId = 5, Lang = "ru", Title = "Разрешено с животными" },

                // Building
                new ParamItemTranslation { id = 11, EntityId = 6, Lang = "en", Title = "Elevator" },
                new ParamItemTranslation { id = 12, EntityId = 6, Lang = "ru", Title = "Лифт" },

                new ParamItemTranslation { id = 13, EntityId = 7, Lang = "en", Title = "24‑hour front desk" },
                new ParamItemTranslation { id = 14, EntityId = 7, Lang = "ru", Title = "Круглосуточная стойка регистрации" },

                new ParamItemTranslation { id = 15, EntityId = 8, Lang = "en", Title = "Security" },
                new ParamItemTranslation { id = 16, EntityId = 8, Lang = "ru", Title = "Охрана" },

                // Location
                new ParamItemTranslation { id = 17, EntityId = 9, Lang = "en", Title = "Parking" },
                new ParamItemTranslation { id = 18, EntityId = 9, Lang = "ru", Title = "Парковка" },

                // Outdoors
                new ParamItemTranslation { id = 19, EntityId = 10, Lang = "en", Title = "Garden" },
                new ParamItemTranslation { id = 20, EntityId = 10, Lang = "ru", Title = "Сад" },

                new ParamItemTranslation { id = 21, EntityId = 11, Lang = "en", Title = "Terrace" },
                new ParamItemTranslation { id = 22, EntityId = 11, Lang = "ru", Title = "Терраса" },

                new ParamItemTranslation { id = 23, EntityId = 12, Lang = "en", Title = "BBQ / Picnic area" },
                new ParamItemTranslation { id = 24, EntityId = 12, Lang = "ru", Title = "Барбекю / Пикник" },

                // Services
                new ParamItemTranslation { id = 25, EntityId = 13, Lang = "en", Title = "Airport shuttle" },
                new ParamItemTranslation { id = 26, EntityId = 13, Lang = "ru", Title = "Трансфер до аэропорта" },

                new ParamItemTranslation { id = 27, EntityId = 14, Lang = "en", Title = "Laundry" },
                new ParamItemTranslation { id = 28, EntityId = 14, Lang = "ru", Title = "Прачечная" },

                new ParamItemTranslation { id = 29, EntityId = 15, Lang = "en", Title = "Dry cleaning" },
                new ParamItemTranslation { id = 30, EntityId = 15, Lang = "ru", Title = "Химчистка" },

                new ParamItemTranslation { id = 31, EntityId = 16, Lang = "en", Title = "Concierge" },
                new ParamItemTranslation { id = 32, EntityId = 16, Lang = "ru", Title = "Консьерж" },

                // Food & Drink
                new ParamItemTranslation { id = 33, EntityId = 17, Lang = "en", Title = "Restaurant" },
                new ParamItemTranslation { id = 34, EntityId = 17, Lang = "ru", Title = "Ресторан" },

                new ParamItemTranslation { id = 35, EntityId = 18, Lang = "en", Title = "Bar" },
                new ParamItemTranslation { id = 36, EntityId = 18, Lang = "ru", Title = "Бар" },

                new ParamItemTranslation { id = 37, EntityId = 19, Lang = "en", Title = "Breakfast included" },
                new ParamItemTranslation { id = 38, EntityId = 19, Lang = "ru", Title = "Завтрак включен" },

                // Wellness & Recreation
                new ParamItemTranslation { id = 39, EntityId = 20, Lang = "en", Title = "Fitness center" },
                new ParamItemTranslation { id = 40, EntityId = 20, Lang = "ru", Title = "Фитнес-центр" },

                new ParamItemTranslation { id = 41, EntityId = 21, Lang = "en", Title = "Sauna" },
                new ParamItemTranslation { id = 42, EntityId = 21, Lang = "ru", Title = "Сауна" },

                new ParamItemTranslation { id = 43, EntityId = 22, Lang = "en", Title = "Outdoor pool" },
                new ParamItemTranslation { id = 44, EntityId = 22, Lang = "ru", Title = "Открытый бассейн" },

                new ParamItemTranslation { id = 45, EntityId = 23, Lang = "en", Title = "Indoor pool" },
                new ParamItemTranslation { id = 46, EntityId = 23, Lang = "ru", Title = "Закрытый бассейн" },
          
                // Room Facilities
                new ParamItemTranslation { id = 47, EntityId = 24, Lang = "en", Title = "Shower" },
                new ParamItemTranslation { id = 48, EntityId = 24, Lang = "ru", Title = "Душ" },

                new ParamItemTranslation { id = 49, EntityId = 25, Lang = "en", Title = "Bathtub" },
                new ParamItemTranslation { id = 50, EntityId = 25, Lang = "ru", Title = "Ванна" },

                new ParamItemTranslation { id = 51, EntityId = 26, Lang = "en", Title = "Hair dryer" },
                new ParamItemTranslation { id = 52, EntityId = 26, Lang = "ru", Title = "Фен" },

                new ParamItemTranslation { id = 53, EntityId = 27, Lang = "en", Title = "TV" },
                new ParamItemTranslation { id = 54, EntityId = 27, Lang = "ru", Title = "Телевизор" },

                new ParamItemTranslation { id = 55, EntityId = 28, Lang = "en", Title = "Minibar" },
                new ParamItemTranslation { id = 56, EntityId = 28, Lang = "ru", Title = "Минибар" },

                new ParamItemTranslation { id = 57, EntityId = 29, Lang = "en", Title = "Safe" },
                new ParamItemTranslation { id = 58, EntityId = 29, Lang = "ru", Title = "Сейф" },

                new ParamItemTranslation { id = 59, EntityId = 30, Lang = "en", Title = "City view" },
                new ParamItemTranslation { id = 60, EntityId = 30, Lang = "ru", Title = "Вид на город" },

                new ParamItemTranslation { id = 61, EntityId = 31, Lang = "en", Title = "Quiet street view" },
                new ParamItemTranslation { id = 62, EntityId = 31, Lang = "ru", Title = "Вид на тихую улицу" },

                new ParamItemTranslation { id = 63, EntityId = 32, Lang = "en", Title = "Double bed" },
                new ParamItemTranslation { id = 64, EntityId = 32, Lang = "ru", Title = "Двуспальная кровать" },

                new ParamItemTranslation { id = 65, EntityId = 33, Lang = "en", Title = "Sofa bed" },
                new ParamItemTranslation { id = 66, EntityId = 33, Lang = "ru", Title = "Диван-кровать" },

                new ParamItemTranslation { id = 67, EntityId = 34, Lang = "en", Title = "Both double and sofa bed" },
                new ParamItemTranslation { id = 68, EntityId = 34, Lang = "ru", Title = "Двуспальная кровать и диван-кровать" },

  
                // Distance from center / Location distances
                new ParamItemTranslation { id = 73, EntityId = 35, Lang = "en", Title = "Distance from center (km)" },
                new ParamItemTranslation { id = 74, EntityId = 35, Lang = "ru", Title = "Расстояние до центра (км)" },

                new ParamItemTranslation { id = 75, EntityId = 36, Lang = "en", Title = "Distance to airport (km)" },
                new ParamItemTranslation { id = 76, EntityId = 36, Lang = "ru", Title = "Расстояние до аэропорта (км)" },

                new ParamItemTranslation { id = 77, EntityId = 37, Lang = "en", Title = "Distance to metro (km)" },
                new ParamItemTranslation { id = 78, EntityId = 37, Lang = "ru", Title = "Расстояние до метро (км)" },

                new ParamItemTranslation { id = 79, EntityId = 38, Lang = "en", Title = "Distance to beach (km)" },
                new ParamItemTranslation { id = 80, EntityId = 38, Lang = "ru", Title = "Расстояние до пляжа (км)" },

                // Room Facilities extended
                new ParamItemTranslation { id = 81, EntityId = 39, Lang = "en", Title = "City view" },
                new ParamItemTranslation { id = 82, EntityId = 39, Lang = "ru", Title = "Вид на город" },

                new ParamItemTranslation { id = 83, EntityId = 40, Lang = "en", Title = "Quiet street view" },
                new ParamItemTranslation { id = 84, EntityId = 40, Lang = "ru", Title = "Вид на тихую улицу" },


                new ParamItemTranslation { id = 85, EntityId = 43, Lang = "en", Title = "Flat-screen TV" },
                new ParamItemTranslation { id = 86, EntityId = 43, Lang = "ru", Title = "Плоский телевизор" },

                new ParamItemTranslation { id = 87, EntityId = 44, Lang = "en", Title = "Streaming services (Netflix)" },
                new ParamItemTranslation { id = 88, EntityId = 44, Lang = "ru", Title = "Стриминговые сервисы (Netflix)" },


                // Beds & Sleeping counts
                new ParamItemTranslation { id = 89, EntityId = 45, Lang = "en", Title = "Single bed" },
                new ParamItemTranslation { id = 90, EntityId = 45, Lang = "ru", Title = "Односпальная кровать" },

                new ParamItemTranslation { id = 91, EntityId = 46, Lang = "en", Title = "Double bed" },
                new ParamItemTranslation { id = 92, EntityId = 46, Lang = "ru", Title = "Двуспальная кровать" },

            

                new ParamItemTranslation { id = 93, EntityId = 49, Lang = "en", Title = "Sofa bed" },
                new ParamItemTranslation { id = 94, EntityId = 49, Lang = "ru", Title = "Диван-кровать" },

                new ParamItemTranslation { id = 95, EntityId = 50, Lang = "en", Title = "Bunk bed" },
                new ParamItemTranslation { id = 96, EntityId = 50, Lang = "ru", Title = "Двухъярусная кровать" },

                new ParamItemTranslation { id = 97, EntityId = 51, Lang = "en", Title = "Baby crib" },
                new ParamItemTranslation { id = 98, EntityId = 51, Lang = "ru", Title = "Детская кроватка" },

                new ParamItemTranslation { id = 99, EntityId = 52, Lang = "en", Title = "Child bed" },
                new ParamItemTranslation { id = 100, EntityId = 52, Lang = "ru", Title = "Кровать для ребенка" },

                // Kitchen
                new ParamItemTranslation { id = 101, EntityId = 53, Lang = "en", Title = "Kitchen" },
                new ParamItemTranslation { id = 102, EntityId = 53, Lang = "ru", Title = "Кухня" },

                new ParamItemTranslation { id = 103, EntityId = 54, Lang = "en", Title = "Refrigerator" },
                new ParamItemTranslation { id = 104, EntityId = 54, Lang = "ru", Title = "Холодильник" },

                new ParamItemTranslation { id = 105, EntityId = 55, Lang = "en", Title = "Microwave" },
                new ParamItemTranslation { id = 106, EntityId = 55, Lang = "ru", Title = "Микроволновка" },

                new ParamItemTranslation { id = 107, EntityId = 56, Lang = "en", Title = "Stovetop" },
                new ParamItemTranslation { id = 108, EntityId = 56, Lang = "ru", Title = "Плита" },

                new ParamItemTranslation { id = 109, EntityId = 57, Lang = "en", Title = "Dishwasher" },
                new ParamItemTranslation { id = 110, EntityId = 57, Lang = "ru", Title = "Посудомоечная машина" },

                new ParamItemTranslation { id = 111, EntityId = 58, Lang = "en", Title = "Kitchenware" },
                new ParamItemTranslation { id = 112, EntityId = 58, Lang = "ru", Title = "Кухонная утварь" },

                new ParamItemTranslation { id = 113, EntityId = 59, Lang = "en", Title = "Electric kettle" },
                new ParamItemTranslation { id = 114, EntityId = 59, Lang = "ru", Title = "Электрический чайник" },

                new ParamItemTranslation { id = 115, EntityId = 60, Lang = "en", Title = "Coffee machine" },
                new ParamItemTranslation { id = 116, EntityId = 60, Lang = "ru", Title = "Кофемашина" },

                new ParamItemTranslation { id = 117, EntityId = 61, Lang = "en", Title = "Toaster" },
                new ParamItemTranslation { id = 118, EntityId = 61, Lang = "ru", Title = "Тостер" },

                // Bathroom
                new ParamItemTranslation { id = 119, EntityId = 62, Lang = "en", Title = "Shampoo" },
                new ParamItemTranslation { id = 120, EntityId = 62, Lang = "ru", Title = "Шампунь" },

                new ParamItemTranslation { id = 121, EntityId = 63, Lang = "en", Title = "Soap" },
                new ParamItemTranslation { id = 122, EntityId = 63, Lang = "ru", Title = "Мыло" },

                new ParamItemTranslation { id = 123, EntityId = 64, Lang = "en", Title = "Towels" },
                new ParamItemTranslation { id = 124, EntityId = 64, Lang = "ru", Title = "Полотенца" },

                new ParamItemTranslation { id = 125, EntityId = 65, Lang = "en", Title = "Hot water" },
                new ParamItemTranslation { id = 126, EntityId = 65, Lang = "ru", Title = "Горячая вода" },

                new ParamItemTranslation { id = 127, EntityId = 66, Lang = "en", Title = "Washing machine" },
                new ParamItemTranslation { id = 128, EntityId = 66, Lang = "ru", Title = "Стиральная машина" },

                new ParamItemTranslation { id = 129, EntityId = 67, Lang = "en", Title = "Dryer" },
                new ParamItemTranslation { id = 130, EntityId = 67, Lang = "ru", Title = "Сушилка" },

                // Safety
                new ParamItemTranslation { id = 131, EntityId = 68, Lang = "en", Title = "Smoke detector" },
                new ParamItemTranslation { id = 132, EntityId = 68, Lang = "ru", Title = "Детектор дыма" },

                new ParamItemTranslation { id = 133, EntityId = 69, Lang = "en", Title = "Fire extinguisher" },
                new ParamItemTranslation { id = 134, EntityId = 69, Lang = "ru", Title = "Огнетушитель" },

                new ParamItemTranslation { id = 135, EntityId = 70, Lang = "en", Title = "First aid kit" },
                new ParamItemTranslation { id = 136, EntityId = 70, Lang = "ru", Title = "Аптечка" },

                new ParamItemTranslation { id = 137, EntityId = 71, Lang = "en", Title = "Exterior security cameras" },
                new ParamItemTranslation { id = 138, EntityId = 71, Lang = "ru", Title = "Камеры внешнего наблюдения" }


            );


        }
    }
}
