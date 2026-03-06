using Globals.Models;
using System.ComponentModel.DataAnnotations;

namespace TranslationApiService.Models
{
    public class TranslationEntityBase : EntityBase
    {
  
        public int EntityId { get; set; }

        public string Lang { get; set; }   // "en", "ru", "de", ...
    }
}
