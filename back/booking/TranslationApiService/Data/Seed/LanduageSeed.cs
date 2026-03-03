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
// Kyiv (city with special status)
new RegionTranslation { id = 1, EntityId = 1, Lang = "en", Title = "Kyiv" },
new RegionTranslation { id = 2, EntityId = 1, Lang = "uk", Title = "Київ" },

// 1
new RegionTranslation { id = 3, EntityId = 2, Lang = "en", Title = "Vinnytsia Oblast" },
new RegionTranslation { id = 4, EntityId = 2, Lang = "uk", Title = "Вінницька область" },

// 2
new RegionTranslation { id = 5, EntityId = 3, Lang = "en", Title = "Volyn Oblast" },
new RegionTranslation { id = 6, EntityId = 3, Lang = "uk", Title = "Волинська область" },

// 3
new RegionTranslation { id = 7, EntityId = 4, Lang = "en", Title = "Dnipropetrovsk Oblast" },
new RegionTranslation { id = 8, EntityId = 4, Lang = "uk", Title = "Дніпропетровська область" },

// 4
new RegionTranslation { id = 9, EntityId = 5, Lang = "en", Title = "Donetsk Oblast" },
new RegionTranslation { id = 10, EntityId = 5, Lang = "uk", Title = "Донецька область" },

// 5
new RegionTranslation { id = 11, EntityId = 6, Lang = "en", Title = "Zhytomyr Oblast" },
new RegionTranslation { id = 12, EntityId = 6, Lang = "uk", Title = "Житомирська область" },

// 6
new RegionTranslation { id = 13, EntityId = 7, Lang = "en", Title = "Zakarpattia Oblast" },
new RegionTranslation { id = 14, EntityId = 7, Lang = "uk", Title = "Закарпатська область" },

// 7
new RegionTranslation { id = 15, EntityId = 8, Lang = "en", Title = "Zaporizhzhia Oblast" },
new RegionTranslation { id = 16, EntityId = 8, Lang = "uk", Title = "Запорізька область" },

// 8
new RegionTranslation { id = 17, EntityId = 9, Lang = "en", Title = "Ivano-Frankivsk Oblast" },
new RegionTranslation { id = 18, EntityId = 9, Lang = "uk", Title = "Івано-Франківська область" },

// 9
new RegionTranslation { id = 19, EntityId = 10, Lang = "en", Title = "Kyiv Oblast" },
new RegionTranslation { id = 20, EntityId = 10, Lang = "uk", Title = "Київська область" },

// 10
new RegionTranslation { id = 21, EntityId = 11, Lang = "en", Title = "Kirovohrad Oblast" },
new RegionTranslation { id = 22, EntityId = 11, Lang = "uk", Title = "Кіровоградська область" },

// 11
new RegionTranslation { id = 23, EntityId = 12, Lang = "en", Title = "Luhansk Oblast" },
new RegionTranslation { id = 24, EntityId = 12, Lang = "uk", Title = "Луганська область" },

// 12
new RegionTranslation { id = 25, EntityId = 13, Lang = "en", Title = "Lviv Oblast" },
new RegionTranslation { id = 26, EntityId = 13, Lang = "uk", Title = "Львівська область" },

// 13
new RegionTranslation { id = 27, EntityId = 14, Lang = "en", Title = "Mykolaiv Oblast" },
new RegionTranslation { id = 28, EntityId = 14, Lang = "uk", Title = "Миколаївська область" },

// 14
new RegionTranslation { id = 29, EntityId = 15, Lang = "en", Title = "Odesa Oblast" },
new RegionTranslation { id = 30, EntityId = 15, Lang = "uk", Title = "Одеська область" },

// 15
new RegionTranslation { id = 31, EntityId = 16, Lang = "en", Title = "Poltava Oblast" },
new RegionTranslation { id = 32, EntityId = 16, Lang = "uk", Title = "Полтавська область" },

// 16
new RegionTranslation { id = 33, EntityId = 17, Lang = "en", Title = "Rivne Oblast" },
new RegionTranslation { id = 34, EntityId = 17, Lang = "uk", Title = "Рівненська область" },

// 17
new RegionTranslation { id = 35, EntityId = 18, Lang = "en", Title = "Sumy Oblast" },
new RegionTranslation { id = 36, EntityId = 18, Lang = "uk", Title = "Сумська область" },

// 18
new RegionTranslation { id = 37, EntityId = 19, Lang = "en", Title = "Ternopil Oblast" },
new RegionTranslation { id = 38, EntityId = 19, Lang = "uk", Title = "Тернопільська область" },

// 19
new RegionTranslation { id = 39, EntityId = 20, Lang = "en", Title = "Kharkiv Oblast" },
new RegionTranslation { id = 40, EntityId = 20, Lang = "uk", Title = "Харківська область" },

// 20
new RegionTranslation { id = 41, EntityId = 21, Lang = "en", Title = "Kherson Oblast" },
new RegionTranslation { id = 42, EntityId = 21, Lang = "uk", Title = "Херсонська область" },

// 21
new RegionTranslation { id = 43, EntityId = 22, Lang = "en", Title = "Khmelnytskyi Oblast" },
new RegionTranslation { id = 44, EntityId = 22, Lang = "uk", Title = "Хмельницька область" },

// 22
new RegionTranslation { id = 45, EntityId = 23, Lang = "en", Title = "Cherkasy Oblast" },
new RegionTranslation { id = 46, EntityId = 23, Lang = "uk", Title = "Черкаська область" },

// 23
new RegionTranslation { id = 47, EntityId = 24, Lang = "en", Title = "Chernivtsi Oblast" },
new RegionTranslation { id = 48, EntityId = 24, Lang = "uk", Title = "Чернівецька область" },

// 24
new RegionTranslation { id = 49, EntityId = 25, Lang = "en", Title = "Chernihiv Oblast" },
new RegionTranslation { id = 50, EntityId = 25, Lang = "uk", Title = "Чернігівська область" },


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
// =================== Україна ===================
new CityTranslation
{
    id = 1,
    EntityId = 1,
    Lang = "uk",
    Title = "Київ",
    Slug = "Kyiv",
    Description = "На території міста знаходиться близько 20 різних парків та зелених зон, 16 природних пам'яток та 2 ботанічні сади. У Києві зосереджено численні архітектурні пам'ятки, важливі для культури України.",
    History = "Київ є одним із найстаріших міст Східної Європи, заснований у V–VI століттях. Історично столиця Київської Русі, центр політичного, економічного та культурного життя України."
},

new CityTranslation
{
    id = 2,
    EntityId = 1,
    Lang = "en",
    Title = "Kyiv",
    Slug = "Kyiv",
    Description = "The city has about 20 different parks and green areas, 16 natural monuments, and 2 botanical gardens. Kyiv hosts numerous architectural landmarks important for Ukraine's culture.",
    History = "Kyiv is one of the oldest cities in Eastern Europe, founded in the 5th–6th centuries. Historically the capital of Kievan Rus', it is the center of political, economic, and cultural life of Ukraine."
},

//--------------------Вінницька область---------------------------------------
new CityTranslation
{
    id = 3,
    EntityId = 2,
    Lang = "uk",
    Title = "Вінниця",
    Slug = "Vinnytsia",
    Description = "На території міста знаходиться близько 20 різних парків та зелених зон, 16 природних пам'яток та 2 ботанічні сади.",
    History = "Вінниця вперше згадується у писемних джерелах у XIV столітті. Місто розвивалося як важливий торговий та адміністративний центр Поділля."
},

new CityTranslation
{
    id = 4,
    EntityId = 2,
    Lang = "en",
    Title = "Vinnytsia",
    Slug = "Vinnytsia",
    Description = "The city has about 20 parks and green areas, 16 natural monuments, and 2 botanical gardens.",
    History = "Vinnytsia was first mentioned in written sources in the 14th century. The city developed as an important trading and administrative center of Podillia."
},

new CityTranslation
{
    id = 5,
    EntityId = 3,
    Lang = "uk",
    Title = "Жмеринка",
    Slug = "Zhmerinka",
    Description = "Жмеринка має кілька історичних парків та культурних пам'яток, що відображають багату історію міста.",
    History = "Жмеринка була заснована у XVIII столітті як важлива залізнична станція на Поділлі та розвивалася разом з будівництвом залізниці."
},

new CityTranslation
{
    id = 6,
    EntityId = 3,
    Lang = "en",
    Title = "Zhmerinka",
    Slug = "Zhmerinka",
    Description = "Zhmerinka has several historical parks and cultural landmarks reflecting the city's rich history.",
    History = "Zhmerinka was founded in the 18th century as an important railway station in Podillia and developed alongside the construction of the railway."
},

new CityTranslation
{
    id = 7,
    EntityId = 4,
    Lang = "uk",
    Title = "Могилів-Подільський",
    Slug = "MohylivPodilskyi",
    Description = "Місто відоме своїми зеленими зонами, історичними спорудами та річковими пейзажами на березі Дністра.",
    History = "Могилів-Подільський згадується з XVI століття. Історично був важливим торговим містом на Поділлі та прикордонним центром."
},

new CityTranslation
{
    id = 8,
    EntityId = 4,
    Lang = "en",
    Title = "Mohyliv-Podilskyi",
    Slug = "MohylivPodilskyi",
    Description = "The city is known for its green areas, historical buildings, and river landscapes on the Dniester bank.",
    History = "Mohyliv-Podilskyi has been mentioned since the 16th century. Historically, it was an important trading city in Podillia and a border center."
},


            //--------------------Волинська область---------------------------------------



new CityTranslation
{
    id = 11,
    EntityId = 6,
    Lang = "uk",
    Title = "Луцьк",
    Slug = "Lutsk",
    Description = "Луцьк має численні історичні пам'ятки, парки та музеї, які відображають культурну спадщину Волині.",
    History = "Луцьк вперше згадується у літописах у XIV столітті. Місто розвивалося як важливий торговий та адміністративний центр регіону."
},
new CityTranslation
{
    id = 12,
    EntityId = 6,
    Lang = "en",
    Title = "Lutsk",
    Slug = "Lutsk",
    Description = "Lutsk has numerous historical landmarks, parks, and museums reflecting Volyn's cultural heritage.",
    History = "Lutsk was first mentioned in chronicles in the 14th century. The city developed as an important trade and administrative center of the region."
},

new CityTranslation
{
    id = 13,
    EntityId = 7,
    Lang = "uk",
    Title = "Ковель",
    Slug = "Kovel",
    Description = "Ковель відомий своїми історичними будівлями, залізничним вузлом та зеленими зонами.",
    History = "Ковель вперше згадується у XV столітті. Місто розвивалося як важливий транспортний і торговий центр Волині."
},
new CityTranslation
{
    id = 14,
    EntityId = 7,
    Lang = "en",
    Title = "Kovel",
    Slug = "Kovel",
    Description = "Kovel is known for its historical buildings, railway junction, and green areas.",
    History = "Kovel was first mentioned in the 15th century. The city developed as an important transport and trade center of Volyn."
},

//--------------------Дніпропетровська область---------------------------------------

new CityTranslation
{
    id = 15,
    EntityId = 8,
    Lang = "uk",
    Title = "Дніпро",
    Slug = "Dnipro",
    Description = "Дніпро має численні парки, набережні та промислові пам'ятки, важливі для економіки регіону.",
    History = "Дніпро було засноване у XVIII столітті як фортеця Катеринослав. Місто стало важливим промисловим центром України."
},
new CityTranslation
{
    id = 16,
    EntityId = 8,
    Lang = "en",
    Title = "Dnipro",
    Slug = "Dnipro",
    Description = "Dnipro has numerous parks, embankments, and industrial landmarks important for the region's economy.",
    History = "Dnipro was founded in the 18th century as the fort of Katerynoslav. The city became an important industrial center of Ukraine."
},

new CityTranslation
{
    id = 17,
    EntityId = 9,
    Lang = "uk",
    Title = "Кривий Ріг",
    Slug = "KryvyiRih",
    Description = "Кривий Ріг відомий своєю гірничо-металургійною промисловістю та протяжними зеленими зонами.",
    History = "Місто було засноване у XVIII столітті і стало ключовим центром металургійної промисловості України."
},
new CityTranslation
{
    id = 18,
    EntityId = 9,
    Lang = "en",
    Title = "Kryvyi Rih",
    Slug = "KryvyiRih",
    Description = "Kryvyi Rih is known for its mining and metallurgical industry and extensive green areas.",
    History = "The city was founded in the 18th century and became a key center of Ukraine's metallurgical industry."
},

new CityTranslation
{
    id = 19,
    EntityId = 10,
    Lang = "uk",
    Title = "Кам’янське",
    Slug = "Kamianske",
    Description = "Місто має численні промислові об’єкти та парки, що розташовані вздовж Дніпра.",
    History = "Кам’янське розвивалося як промисловий центр у XIX–XX століттях і стало важливим для економіки регіону."
},
new CityTranslation
{
    id = 20,
    EntityId = 10,
    Lang = "en",
    Title = "Kamianske",
    Slug = "Kamianske",
    Description = "The city has numerous industrial facilities and parks along the Dnipro river.",
    History = "Kamianske developed as an industrial center in the 19th–20th centuries and became important for the region's economy."
},

new CityTranslation
{
    id = 21,
    EntityId = 11,
    Lang = "uk",
    Title = "Нікополь",
    Slug = "Nikopol",
    Description = "Нікополь відомий своїми промисловими підприємствами та мальовничими берегами Дніпра.",
    History = "Місто було засноване у XVIII столітті та стало важливим центром металургійної та промислової діяльності."
},
new CityTranslation
{
    id = 22,
    EntityId = 11,
    Lang = "en",
    Title = "Nikopol",
    Slug = "Nikopol",
    Description = "Nikopol is known for its industrial enterprises and picturesque Dnipro riverbanks.",
    History = "The city was founded in the 18th century and became an important center of metallurgical and industrial activity."
},



//--------------------Донецька область---------------------------------------

new CityTranslation
{
    id = 23,
    EntityId = 17,
    Lang = "en",
    Title = "Donetsk",
    Slug = "Donetsk",
    Description = "Donetsk is an important industrial city with numerous parks and cultural landmarks.",
    History = "Donetsk was founded in 1869 as a mining settlement and developed into a major industrial center in Eastern Ukraine."
},
new CityTranslation
{
    id = 24,
    EntityId = 17,
    Lang = "uk",
    Title = "Донецьк",
    Slug = "Donetsk",
    Description = "Донецьк — важливе промислове місто з численними парками та культурними пам’ятками.",
    History = "Донецьк було засновано у 1869 році як шахтарське поселення і він став важливим промисловим центром Східної України."
},

new CityTranslation
{
    id = 25,
    EntityId = 18,
    Lang = "en",
    Title = "Sloviansk",
    Slug = "Sloviansk",
    Description = "Sloviansk is known for its historical architecture, riverfronts, and cultural heritage.",
    History = "Sloviansk was founded in 1676 and developed as a regional trade and salt-mining center."
},
new CityTranslation
{
    id = 26,
    EntityId = 18,
    Lang = "uk",
    Title = "Слов’янськ",
    Slug = "Sloviansk",
    Description = "Слов’янськ відомий історичною архітектурою, набережними та культурною спадщиною.",
    History = "Слов’янськ було засновано у 1676 році і розвинулося як регіональний торговий та соляний центр."
},

new CityTranslation
{
    id = 27,
    EntityId = 19,
    Lang = "en",
    Title = "Kramatorsk",
    Slug = "Kramatorsk",
    Description = "Kramatorsk is a key industrial city with parks, cultural sites, and modern infrastructure.",
    History = "Kramatorsk was founded in the late 19th century and grew rapidly as an industrial and railway hub."
},
new CityTranslation
{
    id = 28,
    EntityId = 19,
    Lang = "uk",
    Title = "Краматорськ",
    Slug = "Kramatorsk",
    Description = "Краматорськ — ключове промислове місто з парками, культурними об’єктами та сучасною інфраструктурою.",
    History = "Краматорськ було засновано наприкінці XIX століття і швидко розвинулося як промисловий та залізничний центр."
},

//--------------------Житомирська область---------------------------------------

new CityTranslation
{
    id = 29,
    EntityId = 20,
    Lang = "en",
    Title = "Zhytomyr",
    Slug = "Zhytomyr",
    Description = "Zhytomyr has many parks, museums, and historical buildings reflecting its rich heritage.",
    History = "Zhytomyr was founded in the 9th century and has been an important administrative and cultural center in the region."
},
new CityTranslation
{
    id = 30,
    EntityId = 20,
    Lang = "uk",
    Title = "Житомир",
    Slug = "Zhytomyr",
    Description = "Житомир має численні парки, музеї та історичні будівлі, що відображають його багату спадщину.",
    History = "Житомир було засновано у IX столітті і він був важливим адміністративним та культурним центром регіону."
},

new CityTranslation
{
    id = 31,
    EntityId = 21,
    Lang = "en",
    Title = "Berdychiv",
    Slug = "Berdychiv",
    Description = "Berdychiv is famous for its historic architecture, churches, and Jewish heritage.",
    History = "Berdychiv was first mentioned in 1430 and became a prominent trade and cultural center."
},
new CityTranslation
{
    id = 32,
    EntityId = 21,
    Lang = "uk",
    Title = "Бердичів",
    Slug = "Berdychiv",
    Description = "Бердичів відомий історичною архітектурою, церквами та єврейською спадщиною.",
    History = "Бердичів вперше згадується у 1430 році і став видатним торговим та культурним центром."
},

new CityTranslation
{
    id = 33,
    EntityId = 22,
    Lang = "en",
    Title = "Korosten",
    Slug = "Korosten",
    Description = "Korosten has parks, museums, and ancient historical sites.",
    History = "Korosten dates back to the 9th century and was a significant city in Kievan Rus."
},
new CityTranslation
{
    id = 34,
    EntityId = 22,
    Lang = "uk",
    Title = "Коростень",
    Slug = "Korosten",
    Description = "Коростень має парки, музеї та давні історичні об’єкти.",
    History = "Коростень існує з IX століття і був важливим містом Київської Русі."
},

new CityTranslation
{
    id = 35,
    EntityId = 23,
    Lang = "en",
    Title = "Novohrad-Volynskyi (Zviahel)",
    Slug = "NovohradVolynskyi",
    Description = "Novohrad-Volynskyi has historical architecture, parks, and cultural landmarks.",
    History = "The city dates back to the 13th century and has been a regional administrative and trade center."
},
new CityTranslation
{
    id = 36,
    EntityId = 23,
    Lang = "uk",
    Title = "Новоград-Волинський (Звягель)",
    Slug = "NovohradVolynskyi",
    Description = "Новоград-Волинський має історичну архітектуру, парки та культурні об’єкти.",
    History = "Місто існує з XIII століття і було регіональним адміністративним та торговим центром."
},



//--------------------Закарпатська область---------------------------------------

new CityTranslation
{
    id = 37,
    EntityId = 24,
    Lang = "en",
    Title = "Uzhhorod",
    Slug = "Uzhhorod",
    Description = "Uzhhorod is known for its historic center, parks, and cultural landmarks along the Uzh River.",
    History = "Uzhhorod was first mentioned in the 9th century and has been a key cultural and administrative center in Zakarpattia."
},
new CityTranslation
{
    id = 38,
    EntityId = 24,
    Lang = "uk",
    Title = "Ужгород",
    Slug = "Uzhhorod",
    Description = "Ужгород відомий історичним центром, парками та культурними пам’ятками вздовж річки Уж.",
    History = "Ужгород вперше згадується у IX столітті і був важливим культурним та адміністративним центром Закарпаття."
},

new CityTranslation
{
    id = 39,
    EntityId = 25,
    Lang = "en",
    Title = "Mukachevo",
    Slug = "Mukachevo",
    Description = "Mukachevo features castles, parks, and historical landmarks reflecting its rich history.",
    History = "Mukachevo dates back to the 9th century and has been a regional hub for trade and culture."
},
new CityTranslation
{
    id = 40,
    EntityId = 25,
    Lang = "uk",
    Title = "Мукачево",
    Slug = "Mukachevo",
    Description = "Мукачево має замки, парки та історичні пам’ятки, що відображають його багату історію.",
    History = "Мукачево існує з IX століття і був регіональним центром торгівлі та культури."
},

new CityTranslation
{
    id = 41,
    EntityId = 26,
    Lang = "en",
    Title = "Khust",
    Slug = "Khust",
    Description = "Khust is famous for its medieval castle, parks, and scenic views of the Carpathians.",
    History = "Khust was founded in the 11th century and became an important fortress and trade town in the region."
},
new CityTranslation
{
    id = 42,
    EntityId = 26,
    Lang = "uk",
    Title = "Хуст",
    Slug = "Khust",
    Description = "Хуст відомий середньовічним замком, парками та мальовничими краєвидами Карпат.",
    History = "Хуст було засновано у XI столітті і він став важливою фортецею та торговим містом регіону."
},

new CityTranslation
{
    id = 43,
    EntityId = 27,
    Lang = "en",
    Title = "Berehove",
    Slug = "Berehove",
    Description = "Berehove is known for its wine culture, thermal baths, and historic architecture.",
    History = "Berehove has existed since the 14th century and developed as a center of viticulture and trade."
},
new CityTranslation
{
    id = 44,
    EntityId = 27,
    Lang = "uk",
    Title = "Берегове",
    Slug = "Berehove",
    Description = "Берегове відоме виноробством, термальними джерелами та історичною архітектурою.",
    History = "Берегове існує з XIV століття і розвивалося як центр виноробства та торгівлі."
},

//--------------------Запорізька область---------------------------------------

new CityTranslation
{
    id = 45,
    EntityId = 28,
    Lang = "en",
    Title = "Zaporizhzhia",
    Slug = "Zaporizhzhia",
    Description = "Zaporizhzhia is famous for its industrial significance, Dnipro riverfront, and historical sites.",
    History = "Zaporizhzhia was founded in 1770 and is historically associated with the Zaporizhian Cossacks."
},
new CityTranslation
{
    id = 46,
    EntityId = 28,
    Lang = "uk",
    Title = "Запоріжжя",
    Slug = "Zaporizhzhia",
    Description = "Запоріжжя відоме промисловим значенням, набережною Дніпра та історичними об’єктами.",
    History = "Запоріжжя було засноване у 1770 році та історично пов’язане з Запорізькими козаками."
},

new CityTranslation
{
    id = 47,
    EntityId = 29,
    Lang = "en",
    Title = "Melitopol",
    Slug = "Melitopol",
    Description = "Melitopol features parks, cultural monuments, and is known as a gateway to the Sea of Azov.",
    History = "Melitopol was founded in 1784 and has been a regional trade and agricultural hub."
},
new CityTranslation
{
    id = 48,
    EntityId = 29,
    Lang = "uk",
    Title = "Мелітополь",
    Slug = "Melitopol",
    Description = "Мелітополь має парки, культурні пам’ятки та відоме як ворота до Азовського моря.",
    History = "Мелітополь засновано у 1784 році і він був регіональним торговим та сільськогосподарським центром."
},

