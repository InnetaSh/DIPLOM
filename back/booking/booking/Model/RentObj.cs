using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace booking.Model
{
    public class RentObj
    {
        public int id { get; set; }
        public string Title { get; set; }

       
        public int CityId { get; set; }
        public City City { get; set; }

        public List<ParamsCategory> ParamCategories { get; set; }


    }

}
