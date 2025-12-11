using System.ComponentModel.DataAnnotations;

namespace TranslationApiService.Models
{
    public class TranslationEntityBase
    {
        [Key]
        public int id { get; set; }

        public int EntityId { get; set; }


        public string Lang { get; set; }   // "en", "ru", "de", ...
    }
}
