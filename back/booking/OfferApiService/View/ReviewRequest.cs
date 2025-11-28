using Globals.Controllers;
using Globals.Models;

namespace OfferApiService.View
{
    public class ReviewRequest : IBaseRequest
    {
            public int Rating { get; set; }               // Общая оценка
            public string Comment { get; set; }           // Текст отзыва
            public int OfferId { get; set; }              // ID предложения
            public int UserId { get; set; }               // ID пользователя
            public List<string>? Photos { get; set; }     // Фото 

            // Рейтинг по категориям
            public int Cleanliness { get; set; }
            public int Comfort { get; set; }
            public int Location { get; set; }
            public int Service { get; set; }
            public int ValueForMoney { get; set; }
        
    }
}
