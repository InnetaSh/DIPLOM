namespace booking.Model
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int CountryId { get; set; }
        public string Country { get; set; }

        public List<RentObj> RentObjs { get; set; }
        //public ICollection<Property> Properties { get; set; }
    }

    public class Param<T>
    {
        public string Name { get; set; }
        public T Value { get; set; }
    }

}
