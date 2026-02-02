using AttractionApiService.Models;
using Microsoft.EntityFrameworkCore;

namespace AttractionApiService.Data.Seed
{
    public static class AttractionsSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            //Attraction
            modelBuilder.Entity<Attraction>().HasData(

            // =================== Київ ===================
            new Attraction { id = 1, Latitude = 50.4544, Longitude = 30.5230, CountryId = 1, DistrictId = 1, RegionId = 1, CityId = 1, Address = "Софійська площа, Київ", ImageUrl = "images/attractions/Kyiv_SofiaSquare.jpg" },
            new Attraction { id = 2, Latitude = 50.4500, Longitude = 30.5240, CountryId = 1, DistrictId = 1, RegionId = 1, CityId = 1, Address = "Золоті ворота, Київ", ImageUrl = "images/attractions/Kyiv_GoldenGate.jpg" },
            new Attraction { id = 3, Latitude = 50.4512, Longitude = 30.5260, CountryId = 1, DistrictId = 1, RegionId = 1, CityId = 1, Address = "Михайлівська площа, Київ", ImageUrl = "images/attractions/Kyiv_MikhailSquare.jpg" },
            new Attraction { id = 4, Latitude = 50.4495, Longitude = 30.5210, CountryId = 1, DistrictId = 1, RegionId = 1, CityId = 1, Address = "Андріївський узвіз, Київ", ImageUrl = "images/attractions/Kyiv_AndreevDescent.jpg" },
            new Attraction { id = 5, Latitude = 50.4520, Longitude = 30.5250, CountryId = 1, DistrictId = 1, RegionId = 1, CityId = 1, Address = "Національний музей історії України, Київ", ImageUrl = "images/attractions/Kyiv_NationalMuseum.jpg" },

            new Attraction { id = 6, Latitude = 50.4550, Longitude = 30.5235, CountryId = 1, DistrictId = 2, RegionId = 1, CityId = 1, Address = "Парк Шевченка, Київ", ImageUrl = "images/attractions/Kyiv_ShevchenkoPark.jpg" },
            new Attraction { id = 7, Latitude = 50.4545, Longitude = 30.5245, CountryId = 1, DistrictId = 2, RegionId = 1, CityId = 1, Address = "Київський університет, Київ", ImageUrl = "images/attractions/Kyiv_University.jpg" },
            new Attraction { id = 8, Latitude = 50.4555, Longitude = 30.5255, CountryId = 1, DistrictId = 2, RegionId = 1, CityId = 1, Address = "Ботанічний сад ім. Гришка, Київ", ImageUrl = "images/attractions/Kyiv_BotanicalGarden.jpg" },
            new Attraction { id = 9, Latitude = 50.4535, Longitude = 30.5225, CountryId = 1, DistrictId = 2, RegionId = 1, CityId = 1, Address = "Контрактова площа, Київ", ImageUrl = "images/attractions/Kyiv_ContractSquare.jpg" },
            new Attraction { id = 10, Latitude = 50.4540, Longitude = 30.5230, CountryId = 1, DistrictId = 2, RegionId = 1, CityId = 1, Address = "Михайлівський собор, Київ", ImageUrl = "images/attractions/Kyiv_MikhailCathedral.jpg" },

            new Attraction { id = 11, Latitude = 50.4475, Longitude = 30.5185, CountryId = 1, DistrictId = 3, RegionId = 1, CityId = 1, Address = "Поштова площа, Київ", ImageUrl = "images/attractions/Kyiv_PochtaSquare.jpg" },
            new Attraction { id = 12, Latitude = 50.4470, Longitude = 30.5190, CountryId = 1, DistrictId = 3, RegionId = 1, CityId = 1, Address = "Музей історії Києва, Київ", ImageUrl = "images/attractions/Kyiv_HistoryMuseum.jpg" },
            new Attraction { id = 13, Latitude = 50.4465, Longitude = 30.5175, CountryId = 1, DistrictId = 3, RegionId = 1, CityId = 1, Address = "Набережна Дніпра, Київ", ImageUrl = "images/attractions/Kyiv_DniproEmbankment.jpg" },
            new Attraction { id = 14, Latitude = 50.4472, Longitude = 30.5182, CountryId = 1, DistrictId = 3, RegionId = 1, CityId = 1, Address = "Музей води, Київ", ImageUrl = "images/attractions/Kyiv_WaterMuseum.jpg" },
            new Attraction { id = 15, Latitude = 50.4480, Longitude = 30.5195, CountryId = 1, DistrictId = 3, RegionId = 1, CityId = 1, Address = "Міст Патона, Київ", ImageUrl = "images/attractions/Kyiv_PatonaBridge.jpg" },

            // =================== Ужгород ===================
            new Attraction { id = 16, Latitude = 48.6199, Longitude = 22.2880, CountryId = 1, DistrictId = 4, RegionId = 2, CityId = 2, Address = "Ужгородський замок, Ужгород", ImageUrl = "images/attractions/Uzhgorod_Castle.jpg" },
            new Attraction { id = 17, Latitude = 48.6205, Longitude = 22.2890, CountryId = 1, DistrictId = 4, RegionId = 2, CityId = 2, Address = "Кафедральний собор Ужгорода", ImageUrl = "images/attractions/Uzhgorod_Cathedral.jpg" },
            new Attraction { id = 18, Latitude = 48.6185, Longitude = 22.2875, CountryId = 1, DistrictId = 4, RegionId = 2, CityId = 2, Address = "Ботанічний сад УжНУ", ImageUrl = "images/attractions/Uzhgorod_BotanicalGarden.jpg" },
            new Attraction { id = 19, Latitude = 48.6190, Longitude = 22.2885, CountryId = 1, DistrictId = 4, RegionId = 2, CityId = 2, Address = "Площа Театральна, Ужгород", ImageUrl = "images/attractions/Uzhgorod_TheatreSquare.jpg" },
            new Attraction { id = 20, Latitude = 48.6200, Longitude = 22.2895, CountryId = 1, DistrictId = 4, RegionId = 2, CityId = 2, Address = "Музей народної архітектури Закарпаття", ImageUrl = "images/attractions/Uzhgorod_Museum.jpg" },

            // =================== Львів ===================
            new Attraction { id = 21, Latitude = 49.8400, Longitude = 24.0300, CountryId = 1, DistrictId = 7, RegionId = 3, CityId = 3, Address = "Площа Ринок, Львів", ImageUrl = "images/attractions/Lviv_RynokSquare.jpg" },
            new Attraction { id = 22, Latitude = 49.8410, Longitude = 24.0315, CountryId = 1, DistrictId = 7, RegionId = 3, CityId = 3, Address = "Львівська опера, Львів", ImageUrl = "images/attractions/Lviv_Opera.jpg" },
            new Attraction { id = 23, Latitude = 49.8390, Longitude = 24.0290, CountryId = 1, DistrictId = 7, RegionId = 3, CityId = 3, Address = "Високий замок, Львів", ImageUrl = "images/attractions/Lviv_HighCastle.jpg" },
            new Attraction { id = 24, Latitude = 49.8385, Longitude = 24.0285, CountryId = 1, DistrictId = 7, RegionId = 3, CityId = 3, Address = "Львівський музей історії релігії", ImageUrl = "images/attractions/Lviv_ReligionMuseum.jpg" },
            new Attraction { id = 25, Latitude = 49.8420, Longitude = 24.0320, CountryId = 1, DistrictId = 7, RegionId = 3, CityId = 3, Address = "Парк імені Івана Франка, Львів", ImageUrl = "images/attractions/Lviv_FrankoPark.jpg" },

            // =================== Одеса ===================
            new Attraction { id = 26, Latitude = 46.4830, Longitude = 30.7240, CountryId = 1, DistrictId = 10, RegionId = 4, CityId = 4, Address = "Дерибасівська вулиця, Одеса", ImageUrl = "images/attractions/Odesa_Deribasovska.jpg" },
            new Attraction { id = 27, Latitude = 46.4820, Longitude = 30.7235, CountryId = 1, DistrictId = 10, RegionId = 4, CityId = 4, Address = "Одеський театр опери та балету", ImageUrl = "images/attractions/Odesa_Opera.jpg" },
            new Attraction { id = 28, Latitude = 46.4840, Longitude = 30.7250, CountryId = 1, DistrictId = 10, RegionId = 4, CityId = 4, Address = "Потьомкінські сходи, Одеса", ImageUrl = "images/attractions/Odesa_PotemkinStairs.jpg" },
            new Attraction { id = 29, Latitude = 46.4825, Longitude = 30.7220, CountryId = 1, DistrictId = 10, RegionId = 4, CityId = 4, Address = "Одеський порт, Одеса", ImageUrl = "images/attractions/Odesa_Port.jpg" },
            new Attraction { id = 30, Latitude = 46.4815, Longitude = 30.7230, CountryId = 1, DistrictId = 10, RegionId = 4, CityId = 4, Address = "Приморський бульвар, Одеса", ImageUrl = "images/attractions/Odesa_Boulevard.jpg" },

            // =================== Тернопіль ===================
            new Attraction { id = 31, Latitude = 49.5540, Longitude = 25.5950, CountryId = 1, DistrictId = 13, RegionId = 5, CityId = 5, Address = "Тернопільський замок, Тернопіль", ImageUrl = "images/attractions/Ternopil_Castle.jpg" },
            new Attraction { id = 32, Latitude = 49.5550, Longitude = 25.5960, CountryId = 1, DistrictId = 13, RegionId = 5, CityId = 5, Address = "Тернопільський став, Тернопіль", ImageUrl = "images/attractions/Ternopil_Lake.jpg" },
            new Attraction { id = 33, Latitude = 49.5530, Longitude = 25.5940, CountryId = 1, DistrictId = 13, RegionId = 5, CityId = 5, Address = "Площа Героїв Євромайдану, Тернопіль", ImageUrl = "images/attractions/Ternopil_HeroesSquare.jpg" },
            new Attraction { id = 34, Latitude = 49.5560, Longitude = 25.5980, CountryId = 1, DistrictId = 13, RegionId = 5, CityId = 5, Address = "Музей освіти, Тернопіль", ImageUrl = "images/attractions/Ternopil_MuseumEducation.jpg" },
            new Attraction { id = 35, Latitude = 49.5520, Longitude = 25.5930, CountryId = 1, DistrictId = 13, RegionId = 5, CityId = 5, Address = "Домініканський костел, Тернопіль", ImageUrl = "images/attractions/Ternopil_DominicanChurch.jpg" },

            // =================== Миколаїв ===================
            new Attraction { id = 36, Latitude = 46.9755, Longitude = 31.9950, CountryId = 1, DistrictId = 14, RegionId = 14, CityId = 14, Address = "Миколаївський кораблебудівний завод, Миколаїв", ImageUrl = "images/attractions/Mykolaiv_Shipyard.jpg" },
            new Attraction { id = 37, Latitude = 46.9760, Longitude = 32.0000, CountryId = 1, DistrictId = 14, RegionId = 14, CityId = 14, Address = "Миколаївський зоопарк", ImageUrl = "images/attractions/Mykolaiv_Zoo.jpg" },
            new Attraction { id = 38, Latitude = 46.9745, Longitude = 31.9935, CountryId = 1, DistrictId = 14, RegionId = 14, CityId = 14, Address = "Вулиця Соборна, Миколаїв", ImageUrl = "images/attractions/Mykolaiv_SobornaStreet.jpg" },
            new Attraction { id = 39, Latitude = 46.9735, Longitude = 31.9945, CountryId = 1, DistrictId = 14, RegionId = 14, CityId = 14, Address = "Пам’ятник Катерині II, Миколаїв", ImageUrl = "images/attractions/Mykolaiv_CatherineMonument.jpg" },
            new Attraction { id = 40, Latitude = 46.9750, Longitude = 31.9960, CountryId = 1, DistrictId = 14, RegionId = 14, CityId = 14, Address = "Миколаївський обласний краєзнавчий музей", ImageUrl = "images/attractions/Mykolaiv_RegionalMuseum.jpg" },

            // =================== Херсон ===================
            new Attraction { id = 41, Latitude = 46.4910, Longitude = 30.7330, CountryId = 1, DistrictId = 15, RegionId = 15, CityId = 15, Address = "Херсонський обласний краєзнавчий музей", ImageUrl = "images/attractions/Kherson_RegionalMuseum.jpg" },
            new Attraction { id = 42, Latitude = 46.4920, Longitude = 30.7340, CountryId = 1, DistrictId = 15, RegionId = 15, CityId = 15, Address = "Херсонський морський порт", ImageUrl = "images/attractions/Kherson_Port.jpg" },
            new Attraction { id = 43, Latitude = 46.4890, Longitude = 30.7320, CountryId = 1, DistrictId = 15, RegionId = 15, CityId = 15, Address = "Кафедральний собор Святої Трійці, Херсон", ImageUrl = "images/attractions/Kherson_Cathedral.jpg" },
            new Attraction { id = 44, Latitude = 46.4905, Longitude = 30.7350, CountryId = 1, DistrictId = 15, RegionId = 15, CityId = 15, Address = "Парк Слави, Херсон", ImageUrl = "images/attractions/Kherson_ParkSlavy.jpg" },
            new Attraction { id = 45, Latitude = 46.4885, Longitude = 30.7310, CountryId = 1, DistrictId = 15, RegionId = 15, CityId = 15, Address = "Вулиця Ушакова, Херсон", ImageUrl = "images/attractions/Kherson_UshakovaStreet.jpg" },

            // =================== Луганськ (Сєвєродонецьк) ===================
            new Attraction { id = 46, Latitude = 48.4630, Longitude = 35.0470, CountryId = 1, DistrictId = 16, RegionId = 16, CityId = 16, Address = "Сєвєродонецький міський парк", ImageUrl = "images/attractions/Severodonetsk_Park.jpg" },
            new Attraction { id = 47, Latitude = 48.4640, Longitude = 35.0490, CountryId = 1, DistrictId = 16, RegionId = 16, CityId = 16, Address = "Краєзнавчий музей Сєвєродонецька", ImageUrl = "images/attractions/Severodonetsk_Museum.jpg" },
            new Attraction { id = 48, Latitude = 48.4615, Longitude = 35.0450, CountryId = 1, DistrictId = 16, RegionId = 16, CityId = 16, Address = "Площа Миру, Сєвєродонецьк", ImageUrl = "images/attractions/Severodonetsk_PeaceSquare.jpg" },
            new Attraction { id = 49, Latitude = 48.4625, Longitude = 35.0465, CountryId = 1, DistrictId = 16, RegionId = 16, CityId = 16, Address = "Сєвєродонецький краєзнавчий театр", ImageUrl = "images/attractions/Severodonetsk_Theater.jpg" },
            new Attraction { id = 50, Latitude = 48.4605, Longitude = 35.0445, CountryId = 1, DistrictId = 16, RegionId = 16, CityId = 16, Address = "Вулиця Миру, Сєвєродонецьк", ImageUrl = "images/attractions/Severodonetsk_MiruStreet.jpg" },

            // =================== Рівне ===================
            new Attraction { id = 51, Latitude = 48.6190, Longitude = 26.2520, CountryId = 1, DistrictId = 49, RegionId = 17, CityId = 17, Address = "Рівненський краєзнавчий музей", ImageUrl = "images/attractions/Rivne_RegionalMuseum.jpg" },
            new Attraction { id = 52, Latitude = 48.6205, Longitude = 26.2545, CountryId = 1, DistrictId = 49, RegionId = 17, CityId = 17, Address = "Парк ім. Шевченка, Рівне", ImageUrl = "images/attractions/Rivne_ShevchenkoPark.jpg" },
            new Attraction { id = 53, Latitude = 48.6180, Longitude = 26.2505, CountryId = 1, DistrictId = 49, RegionId = 17, CityId = 17, Address = "Музей бурштину, Рівне", ImageUrl = "images/attractions/Rivne_AmberMuseum.jpg" },
            new Attraction { id = 54, Latitude = 48.6210, Longitude = 26.2555, CountryId = 1, DistrictId = 49, RegionId = 17, CityId = 17, Address = "Площа Незалежності, Рівне", ImageUrl = "images/attractions/Rivne_IndependenceSquare.jpg" },
            new Attraction { id = 55, Latitude = 48.6175, Longitude = 26.2495, CountryId = 1, DistrictId = 49, RegionId = 17, CityId = 17, Address = "Вулиця Соборна, Рівне", ImageUrl = "images/attractions/Rivne_SobornaStreet.jpg" },

            // =================== Рівне (DistrictId = 50) ===================
            new Attraction { id = 56, Latitude = 48.6200, Longitude = 26.2550, CountryId = 1, DistrictId = 50, RegionId = 17, CityId = 17, Address = "Рівненський академічний український музично-драматичний театр", ImageUrl = "images/attractions/Rivne_Theater.jpg" },
            new Attraction { id = 57, Latitude = 48.6215, Longitude = 26.2570, CountryId = 1, DistrictId = 50, RegionId = 17, CityId = 17, Address = "Вулиця Соборна, Рівне", ImageUrl = "images/attractions/Rivne_SobornaStreet2.jpg" },
            new Attraction { id = 58, Latitude = 48.6185, Longitude = 26.2525, CountryId = 1, DistrictId = 50, RegionId = 17, CityId = 17, Address = "Рівненська обласна бібліотека", ImageUrl = "images/attractions/Rivne_Library.jpg" },
            new Attraction { id = 59, Latitude = 48.6195, Longitude = 26.2540, CountryId = 1, DistrictId = 50, RegionId = 17, CityId = 17, Address = "Парк Молоді, Рівне", ImageUrl = "images/attractions/Rivne_YouthPark.jpg" },
            new Attraction { id = 60, Latitude = 48.6170, Longitude = 26.2500, CountryId = 1, DistrictId = 50, RegionId = 17, CityId = 17, Address = "Рівненський академічний обласний театр ляльок", ImageUrl = "images/attractions/Rivne_PuppetTheater.jpg" },

            // =================== Луцьк (DistrictId = 52) ===================
            new Attraction { id = 61, Latitude = 49.8285, Longitude = 23.9425, CountryId = 1, DistrictId = 52, RegionId = 18, CityId = 18, Address = "Замок Любарта, Луцьк", ImageUrl = "images/attractions/Lutsk_LubartCastle.jpg" },
            new Attraction { id = 62, Latitude = 49.8290, Longitude = 23.9440, CountryId = 1, DistrictId = 52, RegionId = 18, CityId = 18, Address = "Вулиця Лесі Українки, Луцьк", ImageUrl = "images/attractions/Lutsk_LesiUkrainkyStreet.jpg" },
            new Attraction { id = 63, Latitude = 49.8275, Longitude = 23.9405, CountryId = 1, DistrictId = 52, RegionId = 18, CityId = 18, Address = "Луцький музей", ImageUrl = "images/attractions/Lutsk_Museum.jpg" },
            new Attraction { id = 64, Latitude = 49.8305, Longitude = 23.9455, CountryId = 1, DistrictId = 52, RegionId = 18, CityId = 18, Address = "Парк імені Лесі Українки, Луцьк", ImageUrl = "images/attractions/Lutsk_Park.jpg" },
            new Attraction { id = 65, Latitude = 49.8255, Longitude = 23.9355, CountryId = 1, DistrictId = 52, RegionId = 18, CityId = 18, Address = "Собор Святої Трійці, Луцьк", ImageUrl = "images/attractions/Lutsk_Cathedral.jpg" },

            // =================== Чернівці (DistrictId = 55) ===================
            new Attraction { id = 66, Latitude = 48.1550, Longitude = 23.5660, CountryId = 1, DistrictId = 55, RegionId = 19, CityId = 19, Address = "Чернівецький національний університет імені Юрія Федьковича", ImageUrl = "images/attractions/Chernivtsi_University.jpg" },
            new Attraction { id = 67, Latitude = 48.1565, Longitude = 23.5680, CountryId = 1, DistrictId = 55, RegionId = 19, CityId = 19, Address = "Вулиця Ольги Кобилянської, Чернівці", ImageUrl = "images/attractions/Chernivtsi_KobylianskaStreet.jpg" },
            new Attraction { id = 68, Latitude = 48.1540, Longitude = 23.5650, CountryId = 1, DistrictId = 55, RegionId = 19, CityId = 19, Address = "Площа Центральна, Чернівці", ImageUrl = "images/attractions/Chernivtsi_CentralSquare.jpg" },
            new Attraction { id = 69, Latitude = 48.1570, Longitude = 23.5705, CountryId = 1, DistrictId = 55, RegionId = 19, CityId = 19, Address = "Чернівецький обласний краєзнавчий музей", ImageUrl = "images/attractions/Chernivtsi_RegionalMuseum.jpg" },
            new Attraction { id = 70, Latitude = 48.1530, Longitude = 23.5635, CountryId = 1, DistrictId = 55, RegionId = 19, CityId = 19, Address = "Парк Жовтневий, Чернівці", ImageUrl = "images/attractions/Chernivtsi_Park.jpg" },

            // =================== Житомир (DistrictId = 58) ===================
            new Attraction { id = 71, Latitude = 50.0005, Longitude = 32.0010, CountryId = 1, DistrictId = 58, RegionId = 20, CityId = 20, Address = "Житомирський музей космонавтики", ImageUrl = "images/attractions/Zhytomyr_SpaceMuseum.jpg" },
            new Attraction { id = 72, Latitude = 50.0015, Longitude = 32.0030, CountryId = 1, DistrictId = 58, RegionId = 20, CityId = 20, Address = "Вулиця Михайлівська, Житомир", ImageUrl = "images/attractions/Zhytomyr_MykhailivskaStreet.jpg" },
            new Attraction { id = 73, Latitude = 49.9990, Longitude = 31.9995, CountryId = 1, DistrictId = 58, RegionId = 20, CityId = 20, Address = "Палац Культури, Житомир", ImageUrl = "images/attractions/Zhytomyr_PalaceOfCulture.jpg" },
            new Attraction { id = 74, Latitude = 50.0020, Longitude = 32.0040, CountryId = 1, DistrictId = 58, RegionId = 20, CityId = 20, Address = "Собор Святої Софії, Житомир", ImageUrl = "images/attractions/Zhytomyr_Cathedral.jpg" },
            new Attraction { id = 75, Latitude = 49.9980, Longitude = 31.9985, CountryId = 1, DistrictId = 58, RegionId = 20, CityId = 20, Address = "Парк ім. Юрія Гагаріна, Житомир", ImageUrl = "images/attractions/Zhytomyr_Park.jpg" },

            // =================== Житомир (DistrictId = 59) ===================
            new Attraction { id = 76, Latitude = 50.0035, Longitude = 32.0060, CountryId = 1, DistrictId = 59, RegionId = 20, CityId = 20, Address = "Житомирський обласний художній музей", ImageUrl = "images/attractions/Zhytomyr_ArtMuseum.jpg" },
            new Attraction { id = 77, Latitude = 50.0040, Longitude = 32.0075, CountryId = 1, DistrictId = 59, RegionId = 20, CityId = 20, Address = "Вулиця Київська, Житомир", ImageUrl = "images/attractions/Zhytomyr_KyivskaStreet.jpg" },
            new Attraction { id = 78, Latitude = 49.9975, Longitude = 31.9970, CountryId = 1, DistrictId = 59, RegionId = 20, CityId = 20, Address = "Музей історії міста Житомир", ImageUrl = "images/attractions/Zhytomyr_HistoryMuseum.jpg" },
            new Attraction { id = 79, Latitude = 50.0010, Longitude = 32.0025, CountryId = 1, DistrictId = 59, RegionId = 20, CityId = 20, Address = "Житомирський ботанічний сад", ImageUrl = "images/attractions/Zhytomyr_BotanicalGarden.jpg" },
            new Attraction { id = 80, Latitude = 49.9960, Longitude = 31.9960, CountryId = 1, DistrictId = 59, RegionId = 20, CityId = 20, Address = "Стадіон 'Полісся', Житомир", ImageUrl = "images/attractions/Zhytomyr_Stadium.jpg" },

            // =================== Суми (DistrictId = 61) ===================
            new Attraction { id = 81, Latitude = 50.0055, Longitude = 36.2320, CountryId = 1, DistrictId = 61, RegionId = 21, CityId = 21, Address = "Сумський академічний театр драми та музичної комедії", ImageUrl = "images/attractions/Sumy_Theater.jpg" },
            new Attraction { id = 82, Latitude = 50.0060, Longitude = 36.2335, CountryId = 1, DistrictId = 61, RegionId = 21, CityId = 21, Address = "Вулиця Воскресенська, Суми", ImageUrl = "images/attractions/Sumy_VoskresenskaStreet.jpg" },
            new Attraction { id = 83, Latitude = 50.0040, Longitude = 36.2300, CountryId = 1, DistrictId = 61, RegionId = 21, CityId = 21, Address = "Сумський обласний художній музей", ImageUrl = "images/attractions/Sumy_ArtMuseum.jpg" },
            new Attraction { id = 84, Latitude = 50.0070, Longitude = 36.2350, CountryId = 1, DistrictId = 61, RegionId = 21, CityId = 21, Address = "Парк ім. Кожедуба, Суми", ImageUrl = "images/attractions/Sumy_Park.jpg" },
            new Attraction { id = 85, Latitude = 50.0030, Longitude = 36.2280, CountryId = 1, DistrictId = 61, RegionId = 21, CityId = 21, Address = "Сумська обласна філармонія", ImageUrl = "images/attractions/Sumy_Philharmonic.jpg" },

            // =================== Кропивницький (DistrictId = 64) ===================
            new Attraction { id = 86, Latitude = 48.5005, Longitude = 32.2610, CountryId = 1, DistrictId = 64, RegionId = 22, CityId = 22, Address = "Кіровоградський обласний художній музей", ImageUrl = "images/attractions/Kropyvnytskyi_ArtMuseum.jpg" },
            new Attraction { id = 87, Latitude = 48.5015, Longitude = 32.2625, CountryId = 1, DistrictId = 64, RegionId = 22, CityId = 22, Address = "Вулиця Велика Перспективна, Кропивницький", ImageUrl = "images/attractions/Kropyvnytskyi_VelykaPerspektyvna.jpg" },
            new Attraction { id = 88, Latitude = 48.4990, Longitude = 32.2595, CountryId = 1, DistrictId = 64, RegionId = 22, CityId = 22, Address = "Кіровоградський академічний театр ім. М. Кропивницького", ImageUrl = "images/attractions/Kropyvnytskyi_Theater.jpg" },
            new Attraction { id = 89, Latitude = 48.5020, Longitude = 32.2630, CountryId = 1, DistrictId = 64, RegionId = 22, CityId = 22, Address = "Парк Ковалівський, Кропивницький", ImageUrl = "images/attractions/Kropyvnytskyi_Park.jpg" },
            new Attraction { id = 90, Latitude = 48.4980, Longitude = 32.2580, CountryId = 1, DistrictId = 64, RegionId = 22, CityId = 22, Address = "Музей історії міста Кропивницький", ImageUrl = "images/attractions/Kropyvnytskyi_HistoryMuseum.jpg" },

            // =================== Вінниця (DistrictId = 67) ===================
            new Attraction { id = 91, Latitude = 49.2335, Longitude = 28.4685, CountryId = 1, DistrictId = 67, RegionId = 23, CityId = 23, Address = "Вінницький державний академічний музично-драматичний театр ім. Садовського", ImageUrl = "images/attractions/Vinnytsia_Theater.jpg" },
            new Attraction { id = 92, Latitude = 49.2345, Longitude = 28.4695, CountryId = 1, DistrictId = 67, RegionId = 23, CityId = 23, Address = "Вулиця Соборна, Вінниця", ImageUrl = "images/attractions/Vinnytsia_SobornaStreet.jpg" },
            new Attraction { id = 93, Latitude = 49.2320, Longitude = 28.4670, CountryId = 1, DistrictId = 67, RegionId = 23, CityId = 23, Address = "Вінницький музей-садиба Миколи Пирогова", ImageUrl = "images/attractions/Vinnytsia_PyrohovMuseum.jpg" },
            new Attraction { id = 94, Latitude = 49.2355, Longitude = 28.4705, CountryId = 1, DistrictId = 67, RegionId = 23, CityId = 23, Address = "Парк ім. Леонтовича, Вінниця", ImageUrl = "images/attractions/Vinnytsia_Park.jpg" },
            new Attraction { id = 95, Latitude = 49.2310, Longitude = 28.4660, CountryId = 1, DistrictId = 67, RegionId = 23, CityId = 23, Address = "Вінницький обласний краєзнавчий музей", ImageUrl = "images/attractions/Vinnytsia_RegionalMuseum.jpg" },

            // =================== Харків (DistrictId = 70) ===================
            new Attraction { id = 96, Latitude = 50.0055, Longitude = 36.2320, CountryId = 1, DistrictId = 70, RegionId = 24, CityId = 24, Address = "Харківський національний академічний театр опери та балету", ImageUrl = "images/attractions/Kharkiv_Opera.jpg" },
            new Attraction { id = 97, Latitude = 50.0065, Longitude = 36.2335, CountryId = 1, DistrictId = 70, RegionId = 24, CityId = 24, Address = "Площа Свободи, Харків", ImageUrl = "images/attractions/Kharkiv_FreedomSquare.jpg" },
            new Attraction { id = 98, Latitude = 50.0040, Longitude = 36.2305, CountryId = 1, DistrictId = 70, RegionId = 24, CityId = 24, Address = "Харківський художній музей", ImageUrl = "images/attractions/Kharkiv_ArtMuseum.jpg" },
            new Attraction { id = 99, Latitude = 50.0070, Longitude = 36.2350, CountryId = 1, DistrictId = 70, RegionId = 24, CityId = 24, Address = "Парк Горького, Харків", ImageUrl = "images/attractions/Kharkiv_GorkyPark.jpg" },
            new Attraction { id = 100, Latitude = 50.0030, Longitude = 36.2280, CountryId = 1, DistrictId = 70, RegionId = 24, CityId = 24, Address = "Харківський історичний музей", ImageUrl = "images/attractions/Kharkiv_HistoryMuseum.jpg" },

            // =================== Харків (DistrictId = 71) ===================
            new Attraction { id = 101, Latitude = 50.0105, Longitude = 36.2360, CountryId = 1, DistrictId = 71, RegionId = 24, CityId = 24, Address = "Харківський державний цирк", ImageUrl = "images/attractions/Kharkiv_Circus.jpg" },
            new Attraction { id = 102, Latitude = 50.0110, Longitude = 36.2375, CountryId = 1, DistrictId = 71, RegionId = 24, CityId = 24, Address = "Вулиця Сумська, Харків", ImageUrl = "images/attractions/Kharkiv_SumskaStreet.jpg" },
            new Attraction { id = 103, Latitude = 50.0090, Longitude = 36.2340, CountryId = 1, DistrictId = 71, RegionId = 24, CityId = 24, Address = "Харківський планетарій", ImageUrl = "images/attractions/Kharkiv_Planetarium.jpg" },
            new Attraction { id = 104, Latitude = 50.0120, Longitude = 36.2380, CountryId = 1, DistrictId = 71, RegionId = 24, CityId = 24, Address = "Парк імені Т.Г. Шевченка, Харків", ImageUrl = "images/attractions/Kharkiv_ShevchenkoPark.jpg" },
            new Attraction { id = 105, Latitude = 50.0080, Longitude = 36.2330, CountryId = 1, DistrictId = 71, RegionId = 24, CityId = 24, Address = "Харківський літературний музей", ImageUrl = "images/attractions/Kharkiv_LiteraryMuseum.jpg" },

            // =================== Харків (DistrictId = 72) ===================
            new Attraction { id = 106, Latitude = 50.0005, Longitude = 36.2260, CountryId = 1, DistrictId = 72, RegionId = 24, CityId = 24, Address = "Харківський зоопарк", ImageUrl = "images/attractions/Kharkiv_Zoo.jpg" },
            new Attraction { id = 107, Latitude = 50.0015, Longitude = 36.2275, CountryId = 1, DistrictId = 72, RegionId = 24, CityId = 24, Address = "Вулиця Пушкінська, Харків", ImageUrl = "images/attractions/Kharkiv_PushkinskaStreet.jpg" },
            new Attraction { id = 108, Latitude = 49.9990, Longitude = 36.2240, CountryId = 1, DistrictId = 72, RegionId = 24, CityId = 24, Address = "Харківський історичний парк", ImageUrl = "images/attractions/Kharkiv_HistoryPark.jpg" },
            new Attraction { id = 109, Latitude = 50.0020, Longitude = 36.2280, CountryId = 1, DistrictId = 72, RegionId = 24, CityId = 24, Address = "Палац студентів ХНУ ім. Каразіна", ImageUrl = "images/attractions/Kharkiv_StudentPalace.jpg" },
            new Attraction { id = 110, Latitude = 49.9980, Longitude = 36.2230, CountryId = 1, DistrictId = 72, RegionId = 24, CityId = 24, Address = "Харківський обласний музей природи", ImageUrl = "images/attractions/Kharkiv_NatureMuseum.jpg" }

            // // USA - New York
            // new Attraction { id = 1, Latitude = 40.6892, Longitude = -74.0445, CountryId = 1, DistrictId = 1, RegionId = 1, CityId = 1, Address = "Attraction 1" },
            // new Attraction { id = 2, Latitude = 40.7851, Longitude = -73.9683, CountryId = 1, DistrictId = 1, RegionId = 1, CityId = 1, Address = "Attraction 2" },
            // new Attraction { id = 3, Latitude = 40.7580, Longitude = -73.9855, CountryId = 1, DistrictId = 1, RegionId = 1, CityId = 1, Address = "Attraction 3" },
            // new Attraction { id = 4, Latitude = 40.7061, Longitude = -73.9969, CountryId = 1, DistrictId = 2, RegionId = 1, CityId = 1, Address = "Attraction 4" },
            // new Attraction { id = 5, Latitude = 40.7484, Longitude = -73.9857, CountryId = 1, DistrictId = 3, RegionId = 1, CityId = 1, Address = "Attraction 5" },

            // // USA - Los Angeles
            // new Attraction { id = 6, Latitude = 34.1341, Longitude = -118.3215, CountryId = 1, DistrictId = 4, RegionId = 2, CityId = 2, Address = "Attraction 6" },
            // new Attraction { id = 7, Latitude = 34.0094, Longitude = -118.4973, CountryId = 1, DistrictId = 5, RegionId = 2, CityId = 2, Address = "Attraction 7" },
            // new Attraction { id = 8, Latitude = 34.1184, Longitude = -118.3004, CountryId = 1, DistrictId = 4, RegionId = 2, CityId = 2, Address = "Attraction 8" },
            // new Attraction { id = 9, Latitude = 34.0780, Longitude = -118.4741, CountryId = 1, DistrictId = 5, RegionId = 2, CityId = 2, Address = "Attraction 9" },
            // new Attraction { id = 10, Latitude = 33.9850, Longitude = -118.4695, CountryId = 1, DistrictId = 6, RegionId = 2, CityId = 2, Address = "Attraction 10" },

            // // USA - Chicago
            // new Attraction { id = 11, Latitude = 41.8826, Longitude = -87.6226, CountryId = 1, DistrictId = 7, RegionId = 3, CityId = 3, Address = "Attraction 11" },
            // new Attraction { id = 12, Latitude = 41.8796, Longitude = -87.6237, CountryId = 1, DistrictId = 7, RegionId = 3, CityId = 3, Address = "Attraction 12" },
            // new Attraction { id = 13, Latitude = 41.8917, Longitude = -87.6075, CountryId = 1, DistrictId = 8, RegionId = 3, CityId = 3, Address = "Attraction 13" },
            // new Attraction { id = 14, Latitude = 41.8789, Longitude = -87.6359, CountryId = 1, DistrictId = 9, RegionId = 3, CityId = 3, Address = "Attraction 14" },
            // new Attraction { id = 15, Latitude = 41.9210, Longitude = -87.6338, CountryId = 1, DistrictId = 8, RegionId = 3, CityId = 3, Address = "Attraction 15" },

            // // Germany - Berlin
            // new Attraction { id = 16, Latitude = 52.5163, Longitude = 13.3777, CountryId = 2, DistrictId = 10, RegionId = 4, CityId = 4, Address = "Attraction 16" },
            // new Attraction { id = 17, Latitude = 52.5351, Longitude = 13.3903, CountryId = 2, DistrictId = 11, RegionId = 4, CityId = 4, Address = "Attraction 17" },
            // new Attraction { id = 18, Latitude = 52.5169, Longitude = 13.4010, CountryId = 2, DistrictId = 10, RegionId = 4, CityId = 4, Address = "Attraction 18" },
            // new Attraction { id = 19, Latitude = 52.5218, Longitude = 13.4132, CountryId = 2, DistrictId = 11, RegionId = 4, CityId = 4, Address = "Attraction 19" },
            // new Attraction { id = 20, Latitude = 52.5076, Longitude = 13.3904, CountryId = 2, DistrictId = 12, RegionId = 4, CityId = 4, Address = "Attraction 20" },

            // // Germany - Munich
            // new Attraction { id = 21, Latitude = 48.1374, Longitude = 11.5755, CountryId = 2, DistrictId = 13, RegionId = 5, CityId = 5, Address = "Attraction 21" },
            // new Attraction { id = 22, Latitude = 48.1593, Longitude = 11.6035, CountryId = 2, DistrictId = 14, RegionId = 5, CityId = 5, Address = "Attraction 22" },
            // new Attraction { id = 23, Latitude = 48.1580, Longitude = 11.5031, CountryId = 2, DistrictId = 13, RegionId = 5, CityId = 5, Address = "Attraction 23" },
            // new Attraction { id = 24, Latitude = 48.1769, Longitude = 11.5560, CountryId = 2, DistrictId = 14, RegionId = 5, CityId = 5, Address = "Attraction 24" },
            // new Attraction { id = 25, Latitude = 48.1740, Longitude = 11.5560, CountryId = 2, DistrictId = 15, RegionId = 5, CityId = 5, Address = "Attraction 25" },

            // // Germany - Hamburg
            // new Attraction { id = 26, Latitude = 53.5436, Longitude = 9.9886, CountryId = 2, DistrictId = 16, RegionId = 6, CityId = 6, Address = "Attraction 26" },
            // new Attraction { id = 27, Latitude = 53.5413, Longitude = 9.9666, CountryId = 2, DistrictId = 17, RegionId = 6, CityId = 6, Address = "Attraction 27" },
            // new Attraction { id = 28, Latitude = 53.5413, Longitude = 9.9841, CountryId = 2, DistrictId = 16, RegionId = 6, CityId = 6, Address = "Attraction 28" },
            // new Attraction { id = 29, Latitude = 53.5503, Longitude = 9.9729, CountryId = 2, DistrictId = 18, RegionId = 6, CityId = 6, Address = "Attraction 29" },
            // new Attraction { id = 30, Latitude = 53.5496, Longitude = 9.9882, CountryId = 2, DistrictId = 16, RegionId = 6, CityId = 6, Address = "Attraction 30" },


            //// France - Paris
            //new Attraction { id = 31, Latitude = 48.8584, Longitude = 2.2945, CountryId = 3, DistrictId = 19, RegionId = 7, CityId = 7, Address = "Attraction 31" },
            //new Attraction { id = 32, Latitude = 48.8606, Longitude = 2.3376, CountryId = 3, DistrictId = 20, RegionId = 7, CityId = 7, Address = "Attraction 32" },
            //new Attraction { id = 33, Latitude = 48.8530, Longitude = 2.3499, CountryId = 3, DistrictId = 19, RegionId = 7, CityId = 7, Address = "Attraction 33" },
            //new Attraction { id = 34, Latitude = 48.8867, Longitude = 2.3431, CountryId = 3, DistrictId = 19, RegionId = 7, CityId = 7, Address = "Attraction 34" },
            //new Attraction { id = 35, Latitude = 48.8698, Longitude = 2.3070, CountryId = 3, DistrictId = 20, RegionId = 7, CityId = 7, Address = "Attraction 35" },

            //// France - Lyon
            //new Attraction { id = 36, Latitude = 45.7620, Longitude = 4.8221, CountryId = 3, DistrictId = 22, RegionId = 8, CityId = 8, Address = "Attraction 36" },
            //new Attraction { id = 37, Latitude = 45.7793, Longitude = 4.8520, CountryId = 3, DistrictId = 23, RegionId = 8, CityId = 8, Address = "Attraction 37" },
            //new Attraction { id = 38, Latitude = 45.7670, Longitude = 4.8270, CountryId = 3, DistrictId = 22, RegionId = 8, CityId = 8, Address = "Attraction 38" },
            //new Attraction { id = 39, Latitude = 45.7670, Longitude = 4.8330, CountryId = 3, DistrictId = 23, RegionId = 8, CityId = 8, Address = "Attraction 39" },
            //new Attraction { id = 40, Latitude = 45.7578, Longitude = 4.8320, CountryId = 3, DistrictId = 24, RegionId = 8, CityId = 8, Address = "Attraction 40" },

            //// France - Marseille
            //new Attraction { id = 41, Latitude = 43.2965, Longitude = 5.3698, CountryId = 3, DistrictId = 25, RegionId = 9, CityId = 9, Address = "Attraction 41" },
            //new Attraction { id = 42, Latitude = 43.2961, Longitude = 5.3624, CountryId = 3, DistrictId = 26, RegionId = 9, CityId = 9, Address = "Attraction 42" },
            //new Attraction { id = 43, Latitude = 43.2950, Longitude = 5.3270, CountryId = 3, DistrictId = 25, RegionId = 9, CityId = 9, Address = "Attraction 43" },
            //new Attraction { id = 44, Latitude = 43.2960, Longitude = 5.3790, CountryId = 3, DistrictId = 26, RegionId = 9, CityId = 9, Address = "Attraction 44" },
            //new Attraction { id = 45, Latitude = 43.2968, Longitude = 5.3892, CountryId = 3, DistrictId = 27, RegionId = 9, CityId = 9, Address = "Attraction 45" },

            //// United Kingdom - London
            //new Attraction { id = 46, Latitude = 51.5081, Longitude = -0.0759, CountryId = 4, DistrictId = 28, RegionId = 10, CityId = 10, Address = "Attraction 46" },
            //new Attraction { id = 47, Latitude = 51.5014, Longitude = -0.1419, CountryId = 4, DistrictId = 29, RegionId = 10, CityId = 10, Address = "Attraction 47" },
            //new Attraction { id = 48, Latitude = 51.5033, Longitude = -0.1195, CountryId = 4, DistrictId = 28, RegionId = 10, CityId = 10, Address = "Attraction 48" },
            //new Attraction { id = 49, Latitude = 51.5194, Longitude = -0.1269, CountryId = 4, DistrictId = 30, RegionId = 10, CityId = 10, Address = "Attraction 49" },
            //new Attraction { id = 50, Latitude = 51.5007, Longitude = -0.1246, CountryId = 4, DistrictId = 29, RegionId = 10, CityId = 10, Address = "Attraction 50" },

            //// United Kingdom - Manchester
            //new Attraction { id = 51, Latitude = 53.4631, Longitude = -2.2913, CountryId = 4, DistrictId = 31, RegionId = 11, CityId = 11, Address = "Attraction 51" },
            //new Attraction { id = 52, Latitude = 53.4869, Longitude = -2.2466, CountryId = 4, DistrictId = 32, RegionId = 11, CityId = 11, Address = "Attraction 52" },
            //new Attraction { id = 53, Latitude = 53.4772, Longitude = -2.2550, CountryId = 4, DistrictId = 31, RegionId = 11, CityId = 11, Address = "Attraction 53" },
            //new Attraction { id = 54, Latitude = 53.4811, Longitude = -2.2461, CountryId = 4, DistrictId = 32, RegionId = 11, CityId = 11, Address = "Attraction 54" },
            //new Attraction { id = 55, Latitude = 53.5485, Longitude = -2.2185, CountryId = 4, DistrictId = 33, RegionId = 11, CityId = 11, Address = "Attraction 55" },

            //// United Kingdom - Birmingham
            //new Attraction { id = 56, Latitude = 52.4797, Longitude = -1.9020, CountryId = 4, DistrictId = 34, RegionId = 12, CityId = 12, Address = "Attraction 56" },
            //new Attraction { id = 57, Latitude = 52.4862, Longitude = -1.9470, CountryId = 4, DistrictId = 35, RegionId = 12, CityId = 12, Address = "Attraction 57" },
            //new Attraction { id = 58, Latitude = 52.4626, Longitude = -1.8920, CountryId = 4, DistrictId = 36, RegionId = 12, CityId = 12, Address = "Attraction 58" },
            //new Attraction { id = 59, Latitude = 52.4762, Longitude = -1.8931, CountryId = 4, DistrictId = 34, RegionId = 12, CityId = 12, Address = "Attraction 59" },
            //new Attraction { id = 60, Latitude = 52.4786, Longitude = -1.9101, CountryId = 4, DistrictId = 35, RegionId = 12, CityId = 12, Address = "Attraction 60" },

            //// Spain - Madrid
            //new Attraction { id = 61, Latitude = 40.4179, Longitude = -3.7143, CountryId = 5, DistrictId = 37, RegionId = 13, CityId = 13, Address = "Attraction 61" },
            //new Attraction { id = 62, Latitude = 40.4168, Longitude = -3.7038, CountryId = 5, DistrictId = 38, RegionId = 13, CityId = 13, Address = "Attraction 62" },
            //new Attraction { id = 63, Latitude = 40.4155, Longitude = -3.7074, CountryId = 5, DistrictId = 37, RegionId = 13, CityId = 13, Address = "Attraction 63" },
            //new Attraction { id = 64, Latitude = 40.4153, Longitude = -3.6846, CountryId = 5, DistrictId = 38, RegionId = 13, CityId = 13, Address = "Attraction 64" },
            //new Attraction { id = 65, Latitude = 40.4240, Longitude = -3.7170, CountryId = 5, DistrictId = 39, RegionId = 13, CityId = 13, Address = "Attraction 65" },

            //// Spain - Barcelona
            //new Attraction { id = 66, Latitude = 41.4036, Longitude = 2.1744, CountryId = 5, DistrictId = 40, RegionId = 14, CityId = 14, Address = "Attraction 66" },
            //new Attraction { id = 67, Latitude = 41.4145, Longitude = 2.1527, CountryId = 5, DistrictId = 41, RegionId = 14, CityId = 14, Address = "Attraction 67" },
            //new Attraction { id = 68, Latitude = 41.3809, Longitude = 2.1730, CountryId = 5, DistrictId = 40, RegionId = 14, CityId = 14, Address = "Attraction 68" },
            //new Attraction { id = 69, Latitude = 41.3917, Longitude = 2.1649, CountryId = 5, DistrictId = 41, RegionId = 14, CityId = 14, Address = "Attraction 69" },
            //new Attraction { id = 70, Latitude = 41.3633, Longitude = 2.1583, CountryId = 5, DistrictId = 42, RegionId = 14, CityId = 14, Address = "Attraction 70" },

            //// Spain - Valencia
            //new Attraction { id = 71, Latitude = 39.4540, Longitude = -0.3510, CountryId = 5, DistrictId = 43, RegionId = 15, CityId = 15, Address = "Attraction 71" },
            //new Attraction { id = 72, Latitude = 39.4753, Longitude = -0.3768, CountryId = 5, DistrictId = 44, RegionId = 15, CityId = 15, Address = "Attraction 72" },
            //new Attraction { id = 73, Latitude = 39.4546, Longitude = -0.3415, CountryId = 5, DistrictId = 43, RegionId = 15, CityId = 15, Address = "Attraction 73" },
            //new Attraction { id = 74, Latitude = 39.4699, Longitude = -0.3753, CountryId = 5, DistrictId = 44, RegionId = 15, CityId = 15, Address = "Attraction 74" },
            //new Attraction { id = 75, Latitude = 39.4747, Longitude = -0.3763, CountryId = 5, DistrictId = 45, RegionId = 15, CityId = 15, Address = "Attraction 75" },

            //// Poland - Warsaw
            //new Attraction { id = 76, Latitude = 52.2450, Longitude = 21.0166, CountryId = 6, DistrictId = 46, RegionId = 16, CityId = 16, Address = "Attraction 76" },
            //new Attraction { id = 77, Latitude = 52.2167, Longitude = 21.0333, CountryId = 6, DistrictId = 47, RegionId = 16, CityId = 16, Address = "Attraction 77" },
            //new Attraction { id = 78, Latitude = 52.2319, Longitude = 21.0067, CountryId = 6, DistrictId = 46, RegionId = 16, CityId = 16, Address = "Attraction 78" },
            //new Attraction { id = 79, Latitude = 52.2490, Longitude = 21.0122, CountryId = 6, DistrictId = 47, RegionId = 16, CityId = 16, Address = "Attraction 79" },
            //new Attraction { id = 80, Latitude = 52.1919, Longitude = 21.0609, CountryId = 6, DistrictId = 48, RegionId = 16, CityId = 16, Address = "Attraction 80" },

            //// Poland - Krakow
            //new Attraction { id = 81, Latitude = 50.0614, Longitude = 19.9372, CountryId = 6, DistrictId = 49, RegionId = 17, CityId = 17, Address = "Attraction 81" },
            //new Attraction { id = 82, Latitude = 50.0647, Longitude = 19.9450, CountryId = 6, DistrictId = 50, RegionId = 17, CityId = 17, Address = "Attraction 82" },
            //new Attraction { id = 83, Latitude = 50.0677, Longitude = 19.9401, CountryId = 6, DistrictId = 49, RegionId = 17, CityId = 17, Address = "Attraction 83" },
            //new Attraction { id = 84, Latitude = 50.0622, Longitude = 19.9367, CountryId = 6, DistrictId = 50, RegionId = 17, CityId = 17, Address = "Attraction 84" },
            //new Attraction { id = 85, Latitude = 50.0590, Longitude = 19.9451, CountryId = 6, DistrictId = 51, RegionId = 17, CityId = 17, Address = "Attraction 85" },

            //// Poland - Gdansk
            //new Attraction { id = 86, Latitude = 54.3520, Longitude = 18.6466, CountryId = 6, DistrictId = 52, RegionId = 18, CityId = 18, Address = "Attraction 86" },
            //new Attraction { id = 87, Latitude = 54.3510, Longitude = 18.6460, CountryId = 6, DistrictId = 53, RegionId = 18, CityId = 18, Address = "Attraction 87" },
            //new Attraction { id = 88, Latitude = 54.3540, Longitude = 18.6500, CountryId = 6, DistrictId = 52, RegionId = 18, CityId = 18, Address = "Attraction 88" },
            //new Attraction { id = 89, Latitude = 54.3480, Longitude = 18.6500, CountryId = 6, DistrictId = 53, RegionId = 18, CityId = 18, Address = "Attraction 89" },
            //new Attraction { id = 90, Latitude = 54.3500, Longitude = 18.6450, CountryId = 6, DistrictId = 54, RegionId = 18, CityId = 18, Address = "Attraction 90" },


            //// Poland - Poznan 
            //new Attraction { id = 91, Latitude = 52.4230, Longitude = 16.8790, CountryId = 6, DistrictId = 55, RegionId = 19, CityId = 19, Address = "Attraction 91" },
            //new Attraction { id = 92, Latitude = 52.4215, Longitude = 16.8775, CountryId = 6, DistrictId = 55, RegionId = 19, CityId = 19, Address = "Attraction 92" },
            //new Attraction { id = 93, Latitude = 52.4240, Longitude = 16.8805, CountryId = 6, DistrictId = 56, RegionId = 19, CityId = 19, Address = "Attraction 93" },
            //new Attraction { id = 94, Latitude = 52.4200, Longitude = 16.8760, CountryId = 6, DistrictId = 56, RegionId = 19, CityId = 19, Address = "Attraction 94" },
            //new Attraction { id = 95, Latitude = 52.4250, Longitude = 16.8820, CountryId = 6, DistrictId = 57, RegionId = 19, CityId = 19, Address = "Attraction 95" },
            //new Attraction { id = 96, Latitude = 52.4190, Longitude = 16.8750, CountryId = 6, DistrictId = 57, RegionId = 19, CityId = 19, Address = "Attraction 96" }
            );
        }
    }
}