new CityTranslation
{
    id = 49,
    EntityId = 30,
    Lang = "en",
    Title = "Berdiansk",
    Slug = "Berdiansk",
    Description = "Berdiansk is a port city with beaches, resorts, and cultural heritage.",
    History = "Berdiansk was founded in 1673 and developed as a major port on the Sea of Azov."
},
new CityTranslation
{
    id = 50,
    EntityId = 30,
    Lang = "uk",
    Title = "Бердянськ",
    Slug = "Berdiansk",
    Description = "Бердянськ — портове місто з пляжами, курортами та культурною спадщиною.",
    History = "Бердянськ засновано у 1673 році і він розвинувся як важливий порт на Азовському морі."
},

new CityTranslation
{
    id = 51,
    EntityId = 31,
    Lang = "en",
    Title = "Enerhodar",
    Slug = "Enerhodar",
    Description = "Enerhodar is known for its hydroelectric power station and modern urban infrastructure.",
    History = "Enerhodar was founded in 1970 and became the center of Zaporizhzhia’s energy production."
},
new CityTranslation
{
    id = 52,
    EntityId = 31,
    Lang = "uk",
    Title = "Енергодар",
    Slug = "Enerhodar",
    Description = "Енергодар відоме ГЕС та сучасною міською інфраструктурою.",
    History = "Енергодар засновано у 1970 році і він став центром енергетичного виробництва Запорізької області."
},


//--------------------Івано-Франківська область---------------------------------------

new CityTranslation
{
    id = 53,
    EntityId = 32,
    Lang = "en",
    Title = "Ivano-Frankivsk",
    Slug = "IvanoFrankivsk",
    Description = "Ivano-Frankivsk is known for its vibrant cultural life, parks, and historic architecture in the heart of the Carpathians.",
    History = "Ivano-Frankivsk was founded in 1662 and has developed as a cultural and administrative center in western Ukraine."
},
new CityTranslation
{
    id = 54,
    EntityId = 32,
    Lang = "uk",
    Title = "Івано-Франківськ",
    Slug = "IvanoFrankivsk",
    Description = "Івано-Франківськ відомий яскравим культурним життям, парками та історичною архітектурою в серці Карпат.",
    History = "Івано-Франківськ було засновано у 1662 році і він розвинувся як культурний та адміністративний центр Західної України."
},

new CityTranslation
{
    id = 55,
    EntityId = 33,
    Lang = "en",
    Title = "Kalush",
    Slug = "Kalush",
    Description = "Kalush is famous for its industrial heritage, scenic landscapes, and historical landmarks.",
    History = "Kalush was first mentioned in the 15th century and became an important regional industrial town."
},
new CityTranslation
{
    id = 56,
    EntityId = 33,
    Lang = "uk",
    Title = "Калуш",
    Slug = "Kalush",
    Description = "Калуш відомий промисловою спадщиною, мальовничими пейзажами та історичними пам’ятками.",
    History = "Калуш вперше згадується у XV столітті і став важливим регіональним промисловим містом."
},

new CityTranslation
{
    id = 57,
    EntityId = 34,
    Lang = "en",
    Title = "Kolomyia",
    Slug = "Kolomyia",
    Description = "Kolomyia is known for its unique cultural heritage, museums, and picturesque streets.",
    History = "Kolomyia has a history dating back to the 13th century and is famous for its artistic and cultural traditions."
},
new CityTranslation
{
    id = 58,
    EntityId = 34,
    Lang = "uk",
    Title = "Коломия",
    Slug = "Kolomyia",
    Description = "Коломия відома унікальною культурною спадщиною, музеями та мальовничими вулицями.",
    History = "Коломия існує з XIII століття і відома своїми художніми та культурними традиціями."
},

new CityTranslation
{
    id = 59,
    EntityId = 35,
    Lang = "en",
    Title = "Yaremche",
    Slug = "Yaremche",
    Description = "Yaremche is a popular mountain resort, known for waterfalls, hiking, and traditional Hutsul culture.",
    History = "Yaremche has been a tourist destination since the 19th century and preserves rich Hutsul traditions."
},
new CityTranslation
{
    id = 60,
    EntityId = 35,
    Lang = "uk",
    Title = "Яремче",
    Slug = "Yaremche",
    Description = "Яремче — популярний гірський курорт, відомий водоспадами, пішохідними маршрутами та традиційною гуцульською культурою.",
    History = "Яремче було туристичним центром з XIX століття і зберігає багаті гуцульські традиції."
},

new CityTranslation
{
    id = 61,
    EntityId = 36,
    Lang = "en",
    Title = "Bukovel",
    Slug = "Bukovel",
    Description = "Bukovel is Ukraine's largest ski resort, offering winter sports, hiking, and wellness facilities.",
    History = "Bukovel was established in 2000 and has become a leading mountain resort in the Carpathians."
},
new CityTranslation
{
    id = 62,
    EntityId = 36,
    Lang = "uk",
    Title = "Буковель",
    Slug = "Bukovel",
    Description = "Буковель — найбільший гірськолижний курорт України, пропонує зимові види спорту, піші маршрути та оздоровчі послуги.",
    History = "Буковель засновано у 2000 році і він став провідним гірським курортом Карпат."
},

//--------------------Київська область---------------------------------------

new CityTranslation
{
    id = 63,
    EntityId = 37,
    Lang = "en",
    Title = "Bila Tserkva",
    Slug = "BilaTserkva",
    Description = "Bila Tserkva is famous for its parks, botanical gardens, and historical architecture along the Ros River.",
    History = "Bila Tserkva was founded in 1032 and became an important regional cultural and administrative center."
},
new CityTranslation
{
    id = 64,
    EntityId = 37,
    Lang = "uk",
    Title = "Біла Церква",
    Slug = "BilaTserkva",
    Description = "Біла Церква відома парками, ботанічними садами та історичною архітектурою вздовж річки Рось.",
    History = "Біла Церква була заснована у 1032 році і стала важливим регіональним культурним та адміністративним центром."
},

new CityTranslation
{
    id = 65,
    EntityId = 38,
    Lang = "en",
    Title = "Boryspil",
    Slug = "Boryspil",
    Description = "Boryspil is a key transport hub with cultural landmarks, parks, and historical sites.",
    History = "Boryspil developed around the 12th century and is best known for its international airport."
},
new CityTranslation
{
    id = 66,
    EntityId = 38,
    Lang = "uk",
    Title = "Бориспіль",
    Slug = "Boryspil",
    Description = "Бориспіль — важливий транспортний вузол з культурними пам’ятками, парками та історичними об’єктами.",
    History = "Бориспіль розвивався з XII століття і відомий міжнародним аеропортом."
},

new CityTranslation
{
    id = 67,
    EntityId = 39,
    Lang = "en",
    Title = "Brovary",
    Slug = "Brovary",
    Description = "Brovary is known for its industrial heritage, parks, and sports facilities near Kyiv.",
    History = "Brovary has been a key suburban city since the 16th century with industrial and residential development."
},
new CityTranslation
{
    id = 68,
    EntityId = 39,
    Lang = "uk",
    Title = "Бровари",
    Slug = "Brovary",
    Description = "Бровари відомі промисловою спадщиною, парками та спортивними об’єктами поблизу Києва.",
    History = "Бровари є важливим передмістям з XVI століття, з промисловим та житловим розвитком."
},

new CityTranslation
{
    id = 69,
    EntityId = 40,
    Lang = "en",
    Title = "Irpin",
    Slug = "Irpin",
    Description = "Irpin is famous for its green zones, riverfronts, and suburban lifestyle near Kyiv.",
    History = "Irpin developed in the early 20th century as a residential and recreational suburb of Kyiv."
},
new CityTranslation
{
    id = 70,
    EntityId = 40,
    Lang = "uk",
    Title = "Ірпінь",
    Slug = "Irpin",
    Description = "Ірпінь відомий зеленими зонами, набережними та передміським стилем життя поблизу Києва.",
    History = "Ірпінь розвивався на початку XX століття як житлове та рекреаційне передмістя Києва."
},

new CityTranslation
{
    id = 71,
    EntityId = 41,
    Lang = "en",
    Title = "Bucha",
    Slug = "Bucha",
    Description = "Bucha is known for its parks, modern residential areas, and suburban atmosphere near Kyiv.",
    History = "Bucha developed rapidly in the late 20th century as a modern suburb of Kyiv."
},
new CityTranslation
{
    id = 72,
    EntityId = 41,
    Lang = "uk",
    Title = "Буча",
    Slug = "Bucha",
    Description = "Буча відома парками, сучасними житловими районами та передміською атмосферою поблизу Києва.",
    History = "Буча швидко розвивалася у кінці XX століття як сучасне передмістя Києва."
},



//--------------------Кіровоградська область---------------------------------------

new CityTranslation
{
    id = 73,
    EntityId = 42,
    Lang = "en",
    Title = "Kropyvnytskyi",
    Slug = "Kropyvnytskyi",
    Description = "Kropyvnytskyi is an administrative and cultural center with numerous parks, theaters, and historical landmarks.",
    History = "Kropyvnytskyi was founded in 1754 as a fortress and has grown into the administrative center of Kirovohrad Oblast."
},
new CityTranslation
{
    id = 74,
    EntityId = 42,
    Lang = "uk",
    Title = "Кропивницький",
    Slug = "Kropyvnytskyi",
    Description = "Кропивницький — адміністративний та культурний центр з численними парками, театрами та історичними пам’ятками.",
    History = "Кропивницький було засновано у 1754 році як фортецю, і він виріс у адміністративний центр Кіровоградської області."
},

new CityTranslation
{
    id = 75,
    EntityId = 43,
    Lang = "en",
    Title = "Oleksandriya",
    Slug = "Oleksandriya",
    Description = "Oleksandriya is known for its parks, botanical gardens, and industrial history.",
    History = "Oleksandriya developed in the 18th century and became a regional trade and industrial center."
},
new CityTranslation
{
    id = 76,
    EntityId = 43,
    Lang = "uk",
    Title = "Олександрія",
    Slug = "Oleksandriya",
    Description = "Олександрія відома парками, ботанічними садами та промисловою історією.",
    History = "Олександрія розвивалася у XVIII столітті і стала регіональним торгово-промисловим центром."
},

new CityTranslation
{
    id = 77,
    EntityId = 44,
    Lang = "en",
    Title = "Svitlovodsk",
    Slug = "Svitlovodsk",
    Description = "Svitlovodsk is a city near the Dnipro River, famous for its hydroelectric power plant and lakes.",
    History = "Svitlovodsk was founded in the 1950s during the construction of the Kremenchuk Hydroelectric Power Plant."
},
new CityTranslation
{
    id = 78,
    EntityId = 44,
    Lang = "uk",
    Title = "Світловодськ",
    Slug = "Svitlovodsk",
    Description = "Світловодськ — місто біля Дніпра, відоме своєю гідроелектростанцією та озерами.",
    History = "Світловодськ було засновано у 1950-х роках під час будівництва Кременчуцької гідроелектростанції."
},

new CityTranslation
{
    id = 79,
    EntityId = 45,
    Lang = "en",
    Title = "Znamianka",
    Slug = "Znamianka",
    Description = "Znamianka is an important railway hub with parks and cultural institutions.",
    History = "Znamianka developed in the late 19th century as a railway junction and industrial town."
},
new CityTranslation
{
    id = 80,
    EntityId = 45,
    Lang = "uk",
    Title = "Знам’янка",
    Slug = "Znamianka",
    Description = "Знам’янка — важливий залізничний вузол з парками та культурними закладами.",
    History = "Знам’янка розвивалася наприкінці XIX століття як залізничний вузол та промислове місто."
},

//--------------------Луганська область---------------------------------------

new CityTranslation
{
    id = 81,
    EntityId = 46,
    Lang = "en",
    Title = "Lysychansk",
    Slug = "Lysychansk",
    Description = "Lysychansk is an industrial city on the Donets River, with parks and cultural institutions.",
    History = "Lysychansk was founded in the 18th century as a salt mining settlement and developed into an industrial city."
},
new CityTranslation
{
    id = 82,
    EntityId = 46,
    Lang = "uk",
    Title = "Лисичанськ",
    Slug = "Lysychansk",
    Description = "Лисичанськ — промислове місто на річці Сіверський Донець, з парками та культурними закладами.",
    History = "Лисичанськ було засновано у XVIII столітті як поселення соляних промислів і розвинулося в промислове місто."
},

new CityTranslation
{
    id = 83,
    EntityId = 47,
    Lang = "en",
    Title = "Severodonetsk",
    Slug = "Severodonetsk",
    Description = "Severodonetsk is a modern industrial city, known for its chemical and manufacturing plants.",
    History = "Severodonetsk was founded in 1934 and grew as a center for chemical industry in eastern Ukraine."
},
new CityTranslation
{
    id = 84,
    EntityId = 47,
    Lang = "uk",
    Title = "Сєвєродонецьк",
    Slug = "Severodonetsk",
    Description = "Сєвєродонецьк — сучасне промислове місто, відоме своїми хімічними та виробничими підприємствами.",
    History = "Сєвєродонецьк було засновано у 1934 році і розвинулося як центр хімічної промисловості на сході України."
},

new CityTranslation
{
    id = 85,
    EntityId = 48,
    Lang = "en",
    Title = "Alchevsk",
    Slug = "Alchevsk",
    Description = "Alchevsk is a steel-producing city with rich industrial history and cultural landmarks.",
    History = "Alchevsk was founded in the late 19th century around metallurgical plants."
},
new CityTranslation
{
    id = 86,
    EntityId = 48,
    Lang = "uk",
    Title = "Алчевськ",
    Slug = "Alchevsk",
    Description = "Алчевськ — місто металургійного виробництва з багатою промисловою історією та культурними пам’ятками.",
    History = "Алчевськ було засновано наприкінці XIX століття навколо металургійних заводів."
},

new CityTranslation
{
    id = 87,
    EntityId = 49,
    Lang = "en",
    Title = "Kramatorsk",
    Slug = "Kramatorsk",
    Description = "Kramatorsk is an industrial and cultural center in Donetsk Oblast, with parks and historical sites.",
    History = "Kramatorsk developed in the late 19th century and became a key industrial hub in eastern Ukraine."
},
new CityTranslation
{
    id = 88,
    EntityId = 49,
    Lang = "uk",
    Title = "Краматорськ",
    Slug = "Kramatorsk",
    Description = "Краматорськ — промисловий та культурний центр Донецької області, з парками та історичними об’єктами.",
    History = "Краматорськ розвивався наприкінці XIX століття і став важливим промисловим вузлом на сході України."
},

//--------------------Львівська область---------------------------------------

new CityTranslation
{
    id = 89,
    EntityId = 50,
    Lang = "en",
    Title = "Lviv",
    Slug = "Lviv",
    Description = "Lviv is a cultural and historical center with over 20 parks, 16 natural monuments, and 2 botanical gardens. The historic center is a UNESCO World Heritage Site, featuring the Opera House, Dominican Cathedral, City Hall, Powder Tower, Lychakiv Cemetery, Armenian Cathedral, and Bernardine Fortress.",
    History = "Lviv was founded in the 13th century by King Danylo of Galicia. Legend says it was named after his son Lev. The city developed as a multicultural center, strategically located on trade routes between Western Europe and the East."
},
new CityTranslation
{
    id = 90,
    EntityId = 50,
    Lang = "uk",
    Title = "Львів",
    Slug = "Lviv",
    Description = "Львів — культурний та історичний центр з понад 20 парками, 16 природними пам’ятками та 2 ботанічними садами. Історичний центр внесено до списку Світової спадщини ЮНЕСКО, включає Оперний театр, Домініканський собор, міську Ратушу, Порохову вежу, Личаківський цвинтар, Вірменський собор та Бернардинську фортецю.",
    History = "Львів засновано у XIII столітті королем Данилом Галицьким. За легендою, місто назване на честь його сина Лева. Львів розвивався як центр багатокультурного суспільства, стратегічно розташований на торгових шляхах між Західною Європою та Сходом."
},

new CityTranslation
{
    id = 91,
    EntityId = 51,
    Lang = "en",
    Title = "Drohobych",
    Slug = "Drohobych",
    Description = "Drohobych is famous for its salt industry, historical churches, and cultural heritage.",
    History = "Drohobych has existed since the 12th century and developed as a trade and salt production center."
},
new CityTranslation
{
    id = 92,
    EntityId = 51,
    Lang = "uk",
    Title = "Дрогобич",
    Slug = "Drohobych",
    Description = "Дрогобич відомий своєю соляною промисловістю, історичними церквами та культурною спадщиною.",
    History = "Дрогобич існує з XII століття і розвинувся як центр торгівлі та видобутку солі."
},

new CityTranslation
{
    id = 93,
    EntityId = 52,
    Lang = "en",
    Title = "Chervonohrad",
    Slug = "Chervonohrad",
    Description = "Chervonohrad is a mining city with parks and cultural centers.",
    History = "Chervonohrad developed in the 20th century around coal mining operations."
},
new CityTranslation
{
    id = 94,
    EntityId = 52,
    Lang = "uk",
    Title = "Червоноград",
    Slug = "Chervonohrad",
    Description = "Червоноград — місто шахтарського профілю з парками та культурними закладами.",
    History = "Червоноград розвивався у XX столітті навколо вугільних шахт."
},

new CityTranslation
{
    id = 95,
    EntityId = 53,
    Lang = "en",
    Title = "Stryi",
    Slug = "Stryi",
    Description = "Stryi is a regional administrative center with historical architecture and local parks.",
    History = "Stryi was first mentioned in the 14th century and became an important trade and cultural hub."
},
new CityTranslation
{
    id = 96,
    EntityId = 53,
    Lang = "uk",
    Title = "Стрий",
    Slug = "Stryi",
    Description = "Стрий — регіональний адміністративний центр з історичною архітектурою та місцевими парками.",
    History = "Стрий вперше згадується у XIV столітті і став важливим торговим та культурним центром."
},

new CityTranslation
{
    id = 97,
    EntityId = 54,
    Lang = "en",
    Title = "Truskavets",
    Slug = "Truskavets",
    Description = "Truskavets is a famous spa and resort town known for its mineral waters and wellness centers.",
    History = "Truskavets has been known since the 19th century for its therapeutic mineral springs and health resorts."
},
new CityTranslation
{
    id = 98,
    EntityId = 54,
    Lang = "uk",
    Title = "Трускавець",
    Slug = "Truskavets",
    Description = "Трускавець — відоме курортне місто, відоме мінеральними водами та оздоровчими центрами.",
    History = "Трускавець відомий з XIX століття своїми лікувальними мінеральними джерелами та курортами."
},

//--------------------Миколаївська область---------------------------------------

new CityTranslation
{
    id = 99,
    EntityId = 55,
    Lang = "en",
    Title = "Mykolaiv",
    Slug = "Mykolaiv",
    Description = "Mykolaiv is a shipbuilding and river port city with parks, museums, and historical landmarks.",
    History = "Mykolaiv was founded in 1789 as a shipbuilding center and developed into an important port city on the Southern Bug River."
},
new CityTranslation
{
    id = 100,
    EntityId = 55,
    Lang = "uk",
    Title = "Миколаїв",
    Slug = "Mykolaiv",
    Description = "Миколаїв — місто кораблебудування та річковий порт з парками, музеями та історичними пам’ятками.",
    History = "Миколаїв засновано у 1789 році як центр кораблебудування і розвинувся в важливий порт на річці Південний Буг."
},


            //--------------------Одеська область---------------------------------------

new CityTranslation
{
    id = 101,
    EntityId = 56,
    Lang = "en",
    Title = "Odesa",
    Slug = "Odesa",
    Description = "Odesa is a major port city on the Black Sea, known for its beaches, historic architecture, and vibrant cultural life.",
    History = "Founded in 1794, Odesa became a key trade and naval center, famous for its multicultural heritage and Potemkin Stairs."
},
new CityTranslation
{
    id = 102,
    EntityId = 56,
    Lang = "uk",
    Title = "Одеса",
    Slug = "Odesa",
    Description = "Одеса — великий портове місто на Чорному морі, відоме своїми пляжами, історичною архітектурою та яскравим культурним життям.",
    History = "Заснована у 1794 році, Одеса стала важливим торговим та морським центром, відомим своєю багатокультурною спадщиною та Потьомкінськими сходами."
},

new CityTranslation
{
    id = 103,
    EntityId = 57,
    Lang = "en",
    Title = "Izmail",
    Slug = "Izmail",
    Description = "Izmail is a historic Danube port city with a rich fortress heritage and river trade significance.",
    History = "Izmail gained prominence in the 18th century due to its strategic location on the Danube and strong fortifications."
},
new CityTranslation
{
    id = 104,
    EntityId = 57,
    Lang = "uk",
    Title = "Ізмаїл",
    Slug = "Izmail",
    Description = "Ізмаїл — історичне портове місто на Дунаї з багатою фортифікаційною спадщиною та значенням у річковій торгівлі.",
    History = "Ізмаїл набув значення у XVIII столітті через стратегічне розташування на Дунаї та потужні укріплення."
},

new CityTranslation
{
    id = 105,
    EntityId = 58,
    Lang = "en",
    Title = "Chornomorsk",
    Slug = "Chornomorsk",
    Description = "Chornomorsk is a modern port city near Odesa, important for maritime transport and industry.",
    History = "Developed in the 20th century as a key maritime hub and industrial center."
},
new CityTranslation
{
    id = 106,
    EntityId = 58,
    Lang = "uk",
    Title = "Чорноморськ",
    Slug = "Chornomorsk",
    Description = "Чорноморськ — сучасне портове місто поблизу Одеси, важливе для морських перевезень та промисловості.",
    History = "Місто розвивалося у XX столітті як важливий морський та промисловий центр."
},

new CityTranslation
{
    id = 107,
    EntityId = 59,
    Lang = "en",
    Title = "Bilhorod-Dnistrovskyi",
    Slug = "BilhorodDnistrovskyi",
    Description = "Bilhorod-Dnistrovskyi is known for its medieval fortress, rich history, and proximity to the Dniester River.",
    History = "Founded in antiquity, it was a key settlement under various empires and a defensive stronghold."
},
new CityTranslation
{
    id = 108,
    EntityId = 59,
    Lang = "uk",
    Title = "Білгород-Дністровський",
    Slug = "BilhorodDnistrovskyi",
    Description = "Білгород-Дністровський відомий своєю середньовічною фортецею, багатою історією та розташуванням біля Дністра.",
    History = "Засноване ще в античні часи, місто було важливим поселенням за різних імперій та оборонною фортецею."
},

new CityTranslation
{
    id = 109,
    EntityId = 60,
    Lang = "en",
    Title = "Podilsk",
    Slug = "Podilsk",
    Description = "Podilsk is a regional administrative city with local industries and historical landmarks.",
    History = "Podilsk has developed as a regional hub since the 18th century, with growing trade and cultural significance."
},
new CityTranslation
{
    id = 110,
    EntityId = 60,
    Lang = "uk",
    Title = "Подільськ",
    Slug = "Podilsk",
    Description = "Подільськ — регіональне адміністративне місто з місцевою промисловістю та історичними пам’ятками.",
    History = "Подільськ розвивався як регіональний центр з XVIII століття, набуваючи значення у торгівлі та культурі."
},

//--------------------Полтавська область---------------------------------------

new CityTranslation
{
    id = 111,
    EntityId = 61,
    Lang = "en",
    Title = "Poltava",
    Slug = "Poltava",
    Description = "Poltava is famous for its historical battle sites, architecture, and cultural heritage.",
    History = "Founded centuries ago, Poltava became historically famous for the 1709 Battle of Poltava, shaping Ukrainian and European history."
},
new CityTranslation
{
    id = 112,
    EntityId = 61,
    Lang = "uk",
    Title = "Полтава",
    Slug = "Poltava",
    Description = "Полтава відома своїми історичними полями битв, архітектурою та культурною спадщиною.",
    History = "Заснована століттями тому, Полтава стала відомою завдяки Полтавській битві 1709 року, що вплинула на українську та європейську історію."
},

