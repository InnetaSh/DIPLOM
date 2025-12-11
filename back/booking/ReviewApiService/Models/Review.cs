
using Globals.Models;
using System;

namespace ReviewApiService.Models
{
    public class Review : EntityBase
    {
            
        public int OfferId { get; set; }        // ID объекта/оффера
        public int UserId { get; set; }         // ID пользователя

    

        // Оценки по категориям (1-10)
        public double Staff { get; set; }           // Персонал
        public double Facilities { get; set; }      // Удобства
        public double Cleanliness { get; set; }     // Чистота
        public double Comfort { get; set; }         // Комфорт
        public double ValueForMoney { get; set; }   // Соотношение цена/качество
        public double Location { get; set; }        // Расположение

        // Общая оценка (среднее всех категорий)
        public double OverallRating
        {
            get
            {
                var ratings = new double[]
                {
                Staff, Facilities, Cleanliness, Comfort, ValueForMoney, Location
                };
                return ratings.Average();
            }
        }

        // Дата создания и обновления
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Опционально: статус модерации
        public bool IsApproved { get; set; } = true;
    }
}


