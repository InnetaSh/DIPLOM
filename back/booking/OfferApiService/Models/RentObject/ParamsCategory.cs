using Globals.Models;

namespace OfferApiService.Models.RentObject
{
    public class ParamsCategory : EntityBase
    {
        public int id { get; set; }             
        public string Title { get; set; }          // Например: "Кухня", "Ванная", "Удобства"
        public List<ParamItem> Items { get; set; } = new(); // Все параметры этой категории
    }

}