new CityTranslation
{
    id = 113,
    EntityId = 62,
    Lang = "en",
    Title = "Kremenchuk",
    Slug = "Kremenchuk",
    Description = "Kremenchuk is an industrial city on the Dnieper River with important manufacturing and port facilities.",
    History = "Developed as a river port and industrial hub since the 18th century, Kremenchuk plays a key role in regional trade."
},
new CityTranslation
{
    id = 114,
    EntityId = 62,
    Lang = "uk",
    Title = "Кременчук",
    Slug = "Kremenchuk",
    Description = "Кременчук — промислове місто на Дніпрі з важливими виробничими та портовими об’єктами.",
    History = "Місто розвивалося як річковий порт та промисловий центр з XVIII століття, граючи ключову роль у регіональній торгівлі."
},

new CityTranslation
{
    id = 115,
    EntityId = 63,
    Lang = "en",
    Title = "Myrhorod",
    Slug = "Myrhorod",
    Description = "Myrhorod is known for its mineral waters, wellness resorts, and cultural landmarks.",
    History = "Since the 16th century, Myrhorod has been a center for spa tourism and cultural development."
},
new CityTranslation
{
    id = 116,
    EntityId = 63,
    Lang = "uk",
    Title = "Миргород",
    Slug = "Myrhorod",
    Description = "Миргород відомий своїми мінеральними водами, курортами та культурними пам’ятками.",
    History = "З XVI століття Миргород був центром курортного туризму та культурного розвитку."
},

new CityTranslation
{
    id = 117,
    EntityId = 64,
    Lang = "en",
    Title = "Lubny",
    Slug = "Lubny",
    Description = "Lubny is a historic city with architectural monuments, local crafts, and parks.",
    History = "Lubny has been inhabited since medieval times and developed as a cultural and trade center."
},
new CityTranslation
{
    id = 118,
    EntityId = 64,
    Lang = "uk",
    Title = "Лубни",
    Slug = "Lubny",
    Description = "Лубни — історичне місто з архітектурними пам’ятками, місцевими ремеслами та парками.",
    History = "Лубни заселені з середньовіччя і розвивалися як культурний та торговий центр."
},

//--------------------Рівненська область---------------------------------------

new CityTranslation
{
    id = 119,
    EntityId = 65,
    Lang = "en",
    Title = "Rivne",
    Slug = "Rivne",
    Description = "Rivne is a regional center known for its parks, cultural sites, and local industries.",
    History = "Rivne was first mentioned in historical records in the 13th century and developed as an administrative and cultural center in western Ukraine."
},
new CityTranslation
{
    id = 120,
    EntityId = 65,
    Lang = "uk",
    Title = "Рівне",
    Slug = "Rivne",
    Description = "Рівне — обласний центр, відомий своїми парками, культурними пам’ятками та місцевою промисловістю.",
    History = "Рівне вперше згадується у XIII столітті та розвивалося як адміністративний та культурний центр Західної України."
},

new CityTranslation
{
    id = 121,
    EntityId = 66,
    Lang = "en",
    Title = "Dubno",
    Slug = "Dubno",
    Description = "Dubno is famous for its medieval castle, historical landmarks, and annual cultural events.",
    History = "Dubno has a history dating back to the 11th century and was a strategic fortress city in Volhynia."
},
new CityTranslation
{
    id = 122,
    EntityId = 66,
    Lang = "uk",
    Title = "Дубно",
    Slug = "Dubno",
    Description = "Дубно відоме своєю середньовічною фортецею, історичними пам’ятками та щорічними культурними заходами.",
    History = "Дубно має історію, що сягає XI століття, і було стратегічним фортефікаційним містом Волині."
},

new CityTranslation
{
    id = 123,
    EntityId = 67,
    Lang = "en",
    Title = "Varash",
    Slug = "Varash",
    Description = "Varash is an industrial town known for its nuclear power plant and regional economic significance.",
    History = "Varash was developed in the 20th century as a center for nuclear energy and industrial growth."
},
new CityTranslation
{
    id = 124,
    EntityId = 67,
    Lang = "uk",
    Title = "Вараш",
    Slug = "Varash",
    Description = "Вараш — промислове місто, відоме своєю атомною електростанцією та економічним значенням для регіону.",
    History = "Вараш розвивався у XX столітті як центр ядерної енергетики та промислового розвитку."
},

new CityTranslation
{
    id = 125,
    EntityId = 68,
    Lang = "en",
    Title = "Ostroh",
    Slug = "Ostroh",
    Description = "Ostroh is a historical city with a famous academy, ancient churches, and cultural heritage sites.",
    History = "Ostroh dates back to the 14th century and was a major center of education, culture, and Orthodox scholarship."
},
new CityTranslation
{
    id = 126,
    EntityId = 68,
    Lang = "uk",
    Title = "Острог",
    Slug = "Ostroh",
    Description = "Острог — історичне місто з відомою академією, давніми церквами та культурними пам’ятками.",
    History = "Острог існує з XIV століття і був важливим центром освіти, культури та православної науки."
},

//--------------------Сумська область---------------------------------------

new CityTranslation
{
    id = 127,
    EntityId = 69,
    Lang = "en",
    Title = "Sumy",
    Slug = "Sumy",
    Description = "Sumy is a regional administrative center with cultural landmarks, parks, and industrial enterprises.",
    History = "Founded in the 17th century as a fortress city, Sumy became an important center of trade and culture in northeastern Ukraine."
},
new CityTranslation
{
    id = 128,
    EntityId = 69,
    Lang = "uk",
    Title = "Суми",
    Slug = "Sumy",
    Description = "Суми — обласний центр з культурними пам’ятками, парками та промисловими підприємствами.",
    History = "Засноване у XVII столітті як фортеця, місто Суми стало важливим центром торгівлі та культури на північному сході України."
},

new CityTranslation
{
    id = 129,
    EntityId = 70,
    Lang = "en",
    Title = "Konotop",
    Slug = "Konotop",
    Description = "Konotop is known for its historical battle sites, churches, and local cultural traditions.",
    History = "Konotop became famous after the 1659 battle and developed as a regional trade and military center."
},
new CityTranslation
{
    id = 130,
    EntityId = 70,
    Lang = "uk",
    Title = "Конотоп",
    Slug = "Konotop",
    Description = "Конотоп відоме історичними полями битв, церквами та місцевими культурними традиціями.",
    History = "Конотоп здобув популярність після битви 1659 року та розвивався як регіональний торговельний і військовий центр."
},

new CityTranslation
{
    id = 131,
    EntityId = 71,
    Lang = "en",
    Title = "Okhtyrka",
    Slug = "Okhtyrka",
    Description = "Okhtyrka is a city with historical churches, parks, and a rich local history.",
    History = "Established in the 17th century, Okhtyrka was an important Cossack town and administrative center."
},
new CityTranslation
{
    id = 132,
    EntityId = 71,
    Lang = "uk",
    Title = "Охтирка",
    Slug = "Okhtyrka",
    Description = "Охтирка — місто з історичними церквами, парками та багатою місцевою історією.",
    History = "Заснована у XVII столітті, Охтирка була важливим козацьким містом та адміністративним центром."
},

new CityTranslation
{
    id = 133,
    EntityId = 72,
    Lang = "en",
    Title = "Shostka",
    Slug = "Shostka",
    Description = "Shostka is an industrial city known for its chemical and manufacturing industries and local cultural sites.",
    History = "Shostka developed in the 18th-19th centuries as a center for chemical production and regional trade."
},
new CityTranslation
{
    id = 134,
    EntityId = 72,
    Lang = "uk",
    Title = "Шостка",
    Slug = "Shostka",
    Description = "Шостка — промислове місто, відоме хімічною та виробничою промисловістю, а також місцевими культурними пам’ятками.",
    History = "Шостка розвивалася у XVIII–XIX століттях як центр хімічного виробництва та регіональної торгівлі."
},


//--------------------Тернопільська область---------------------------------------

new CityTranslation
{
    id = 135,
    EntityId = 73,
    Lang = "en",
    Title = "Ternopil",
    Slug = "Ternopil",
    Description = "Ternopil is a cultural and educational center in western Ukraine, known for its lakes, parks, and historical landmarks.",
    History = "Ternopil was founded in the 16th century as a defensive settlement and developed into an important regional center of trade, culture, and education."
},
new CityTranslation
{
    id = 136,
    EntityId = 73,
    Lang = "uk",
    Title = "Тернопіль",
    Slug = "Ternopil",
    Description = "Тернопіль — культурний та освітній центр Західної України, відомий озерами, парками та історичними пам’ятками.",
    History = "Тернопіль заснований у XVI столітті як оборонне поселення та став важливим регіональним центром торгівлі, культури та освіти."
},

new CityTranslation
{
    id = 137,
    EntityId = 74,
    Lang = "en",
    Title = "Chortkiv",
    Slug = "Chortkiv",
    Description = "Chortkiv is famous for its architectural landmarks, churches, and rich cultural heritage.",
    History = "Chortkiv was first mentioned in the 15th century and developed as a key town in the historical region of Galicia."
},
new CityTranslation
{
    id = 138,
    EntityId = 74,
    Lang = "uk",
    Title = "Чортків",
    Slug = "Chortkiv",
    Description = "Чортків відомий архітектурними пам’ятками, церквами та багатою культурною спадщиною.",
    History = "Чортків вперше згадується у XV столітті та розвивався як важливе місто історичної Галичини."
},

new CityTranslation
{
    id = 139,
    EntityId = 75,
    Lang = "en",
    Title = "Kremenets",
    Slug = "Kremenets",
    Description = "Kremenets is known for its historic castle, scenic hills, and educational institutions.",
    History = "Kremenets has a long history dating back to the 11th century and was a significant cultural and defensive center in the region."
},
new CityTranslation
{
    id = 140,
    EntityId = 75,
    Lang = "uk",
    Title = "Кременець",
    Slug = "Kremenets",
    Description = "Кременець відомий історичною фортецею, мальовничими пагорбами та освітніми закладами.",
    History = "Кременець має давню історію з XI століття та був важливим культурним і оборонним центром регіону."
},

//--------------------Харківська область---------------------------------------

new CityTranslation
{
    id = 141,
    EntityId = 76,
    Lang = "en",
    Title = "Kharkiv",
    Slug = "Kharkiv",
    Description = "Kharkiv is a major industrial, cultural, and educational center in eastern Ukraine, known for theaters, universities, and parks.",
    History = "Kharkiv was founded in the mid-17th century as a fortress and grew into a major hub of trade, industry, and culture in eastern Ukraine."
},
new CityTranslation
{
    id = 142,
    EntityId = 76,
    Lang = "uk",
    Title = "Харків",
    Slug = "Kharkiv",
    Description = "Харків — великий промисловий, культурний та освітній центр Східної України, відомий театрами, університетами та парками.",
    History = "Харків заснований у середині XVII століття як фортеця і розвинувся у важливий центр торгівлі, промисловості та культури Східної України."
},

new CityTranslation
{
    id = 143,
    EntityId = 77,
    Lang = "en",
    Title = "Izium",
    Slug = "Izium",
    Description = "Izium is known for its historical monuments, rivers, and strategic location in the Donbas region.",
    History = "Izium developed as a Cossack settlement and later became an important trade and military town in eastern Ukraine."
},
new CityTranslation
{
    id = 144,
    EntityId = 77,
    Lang = "uk",
    Title = "Ізюм",
    Slug = "Izium",
    Description = "Ізюм відомий історичними пам’ятками, річками та стратегічним розташуванням у регіоні Донбас.",
    History = "Ізюм розвивався як козацьке поселення і згодом став важливим торговельним та військовим містом Східної України."
},

new CityTranslation
{
    id = 145,
    EntityId = 78,
    Lang = "en",
    Title = "Lozova",
    Slug = "Lozova",
    Description = "Lozova is a regional industrial town with historical sites and cultural traditions.",
    History = "Lozova grew during the 19th century as a railway hub and industrial center in eastern Ukraine."
},
new CityTranslation
{
    id = 146,
    EntityId = 78,
    Lang = "uk",
    Title = "Лозова",
    Slug = "Lozova",
    Description = "Лозова — регіональне промислове місто з історичними пам’ятками та культурними традиціями.",
    History = "Лозова розвивалася у XIX столітті як залізничний вузол та промисловий центр Східної України."
},

new CityTranslation
{
    id = 147,
    EntityId = 79,
    Lang = "en",
    Title = "Chuhuiv",
    Slug = "Chuhuiv",
    Description = "Chuhuiv is known for its military history, cultural heritage, and regional significance.",
    History = "Chuhuiv was founded in the 17th century as a fortress and became a key Cossack and trade center."
},
new CityTranslation
{
    id = 148,
    EntityId = 79,
    Lang = "uk",
    Title = "Чугуїв",
    Slug = "Chuhuiv",
    Description = "Чугуїв відомий військовою історією, культурною спадщиною та регіональним значенням.",
    History = "Чугуїв заснований у XVII столітті як фортеця і став важливим козацьким та торговельним центром."
},

//--------------------Херсонська область---------------------------------------

new CityTranslation
{
    id = 149,
    EntityId = 80,
    Lang = "en",
    Title = "Kherson",
    Slug = "Kherson",
    Description = "Kherson is a port city in southern Ukraine, located near the Dnipro River and the Black Sea, known for its parks and cultural landmarks.",
    History = "Kherson was founded in 1778 by the Russian Empire as a fortress and shipbuilding center. Over time, it developed into an important administrative and economic hub of southern Ukraine."
},
new CityTranslation
{
    id = 150,
    EntityId = 80,
    Lang = "uk",
    Title = "Херсон",
    Slug = "Kherson",
    Description = "Херсон — портове місто на півдні України, розташоване біля Дніпра та Чорного моря, відоме парками та культурними пам’ятками.",
    History = "Херсон заснований у 1778 році Російською імперією як фортеця та центр суднобудування. Згодом місто стало важливим адміністративним та економічним центром Півдня України."
},

new CityTranslation
{
    id = 151,
    EntityId = 81,
    Lang = "en",
    Title = "Nova Kakhovka",
    Slug = "NovaKakhovka",
    Description = "Nova Kakhovka is a modern city near the Kakhovka Reservoir, known for its hydroelectric power station and green spaces.",
    History = "Nova Kakhovka was established in 1952 during the construction of the Kakhovka Hydroelectric Power Plant and became a planned city for workers and engineers."
},
new CityTranslation
{
    id = 152,
    EntityId = 81,
    Lang = "uk",
    Title = "Нова Каховка",
    Slug = "NovaKakhovka",
    Description = "Нова Каховка — сучасне місто біля Каховського водосховища, відоме гідроелектростанцією та зеленими зонами.",
    History = "Нова Каховка заснована у 1952 році під час будівництва Каховської гідроелектростанції як планове місто для робітників та інженерів."
},

new CityTranslation
{
    id = 153,
    EntityId = 82,
    Lang = "en",
    Title = "Kakhovka",
    Slug = "Kakhovka",
    Description = "Kakhovka is a historic city on the Dnipro River, known for its cultural sites, water sports, and proximity to the Kakhovka Reservoir.",
    History = "Kakhovka was founded in the late 18th century as a fortress and later developed as a regional trade and cultural center."
},
new CityTranslation
{
    id = 154,
    EntityId = 82,
    Lang = "uk",
    Title = "Каховка",
    Slug = "Kakhovka",
    Description = "Каховка — історичне місто на Дніпрі, відоме культурними пам’ятками, водними видами спорту та близькістю до Каховського водосховища.",
    History = "Каховка заснована наприкінці XVIII століття як фортеця і згодом розвинулася як регіональний торговельний та культурний центр."
},

//--------------------Хмельницька область---------------------------------------

new CityTranslation
{
    id = 155,
    EntityId = 83,
    Lang = "en",
    Title = "Khmelnytskyi",
    Slug = "Khmelnytskyi",
    Description = "Khmelnytskyi is an industrial and cultural center in western Ukraine, featuring parks, theaters, and universities.",
    History = "Khmelnytskyi was founded in the 15th century and developed as a regional trade and administrative hub. The city was renamed after the Ukrainian Hetman Bohdan Khmelnytsky in the 20th century."
},
new CityTranslation
{
    id = 156,
    EntityId = 83,
    Lang = "uk",
    Title = "Хмельницький",
    Slug = "Khmelnytskyi",
    Description = "Хмельницький — промисловий та культурний центр Західної України, з парками, театрами та університетами.",
    History = "Хмельницький заснований у XV столітті та розвинувся як регіональний торговельний та адміністративний центр. Місто було назване на честь українського гетьмана Богдана Хмельницького у XX столітті."
},

new CityTranslation
{
    id = 157,
    EntityId = 84,
    Lang = "en",
    Title = "Kamianets-Podilskyi",
    Slug = "KamianetsPodilskyi",
    Description = "Kamianets-Podilskyi is famous for its medieval castle, historic old town, and scenic canyon views.",
    History = "Kamianets-Podilskyi dates back to the 11th century and was a major defensive and administrative center in Podilia."
},
new CityTranslation
{
    id = 158,
    EntityId = 84,
    Lang = "uk",
    Title = "Кам’янець-Подільський",
    Slug = "KamianetsPodilskyi",
    Description = "Кам’янець-Подільський відомий середньовічною фортецею, історичним старим містом та мальовничими каньйонними пейзажами.",
    History = "Кам’янець-Подільський існує з XI століття і був важливим оборонним та адміністративним центром Поділля."
},

new CityTranslation
{
    id = 159,
    EntityId = 85,
    Lang = "en",
    Title = "Shepetivka",
    Slug = "Shepetivka",
    Description = "Shepetivka is a regional transport and industrial town with cultural landmarks and parks.",
    History = "Shepetivka developed in the 19th century as a railway hub and became an important local economic and administrative center."
},
new CityTranslation
{
    id = 160,
    EntityId = 85,
    Lang = "uk",
    Title = "Шепетівка",
    Slug = "Shepetivka",
    Description = "Шепетівка — регіональне транспортне та промислове місто з культурними пам’ятками та парками.",
    History = "Шепетівка розвивалася у XIX столітті як залізничний вузол і стала важливим місцевим економічним та адміністративним центром."
},
//--------------------Черкаська область---------------------------------------

new CityTranslation
{
    id = 161,
    EntityId = 86,
    Lang = "en",
    Title = "Cherkasy",
    Slug = "Cherkasy",
    Description = "Cherkasy is a regional center on the Dnipro River, known for parks, museums, and cultural landmarks.",
    History = "Cherkasy was first mentioned in the 13th century. It grew as a trade and administrative hub in central Ukraine, playing an important role in regional history."
},
new CityTranslation
{
    id = 162,
    EntityId = 86,
    Lang = "uk",
    Title = "Черкаси",
    Slug = "Cherkasy",
    Description = "Черкаси — обласний центр на Дніпрі, відомий парками, музеями та культурними пам’ятками.",
    History = "Черкаси вперше згадані у XIII столітті. Місто розвивалося як торговельний та адміністративний центр Центральної України, відіграючи важливу роль у регіональній історії."
},

new CityTranslation
{
    id = 163,
    EntityId = 87,
    Lang = "en",
    Title = "Uman",
    Slug = "Uman",
    Description = "Uman is famous for its Sofiyivka Park, cultural heritage, and annual tourism attractions.",
    History = "Uman was founded in the 17th century and became known for its gardens and historical architecture."
},
new CityTranslation
{
    id = 164,
    EntityId = 87,
    Lang = "uk",
    Title = "Умань",
    Slug = "Uman",
    Description = "Умань відома парком «Софіївка», культурною спадщиною та туристичними пам’ятками.",
    History = "Умань заснована у XVII столітті і стала відомою своїми садами та історичною архітектурою."
},

new CityTranslation
{
    id = 165,
    EntityId = 88,
    Lang = "en",
    Title = "Smila",
    Slug = "Smila",
    Description = "Smila is an industrial and transport town on the Dnipro River, with cultural and natural sites.",
    History = "Smila developed in the 19th century as a local industrial center and river port."
},
new CityTranslation
{
    id = 166,
    EntityId = 88,
    Lang = "uk",
    Title = "Сміла",
    Slug = "Smila",
    Description = "Сміла — промислове та транспортне місто на Дніпрі, з культурними та природними об’єктами.",
    History = "Сміла розвивалася у XIX столітті як місцевий промисловий центр та річковий порт."
},

//--------------------Чернівецька область---------------------------------------

new CityTranslation
{
    id = 167,
    EntityId = 89,
    Lang = "en",
    Title = "Chernivtsi",
    Slug = "Chernivtsi",
    Description = "Chernivtsi is a cultural and educational hub in western Ukraine, known for its architecture and universities.",
    History = "Chernivtsi was founded in the 15th century and became an important center of education and culture, often called 'Little Vienna'."
},
new CityTranslation
{
    id = 168,
    EntityId = 89,
    Lang = "uk",
    Title = "Чернівці",
    Slug = "Chernivtsi",
    Description = "Чернівці — культурний та освітній центр Західної України, відомий архітектурою та університетами.",
    History = "Чернівці засновані у XV столітті та стали важливим центром освіти та культури, часто їх називають «Маленька Відень»."
},

new CityTranslation
{
    id = 169,
    EntityId = 90,
    Lang = "en",
    Title = "Khotyn",
    Slug = "Khotyn",
    Description = "Khotyn is famous for its medieval fortress, historic center, and scenic views of the Dniester River.",
    History = "Khotyn dates back to the 10th century and was a strategic fortress throughout regional conflicts."
},
new CityTranslation
{
    id = 170,
    EntityId = 90,
    Lang = "uk",
    Title = "Хотин",
    Slug = "Khotyn",
    Description = "Хотин відомий середньовічною фортецею, історичним центром та мальовничими краєвидами Дністра.",
    History = "Хотин існує з X століття і був стратегічною фортецею під час численних регіональних конфліктів."
},

new CityTranslation
{
    id = 171,
    EntityId = 91,
    Lang = "en",
    Title = "Novodnistrovsk",
    Slug = "Novodnistrovsk",
    Description = "Novodnistrovsk is a modern town on the Dniester River, known for its hydroelectric power plant and reservoirs.",
    History = "Novodnistrovsk was founded in the 1970s during the construction of the Dniester Hydroelectric Power Plant."
},
new CityTranslation
{
    id = 172,
    EntityId = 91,
    Lang = "uk",
    Title = "Новодністровськ",
    Slug = "Novodnistrovsk",
    Description = "Новодністровськ — сучасне місто на Дністрі, відоме гідроелектростанцією та водосховищами.",
    History = "Новодністровськ заснований у 1970-х роках під час будівництва Дністровської ГЕС."
},

//--------------------Чернігівська область---------------------------------------

