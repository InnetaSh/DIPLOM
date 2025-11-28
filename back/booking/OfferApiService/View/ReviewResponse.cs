using Globals.Controllers;
using System;

namespace OfferApiService.View
{
    public class ReviewResponse : IBaseResponse
    {
        public int id { get; set; }                   // ID отзыва
        public int Rating { get; set; }               // Общая оценка
        public string Comment { get; set; }           // Текст отзыва
        public int OfferId { get; set; }              // ID предложения
        public int UserId { get; set; }               // ID пользователя
        public string? Response { get; set; }         // Ответ владельца
        public DateTime CreatedAt { get; set; }       // Дата создания
        public bool IsApproved { get; set; }          // Статус модерации
        public bool IsAnonymous { get; set; }         // Анонимный отзыв
        public List<string> Photos { get; set; }      // Фото

        // Рейтинг по категориям
        public int Cleanliness { get; set; }
        public int Comfort { get; set; }
        public int Location { get; set; }
        public int Service { get; set; }
        public int ValueForMoney { get; set; }
    }
}
