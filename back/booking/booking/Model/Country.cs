namespace booking.Model
{
    public class Country : EntityBase
    {
        
        public string Name { get; set; }

        public List<City> Cities { get; set; }
    }
}