new CityTranslation
{
    id = 173,
    EntityId = 92,
    Lang = "en",
    Title = "Chernihiv",
    Slug = "Chernihiv",
    Description = "Chernihiv is an ancient city in northern Ukraine, with cathedrals, monasteries, and historical landmarks.",
    History = "Chernihiv was founded over a thousand years ago and became one of the main centers of Kievan Rus."
},
new CityTranslation
{
    id = 174,
    EntityId = 92,
    Lang = "uk",
    Title = "Чернігів",
    Slug = "Chernihiv",
    Description = "Чернігів — давнє місто на півночі України, з соборами, монастирями та історичними пам’ятками.",
    History = "Чернігів заснований понад тисячу років тому і став одним із головних центрів Київської Русі."
},

new CityTranslation
{
    id = 175,
    EntityId = 93,
    Lang = "en",
    Title = "Nizhyn",
    Slug = "Nizhyn",
    Description = "Nizhyn is known for its historic architecture, churches, and traditional cultural heritage.",
    History = "Nizhyn developed in the 17th century as a trade town and later became an educational center."
},
new CityTranslation
{
    id = 176,
    EntityId = 93,
    Lang = "uk",
    Title = "Ніжин",
    Slug = "Nizhyn",
    Description = "Ніжин відомий історичною архітектурою, церквами та традиційною культурною спадщиною.",
    History = "Ніжин розвивався у XVII столітті як торгове місто, згодом став освітнім центром."
},

new CityTranslation
{
    id = 177,
    EntityId = 94,
    Lang = "en",
    Title = "Pryluky",
    Slug = "Pryluky",
    Description = "Pryluky is a regional town with historic churches, local museums, and green spaces.",
    History = "Pryluky was first mentioned in the 12th century and developed as a local administrative and trade hub."
},
new CityTranslation
{
    id = 178,
    EntityId = 94,
    Lang = "uk",
    Title = "Прилуки",
    Slug = "Pryluky",
    Description = "Прилуки — регіональне місто з історичними церквами, місцевими музеями та зеленими зонами.",
    History = "Прилуки вперше згадані у XII столітті і розвивалися як місцевий адміністративний та торговельний центр."
},






// =================== USA ===================

new CityTranslation
{
    id = 179,
    EntityId = 95,
    Lang = "en",
    Title = "New York",
    Slug = "NewYork",
    Description = "New York City is the largest city in the USA, famous for its skyline, Broadway theaters, and cultural diversity.",
    History = "Founded in 1624 as a Dutch settlement called New Amsterdam, it became New York in 1664 and grew into a major economic and cultural hub."
},
new CityTranslation
{
    id = 180,
    EntityId = 95,
    Lang = "uk",
    Title = "Нью-Йорк",
    Slug = "NewYork",
    Description = "Нью-Йорк — найбільше місто США, відоме своїм горизонтом, театрами Бродвею та культурним розмаїттям.",
    History = "Засноване у 1624 році як голландське поселення Нью-Амстердам, стало Нью-Йорком у 1664 році і перетворилося на важливий економічний та культурний центр."
},

new CityTranslation
{
    id = 181,
    EntityId = 96,
    Lang = "en",
    Title = "Los Angeles",
    Slug = "LosAngeles",
    Description = "Los Angeles is known for Hollywood, entertainment industry, beaches, and diverse neighborhoods.",
    History = "Founded in 1781, Los Angeles grew rapidly during the 20th century, becoming the center of film, television, and cultural innovation."
},
new CityTranslation
{
    id = 182,
    EntityId = 96,
    Lang = "uk",
    Title = "Лос-Анджелес",
    Slug = "LosAngeles",
    Description = "Лос-Анджелес відомий Голлівудом, індустрією розваг, пляжами та різноманітними районами.",
    History = "Засноване у 1781 році, Лос-Анджелес швидко розвивалося у XX столітті, ставши центром кіно, телебачення та культурних інновацій."
},

new CityTranslation
{
    id = 183,
    EntityId = 97,
    Lang = "en",
    Title = "Chicago",
    Slug = "Chicago",
    Description = "Chicago is a major city on Lake Michigan, famous for its architecture, deep-dish pizza, and jazz music.",
    History = "Founded in 1833, Chicago became a major transportation and industrial hub in the 19th century, rebuilding rapidly after the Great Fire of 1871."
},
new CityTranslation
{
    id = 184,
    EntityId = 97,
    Lang = "uk",
    Title = "Чикаго",
    Slug = "Chicago",
    Description = "Чикаго — велике місто на озері Мічиган, відоме архітектурою, піцою deep-dish та джазовою музикою.",
    History = "Засноване у 1833 році, Чикаго стало важливим транспортним та промисловим центром у XIX столітті, швидко відновившись після Великої пожежі 1871 року."
},

// =================== Germany ===================

new CityTranslation
{
    id = 185,
    EntityId = 98,
    Lang = "en",
    Title = "Berlin",
    Slug = "Berlin",
    Description = "Berlin is the capital of Germany, known for its history, modern culture, museums, and landmarks like the Brandenburg Gate.",
    History = "Berlin has a rich history dating back to the 13th century and became the capital of unified Germany in 1871."
},
new CityTranslation
{
    id = 186,
    EntityId = 98,
    Lang = "uk",
    Title = "Берлін",
    Slug = "Berlin",
    Description = "Берлін — столиця Німеччини, відомий історією, сучасною культурою, музеями та пам’ятками, такими як Бранденбурзькі ворота.",
    History = "Берлін має багату історію, що сягає XIII століття, і став столицею об’єднаної Німеччини у 1871 році."
},

new CityTranslation
{
    id = 187,
    EntityId = 99,
    Lang = "en",
    Title = "Munich",
    Slug = "Munich",
    Description = "Munich is famous for its beer culture, Oktoberfest festival, historical architecture, and vibrant arts scene.",
    History = "Founded in 1158, Munich grew into the capital of Bavaria and a major cultural and economic center."
},
new CityTranslation
{
    id = 188,
    EntityId = 99,
    Lang = "uk",
    Title = "Мюнхен",
    Slug = "Munich",
    Description = "Мюнхен відомий пивною культурою, фестивалем Октоберфест, історичною архітектурою та яскравим мистецьким життям.",
    History = "Заснований у 1158 році, Мюнхен став столицею Баварії та важливим культурним і економічним центром."
},

new CityTranslation
{
    id = 189,
    EntityId = 100,
    Lang = "en",
    Title = "Hamburg",
    Slug = "Hamburg",
    Description = "Hamburg is a major port city in northern Germany, known for its harbor, canals, and vibrant cultural scene.",
    History = "Founded in the 9th century, Hamburg became a member of the Hanseatic League and developed into a major trading hub."
},
new CityTranslation
{
    id = 190,
    EntityId = 100,
    Lang = "uk",
    Title = "Гамбург",
    Slug = "Hamburg",
    Description = "Гамбург — велике портове місто на півночі Німеччини, відоме своїм портом, каналами та яскравим культурним життям.",
    History = "Заснований у IX столітті, Гамбург став членом Ганзейського союзу і розвинувся в значний торговельний центр."
},

// =================== France ===================

new CityTranslation
{
    id = 191,
    EntityId = 101,
    Lang = "en",
    Title = "Paris",
    Slug = "Paris",
    Description = "Paris is the capital of France, famous for the Eiffel Tower, art museums, fashion, and romantic atmosphere.",
    History = "Founded in the 3rd century BC by the Parisii tribe, Paris became a major center of culture, politics, and economy over the centuries."
},
new CityTranslation
{
    id = 192,
    EntityId = 101,
    Lang = "uk",
    Title = "Париж",
    Slug = "Paris",
    Description = "Париж — столиця Франції, відомий Ейфелевою вежею, художніми музеями, модою та романтичною атмосферою.",
    History = "Заснований у III столітті до н.е. племенем паризіїв, Париж згодом став важливим культурним, політичним та економічним центром."
},

new CityTranslation
{
    id = 193,
    EntityId = 102,
    Lang = "en",
    Title = "Lyon",
    Slug = "Lyon",
    Description = "Lyon is known for its historical and architectural landmarks, gastronomy, and vibrant cultural scene.",
    History = "Founded by the Romans in 43 BC as Lugdunum, Lyon became a major center of commerce and silk production."
},
new CityTranslation
{
    id = 194,
    EntityId = 102,
    Lang = "uk",
    Title = "Ліон",
    Slug = "Lyon",
    Description = "Ліон відомий історичними та архітектурними пам’ятками, гастрономією та яскравим культурним життям.",
    History = "Заснований римлянами у 43 році до н.е. як Лугдунум, Ліон став важливим центром торгівлі та виробництва шовку."
},

new CityTranslation
{
    id = 195,
    EntityId = 103,
    Lang = "en",
    Title = "Marseille",
    Slug = "Marseille",
    Description = "Marseille is a major port city in southern France, famous for its Old Port, diverse culture, and Mediterranean cuisine.",
    History = "Founded around 600 BC by Greek settlers from Phocaea, Marseille grew into a strategic port and commercial hub."
},
new CityTranslation
{
    id = 196,
    EntityId = 103,
    Lang = "uk",
    Title = "Марсель",
    Slug = "Marseille",
    Description = "Марсель — велике портове місто на півдні Франції, відоме Старим портом, різноманітною культурою та середземноморською кухнею.",
    History = "Засноване близько 600 року до н.е. грецькими колоністами з Фокей, Марсель став стратегічним портом і торговельним центром."
},

// =================== UK ===================

new CityTranslation
{
    id = 197,
    EntityId = 104,
    Lang = "en",
    Title = "London",
    Slug = "London",
    Description = "London is the capital of the UK, known for its historic landmarks, cultural institutions, and financial district.",
    History = "Founded by the Romans as Londinium in 43 AD, London has grown into a global cultural, political, and economic hub."
},
new CityTranslation
{
    id = 198,
    EntityId = 104,
    Lang = "uk",
    Title = "Лондон",
    Slug = "London",
    Description = "Лондон — столиця Великої Британії, відомий історичними пам’ятками, культурними установами та фінансовим центром.",
    History = "Заснований римлянами як Лондиніум у 43 році н.е., Лондон перетворився на глобальний культурний, політичний та економічний центр."
},

new CityTranslation
{
    id = 199,
    EntityId = 105,
    Lang = "en",
    Title = "Manchester",
    Slug = "Manchester",
    Description = "Manchester is famous for its industrial heritage, music scene, football culture, and universities.",
    History = "Manchester grew rapidly during the Industrial Revolution as a major textile manufacturing city."
},
new CityTranslation
{
    id = 200,
    EntityId = 105,
    Lang = "uk",
    Title = "Манчестер",
    Slug = "Manchester",
    Description = "Манчестер відомий промисловою спадщиною, музичною сценою, футбольною культурою та університетами.",
    History = "Манчестер швидко розвивався під час промислової революції як великий центр текстильної промисловості."
},

new CityTranslation
{
    id = 201,
    EntityId = 106,
    Lang = "en",
    Title = "Birmingham",
    Slug = "Birmingham",
    Description = "Birmingham is a major city in England, known for its manufacturing history, canals, and vibrant arts and music scene.",
    History = "Birmingham expanded rapidly in the 18th and 19th centuries as an industrial powerhouse, shaping modern England’s economy."
},
new CityTranslation
{
    id = 202,
    EntityId = 106,
    Lang = "uk",
    Title = "Бірмінгем",
    Slug = "Birmingham",
    Description = "Бірмінгем — велике місто в Англії, відоме промисловою історією, каналами та яскравим мистецьким і музичним життям.",
    History = "Бірмінгем швидко розвивався у XVIII–XIX століттях як промисловий центр, формуючи сучасну економіку Англії."
},


// =================== Spain ===================

new CityTranslation
{
    id = 203,
    EntityId = 107,
    Lang = "en",
    Title = "Madrid",
    Slug = "Madrid",
    Description = "Madrid is the capital of Spain, famous for its royal palace, museums, and vibrant cultural life.",
    History = "Founded in the 9th century as a fortress town, Madrid became the capital of Spain in 1561 and has been a major political and cultural center since."
},
new CityTranslation
{
    id = 204,
    EntityId = 107,
    Lang = "uk",
    Title = "Мадрид",
    Slug = "Madrid",
    Description = "Мадрид — столиця Іспанії, відомий королівським палацом, музеями та яскравим культурним життям.",
    History = "Заснований у IX столітті як фортеця, Мадрид став столицею Іспанії у 1561 році та з тих пір є важливим політичним і культурним центром."
},

new CityTranslation
{
    id = 205,
    EntityId = 108,
    Lang = "en",
    Title = "Barcelona",
    Slug = "Barcelona",
    Description = "Barcelona is a coastal city in Spain, famous for its architecture by Antoni Gaudí, beaches, and lively cultural scene.",
    History = "Founded by the Romans as Barcino, Barcelona grew into a major medieval trading hub and later a center of art, culture, and commerce."
},
new CityTranslation
{
    id = 206,
    EntityId = 108,
    Lang = "uk",
    Title = "Барселона",
    Slug = "Barcelona",
    Description = "Барселона — прибережне місто Іспанії, відоме архітектурою Антоніо Гауді, пляжами та активним культурним життям.",
    History = "Заснована римлянами як Барсіно, Барселона перетворилася на важливий середньовічний торговельний центр, а пізніше — на центр мистецтва, культури та торгівлі."
},

new CityTranslation
{
    id = 207,
    EntityId = 109,
    Lang = "en",
    Title = "Valencia",
    Slug = "Valencia",
    Description = "Valencia is a port city on Spain’s southeastern coast, known for its City of Arts and Sciences and historic old town.",
    History = "Founded as a Roman colony in 138 BC, Valencia has a rich history of commerce, culture, and architecture."
},
new CityTranslation
{
    id = 208,
    EntityId = 109,
    Lang = "uk",
    Title = "Валенсія",
    Slug = "Valencia",
    Description = "Валенсія — портове місто на південному сході Іспанії, відоме Містом мистецтв і наук та історичним старим містом.",
    History = "Заснована як римська колонія у 138 році до н.е., Валенсія має багату історію торгівлі, культури та архітектури."
},

// =================== Poland ===================

new CityTranslation
{
    id = 209,
    EntityId = 110,
    Lang = "en",
    Title = "Warsaw",
    Slug = "Warsaw",
    Description = "Warsaw is the capital of Poland, known for its historic old town, Royal Castle, and modern urban landscape.",
    History = "Founded in the 13th century, Warsaw became Poland’s capital in 1596 and has undergone major rebuilding after World War II."
},
new CityTranslation
{
    id = 210,
    EntityId = 110,
    Lang = "uk",
    Title = "Варшава",
    Slug = "Warsaw",
    Description = "Варшава — столиця Польщі, відома історичним старим містом, Королівським замком та сучасним міським ландшафтом.",
    History = "Заснована у XIII столітті, Варшава стала столицею Польщі у 1596 році і була відновлена після значних руйнувань під час Другої світової війни."
},

new CityTranslation
{
    id = 211,
    EntityId = 111,
    Lang = "en",
    Title = "Krakow",
    Slug = "Krakow",
    Description = "Krakow is a historic city in Poland, famous for its medieval old town, Wawel Castle, and vibrant cultural life.",
    History = "Founded in the 7th century, Krakow was the royal capital of Poland until 1596 and remains a cultural and academic center."
},
new CityTranslation
{
    id = 212,
    EntityId = 111,
    Lang = "uk",
    Title = "Краків",
    Slug = "Krakow",
    Description = "Краків — історичне місто в Польщі, відоме середньовічним старим містом, Вавельським замком та яскравим культурним життям.",
    History = "Заснований у VII столітті, Краків був королівською столицею Польщі до 1596 року та залишається культурним і науковим центром."
},

