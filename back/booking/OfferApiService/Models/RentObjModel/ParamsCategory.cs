using Globals.Models;

namespace OfferApiService.Models.RentObjModel
{
    public class ParamsCategory : EntityBase
    {
                // Например: "Кухня", "Ванная", "Удобства"
        public List<ParamItem> Items { get; set; } = new(); // Все параметры этой категории
    }

}
