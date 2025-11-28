using Globals.Models;

namespace OfferApiService.Models
{
    public class Review : EntityBase
    {
        public int Rating { get; set; } // Общая оценка
        public string Comment { get; set; }
        public int OfferId { get; set; }
        public int UserId { get; set; }
        public string? Response { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsApproved { get; set; } = true;
        public bool IsAnonymous { get; set; } = false;
        public List<string> Photos { get; set; } = new List<string>();

        // Рейтинг по категориям
        public int Cleanliness { get; set; }       // Чистота
        public int Comfort { get; set; }           // Комфорт
        public int Location { get; set; }          // Расположение
        public int Service { get; set; }           // Сервис
        public int ValueForMoney { get; set; }     // Соотношение цена/качество
    }

}