new CityTranslation
{
    id = 213,
    EntityId = 112,
    Lang = "en",
    Title = "Poznan",
    Slug = "Poznan",
    Description = "Poznan is a major city in western Poland, known for its renaissance old town, trade fairs, and universities.",
    History = "Founded in the 10th century, Poznan became an important political, commercial, and cultural hub in Poland."
},
new CityTranslation
{
    id = 214,
    EntityId = 112,
    Lang = "uk",
    Title = "Познань",
    Slug = "Poznan",
    Description = "Познань — велике місто на заході Польщі, відоме ренесансним старим містом, ярмарками та університетами.",
    History = "Заснована у X столітті, Познань стала важливим політичним, торговельним та культурним центром Польщі."
}

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
                new DistrictTranslation { id = 12, EntityId = 6, Lang = "uk", Title = "Залізничний район" },

                // Одеса
                new DistrictTranslation { id = 13, EntityId = 7, Lang = "en", Title = "Primorskyi District" },
                new DistrictTranslation { id = 14, EntityId = 7, Lang = "uk", Title = "Приморський район" },
                new DistrictTranslation { id = 15, EntityId = 8, Lang = "en", Title = "Malynovskyi District" },
                new DistrictTranslation { id = 16, EntityId = 8, Lang = "uk", Title = "Малиновський район" },
                new DistrictTranslation { id = 17, EntityId = 9, Lang = "en", Title = "Kyivskyi District" },
                new DistrictTranslation { id = 18, EntityId = 9, Lang = "uk", Title = "Київський район" },

                // Харків
                new DistrictTranslation { id = 19, EntityId = 10, Lang = "en", Title = "Kharkivskyi District" },
                new DistrictTranslation { id = 20, EntityId = 10, Lang = "uk", Title = "Харківський район" },
                new DistrictTranslation { id = 21, EntityId = 11, Lang = "en", Title = "Saltivskyi District" },
                new DistrictTranslation { id = 22, EntityId = 11, Lang = "uk", Title = "Салтівський район" },
                new DistrictTranslation { id = 23, EntityId = 12, Lang = "en", Title = "Osnovianskyi District" },
                new DistrictTranslation { id = 24, EntityId = 12, Lang = "uk", Title = "Основ'янський район" },

                // Дніпро
                new DistrictTranslation { id = 25, EntityId = 13, Lang = "en", Title = "Sobornyi District" },
                new DistrictTranslation { id = 26, EntityId = 13, Lang = "uk", Title = "Соборний район" },
                new DistrictTranslation { id = 27, EntityId = 14, Lang = "en", Title = "Shevchenkivskyi District" },
                new DistrictTranslation { id = 28, EntityId = 14, Lang = "uk", Title = "Шевченківський район" },
                new DistrictTranslation { id = 29, EntityId = 15, Lang = "en", Title = "Central District" },
                new DistrictTranslation { id = 30, EntityId = 15, Lang = "uk", Title = "Центральний район" },

                // Запоріжжя
                new DistrictTranslation { id = 31, EntityId = 16, Lang = "en", Title = "Zavodskyi District" },
                new DistrictTranslation { id = 32, EntityId = 16, Lang = "uk", Title = "Заводський район" },
                new DistrictTranslation { id = 33, EntityId = 17, Lang = "en", Title = "Oleksandrivskyi District" },
                new DistrictTranslation { id = 34, EntityId = 17, Lang = "uk", Title = "Олександрівський район" },
                new DistrictTranslation { id = 35, EntityId = 18, Lang = "en", Title = "Komunarskyi District" },
                new DistrictTranslation { id = 36, EntityId = 18, Lang = "uk", Title = "Комунарський район" },

                // Івано-Франківськ
                new DistrictTranslation { id = 37, EntityId = 19, Lang = "en", Title = "City Center" },
                new DistrictTranslation { id = 38, EntityId = 19, Lang = "uk", Title = "Центр міста" },
                new DistrictTranslation { id = 39, EntityId = 20, Lang = "en", Title = "Prykarpattia District" },
                new DistrictTranslation { id = 40, EntityId = 20, Lang = "uk", Title = "Прикарпатський район" },
                new DistrictTranslation { id = 41, EntityId = 21, Lang = "en", Title = "North District" },
                new DistrictTranslation { id = 42, EntityId = 21, Lang = "uk", Title = "Північний район" },

                // Чернівці
                new DistrictTranslation { id = 43, EntityId = 22, Lang = "en", Title = "City Center" },
                new DistrictTranslation { id = 44, EntityId = 22, Lang = "uk", Title = "Центр міста" },
                new DistrictTranslation { id = 45, EntityId = 23, Lang = "en", Title = "East District" },
                new DistrictTranslation { id = 46, EntityId = 23, Lang = "uk", Title = "Східний район" },
                new DistrictTranslation { id = 47, EntityId = 24, Lang = "en", Title = "South District" },
                new DistrictTranslation { id = 48, EntityId = 24, Lang = "uk", Title = "Південний район" },


            // Рівне
            new DistrictTranslation { id = 55, EntityId = 25, Lang = "en", Title = "Central" },
            new DistrictTranslation { id = 56, EntityId = 25, Lang = "uk", Title = "Центр" },
            new DistrictTranslation { id = 57, EntityId = 26, Lang = "en", Title = "East" },
            new DistrictTranslation { id = 58, EntityId = 26, Lang = "uk", Title = "Схід" },
            new DistrictTranslation { id = 59, EntityId = 27, Lang = "en", Title = "West" },
            new DistrictTranslation { id = 60, EntityId = 27, Lang = "uk", Title = "Захід" },

            // Вінниця
            new DistrictTranslation { id = 61, EntityId = 28, Lang = "en", Title = "Central" },
            new DistrictTranslation { id = 62, EntityId = 28, Lang = "uk", Title = "Центр" },
            new DistrictTranslation { id = 63, EntityId = 29, Lang = "en", Title = "North" },
            new DistrictTranslation { id = 64, EntityId = 29, Lang = "uk", Title = "Північ" },
            new DistrictTranslation { id = 65, EntityId = 30, Lang = "en", Title = "South" },
            new DistrictTranslation { id = 66, EntityId = 30, Lang = "uk", Title = "Південь" },

            // Черкаси
            new DistrictTranslation { id = 67, EntityId = 31, Lang = "en", Title = "Central" },
            new DistrictTranslation { id = 68, EntityId = 31, Lang = "uk", Title = "Центр" },
            new DistrictTranslation { id = 69, EntityId = 32, Lang = "en", Title = "North" },
            new DistrictTranslation { id = 70, EntityId = 32, Lang = "uk", Title = "Північ" },
            new DistrictTranslation { id = 71, EntityId = 33, Lang = "en", Title = "South" },
            new DistrictTranslation { id = 72, EntityId = 33, Lang = "uk", Title = "Південь" },

            // Полтава
            new DistrictTranslation { id = 73, EntityId = 34, Lang = "en", Title = "Central" },
            new DistrictTranslation { id = 74, EntityId = 34, Lang = "uk", Title = "Центр" },
            new DistrictTranslation { id = 75, EntityId = 35, Lang = "en", Title = "North" },
            new DistrictTranslation { id = 76, EntityId = 35, Lang = "uk", Title = "Північ" },
            new DistrictTranslation { id = 77, EntityId = 36, Lang = "en", Title = "South" },
            new DistrictTranslation { id = 78, EntityId = 36, Lang = "uk", Title = "Південь" },

            // Кропивницький
            new DistrictTranslation { id = 79, EntityId = 37, Lang = "en", Title = "Central" },
            new DistrictTranslation { id = 80, EntityId = 37, Lang = "uk", Title = "Центр" },
            new DistrictTranslation { id = 81, EntityId = 38, Lang = "en", Title = "East" },
            new DistrictTranslation { id = 82, EntityId = 38, Lang = "uk", Title = "Схід" },
            new DistrictTranslation { id = 83, EntityId = 39, Lang = "en", Title = "West" },
            new DistrictTranslation { id = 84, EntityId = 39, Lang = "uk", Title = "Захід" },

            // Миколаїв
            new DistrictTranslation { id = 85, EntityId = 40, Lang = "en", Title = "Central" },
            new DistrictTranslation { id = 86, EntityId = 40, Lang = "uk", Title = "Центр" },
            new DistrictTranslation { id = 87, EntityId = 41, Lang = "en", Title = "North" },
            new DistrictTranslation { id = 88, EntityId = 41, Lang = "uk", Title = "Північ" },
            new DistrictTranslation { id = 89, EntityId = 42, Lang = "en", Title = "South" },
            new DistrictTranslation { id = 90, EntityId = 42, Lang = "uk", Title = "Південь" },

            // Херсон
            new DistrictTranslation { id = 91, EntityId = 43, Lang = "en", Title = "Central" },
            new DistrictTranslation { id = 92, EntityId = 43, Lang = "uk", Title = "Центр" },
            new DistrictTranslation { id = 93, EntityId = 44, Lang = "en", Title = "North" },
            new DistrictTranslation { id = 94, EntityId = 44, Lang = "uk", Title = "Північ" },
            new DistrictTranslation { id = 95, EntityId = 45, Lang = "en", Title = "South" },
            new DistrictTranslation { id = 96, EntityId = 45, Lang = "uk", Title = "Південь" },

            // Луцьк
            new DistrictTranslation { id = 97, EntityId = 46, Lang = "en", Title = "Central" },
            new DistrictTranslation { id = 98, EntityId = 46, Lang = "uk", Title = "Центр" },
            new DistrictTranslation { id = 99, EntityId = 47, Lang = "en", Title = "North" },
            new DistrictTranslation { id = 100, EntityId = 47, Lang = "uk", Title = "Північ" },
            new DistrictTranslation { id = 101, EntityId = 48, Lang = "en", Title = "South" },
            new DistrictTranslation { id = 102, EntityId = 48, Lang = "uk", Title = "Південь" },
            // =================== DistrictTranslation ===================

            // New York
            new DistrictTranslation { id = 103, EntityId = 49, Lang = "en", Title = "Manhattan" },
            new DistrictTranslation { id = 104, EntityId = 49, Lang = "uk", Title = "Манхеттен" },
            new DistrictTranslation { id = 105, EntityId = 50, Lang = "en", Title = "Brooklyn" },
            new DistrictTranslation { id = 106, EntityId = 50, Lang = "uk", Title = "Бруклін" },
            new DistrictTranslation { id = 107, EntityId = 51, Lang = "en", Title = "Queens" },
            new DistrictTranslation { id = 108, EntityId = 51, Lang = "uk", Title = "Квінс" },

            // Los Angeles
            new DistrictTranslation { id = 109, EntityId = 52, Lang = "en", Title = "Hollywood" },
            new DistrictTranslation { id = 110, EntityId = 52, Lang = "uk", Title = "Голлівуд" },
            new DistrictTranslation { id = 111, EntityId = 53, Lang = "en", Title = "Downtown LA" },
            new DistrictTranslation { id = 112, EntityId = 53, Lang = "uk", Title = "Центр ЛА" },
            new DistrictTranslation { id = 113, EntityId = 54, Lang = "en", Title = "Santa Monica" },
            new DistrictTranslation { id = 114, EntityId = 54, Lang = "uk", Title = "Санта-Моніка" },

            // Chicago
            new DistrictTranslation { id = 115, EntityId = 106, Lang = "en", Title = "Loop" },
            new DistrictTranslation { id = 116, EntityId = 106, Lang = "uk", Title = "Луп" },
            new DistrictTranslation { id = 117, EntityId = 107, Lang = "en", Title = "Lincoln Park" },
            new DistrictTranslation { id = 118, EntityId = 107, Lang = "uk", Title = "Лінкольн-Парк" },
            new DistrictTranslation { id = 119, EntityId = 108, Lang = "en", Title = "South Side" },
            new DistrictTranslation { id = 120, EntityId = 108, Lang = "uk", Title = "Південна частина" },

            // Berlin
            new DistrictTranslation { id = 121, EntityId = 109, Lang = "en", Title = "Mitte" },
            new DistrictTranslation { id = 122, EntityId = 109, Lang = "uk", Title = "Мітте" },
            new DistrictTranslation { id = 123, EntityId = 110, Lang = "en", Title = "Charlottenburg" },
            new DistrictTranslation { id = 124, EntityId = 110, Lang = "uk", Title = "Шарлоттенбург" },
            new DistrictTranslation { id = 125, EntityId = 111, Lang = "en", Title = "Kreuzberg" },
            new DistrictTranslation { id = 126, EntityId = 111, Lang = "uk", Title = "Кройцберг" },

            // Munich
            new DistrictTranslation { id = 127, EntityId = 112, Lang = "en", Title = "Altstadt" },
            new DistrictTranslation { id = 128, EntityId = 112, Lang = "uk", Title = "Старе місто" },
            new DistrictTranslation { id = 129, EntityId = 113, Lang = "en", Title = "Schwabing" },
            new DistrictTranslation { id = 130, EntityId = 113, Lang = "uk", Title = "Швабінг" },
            new DistrictTranslation { id = 131, EntityId = 114, Lang = "en", Title = "Maxvorstadt" },
            new DistrictTranslation { id = 132, EntityId = 114, Lang = "uk", Title = "Максфорштадт" },

            // Hamburg
            new DistrictTranslation { id = 133, EntityId = 115, Lang = "en", Title = "Altstadt" },
            new DistrictTranslation { id = 134, EntityId = 115, Lang = "uk", Title = "Старе місто" },
            new DistrictTranslation { id = 135, EntityId = 116, Lang = "en", Title = "St. Pauli" },
            new DistrictTranslation { id = 136, EntityId = 116, Lang = "uk", Title = "Санкт-Паулі" },
            new DistrictTranslation { id = 137, EntityId = 117, Lang = "en", Title = "Altona" },
            new DistrictTranslation { id = 138, EntityId = 117, Lang = "uk", Title = "Альтона" },

            // Paris
            new DistrictTranslation { id = 139, EntityId = 118, Lang = "en", Title = "Montmartre" },
            new DistrictTranslation { id = 140, EntityId = 118, Lang = "uk", Title = "Монмартр" },
            new DistrictTranslation { id = 141, EntityId = 119, Lang = "en", Title = "Latin Quarter" },
            new DistrictTranslation { id = 142, EntityId = 119, Lang = "uk", Title = "Латинський квартал" },
            new DistrictTranslation { id = 143, EntityId = 120, Lang = "en", Title = "Marais" },
            new DistrictTranslation { id = 144, EntityId = 120, Lang = "uk", Title = "Маре" },

            // Lyon
            new DistrictTranslation { id = 145, EntityId = 121, Lang = "en", Title = "Presqu'île" },
            new DistrictTranslation { id = 146, EntityId = 121, Lang = "uk", Title = "Преск’іль" },
            new DistrictTranslation { id = 147, EntityId = 122, Lang = "en", Title = "Croix-Rousse" },
            new DistrictTranslation { id = 148, EntityId = 122, Lang = "uk", Title = "Круа-Рус" },
            new DistrictTranslation { id = 149, EntityId = 123, Lang = "en", Title = "Part-Dieu" },
            new DistrictTranslation { id = 150, EntityId = 123, Lang = "uk", Title = "Пар-Дьє" },


            // Marseille
            new DistrictTranslation { id = 151, EntityId = 124, Lang = "en", Title = "Old Port" },
            new DistrictTranslation { id = 152, EntityId = 124, Lang = "uk", Title = "Старий порт" },
            new DistrictTranslation { id = 153, EntityId = 125, Lang = "en", Title = "Le Panier" },
            new DistrictTranslation { id = 154, EntityId = 125, Lang = "uk", Title = "Ле Пан’є" },
            new DistrictTranslation { id = 155, EntityId = 126, Lang = "en", Title = "La Joliette" },
            new DistrictTranslation { id = 156, EntityId = 126, Lang = "uk", Title = "Ла Жольєт" },

            // London
            new DistrictTranslation { id = 157, EntityId = 127, Lang = "en", Title = "Camden" },
            new DistrictTranslation { id = 158, EntityId = 127, Lang = "uk", Title = "Кемден" },
            new DistrictTranslation { id = 159, EntityId = 128, Lang = "en", Title = "Westminster" },
            new DistrictTranslation { id = 160, EntityId = 128, Lang = "uk", Title = "Вестмінстер" },
            new DistrictTranslation { id = 161, EntityId = 129, Lang = "en", Title = "Greenwich" },
            new DistrictTranslation { id = 162, EntityId = 129, Lang = "uk", Title = "Грінвіч" },

            // Manchester
            new DistrictTranslation { id = 163, EntityId = 130, Lang = "en", Title = "Salford" },
            new DistrictTranslation { id = 164, EntityId = 130, Lang = "uk", Title = "Салфорд" },
            new DistrictTranslation { id = 165, EntityId = 131, Lang = "en", Title = "Didsbury" },
            new DistrictTranslation { id = 166, EntityId = 131, Lang = "uk", Title = "Дідсбері" },
            new DistrictTranslation { id = 167, EntityId = 132, Lang = "en", Title = "Cheetham Hill" },
            new DistrictTranslation { id = 168, EntityId = 132, Lang = "uk", Title = "Чітем-Гілл" },

            // Birmingham
            new DistrictTranslation { id = 169, EntityId = 133, Lang = "en", Title = "City Centre" },
            new DistrictTranslation { id = 170, EntityId = 133, Lang = "uk", Title = "Центр міста" },
            new DistrictTranslation { id = 171, EntityId = 134, Lang = "en", Title = "Edgbaston" },
            new DistrictTranslation { id = 172, EntityId = 134, Lang = "uk", Title = "Еджбастон" },
            new DistrictTranslation { id = 173, EntityId = 135, Lang = "en", Title = "Selly Oak" },
            new DistrictTranslation { id = 174, EntityId = 135, Lang = "uk", Title = "Селлі-Оук" },

            // Madrid
            new DistrictTranslation { id = 175, EntityId = 136, Lang = "en", Title = "Centro" },
            new DistrictTranslation { id = 176, EntityId = 136, Lang = "uk", Title = "Центро" },
            new DistrictTranslation { id = 177, EntityId = 137, Lang = "en", Title = "Salamanca" },
            new DistrictTranslation { id = 178, EntityId = 137, Lang = "uk", Title = "Саламанка" },
            new DistrictTranslation { id = 179, EntityId = 138, Lang = "en", Title = "Chamartín" },
            new DistrictTranslation { id = 180, EntityId = 138, Lang = "uk", Title = "Чамартін" },

            // Barcelona
            new DistrictTranslation { id = 181, EntityId = 139, Lang = "en", Title = "Eixample" },
            new DistrictTranslation { id = 182, EntityId = 139, Lang = "uk", Title = "Ейшампле" },
            new DistrictTranslation { id = 183, EntityId = 140, Lang = "en", Title = "Gràcia" },
            new DistrictTranslation { id = 184, EntityId = 140, Lang = "uk", Title = "Грасія" },
            new DistrictTranslation { id = 185, EntityId = 141, Lang = "en", Title = "Ciutat Vella" },
            new DistrictTranslation { id = 186, EntityId = 141, Lang = "uk", Title = "С’юта Велья" },

            // Valencia
            new DistrictTranslation { id = 187, EntityId = 142, Lang = "en", Title = "El Carmen" },
            new DistrictTranslation { id = 188, EntityId = 142, Lang = "uk", Title = "Ель Кармен" },
            new DistrictTranslation { id = 189, EntityId = 143, Lang = "en", Title = "Ruzafa" },
            new DistrictTranslation { id = 190, EntityId = 143, Lang = "uk", Title = "Русaфа" },
            new DistrictTranslation { id = 191, EntityId = 144, Lang = "en", Title = "Benimaclet" },
            new DistrictTranslation { id = 192, EntityId = 144, Lang = "uk", Title = "Бенімаcлет" },

            // Warsaw
            new DistrictTranslation { id = 193, EntityId = 145, Lang = "en", Title = "Śródmieście" },
            new DistrictTranslation { id = 194, EntityId = 145, Lang = "uk", Title = "Шродмієстє" },
            new DistrictTranslation { id = 195, EntityId = 146, Lang = "en", Title = "Praga-Północ" },
            new DistrictTranslation { id = 196, EntityId = 146, Lang = "uk", Title = "Прага-Північ" },
            new DistrictTranslation { id = 197, EntityId = 147, Lang = "en", Title = "Wola" },
            new DistrictTranslation { id = 198, EntityId = 147, Lang = "uk", Title = "Воля" },

            // Krakow
            new DistrictTranslation { id = 199, EntityId = 148, Lang = "en", Title = "Old Town" },
            new DistrictTranslation { id = 200, EntityId = 148, Lang = "uk", Title = "Старе місто" },
            new DistrictTranslation { id = 201, EntityId = 149, Lang = "en", Title = "Kazimierz" },
            new DistrictTranslation { id = 202, EntityId = 149, Lang = "uk", Title = "Казімєж" },
            new DistrictTranslation { id = 203, EntityId = 150, Lang = "en", Title = "Podgórze" },
            new DistrictTranslation { id = 204, EntityId = 150, Lang = "uk", Title = "Подгуже" },

            // Poznan
            new DistrictTranslation { id = 205, EntityId = 151, Lang = "en", Title = "Stare Miasto" },
            new DistrictTranslation { id = 206, EntityId = 151, Lang = "uk", Title = "Старе місто" },
            new DistrictTranslation { id = 207, EntityId = 152, Lang = "en", Title = "Grunwald" },
            new DistrictTranslation { id = 208, EntityId = 152, Lang = "uk", Title = "Грюнвальд" },
            new DistrictTranslation { id = 209, EntityId = 153, Lang = "en", Title = "Jeżyce" },
            new DistrictTranslation { id = 210, EntityId = 153, Lang = "uk", Title = "Єжице" }

        );


            modelBuilder.Entity<AttractionTranslation>().HasData(

            //// =================== Київ ===================
            ///  // Софійська площа, Київ
            new AttractionTranslation
            {
                id = 1,
                EntityId = 1,
                Lang = "en",
                Title = "Sofia Square",
                Description = "A historic square dominated by the Saint Sophia Cathedral. Visitors can admire the architectural grandeur of this UNESCO World Heritage site and enjoy the rich history of Kyiv. The square is often bustling with cultural events, street performances, and local life.",
                Address = "Sofiiska Square, Kyiv"
            },

            new AttractionTranslation
            {
                id = 2,
                EntityId = 1,
                Lang = "uk",
                Title = "Софійська площа",
                Description = "Історична площа, на якій розташований Собор Святої Софії. Тут можна насолодитися величною архітектурою, відчути атмосферу старовинного Києва та побачити, як поєднуються історія й сучасне життя міста.\r\n\r\nПлоща часто стає місцем культурних подій, виставок та вуличних перформансів. Туристи можуть ознайомитися з багатою спадщиною Києва та зробити незабутні фото на фоні головного символу столиці – Софійського собору.\r\n\r\nЦе одне з найважливіших місць для відвідування як туристами, так і місцевими жителями, адже воно поєднує історію, культуру та мистецтво в одному просторі.",
                Address = "Софійська площа, Київ"
            },

            // Михайлівська площа, Київ",
            new AttractionTranslation
            {
                id = 3,
                EntityId = 2,
                Lang = "en",
                Title = "Mykhailivska Square",
                Description = "A central square in Kyiv featuring the stunning St. Michael's Golden-Domed Monastery. Visitors can enjoy the vibrant atmosphere, historic architecture, and cultural events. The square is a hub for both locals and tourists, offering picturesque views and a glimpse into Kyiv’s spiritual heritage.",
                Address = "Mykhailivska Square, Kyiv"
            },


            new AttractionTranslation
            {
                id = 4,
                EntityId = 2,
                Lang = "uk",
                Title = "Михайлівська площа",
                Description = "Центральна площа Києва з величним Михайлівським Золотоверхим монастирем. Тут можна насолодитися історичною архітектурою, спостерігати за культурним життям міста та відчути атмосферу Києва.\r\n\r\nПлоща є важливим місцем для туристів і мешканців столиці, де часто проходять фестивалі, виставки та святкові події. Відвідувачі можуть зробити чудові фотографії на фоні яскравих куполів монастиря та дізнатися більше про духовну спадщину Києва.",
                Address = "Михайлівська площа, Київ"
            },


            // "Андріївський узвіз, Київ",
new AttractionTranslation
{
    id = 5,
    EntityId = 3,
    Lang = "en",
    Title = "Andriyivskyy Descent",
    Description = "One of Kyiv’s most famous streets, Andriyivskyy Descent is a historic and artistic landmark. Lined with charming old buildings, art galleries, souvenir shops, and cafes, it offers a unique glimpse into Kyiv’s cultural heritage. Visitors can admire the St. Andrew’s Church and enjoy vibrant street performances along the descent.",
    Address = "Andriyivskyy Descent, Kyiv"
},
new AttractionTranslation
{
    id = 6,
    EntityId = 3,
    Lang = "uk",
    Title = "Андріївський узвіз",
    Description = "Одна з найвідоміших вулиць Києва — Андріївський узвіз є історичною та культурною пам’яткою. Вузька вулиця з чарівними старовинними будівлями, художніми галереями, сувенірними крамницями та кав’ярнями надає унікальну можливість зануритися в атмосферу Києва.\r\n\r\nТут розташований Андріївський собор, а також часто можна спостерігати вуличні виступи музикантів і художників. Узвіз є улюбленим місцем для прогулянок туристів та місцевих мешканців, поєднуючи історію, мистецтво та живу атмосферу міста.",
    Address = "Андріївський узвіз, Київ"
},


//  "Контрактова площа",
new AttractionTranslation
{
    id = 7,
    EntityId = 4,
    Lang = "en",
    Title = "Kontraktova Square",
    Description = "A historic square in the Podil district of Kyiv, Kontraktova Square is known for its charming architecture, lively markets, and cultural events. The square has been a commercial and social hub for centuries, featuring historic buildings, monuments, and easy access to the scenic Dnipro River embankment.",
    Address = "Kontraktova Square, Kyiv"
},

new AttractionTranslation
{
    id = 8,
    EntityId = 4,
    Lang = "uk",
    Title = "Контрактова площа",
    Description = "Історична площа в Подільському районі Києва, Контрактова площа відома своєю чарівною архітектурою, живими ринками та культурними подіями. Площа століттями була центром комерційного та соціального життя міста.\r\n\r\nТут можна побачити історичні будівлі, пам’ятники, а також насолодитися прогулянками вздовж набережної Дніпра. Контрактова площа залишається популярним місцем для туристів та місцевих жителів, поєднуючи історію, культуру і сучасну атмосферу Києва.",
    Address = "Контрактова площа, Київ"
},

// "Золоті ворота",
new AttractionTranslation
{
    id = 9,
    EntityId = 5,
    Lang = "en",
    Title = "Golden Gate",
    Description = "One of Kyiv’s most iconic landmarks, the Golden Gate is a historic fortification dating back to the 11th century. Visitors can explore the reconstructed gate, learn about Kyiv’s medieval history, and enjoy panoramic views from the observation deck. The site often hosts exhibitions and cultural events.",
    Address = "Golden Gate, Kyiv"
},

new AttractionTranslation
{
    id = 10,
    EntityId = 5,
    Lang = "uk",
    Title = "Золоті ворота",
    Description = "Одна з найвідоміших пам’яток Києва — Золоті ворота, історична фортифікаційна споруда XI століття. Відвідувачі можуть оглянути реконструйовані ворота, ознайомитися з середньовічною історією Києва та насолодитися панорамним видом з оглядового майданчика.\r\n\r\nНа території часто проводяться виставки та культурні події, що робить Золоті ворота важливим центром історії та культури столиці.",
    Address = "Золоті ворота, Київ"
},


// "Парк Шевченка",
new AttractionTranslation
{
    id = 11,
    EntityId = 6,
    Lang = "en",
    Title = "Shevchenko Park",
    Description = "A beautiful green space in the heart of Kyiv, Shevchenko Park is perfect for leisurely walks, outdoor activities, and enjoying nature. The park features monuments, fountains, and tree-lined paths, offering a peaceful retreat from the city’s hustle and bustle. It is also home to cultural events and festivals throughout the year.",
    Address = "Shevchenko Park, Kyiv"
},

new AttractionTranslation
{
    id = 12,
    EntityId = 6,
    Lang = "uk",
    Title = "Парк Шевченка",
    Description = "Прекрасна зелена зона в центрі Києва, Парк Шевченка ідеально підходить для прогулянок, активного відпочинку та насолоди природою. У парку є пам’ятники, фонтани та алеї з деревами, що створюють затишну атмосферу серед міського шуму.\r\n\r\nПротягом року тут проводяться культурні події та фестивалі, що робить парк популярним місцем для місцевих жителів і туристів.",
    Address = "Парк Шевченка, Київ"
},


// "Пейзажна алея",
new AttractionTranslation
{
    id = 13,
    EntityId = 7,
    Lang = "en",
    Title = "Landscape Alley",
    Description = "A scenic and colorful walkway in Kyiv, Landscape Alley is famous for its vibrant murals, whimsical sculptures, and panoramic views of the city. This artistic alley is a favorite spot for photography, leisurely strolls, and discovering Kyiv’s creative spirit.",
    Address = "Landscape Alley, Kyiv"
},

new AttractionTranslation
{
    id = 14,
    EntityId = 7,
    Lang = "uk",
    Title = "Пейзажна алея",
    Description = "Живописна та яскрава вулиця в Києві, Пейзажна алея славиться своїми кольоровими муралами, оригінальними скульптурами та панорамними видами на місто. Ця мистецька алея є улюбленим місцем для фотографій, прогулянок та знайомства з творчим духом Києва.",
    Address = "Пейзажна алея, Київ"
},

// "Майдан Незалежності",
new AttractionTranslation
{
    id = 15,
    EntityId = 8,
    Lang = "en",
    Title = "Maidan Nezalezhnosti",
    Description = "Kyiv’s central square and a symbol of Ukraine’s independence, Maidan Nezalezhnosti hosts political events, cultural festivals, and public gatherings. The square is surrounded by historic buildings, fountains, and monuments, making it a hub of city life and a must-see landmark.",
    Address = "Maidan Nezalezhnosti, Kyiv"
},

new AttractionTranslation
{
    id = 16,
    EntityId = 8,
    Lang = "uk",
    Title = "Майдан Незалежності",
    Description = "Центральна площа Києва та символ незалежності України, Майдан Незалежності є місцем політичних подій, культурних фестивалів та громадських зібрань. Площа оточена історичними будівлями, фонтанами та пам’ятниками, що робить її серцем міського життя та обов’язковою для відвідування пам’яткою.",
    Address = "Майдан Незалежності, Київ"
},


            // =================== Винниця ===================

// "Фонтан Рошен",
new AttractionTranslation
{
    id = 17,
    EntityId = 9,
    Lang = "en",
    Title = "Roshen Fountain",
    Description = "A spectacular floating fountain on the Southern Bug River in Vinnytsia, the Roshen Fountain is one of the largest in Europe. Illuminated at night with colorful lights and music, it offers a mesmerizing show for locals and tourists alike.",
    Address = "Roshen Fountain, Vinnytsia"
},

new AttractionTranslation
{
    id = 18,
    EntityId = 9,
    Lang = "uk",
    Title = "Фонтан Рошен",
    Description = "Вражаючий плаваючий фонтан на річці Південний Буг у Вінниці, Фонтан Рошен є одним з найбільших у Європі. Увечері він підсвічується яскравими кольорами під музику, створюючи захоплююче шоу для мешканців та туристів.",
    Address = "Фонтан Рошен, Вінниця"
},

// "Вінницький центральний парк",
new AttractionTranslation
{
    id = 19,
    EntityId = 10,
    Lang = "en",
    Title = "Vinnytsia Central Park",
    Description = "A large and peaceful green space in Vinnytsia, Central Park features walking paths, fountains, playgrounds, and open areas for relaxation. It is perfect for family outings, jogging, and enjoying nature in the heart of the city.",
    Address = "Vinnytsia Central Park, Vinnytsia"
},

new AttractionTranslation
{
    id = 20,
    EntityId = 10,
    Lang = "uk",
    Title = "Вінницький центральний парк",
    Description = "Велика та затишна зелена зона у Вінниці, Центральний парк має прогулянкові алеї, фонтани, дитячі майданчики та відкриті території для відпочинку. Ідеальне місце для сімейних прогулянок, бігу та насолоди природою в центрі міста.",
    Address = "Вінницький центральний парк, Вінниця"
},


// "Вежа годинника",
new AttractionTranslation
{
    id = 21,
    EntityId = 11,
    Lang = "en",
    Title = "Clock Tower",
    Description = "A historic landmark in Vinnytsia, the Clock Tower offers panoramic views of the city from its top. Visitors can admire the architecture and enjoy a glimpse into Vinnytsia’s rich history while exploring the surrounding area.",
    Address = "Clock Tower, Vinnytsia"
},

new AttractionTranslation
{
    id = 22,
    EntityId = 11,
    Lang = "uk",
    Title = "Вежа годинника",
    Description = "Історична пам’ятка Вінниці — Вежа годинника. З її вершини відкриваються панорамні види на місто. Відвідувачі можуть насолодитися архітектурою та дізнатися більше про багату історію Вінниці, прогулявшись навколишньою територією.",
    Address = "Вежа годинника, Вінниця"
},

// "Музей-садиба Пирогова",
new AttractionTranslation
{
    id = 23,
    EntityId = 12,
    Lang = "en",
    Title = "Pirogov Museum-Estate",
    Description = "Dedicated to the life and work of the famous surgeon Nikolai Pirogov, this museum-estate showcases his achievements, medical instruments, and historical artifacts. The estate is surrounded by beautiful gardens, offering an educational and relaxing experience for visitors.",
    Address = "Pirogov Museum-Estate, Vinnytsia"
},

new AttractionTranslation
{
    id = 24,
    EntityId = 12,
    Lang = "uk",
    Title = "Музей-садиба Пирогова",
    Description = "Присвячена життю та діяльності відомого хірурга Миколи Пирогова, ця музей-садиба демонструє його досягнення, медичні інструменти та історичні експонати. Територія оточена гарними садами, що робить відвідування пізнавальним та приємним.",
    Address = "Музей-садиба Пирогова, Вінниця"
},

// "Вінницький дендропарк",
new AttractionTranslation
{
    id = 25,
    EntityId = 13,
    Lang = "en",
    Title = "Vinnytsia Dendropark",
    Description = "A beautiful botanical garden in Vinnytsia, the Dendropark features a wide variety of trees, plants, and walking paths. It’s an ideal place for nature walks, photography, and enjoying the peaceful atmosphere away from the city hustle.",
    Address = "Vinnytsia Dendropark, Vinnytsia"
},

new AttractionTranslation
{
    id = 26,
    EntityId = 13,
    Lang = "uk",
    Title = "Вінницький дендропарк",
    Description = "Прекрасний ботанічний сад у Вінниці, Дендропарк має велику кількість дерев, рослин та прогулянкових доріжок. Це ідеальне місце для прогулянок на природі, фотографування та насолоди спокійною атмосферою подалі від міського шуму.",
    Address = "Вінницький дендропарк, Вінниця"
},

// "Вінницький обласний краєзнавчий музей",
new AttractionTranslation
{
    id = 27,
    EntityId = 14,
    Lang = "en",
    Title = "Vinnytsia Regional Museum",
    Description = "The Vinnytsia Regional Museum showcases the history, culture, and traditions of the Vinnytsia region. Visitors can explore archaeological finds, art exhibits, and historical artifacts, offering a deep insight into the region’s rich heritage.",
    Address = "Vinnytsia Regional Museum, Vinnytsia"
},

new AttractionTranslation
{
    id = 28,
    EntityId = 14,
    Lang = "uk",
    Title = "Вінницький обласний краєзнавчий музей",
    Description = "Вінницький обласний краєзнавчий музей демонструє історію, культуру та традиції Вінницького краю. Відвідувачі можуть ознайомитися з археологічними знахідками, художніми експозиціями та історичними артефактами, що дає глибоке уявлення про багату спадщину регіону.",
    Address = "Вінницький обласний краєзнавчий музей, Вінниця"
},

// "Європейська площа",
new AttractionTranslation
{
    id = 29,
    EntityId = 15,
    Lang = "en",
    Title = "European Square",
    Description = "A central square in Vinnytsia, European Square is a hub for cultural events, public gatherings, and local celebrations. Surrounded by historic buildings and shops, it offers visitors a lively atmosphere and a sense of the city’s modern and traditional life.",
    Address = "European Square, Vinnytsia"
},

new AttractionTranslation
{
    id = 30,
    EntityId = 15,
    Lang = "uk",
    Title = "Європейська площа",
    Description = "Центральна площа Вінниці, Європейська площа є місцем культурних заходів, громадських зібрань та місцевих святкувань. Оточена історичними будівлями та магазинами, вона пропонує відвідувачам живу атмосферу та поєднання сучасного й традиційного життя міста.",
    Address = "Європейська площа, Вінниця"
},

// "Набережна річки Південний Буг",
new AttractionTranslation
{
    id = 31,
    EntityId = 16,
    Lang = "en",
    Title = "Southern Bug River Embankment",
    Description = "A scenic riverside area in Vinnytsia along the Southern Bug River, perfect for walks, jogging, and leisure activities. The embankment features benches, fountains, and viewpoints, making it a favorite spot for both locals and tourists.",
    Address = "Southern Bug River Embankment, Vinnytsia"
},

new AttractionTranslation
{
    id = 32,
    EntityId = 16,
    Lang = "uk",
    Title = "Набережна річки Південний Буг",
    Description = "Живописна набережна у Вінниці вздовж річки Південний Буг, ідеальна для прогулянок, бігу та відпочинку. Тут є лавки, фонтани та оглядові майданчики, що робить її популярним місцем для мешканців та туристів.",
    Address = "Набережна річки Південний Буг, Вінниця"
},


// =================== Луцьк ===================

// "Замок Любарта",
new AttractionTranslation
{
    id = 33,
    EntityId = 17,
    Lang = "en",
    Title = "Lubart's Castle",
    Description = "A historic castle in Lutsk, Lubart's Castle dates back to the 14th century. Visitors can explore the fortress walls, towers, and exhibitions that showcase the region’s medieval history, architecture, and culture.",
    Address = "Lubart's Castle, Lutsk"
},

new AttractionTranslation
{
    id = 34,
    EntityId = 17,
    Lang = "uk",
    Title = "Замок Любарта",
    Description = "Історичний замок у Луцьку, Замок Любарта датується XIV століттям. Відвідувачі можуть оглянути стіни фортеці, вежі та експозиції, що демонструють середньовічну історію, архітектуру та культуру регіону.",
    Address = "Замок Любарта, Луцьк"
},

// "Собор Святих апостолів Петра і Павла",
new AttractionTranslation
{
    id = 35,
    EntityId = 18,
    Lang = "en",
    Title = "Cathedral of Saints Peter and Paul",
    Description = "A majestic cathedral in Lutsk, known for its beautiful baroque architecture and religious significance. The Cathedral of Saints Peter and Paul is a center for worship and community events, attracting visitors with its intricate interiors and historic charm.",
    Address = "Cathedral of Saints Peter and Paul, Lutsk"
},

new AttractionTranslation
{
    id = 36,
    EntityId = 18,
    Lang = "uk",
    Title = "Собор Святих апостолів Петра і Павла",
    Description = "Величний собор у Луцьку, відомий своєю прекрасною бароковою архітектурою та релігійним значенням. Собор Святих апостолів Петра і Павла є центром поклоніння та громадських заходів, приваблюючи відвідувачів витонченими інтер’єрами та історичним шармом.",
    Address = "Собор Святих апостолів Петра і Павла, Луцьк"
},

// "Луцький історичний музей",
new AttractionTranslation
{
    id = 37,
    EntityId = 19,
    Lang = "en",
    Title = "Lutsk Historical Museum",
    Description = "The Lutsk Historical Museum offers exhibits on the history, culture, and traditions of Lutsk and the Volyn region. Visitors can explore archaeological artifacts, historical documents, and local art in a rich educational setting.",
    Address = "Lutsk Historical Museum, Lutsk"
},

new AttractionTranslation
{
    id = 38,
    EntityId = 19,
    Lang = "uk",
    Title = "Луцький історичний музей",
    Description = "Луцький історичний музей пропонує експозиції про історію, культуру та традиції Луцька та Волинського краю. Відвідувачі можуть ознайомитися з археологічними артефактами, історичними документами та місцевим мистецтвом у пізнавальній атмосфері.",
    Address = "Луцький історичний музей, Луцьк"
},

// "Парк імені Лесі Українки",
new AttractionTranslation
{
    id = 39,
    EntityId = 20,
    Lang = "en",
    Title = "Lesia Ukrainka Park",
    Description = "A peaceful urban park in Lutsk named after the famous Ukrainian poet Lesia Ukrainka. The park features walking paths, statues, and green spaces, making it a popular spot for relaxation, recreation, and family outings.",
    Address = "Lesia Ukrainka Park, Lutsk"
},

new AttractionTranslation
{
    id = 40,
    EntityId = 20,
    Lang = "uk",
    Title = "Парк імені Лесі Українки",
    Description = "Спокійний міський парк у Луцьку, названий на честь відомої української поетеси Лесі Українки. Парк має прогулянкові доріжки, пам’ятники та зелені зони, що робить його популярним місцем для відпочинку, розваг та сімейних прогулянок.",
    Address = "Парк імені Лесі Українки, Луцьк"
},

// "Кафедральний собор Святої Трійці",
new AttractionTranslation
{
    id = 41,
    EntityId = 21,
    Lang = "en",
    Title = "Holy Trinity Cathedral",
    Description = "An iconic cathedral in Lutsk, the Holy Trinity Cathedral is known for its striking architecture, religious significance, and vibrant community events. Visitors can admire its detailed interiors and participate in local ceremonies.",
    Address = "Holy Trinity Cathedral, Lutsk"
},

new AttractionTranslation
{
    id = 42,
    EntityId = 21,
    Lang = "uk",
    Title = "Кафедральний собор Святої Трійці",
    Description = "Відомий собор у Луцьку, Кафедральний собор Святої Трійці славиться своєю вражаючою архітектурою, релігійним значенням та активним громадським життям. Відвідувачі можуть милуватися деталізованими інтер’єрами та брати участь у місцевих церемоніях.",
    Address = "Кафедральний собор Святої Трійці, Луцьк"
},

// "Площа Ринок",
new AttractionTranslation
{
    id = 43,
    EntityId = 22,
    Lang = "en",
    Title = "Market Square",
    Description = "Lutsk's historic Market Square is a vibrant public space surrounded by colorful buildings, shops, and cafes. The square hosts cultural events, festivals, and markets, offering visitors a glimpse into the city’s local life and history.",
    Address = "Market Square, Lutsk"
},

new AttractionTranslation
{
    id = 44,
    EntityId = 22,
    Lang = "uk",
    Title = "Площа Ринок",
    Description = "Історична Площа Ринок у Луцьку — це жвавий громадський простір, оточений яскравими будівлями, магазинами та кафе. На площі проходять культурні заходи, фестивалі та ринки, що дає відвідувачам змогу відчути місцеве життя та історію міста.",
    Address = "Площа Ринок, Луцьк"
},

// "Вул. Лесі Українки",
new AttractionTranslation
{
    id = 45,
    EntityId = 23,
    Lang = "en",
    Title = "Lesia Ukrainka Street",
    Description = "A charming street in Lutsk named after the famous poet Lesia Ukrainka. The street is lined with historic buildings, shops, and cafes, offering visitors a peaceful walk through the city’s cultural and architectural heritage.",
    Address = "Lesia Ukrainka Street, Lutsk"
},

new AttractionTranslation
{
    id = 46,
    EntityId = 23,
    Lang = "uk",
    Title = "Вул. Лесі Українки",
    Description = "Чарівна вулиця у Луцьку, названа на честь відомої поетеси Лесі Українки. Вулиця забудована історичними будівлями, магазинами та кафе, що дозволяє відвідувачам насолодитися прогулянкою та культурною та архітектурною спадщиною міста.",
    Address = "Вул. Лесі Українки, Луцьк"
},

// "Замкова площа",
new AttractionTranslation
{
    id = 47,
    EntityId = 24,
    Lang = "en",
    Title = "Castle Square",
    Description = "Castle Square in Lutsk is a historic plaza located near Lubart's Castle. Surrounded by picturesque buildings and local landmarks, it is a hub for cultural events, markets, and gatherings, reflecting the city’s medieval charm.",
    Address = "Castle Square, Lutsk"
},

new AttractionTranslation
{
    id = 48,
    EntityId = 24,
    Lang = "uk",
    Title = "Замкова площа",
    Description = "Замкова площа у Луцьку — історична площа біля Замку Любарта. Оточена мальовничими будівлями та місцевими пам’ятками, площа є центром культурних заходів, ринків та зборів, що відображає середньовічний шарм міста.",
    Address = "Замкова площа, Луцьк"
},

// =================== Дніпро ===================


// "Парк ім. Т. Шевченка",
new AttractionTranslation
{
    id = 49,
    EntityId = 25,
    Lang = "en",
    Title = "Shevchenko Park",
    Description = "Shevchenko Park in Dnipro is a peaceful green space in the city center, offering walking paths, fountains, and monuments dedicated to the Ukrainian poet Taras Shevchenko. It's a favorite spot for relaxation and outdoor activities for locals and visitors.",
    Address = "Shevchenko Park, Dnipro"
},

new AttractionTranslation
{
    id = 50,
    EntityId = 25,
    Lang = "uk",
    Title = "Парк ім. Т. Шевченка",
    Description = "Парк імені Тараса Шевченка у Дніпрі — затишна зелена зона в центрі міста з доріжками для прогулянок, фонтанами та пам’ятниками, присвяченими українському поету Тарасу Шевченку. Улюблене місце відпочинку та активного проведення часу для мешканців і гостей міста.",
    Address = "Парк ім. Т. Шевченка, Дніпро"
},

// "Монастирський острів",
new AttractionTranslation
{
    id = 51,
    EntityId = 26,
    Lang = "en",
    Title = "Monastyr Island",
    Description = "Monastyr Island in Dnipro is a scenic river island known for its walking trails, historical sites, and natural beauty. Visitors can enjoy quiet strolls, watch local wildlife, and explore cultural landmarks.",
    Address = "Monastyr Island, Dnipro"
},

new AttractionTranslation
{
    id = 52,
    EntityId = 26,
    Lang = "uk",
    Title = "Монастирський острів",
    Description = "Монастирський острів у Дніпрі — мальовничий острів на річці, відомий своїми прогулянковими маршрутами, історичними місцями та природною красою. Відвідувачі можуть насолоджуватися тихими прогулянками, спостерігати місцеву флору та фауну та знайомитися з культурними пам’ятками.",
    Address = "Монастирський острів, Дніпро"
},

// "Дніпровська набережна",
new AttractionTranslation
{
    id = 53,
    EntityId = 27,
    Lang = "en",
    Title = "Dnipro Embankment",
    Description = "Dnipro Embankment is a popular riverside area offering scenic views of the Dnipro River, walking paths, cafes, and recreational spots. It's a central hub for city events, leisure, and cultural activities.",
    Address = "Dnipro Embankment, Dnipro"
},

new AttractionTranslation
{
    id = 54,
    EntityId = 27,
    Lang = "uk",
    Title = "Дніпровська набережна",
    Description = "Дніпровська набережна — популярна прибережна зона з мальовничими видами на річку Дніпро, прогулянковими доріжками, кафе та місцями для відпочинку. Це центральне місце проведення міських заходів, відпочинку та культурних активностей.",
    Address = "Дніпровська набережна, Дніпро"
},


// "Музей історії Дніпра",
new AttractionTranslation
{
    id = 55,
    EntityId = 28,
    Lang = "en",
    Title = "Dnipro History Museum",
    Description = "The Dnipro History Museum showcases the rich history of the city and the surrounding region. Exhibits include artifacts from ancient settlements, medieval times, and modern history, offering visitors a comprehensive view of Dnipro’s cultural heritage.",
    Address = "Dnipro History Museum, Dnipro"
},

new AttractionTranslation
{
    id = 56,
    EntityId = 28,
    Lang = "uk",
    Title = "Музей історії Дніпра",
    Description = "Музей історії Дніпра демонструє багату історію міста та регіону. Експозиції включають артефакти з давніх поселень, середньовіччя та сучасності, надаючи відвідувачам повне уявлення про культурну спадщину Дніпра.",
    Address = "Музей історії Дніпра, Дніпро"
},

// "Парк Глоби",
new AttractionTranslation
{
    id = 57,
    EntityId = 29,
    Lang = "en",
    Title = "Globa Park",
    Description = "Globa Park is a scenic city park in Dnipro featuring green lawns, walking paths, and recreational areas. It’s a popular spot for families, joggers, and anyone looking to enjoy nature within the urban environment.",
    Address = "Globa Park, Dnipro"
},

new AttractionTranslation
{
    id = 58,
    EntityId = 29,
    Lang = "uk",
    Title = "Парк Глоби",
    Description = "Парк Глоби — мальовничий міський парк у Дніпрі з зеленими галявинами, прогулянковими доріжками та зонами відпочинку. Це популярне місце для сімей, бігунів та всіх, хто хоче насолодитися природою в міському середовищі.",
    Address = "Парк Глоби, Дніпро"
},

// "Dnipro Planetarium"
new AttractionTranslation
{
    id = 59,
    EntityId = 30,
    Lang = "en",
    Title = "Dnipro Planetarium",
    Description = "Dnipro Planetarium is a modern astronomical center offering immersive shows about space, stars, and the universe. Equipped with advanced projection technology, it provides educational programs, interactive exhibits, and engaging experiences for visitors of all ages.",
    Address = "10 Krutohirnyi Descent, Dnipro"
},

new AttractionTranslation
{
    id = 60,
    EntityId = 30,
    Lang = "uk",
    Title = "Планетарій Дніпра",
    Description = "Планетарій Дніпра — сучасний астрономічний центр, що пропонує захопливі шоу про космос, зірки та Всесвіт. Оснащений сучасними проєкційними технологіями, він проводить освітні програми, інтерактивні виставки та пізнавальні заходи для відвідувачів різного віку.",
    Address = "Крутогірний узвіз, 10, Дніпро"
},
// "Dnipro Aerospace Center"
new AttractionTranslation
{
    id = 61,
    EntityId = 31,
    Lang = "en",
    Title = "National Aerospace Education Center of Youth named after Makarov",
    Description = "The National Aerospace Education Center of Youth in Dnipro is a unique museum and educational complex dedicated to space exploration and rocket engineering. Visitors can see real spacecraft, rocket models, and interactive exhibits highlighting Dnipro’s key role in the aerospace industry.",
    Address = "26 Haharina Avenue, Dnipro"
},

new AttractionTranslation
{
    id = 62,
    EntityId = 31,
    Lang = "uk",
    Title = "Національний центр аерокосмічної освіти молоді ім. Макарова",
    Description = "Національний центр аерокосмічної освіти молоді у Дніпрі — унікальний музейно-освітній комплекс, присвячений дослідженню космосу та ракетобудуванню. Тут представлені справжні космічні апарати, макети ракет та інтерактивні експозиції, що демонструють ключову роль Дніпра в аерокосмічній галузі.",
    Address = "проспект Гагаріна, 26, Дніпро"
},

// "Дніпровський театр опери та балету",
new AttractionTranslation
{
    id = 63,
    EntityId = 32,
    Lang = "en",
    Title = "Dnipro Opera and Ballet Theatre",
    Description = "The Dnipro Opera and Ballet Theatre is a cultural landmark offering high-quality performances of opera, ballet, and classical music. Its stunning architecture and artistic repertoire make it a must-visit destination for art lovers and tourists.",
    Address = "Dnipro Opera and Ballet Theatre, Dnipro"
},

new AttractionTranslation
{
    id = 64,
    EntityId = 32,
    Lang = "uk",
    Title = "Дніпровський театр опери та балету",
    Description = "Дніпровський театр опери та балету — культурна пам’ятка, де проходять високоякісні постановки опери, балету та класичної музики. Вражаюча архітектура та художній репертуар роблять його обов’язковим для відвідування любителями мистецтва та туристами.",
    Address = "Дніпровський театр опери та балету, Дніпро"
},

// =================== Ужгород ===================


// "Ужгородський замок",
new AttractionTranslation
{
    id = 97,
    EntityId = 49,
    Lang = "en",
    Title = "Uzhhorod Castle",
    Description = "Uzhhorod Castle is a historic fortress dating back to the 13th century, perched on a hill overlooking the city. Visitors can explore its museum exhibits, fortifications, and enjoy panoramic views of Uzhhorod and the surrounding Carpathian foothills.",
    Address = "Uzhhorod Castle, Uzhhorod"
},

new AttractionTranslation
{
    id = 98,
    EntityId = 49,
    Lang = "uk",
    Title = "Ужгородський замок",
    Description = "Ужгородський замок — історична фортеця XIII століття, розташована на пагорбі з видом на місто. Відвідувачі можуть оглянути музейні експозиції, фортифікації та насолодитися панорамними краєвидами Ужгорода та передгір’їв Карпат.",
    Address = "Ужгородський замок, Ужгород"
},

// "Площа Театральна",
new AttractionTranslation
{
    id = 99,
    EntityId = 50,
    Lang = "en",
    Title = "Theatre Square",
    Description = "Theatre Square in Uzhhorod is the central hub of the city, known for its lively atmosphere, cafes, cultural events, and historic architecture. It's a popular gathering place for both locals and tourists.",
    Address = "Theatre Square, Uzhhorod"
},

new AttractionTranslation
{
    id = 100,
    EntityId = 50,
    Lang = "uk",
    Title = "Площа Театральна",
    Description = "Площа Театральна в Ужгороді — центральний майдан міста, відомий своєю живою атмосферою, кафе, культурними подіями та історичною архітектурою. Це популярне місце зустрічей для місцевих жителів та туристів.",
    Address = "Площа Театральна, Ужгород"
},

// "Ботанічний сад УжНУ",
new AttractionTranslation
{
    id = 101,
    EntityId = 51,
    Lang = "en",
    Title = "UzhNU Botanical Garden",
    Description = "The UzhNU Botanical Garden offers a serene environment with diverse plant collections, themed gardens, and walking paths. It's a perfect spot for nature lovers, students, and families seeking a quiet escape in Uzhhorod.",
    Address = "UzhNU Botanical Garden, Uzhhorod"
},

new AttractionTranslation
{
    id = 102,
    EntityId = 51,
    Lang = "uk",
    Title = "Ботанічний сад УжНУ",
    Description = "Ботанічний сад УжНУ пропонує затишну атмосферу з різноманітними колекціями рослин, тематичними садками та прогулянковими доріжками. Це ідеальне місце для любителів природи, студентів та сімей, які шукають спокійний відпочинок в Ужгороді.",
    Address = "Ботанічний сад УжНУ, Ужгород"
},

// "Пішохідний міст",
new AttractionTranslation
{
    id = 103,
    EntityId = 52,
    Lang = "en",
    Title = "Pedestrian Bridge",
    Description = "The Pedestrian Bridge in Uzhhorod is a modern walkway over the Uzh River, offering scenic views of the city and a popular spot for leisurely strolls and photography.",
    Address = "Pedestrian Bridge, Uzhhorod"
},

new AttractionTranslation
{
    id = 104,
    EntityId = 52,
    Lang = "uk",
    Title = "Пішохідний міст",
    Description = "Пішохідний міст в Ужгороді — сучасний міст через річку Уж, що пропонує мальовничі краєвиди міста. Популярне місце для прогулянок та фотографій.",
    Address = "Пішохідний міст, Ужгород"
},

// "Собор святого Георгія",
new AttractionTranslation
{
    id = 105,
    EntityId = 53,
    Lang = "en",
    Title = "St. George Cathedral",
    Description = "St. George Cathedral is a historic Orthodox church in Uzhhorod, famous for its striking Baroque architecture, beautiful frescoes, and spiritual significance to the local community.",
    Address = "St. George Cathedral, Uzhhorod"
},

new AttractionTranslation
{
    id = 106,
    EntityId = 53,
    Lang = "uk",
    Title = "Собор святого Георгія",
    Description = "Собор святого Георгія — історична православна церква в Ужгороді, відома своєю вражаючою бароковою архітектурою, красивими фресками та духовним значенням для місцевої громади.",
    Address = "Собор святого Георгія, Ужгород"
},

// "Музей народної архітектури та побуту",
new AttractionTranslation
{
    id = 107,
    EntityId = 54,
    Lang = "en",
    Title = "Museum of Folk Architecture and Life",
    Description = "The Museum of Folk Architecture and Life in Uzhhorod showcases traditional houses, churches, and rural artifacts from the Carpathian region. Visitors can immerse themselves in the history and culture of local communities.",
    Address = "Museum of Folk Architecture and Life, Uzhhorod"
},

new AttractionTranslation
{
    id = 108,
    EntityId = 54,
    Lang = "uk",
    Title = "Музей народної архітектури та побуту",
    Description = "Музей народної архітектури та побуту в Ужгороді демонструє традиційні будинки, церкви та сільські предмети з Карпатського регіону. Відвідувачі можуть зануритися в історію та культуру місцевих громад.",
    Address = "Музей народної архітектури та побуту, Ужгород"
},

// "Ужгородська набережна"
new AttractionTranslation
{
    id = 109,
    EntityId = 55,
    Lang = "en",
    Title = "Uzhhorod Riverside Promenade",
    Description = "The Uzhhorod Riverside Promenade is a scenic riverside area along the Uzh River, perfect for walking, relaxing, and enjoying views of the city’s historic center. It hosts seasonal events and local gatherings.",
    Address = "Uzhhorod Riverside Promenade, Uzhhorod"
},

new AttractionTranslation
{
    id = 110,
    EntityId = 55,
    Lang = "uk",
    Title = "Ужгородська набережна",
    Description = "Ужгородська набережна — мальовнича зона вздовж річки Уж, ідеальна для прогулянок, відпочинку та споглядання історичного центру міста. Тут проводяться сезонні заходи та місцеві зібрання.",
    Address = "Ужгородська набережна, Ужгород"
},

// "Невицький замок"
new AttractionTranslation
{
    id = 111,
    EntityId = 56,
    Lang = "en",
    Title = "Nevytsky Castle",
    Description = "Nevytsky Castle, located near Uzhhorod in the village of Nevytske, is a historic medieval castle perched on a hill. Visitors can explore the ruins, enjoy panoramic views, and learn about its rich history.",
    Address = "Nevytsky Castle, Nevytske"
},

new AttractionTranslation
{
    id = 112,
    EntityId = 56,
    Lang = "uk",
    Title = "Невицький замок",
    Description = "Невицький замок, розташований біля Ужгорода в селі Невицьке, — історичний середньовічний замок на пагорбі. Відвідувачі можуть оглянути руїни, насолодитися панорамними краєвидами та дізнатися про його багату історію.",
    Address = "Невицький замок, село Невицьке"
},


// =================== Запоріжжя ===================


// "Хортиця"
new AttractionTranslation
{
    id = 149,
    EntityId = 57,
    Lang = "en",
    Title = "Khortytsia Island, Zaporizhzhia",
    Description = "Khortytsia Island is the largest island on the Dnipro River and a historical symbol of the Zaporizhian Cossacks. Visitors can explore scenic landscapes, ancient fortifications, and cultural museums.",
    Address = "Khortytsia Island, Zaporizhzhia"
},

new AttractionTranslation
{
    id = 150,
    EntityId = 57,
    Lang = "uk",
    Title = "Хортиця, Запоріжжя",
    Description = "Острів Хортиця — найбільший острів на річці Дніпро та історичний символ запорізьких козаків. Відвідувачі можуть оглянути мальовничі ландшафти, давні фортифікації та культурні музеї.",
    Address = "Хортиця, Запоріжжя"
},


// "Музей історії запорізького козацтва"
new AttractionTranslation
{
    id = 151,
    EntityId = 58,
    Lang = "en",
    Title = "Zaporizhian Cossacks History Museum",
    Description = "The museum showcases the rich history of the Zaporizhian Cossacks with exhibits of weapons, artifacts, and interactive displays detailing their culture and way of life.",
    Address = "Zaporizhian Cossacks History Museum, Zaporizhzhia"
},

new AttractionTranslation
{
    id = 152,
    EntityId = 58,
    Lang = "uk",
    Title = "Музей історії запорізького козацтва",
    Description = "Музей представляє багату історію запорізьких козаків через експонати зброї, артефактів та інтерактивні виставки, що розкривають їхню культуру та побут.",
    Address = "Музей історії запорізького козацтва, Запоріжжя"
},
// "Парк Дубовий Гай"
new AttractionTranslation
{
    id = 153,
    EntityId = 59,
    Lang = "en",
    Title = "Dubovyi Hai Park, Zaporizhzhia",
    Description = "Dubovyi Hai Park is a large green space with walking trails, playgrounds, and recreational areas, ideal for family leisure and outdoor activities.",
    Address = "Dubovyi Hai Park, Zaporizhzhia"
},

new AttractionTranslation
{
    id = 154,
    EntityId = 59,
    Lang = "uk",
    Title = "Парк Дубовий Гай, Запоріжжя",
    Description = "Парк Дубовий Гай — велика зелена зона з пішохідними доріжками, дитячими майданчиками та зонами відпочинку, ідеальна для сімейного відпочинку та активного дозвілля.",
    Address = "Парк Дубовий Гай, Запоріжжя"
},


// "Дніпровська набережна"
new AttractionTranslation
{
    id = 155,
    EntityId = 60,
    Lang = "en",
    Title = "Dnipro Embankment, Zaporizhzhia",
    Description = "The Dnipro Embankment in Zaporizhzhia is a scenic riverside promenade with walking paths, cafes, and recreational spaces, perfect for leisure and family outings.",
    Address = "Dnipro Embankment, Zaporizhzhia"
},

new AttractionTranslation
{
    id = 156,
    EntityId = 60,
    Lang = "uk",
    Title = "Дніпровська набережна, Запоріжжя",
    Description = "Дніпровська набережна в Запоріжжі — мальовнича набережна з пішохідними доріжками, кафе та зонами відпочинку, ідеальна для прогулянок та сімейного відпочинку.",
    Address = "Дніпровська набережна, Запоріжжя"
},

// "Музей локомотивів"
new AttractionTranslation
{
    id = 157,
    EntityId = 61, 
    Lang = "en",
    Title = "Locomotive Museum, Zaporizhzhia",
    Description = "The Locomotive Museum in Zaporizhzhia showcases historic trains and railway artifacts, offering visitors an interactive and educational experience about rail transport.",
    Address = "Locomotive Museum, Zaporizhzhia"
},

new AttractionTranslation
{
    id = 158,
    EntityId = 61,  
    Lang = "uk",
    Title = "Музей локомотивів, Запоріжжя",
    Description = "Музей локомотивів у Запоріжжі представляє історичні потяги та залізничні артефакти, пропонуючи відвідувачам інтерактивний та пізнавальний досвід знайомства з залізничним транспортом.",
    Address = "Музей локомотивів, Запоріжжя"
},

// "Музей техніки «Фаетон»"
new AttractionTranslation
{
    id = 159,
    EntityId = 62,
    Lang = "en",
    Title = "Fayeton Technical Museum, Zaporizhzhia",
    Description = "Fayeton Technical Museum in Zaporizhzhia showcases a unique collection of historical vehicles, machinery, and technological exhibits, offering an interactive experience for visitors of all ages.",
    Address = "Fayeton Technical Museum, Zaporizhzhia"
},

new AttractionTranslation
{
    id = 160,
    EntityId = 62,
    Lang = "uk",
    Title = "Музей техніки «Фаетон», Запоріжжя",
    Description = "Музей техніки «Фаетон» у Запоріжжі представляє унікальну колекцію історичних транспортних засобів, машин та технологічних експонатів, пропонуючи інтерактивний досвід для відвідувачів усіх вікових груп.",
    Address = "Музей техніки «Фаетон», Запоріжжя"
},

// "Запорізька ГЕС (Дніпровська дамба)"
new AttractionTranslation
{
    id = 161,
    EntityId = 63,
    Lang = "en",
    Title = "Zaporizhzhia HydroPower Plant (Dnipro Dam)",
    Description = "The Zaporizhzhia Hydroelectric Power Plant, also known as the Dnipro Dam, is a massive engineering landmark on the Dnipro River. It offers impressive views of the river and industrial architecture, attracting visitors interested in engineering, history, and energy production.",
    Address = "Zaporizhzhia HydroPower Plant, Zaporizhzhia"
},

new AttractionTranslation
{
    id = 162,
    EntityId = 63,
    Lang = "uk",
    Title = "Запорізька ГЕС (Дніпровська дамба)",
    Description = "Запорізька гідроелектростанція, відома як Дніпровська дамба, — це велична інженерна пам’ятка на річці Дніпро. Вона пропонує вражаючі види на річку та промислову архітектуру, приваблюючи відвідувачів, зацікавлених в інженерії, історії та виробництві енергії.",
    Address = "Запорізька ГЕС, Запоріжжя"
},

// "Музей авіації та космонавтики"
new AttractionTranslation
{
    id = 163,
    EntityId = 64,
    Lang = "en",
    Title = "Aviation and Cosmonautics Museum, Zaporizhzhia",
    Description = "The Aviation and Cosmonautics Museum in Zaporizhzhia showcases historic aircraft, spacecraft models, and exhibits on aviation history and space exploration, making it a must-visit for technology and science enthusiasts.",
    Address = "Aviation and Cosmonautics Museum, Zaporizhzhia"
},

new AttractionTranslation
{
    id = 164,
    EntityId = 64,
    Lang = "uk",
    Title = "Музей авіації та космонавтики, Запоріжжя",
    Description = "Музей авіації та космонавтики в Запоріжжі представляє історичні літаки, моделі космічних апаратів та експозиції з історії авіації та освоєння космосу, що робить його обов’язковим для відвідування для поціновувачів науки та техніки.",
    Address = "Музей авіації та космонавтики, Запоріжжя"
},

// =================== Івано-Франківськ ===================


// "Ратуша Івано-Франківська",
new AttractionTranslation
{
    id = 165,
    EntityId = 65,
    Lang = "en",
    Title = "Ivano-Frankivsk City Hall",
    Description = "Ivano-Frankivsk City Hall is a historic building located in the heart of the city. Known for its distinctive clock tower, it serves as the administrative center and a landmark for visitors exploring the old town.",
    Address = "Ivano-Frankivsk City Hall, Ivano-Frankivsk"
},

new AttractionTranslation
{
    id = 166,
    EntityId = 65,
    Lang = "uk",
    Title = "Ратуша Івано-Франківська",
    Description = "Ратуша Івано-Франківська — історична будівля в центрі міста. Відома своєю характерною вежею з годинником, вона слугує адміністративним центром та визначною пам’яткою для відвідувачів старого міста.",
    Address = "Ратуша Івано-Франківська, Івано-Франківськ"
},

// "Площа Ринок",
new AttractionTranslation
{
    id = 167,
    EntityId = 66,
    Lang = "en",
    Title = "Rynok Square",
    Description = "Rynok Square is the central square of Ivano-Frankivsk, surrounded by colorful historic buildings, cafes, and cultural institutions. It is a lively place for locals and tourists, hosting festivals and markets throughout the year.",
    Address = "Rynok Square, Ivano-Frankivsk"
},

new AttractionTranslation
{
    id = 168,
    EntityId = 66,
    Lang = "uk",
    Title = "Площа Ринок",
    Description = "Площа Ринок — центральна площа Івано-Франківська, оточена яскравими історичними будівлями, кафе та культурними закладами. Тут активно проходять фестивалі та ярмарки, а площа є улюбленим місцем жителів та туристів.",
    Address = "Площа Ринок, Івано-Франківськ"
},

// "Вулиця Незалежності",
new AttractionTranslation
{
    id = 169,
    EntityId = 67,
    Lang = "en",
    Title = "Independence Street",
    Description = "Independence Street is a vibrant pedestrian street in Ivano-Frankivsk, lined with shops, restaurants, and historic architecture. It is a popular destination for strolling, shopping, and experiencing the city's cultural life.",
    Address = "Independence Street, Ivano-Frankivsk"
},

new AttractionTranslation
{
    id = 170,
    EntityId = 67,
    Lang = "uk",
    Title = "Вулиця Незалежності",
    Description = "Вулиця Незалежності — жвава пішохідна вулиця в Івано-Франківську, оточена магазинами, ресторанами та історичною архітектурою. Популярне місце для прогулянок, шопінгу та знайомства з культурним життям міста.",
    Address = "Вулиця Незалежності, Івано-Франківськ"
},

// "Парк ім. Т. Шевченка",
new AttractionTranslation
{
    id = 171,
    EntityId = 68,
    Lang = "en",
    Title = "Shevchenko Park",
    Description = "Shevchenko Park is a serene green space in the heart of Ivano-Frankivsk, perfect for leisurely walks, outdoor activities, and family gatherings. The park features statues, fountains, and shaded pathways that celebrate the city's cultural heritage.",
    Address = "Shevchenko Park, Ivano-Frankivsk"
},

new AttractionTranslation
{
    id = 172,
    EntityId = 68,
    Lang = "uk",
    Title = "Парк ім. Т. Шевченка",
    Description = "Парк ім. Т. Шевченка — спокійна зелена зона в центрі Івано-Франківська, ідеальна для прогулянок, відпочинку та сімейних зустрічей. У парку розташовані статуї, фонтани та затінені алеї, що відображають культурну спадщину міста.",
    Address = "Парк ім. Т. Шевченка, Івано-Франківськ"
},

// "Музей народного мистецтва Гуцульщини та Покуття",
new AttractionTranslation
{
    id = 173,
    EntityId = 69,
    Lang = "en",
    Title = "Hutsul and Pokuttya Folk Art Museum",
    Description = "The Hutsul and Pokuttya Folk Art Museum showcases traditional arts and crafts from the Hutsul and Pokuttya regions. Visitors can explore exhibits of folk costumes, textiles, woodwork, and religious artifacts, reflecting the rich cultural heritage of western Ukraine.",
    Address = "Hutsul and Pokuttya Folk Art Museum, Ivano-Frankivsk"
},

new AttractionTranslation
{
    id = 174,
    EntityId = 69,
    Lang = "uk",
    Title = "Музей народного мистецтва Гуцульщини та Покуття",
    Description = "Музей народного мистецтва Гуцульщини та Покуття представляє традиційне мистецтво та ремесла регіонів Гуцульщини та Покуття. В експозиції — народні костюми, тканини, дерев’яні вироби та релігійні артефакти, що відображають багату культурну спадщину Західної України.",
    Address = "Музей народного мистецтва Гуцульщини та Покуття, Івано-Франківськ"
},

// "Кафедральний собор Святого Воскресіння",
new AttractionTranslation
{
    id = 175,
    EntityId = 70,
    Lang = "en",
    Title = "Holy Resurrection Cathedral",
    Description = "Holy Resurrection Cathedral is a prominent religious landmark in Ivano-Frankivsk, known for its striking architecture and spiritual significance. The cathedral hosts regular services and is an important center for the local Orthodox community.",
    Address = "Holy Resurrection Cathedral, Ivano-Frankivsk"
},

new AttractionTranslation
{
    id = 176,
    EntityId = 70,
    Lang = "uk",
    Title = "Кафедральний собор Святого Воскресіння",
    Description = "Кафедральний собор Святого Воскресіння — визначна релігійна пам’ятка Івано-Франківська, відома своєю вражаючою архітектурою та духовним значенням. У соборі регулярно проводяться богослужіння, він є важливим центром для місцевої православної громади.",
    Address = "Кафедральний собор Святого Воскресіння, Івано-Франківськ"
},

// "Бастіон",
new AttractionTranslation
{
    id = 177,
    EntityId = 71,
    Lang = "en",
    Title = "Bastion",
    Description = "Bastion is a historic fortification in Ivano-Frankivsk, offering visitors a glimpse into the city's defensive past. The site features preserved walls, scenic viewpoints, and serves as a cultural landmark in the heart of the city.",
    Address = "Bastion, Ivano-Frankivsk"
},

new AttractionTranslation
{
    id = 178,
    EntityId = 71,
    Lang = "uk",
    Title = "Бастіон",
    Description = "Бастіон — історична фортифікація Івано-Франківська, яка дає змогу ознайомитися з оборонним минулим міста. На території збережені стіни, є мальовничі оглядові майданчики, і він служить культурною пам’яткою в центрі міста.",
    Address = "Бастіон, Івано-Франківськ"
},

// "Ivano-Frankivsk City Lake"
new AttractionTranslation
{
    id = 143,
    EntityId = 72,
    Lang = "en",
    Title = "Ivano-Frankivsk City Lake",
    Description = "Ivano-Frankivsk City Lake is a picturesque recreational area and one of the most popular places in the city. Visitors can enjoy scenic walking paths, small bridges, the romantic 'Island of Love,' and beautiful sunset views over the water. It is a favorite spot for relaxation, sports, and photography.",
    Address = "City Lake, Ivano-Frankivsk"
},

new AttractionTranslation
{
    id = 144,
    EntityId = 72,
    Lang = "uk",
    Title = "Міське озеро",
    Description = "Міське озеро в Івано-Франківську — мальовнича зона відпочинку та одне з найпопулярніших місць міста. Тут можна насолодитися прогулянками набережною, містками, романтичним «Островом кохання» та чудовими заходами сонця над водою. Це улюблене місце для відпочинку, спорту та фотосесій.",
    Address = "Міське озеро, Івано-Франківськ"
},

// =================== Буковель ===================


// "Гірськолижний курорт Буковель",
new AttractionTranslation
{
    id = 181,
    EntityId = 73,
    Lang = "en",
    Title = "Bukovel Ski Resort",
    Description = "Bukovel Ski Resort is the largest ski and winter sports destination in Ukraine, offering a wide range of slopes for all skill levels, modern lift systems, and numerous accommodations. It is a popular spot for skiing, snowboarding, and winter recreation amidst the scenic Carpathian Mountains.",
    Address = "Bukovel Ski Resort, Bukovel"
},

new AttractionTranslation
{
    id = 182,
    EntityId = 73,
    Lang = "uk",
    Title = "Гірськолижний курорт Буковель",
    Description = "Гірськолижний курорт Буковель — найбільший гірськолижний та зимовий спортивний курорт України, що пропонує різноманітні траси для будь-якого рівня, сучасні підйомники та численні місця для проживання. Популярне місце для катання на лижах, сноуборді та зимового відпочинку серед мальовничих Карпат.",
    Address = "Гірськолижний курорт Буковель, Буковель"
},

// "Озеро Молодості",
new AttractionTranslation
{
    id = 183,
    EntityId = 74,
    Lang = "en",
    Title = "Lake Molodosti",
    Description = "Lake Molodosti is a scenic lake in Bukovel, ideal for relaxation and outdoor activities. Surrounded by beautiful forested landscapes, the lake offers boating, walking trails, and peaceful spots for visitors to enjoy nature.",
    Address = "Lake Molodosti, Bukovel"
},

new AttractionTranslation
{
    id = 184,
    EntityId = 74,
    Lang = "uk",
    Title = "Озеро Молодості",
    Description = "Озеро Молодості — мальовниче озеро в Буковелі, ідеальне для відпочинку та активного дозвілля. Озеро оточене красивими лісовими пейзажами, тут можна кататися на човнах, гуляти пішохідними доріжками та насолоджуватися природою.",
    Address = "Озеро Молодості, Буковель"
},

// "Парк атракціонів",
new AttractionTranslation
{
    id = 185,
    EntityId = 75,
    Lang = "en",
    Title = "Amusement Park",
    Description = "Bukovel Amusement Park offers fun rides, games, and attractions for families and visitors of all ages. Located near the resort area, it provides entertainment beyond winter sports, making it a year-round destination for recreation.",
    Address = "Amusement Park, Bukovel"
},

new AttractionTranslation
{
    id = 186,
    EntityId = 75,
    Lang = "uk",
    Title = "Парк атракціонів",
    Description = "Парк атракціонів у Буковелі пропонує розважальні атракціони, ігри та активності для сімей та відвідувачів будь-якого віку. Розташований поблизу курортної зони, він забезпечує розваги поза зимовими видами спорту та робить курорт привабливим цілий рік.",
    Address = "Парк атракціонів, Буковель"
},


// "Канатна дорога Буковель",
new AttractionTranslation
{
    id = 187,
    EntityId = 76,
    Lang = "en",
    Title = "Bukovel Cable Car",
    Description = "The Bukovel Cable Car offers scenic rides over the ski resort and surrounding Carpathian landscapes. It provides convenient access to ski slopes and panoramic views, making it a favorite for both skiers and sightseers.",
    Address = "Bukovel Cable Car, Bukovel"
},

new AttractionTranslation
{
    id = 188,
    EntityId = 76,
    Lang = "uk",
    Title = "Канатна дорога Буковель",
    Description = "Канатна дорога Буковель пропонує мальовничі поїздки над курортом та навколишніми Карпатами. Вона забезпечує зручний доступ до гірськолижних трас та панорамні види, що робить її популярною як серед лижників, так і серед туристів.",
    Address = "Канатна дорога Буковель, Буковель"
},

// "Mavka Aquapark Bukovel"
new AttractionTranslation
{
    id = 189,
    EntityId = 77,
    Lang = "en",
    Title = "Mavka Aquapark Bukovel",
    Description = "Mavka Aquapark in Bukovel is a modern year-round water entertainment complex inspired by Ukrainian mythology. It features indoor and outdoor pools, thrilling water slides, relaxation areas, and family attractions, making it one of the most popular leisure destinations in the Carpathians.",
    Address = "Vyshnia area, Bukovel"
},

new AttractionTranslation
{
    id = 190,
    EntityId = 77,
    Lang = "uk",
    Title = "Аквапарк «Мавка» Буковель",
    Description = "Аквапарк «Мавка» у Буковелі — сучасний всесезонний водний розважальний комплекс, натхненний українською міфологією. Тут є криті та відкриті басейни, водні гірки, зони відпочинку та сімейні атракції, що робить його одним із найпопулярніших місць дозвілля в Карпатах.",
    Address = "урочище Вишня, Буковель"
},
// "Bukovel Adventure Park"
new AttractionTranslation
{
    id = 191,
    EntityId = 78,
    Lang = "en",
    Title = "Bukovel Adventure Park",
    Description = "Bukovel Adventure Park is an all-season outdoor recreation area offering activities for families and adventure seekers. Visitors can enjoy tubing tracks, zip-lines, rope courses, and other fun attractions set in the beautiful Carpathian landscape.",
    Address = "Vyshnia area, Bukovel"
},

new AttractionTranslation
{
    id = 192,
    EntityId = 78,
    Lang = "uk",
    Title = "Пригодницький парк Буковель",
    Description = "Пригодницький парк Буковель — всесезонна зона відпочинку на відкритому повітрі з атракціями для сімей та любителів активного відпочинку. Тут є тюбінгові траси, zip-line, мотузкові маршрути та інші розваги на фоні мальовничих Карпат.",
    Address = "урочище Вишня, Буковель"
},

// "Готель «Буковель»",
new AttractionTranslation
{
    id = 193,
    EntityId = 79,
    Lang = "en",
    Title = "Bukovel Hotel",
    Description = "Bukovel Hotel offers comfortable accommodation right in the heart of the Bukovel resort, providing easy access to ski slopes, cable cars, and other resort attractions. It features modern amenities and cozy rooms for guests.",
    Address = "Bukovel Hotel, Bukovel"
},

new AttractionTranslation
{
    id = 194,
    EntityId = 79,
    Lang = "uk",
    Title = "Готель «Буковель»",
    Description = "Готель «Буковель» пропонує комфортне проживання в самому серці курорту Буковель, забезпечуючи легкий доступ до гірськолижних трас, канатних доріг та інших атракцій курорту. Готель оснащений сучасними зручностями та затишними номерами.",
    Address = "Готель «Буковель», Буковель"
},

// "Bukovel Central Zone"
new AttractionTranslation
{
    id = 195,
    EntityId = 80,
    Lang = "en",
    Title = "Bukovel Central Zone",
    Description = "The Central Zone of Bukovel is the heart of the ski resort, featuring restaurants, shops, entertainment areas, and access points to all main slopes. It is a hub for both winter and summer activities, making it a must-visit location for tourists.",
    Address = "Central Zone, Bukovel"
},

new AttractionTranslation
{
    id = 196,
    EntityId = 80,
    Lang = "uk",
    Title = "Центральна зона Буковеля",
    Description = "Центральна зона Буковеля — серце курорту, де розташовані ресторани, магазини, розважальні майданчики та точки доступу до основних трас. Це центр зимових та літніх активностей, обов’язковий для відвідування туристами.",
    Address = "Центральна зона, Буковель"
},

// =================== Львів ===================

// "Площа Ринок, Львів"
new AttractionTranslation
{
    id = 197,
    EntityId = 81,
    Lang = "en",
    Title = "Rynok Square, Lviv",
    Description = "Rynok Square is the historic heart of Lviv, surrounded by colorful buildings, cafés, and historic landmarks. It’s the perfect place to explore the city’s vibrant culture and architecture.",
    Address = "Rynok Square, Lviv"
},

new AttractionTranslation
{
    id = 198,
    EntityId = 81,
    Lang = "uk",
    Title = "Площа Ринок, Львів",
    Description = "Площа Ринок — історичне серце Львова, оточене яскравими будинками, кав’ярнями та історичними пам’ятками. Ідеальне місце для знайомства з культурою та архітектурою міста.",
    Address = "Площа Ринок, Львів"
},

// "Львівська Оперна"
new AttractionTranslation
{
    id = 199,
    EntityId = 82,
    Lang = "en",
    Title = "Lviv Opera House",
    Description = "The Lviv Opera House is a stunning architectural masterpiece hosting opera, ballet, and concerts. Its ornate interiors and rich history make it a must-visit cultural landmark.",
    Address = "Lviv Opera House, Lviv"
},

new AttractionTranslation
{
    id = 200,
    EntityId = 82,
    Lang = "uk",
    Title = "Львівська Оперна",
    Description = "Львівська Оперна — вражаючий архітектурний шедевр, де проходять опери, балети та концерти. Його розкішні інтер’єри та багата історія роблять його обов’язковим для відвідування культурним об’єктом.",
    Address = "Львівська Оперна, Львів"
},

// "Високий замок"
new AttractionTranslation
{
    id = 201,
    EntityId = 83,
    Lang = "en",
    Title = "High Castle, Lviv",
    Description = "High Castle is a historic hilltop site in Lviv offering panoramic views of the city. Visitors can explore the ruins and enjoy scenic walks while learning about Lviv’s history.",
    Address = "High Castle, Lviv"
},

new AttractionTranslation
{
    id = 202,
    EntityId = 83,
    Lang = "uk",
    Title = "Високий замок",
    Description = "Високий замок — історичне місце на пагорбі у Львові з панорамними видами на місто. Відвідувачі можуть оглянути руїни, прогулятися мальовничими стежками та дізнатися більше про історію Львова.",
    Address = "Високий замок, Львів"
},

// Підземелля Ратуші
new AttractionTranslation
{
    id = 203,
    EntityId = 84,
    Lang = "en",
    Title = "Town Hall Undergrounds",
    Description = "The Town Hall Undergrounds in Lviv offer a fascinating glimpse into the city's medieval past. Visitors can explore historical cellars, tunnels, and exhibits about Lviv's urban development, making it a unique interactive experience.",
    Address = "Town Hall Undergrounds, Lviv"
},
new AttractionTranslation
{
    id = 204,
    EntityId = 84,
    Lang = "uk",
    Title = "Підземелля Ратуші",
    Description = "Підземелля Ратуші у Львові пропонують захопливий погляд на середньовічне минуле міста. Відвідувачі можуть досліджувати історичні підвали, тунелі та експозиції про розвиток Львова, що робить цей об’єкт унікальним інтерактивним досвідом.",
    Address = "Підземелля Ратуші, Львів"
},

// "Арсенал Львів"
new AttractionTranslation
{
    id = 205,
    EntityId = 85,
    Lang = "en",
    Title = "Lviv Arsenal",
    Description = "Lviv Arsenal is a historic fortress building that once served as an armory. The Arsenal Museum in Lviv showcases historical weaponry, armor, and military artifacts. Visitors can enjoy interactive displays and learn about the military history of the region, making it both educational and visually impressive.",
    Address = "Lviv Arsenal, Lviv"
},

new AttractionTranslation
{
    id = 206,
    EntityId = 85,
    Lang = "uk",
    Title = "Арсенал Львів",
    Description = "Арсенал Львів — історична фортифікаційна споруда, що колись слугувала арсеналом. Музей зброї (Арсенал) у Львові демонструє історичну зброю, обладунки та військові артефакти. Відвідувачі можуть оглянути інтерактивні експозиції та дізнатися про військову історію регіону, що робить музей цікавим та візуально привабливим.",
    Address = "Арсенал Львів, Львів"
},

// Музей шоколаду
new AttractionTranslation
{
    id = 207,
    EntityId = 86,
    Lang = "en",
    Title = "Chocolate Museum Lviv",
    Description = "The Chocolate Museum in Lviv offers visitors a delicious and interactive experience. Guests can learn about chocolate making, see live demonstrations, taste various treats, and enjoy a visually stunning exhibition of chocolate art.",
    Address = "Chocolate Museum, Lviv"
},
new AttractionTranslation
{
    id = 208,
    EntityId = 86,
    Lang = "uk",
    Title = "Музей шоколаду",
    Description = "Музей шоколаду у Львові пропонує відвідувачам смачний та інтерактивний досвід. Гості можуть дізнатися про виробництво шоколаду, подивитися живі демонстрації, скуштувати різні ласощі та насолодитися візуально привабливою експозицією шоколадного мистецтва.",
    Address = "Музей шоколаду, Львів"
},

// Церква Ольги та Єлизавети
new AttractionTranslation
{
    id = 209,
    EntityId = 87,
    Lang = "en",
    Title = "Church of St. Olga and St. Elizabeth",
    Description = "The Church of St. Olga and St. Elizabeth in Lviv is a stunning neo-Gothic cathedral known for its intricate architecture, stained-glass windows, and historical significance. It is one of the most photogenic landmarks in the city.",
    Address = "Church of St. Olga and St. Elizabeth, Lviv"
},
new AttractionTranslation
{
    id = 210,
    EntityId = 87,
    Lang = "uk",
    Title = "Церква Ольги та Єлизавети",
    Description = "Церква Ольги та Єлизавети у Львові — чудовий неоготичний храм, відомий своєю витонченою архітектурою, вітражами та історичною цінністю. Це один із найфотогенічніших об’єктів міста.",
    Address = "Церква Ольги та Єлизавети, Львів"
},

// "Собор Святого Юра"
new AttractionTranslation
{
    id = 211,
    EntityId = 88,
    Lang = "en",
    Title = "St. George Cathedral, Lviv",
    Description = "St. George Cathedral is a magnificent Baroque-style cathedral in Lviv, serving as a spiritual and architectural landmark. Its intricate interior and historic significance attract many visitors.",
    Address = "St. George Cathedral, Lviv"
},

new AttractionTranslation
{
    id = 212,
    EntityId = 88,
    Lang = "uk",
    Title = "Собор Святого Юра",
    Description = "Собор Святого Юра — величний катедральний собор у стилі бароко у Львові, який є духовною та архітектурною пам’яткою. Його багатий інтер’єр та історичне значення приваблюють численних відвідувачів.",
    Address = "Собор Святого Юра, Львів"
},


// =================== Одеса ===================


// "Дерибасівська вулиця, Одеса"
new AttractionTranslation
{
    id = 213,
    EntityId = 89,
    Lang = "en",
    Title = "Deribasivska Street, Odesa",
    Description = "Deribasivska Street is the heart of Odesa, famous for its lively pedestrian area, historic buildings, cafes, and shops. It's a central spot for walking, dining, and enjoying city life.",
    Address = "Deribasivska Street, Odesa"
},

new AttractionTranslation
{
    id = 214,
    EntityId = 89,
    Lang = "uk",
    Title = "Дерибасівська вулиця, Одеса",
    Description = "Дерибасівська вулиця — серце Одеси, відоме своєю жвавою пішохідною зоною, історичними будівлями, кафе та магазинами. Центральне місце для прогулянок, відпочинку та насолоди міським життям.",
    Address = "Дерибасівська вулиця, Одеса"
},

// "Одеський оперний театр"
new AttractionTranslation
{
    id = 215,
    EntityId = 90,
    Lang = "en",
    Title = "Odesa Opera and Ballet Theater",
    Description = "The Odesa Opera and Ballet Theater is a stunning architectural landmark known for its baroque style and rich history. It hosts world-class opera and ballet performances attracting visitors from around the world.",
    Address = "Odesa Opera and Ballet Theater, Odesa"
},

new AttractionTranslation
{
    id = 216,
    EntityId = 90,
    Lang = "uk",
    Title = "Одеський оперний театр",
    Description = "Одеський оперний театр — вражаюча архітектурна пам’ятка у стилі бароко з багатою історією. Тут проводяться світового рівня оперні та балетні вистави, що приваблюють відвідувачів з усього світу.",
    Address = "Одеський оперний театр, Одеса"
},

// "Воронцовський палац"
new AttractionTranslation
{
    id = 217,
    EntityId = 91,
    Lang = "en",
    Title = "Vorontsov Palace, Odesa",
    Description = "Vorontsov Palace in Odesa is a historic architectural gem, famous for its elegant design, beautiful gardens, and cultural significance. Visitors can explore the palace grounds, admire decorative details, and enjoy the picturesque scenery.",
    Address = "Vorontsov Palace, Odesa"
},

new AttractionTranslation
{
    id = 218,
    EntityId = 91,
    Lang = "uk",
    Title = "Воронцовський палац, Одеса",
    Description = "Воронцовський палац в Одесі — історична архітектурна перлина, відома своєю елегантною спорудою, красивими садами та культурним значенням. Відвідувачі можуть прогулятися територією палацу, помилуватися декоративними деталями та насолодитися живописними краєвидами.",
    Address = "Воронцовський палац, Одеса"
},

// "Приморський бульвар"
new AttractionTranslation
{
    id = 219,
    EntityId = 92,
    Lang = "en",
    Title = "Primorsky Boulevard, Odesa",
    Description = "Primorsky Boulevard is a scenic waterfront promenade in Odesa lined with historic buildings, monuments, and gardens. It’s perfect for leisurely walks and enjoying views of the Black Sea.",
    Address = "Primorsky Boulevard, Odesa"
},

new AttractionTranslation
{
    id = 220,
    EntityId = 92,
    Lang = "uk",
    Title = "Приморський бульвар, Одеса",
    Description = "Приморський бульвар — мальовнича набережна Одеси з історичними будівлями, пам’ятниками та садами. Ідеальне місце для прогулянок та насолоди видами на Чорне море.",
    Address = "Приморський бульвар, Одеса"
},
// "Музей західного та східного мистецтва"
new AttractionTranslation
{
    id = 221,
    EntityId = 93,
    Lang = "en",
    Title = "Museum of Western and Eastern Art, Odesa",
    Description = "The Museum of Western and Eastern Art in Odesa houses a rich collection of European, Asian, and Middle Eastern art. Visitors can explore paintings, sculptures, and decorative arts from various cultures and eras.",
    Address = "Museum of Western and Eastern Art, Odesa"
},

new AttractionTranslation
{
    id = 222,
    EntityId = 93,
    Lang = "uk",
    Title = "Музей західного та східного мистецтва, Одеса",
    Description = "Музей західного та східного мистецтва в Одесі містить багату колекцію європейського, азійського та ближньосхідного мистецтва. Відвідувачі можуть ознайомитися з картинами, скульптурами та декоративним мистецтвом різних культур і епох.",
    Address = "Музей західного та східного мистецтва, Одеса"
},

// "Гавань Одеси"
new AttractionTranslation
{
    id = 223,
    EntityId = 94,
    Lang = "en",
    Title = "Odesa Harbor",
    Description = "Odesa Harbor is the bustling port of the city, offering scenic views of ships, piers, and the Black Sea. It's a hub for maritime activity and a popular spot for walks along the waterfront.",
    Address = "Odesa Harbor, Odesa"
},

new AttractionTranslation
{
    id = 224,
    EntityId = 94,
    Lang = "uk",
    Title = "Гавань Одеси",
    Description = "Гавань Одеси — це жвавий порт міста з мальовничими видами на кораблі, причали та Чорне море. Центр морської діяльності та популярне місце для прогулянок уздовж набережної.",
    Address = "Гавань Одеси"
},

// "Парк Шевченка"
new AttractionTranslation
{
    id = 225,
    EntityId = 95,
    Lang = "en",
    Title = "Shevchenko Park, Odesa",
    Description = "Shevchenko Park is a beautiful green space in Odesa featuring walking paths, fountains, and monuments. It is a favorite location for relaxation and leisure activities among locals and visitors.",
    Address = "Shevchenko Park, Odesa"
},

new AttractionTranslation
{
    id = 226,
    EntityId = 95,
    Lang = "uk",
    Title = "Парк Шевченка, Одеса",
    Description = "Парк Шевченка — гарна зелена зона в Одесі з прогулянковими доріжками, фонтанами та пам’ятниками. Улюблене місце відпочинку та розваг для мешканців і туристів.",
    Address = "Парк Шевченка, Одеса"
},

// "Ланжерон"
new AttractionTranslation
{
    id = 227,
    EntityId = 96,
    Lang = "en",
    Title = "Lanzheron Beach, Odesa",
    Description = "Lanzheron Beach is one of Odesa’s most popular city beaches, offering sandy shores, cafes, and recreational facilities. It’s ideal for sunbathing, swimming, and enjoying seaside activities.",
    Address = "Lanzheron Beach, Odesa"
},

new AttractionTranslation
{
    id = 228,
    EntityId = 96,
    Lang = "uk",
    Title = "Ланжерон, Одеса",
    Description = "Ланжерон — один з найпопулярніших міських пляжів Одеси з піщаним берегом, кафе та зонами відпочинку. Ідеальне місце для засмаги, купання та морських розваг.",
    Address = "Ланжерон, Одеса"
},


// =================== Харків ===================

// "Харківський художній музей"
new AttractionTranslation
{
    id = 229,
    EntityId = 97,
    Lang = "en",
    Title = "Kharkiv Art Museum",
    Description = "The Kharkiv Art Museum houses an extensive collection of Ukrainian and European art, including paintings, sculptures, and temporary exhibitions. A must-visit for art lovers exploring Kharkiv.",
    Address = "Kharkiv Art Museum, Kharkiv"
},

new AttractionTranslation
{
    id = 230,
    EntityId = 97,
    Lang = "uk",
    Title = "Харківський художній музей",
    Description = "Харківський художній музей зберігає велику колекцію українського та європейського мистецтва, включаючи живопис, скульптуру та тимчасові виставки. Обов’язкова локація для любителів мистецтва в Харкові.",
    Address = "Харківський художній музей, Харків"
},

// "Університет ім. Каразіна"
new AttractionTranslation
{
    id = 231,
    EntityId = 98,
    Lang = "en",
    Title = "Karazin University, Kharkiv",
    Description = "Karazin University is a historic and prestigious university in Kharkiv, known for its classical architecture and significant contributions to science and education in Ukraine.",
    Address = "Karazin University, Kharkiv"
},

new AttractionTranslation
{
    id = 232,
    EntityId = 98,
    Lang = "uk",
    Title = "Університет ім. Каразіна, Харків",
    Description = "Університет ім. Каразіна — історичний і престижний університет у Харкові, відомий класичною архітектурою та значним внеском у науку та освіту в Україні.",
    Address = "Університет ім. Каразіна, Харків"
},

// "Парк ім. Горького"
new AttractionTranslation
{
    id = 233,
    EntityId = 99,
    Lang = "en",
    Title = "Gorky Park, Kharkiv",
    Description = "Gorky Park in Kharkiv is a large recreational area featuring walking paths, amusement rides, lakes, and green spaces, making it a favorite spot for families and tourists.",
    Address = "Gorky Park, Kharkiv"
},

new AttractionTranslation
{
    id = 234,
    EntityId = 99,
    Lang = "uk",
    Title = "Парк ім. Горького, Харків",
    Description = "Парк ім. Горького у Харкові — велика рекреаційна зона з пішохідними доріжками, атракціонами, озерами та зеленими зонами, улюблене місце для сімей та туристів.",
    Address = "Парк ім. Горького, Харків"
},

// "Сад Шевченка"
new AttractionTranslation
{
    id = 235,
    EntityId = 100,
    Lang = "en",
    Title = "Shevchenko Garden, Kharkiv",
    Description = "Shevchenko Garden is a historic public park in Kharkiv, offering scenic walking paths, statues, fountains, and cultural events, named in honor of the famous Ukrainian poet Taras Shevchenko.",
    Address = "Shevchenko Garden, Kharkiv"
},

new AttractionTranslation
{
    id = 236,
    EntityId = 100,
    Lang = "uk",
    Title = "Сад Шевченка, Харків",
    Description = "Сад Шевченка — історичний громадський парк у Харкові з мальовничими доріжками, скульптурами, фонтанами та культурними подіями, названий на честь відомого українського поета Тараса Шевченка.",
    Address = "Сад Шевченка, Харків"
},
// "Покровський собор"
new AttractionTranslation
{
    id = 237,
    EntityId = 101,
    Lang = "en",
    Title = "Pokrovsky Cathedral, Kharkiv",
    Description = "Pokrovsky Cathedral is one of Kharkiv’s most beautiful and historic churches, known for its stunning architecture, intricate interior, and cultural significance. Visitors can admire the ornate details and peaceful surroundings.",
    Address = "Pokrovsky Cathedral, Kharkiv"
},

new AttractionTranslation
{
    id = 238,
    EntityId = 101,
    Lang = "uk",
    Title = "Покровський собор, Харків",
    Description = "Покровський собор — одна з найгарніших і найісторичніших церков Харкова, відома своєю вражаючою архітектурою, витонченим інтер’єром та культурним значенням. Відвідувачі можуть помилуватися декоративними деталями та спокійною атмосферою.",
    Address = "Покровський собор, Харків"
},

// "Харківська Опера"
new AttractionTranslation
{
    id = 239,
    EntityId = 102,
    Lang = "en",
    Title = "Kharkiv Opera House",
    Description = "The Kharkiv Opera House is a historic theater known for its grand architecture and world-class performances of opera and ballet, attracting both locals and tourists.",
    Address = "Kharkiv Opera House, Kharkiv"
},

new AttractionTranslation
{
    id = 240,
    EntityId = 102,
    Lang = "uk",
    Title = "Харківська Опера, Харків",
    Description = "Харківська Опера — історичний театр, відомий своєю величною архітектурою та висококласними виступами опери та балету, приваблює як місцевих жителів, так і туристів.",
    Address = "Харківська Опера, Харків"
},

// "Ботанічний сад Харківського університету"
new AttractionTranslation
{
    id = 241,
    EntityId = 103,
    Lang = "en",
    Title = "Botanical Garden of Kharkiv University, Kharkiv",
    Description = "The Botanical Garden of Kharkiv University is a serene green space showcasing diverse plant collections, beautiful landscapes, and walking paths. It’s a favorite spot for relaxation, study, and photography.",
    Address = "Botanical Garden of Kharkiv University, Kharkiv"
},

new AttractionTranslation
{
    id = 242,
    EntityId = 103,
    Lang = "uk",
    Title = "Ботанічний сад Харківського університету, Харків",
    Description = "Ботанічний сад Харківського університету — затишна зелена зона з різноманітними колекціями рослин, красивими ландшафтами та прогулянковими доріжками. Улюблене місце для відпочинку, навчання та фотографування.",
    Address = "Ботанічний сад Харківського університету, Харків"
},

// "Парк Фельдмана"
new AttractionTranslation
{
    id = 243,
    EntityId = 104,
    Lang = "en",
    Title = "Feldman Ecopark, Kharkiv",
    Description = "Feldman Ecopark is a sprawling park and zoo in Kharkiv, featuring diverse wildlife, recreational areas, playgrounds, and scenic walking paths. It’s perfect for family outings and nature exploration.",
    Address = "Feldman Ecopark, Kharkiv"
},

new AttractionTranslation
{
    id = 244,
    EntityId = 104,
    Lang = "uk",
    Title = "Парк Фельдмана, Харків",
    Description = "Парк Фельдмана — просторий парк та зоопарк у Харкові з різноманітними тваринами, зонами відпочинку, дитячими майданчиками та мальовничими прогулянковими доріжками. Ідеальне місце для сімейного відпочинку та знайомства з природою.",
    Address = "Парк Фельдмана, Харків"
}
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
