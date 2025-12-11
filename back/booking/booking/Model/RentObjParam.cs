namespace booking.Model
{
    public class RentObjParam<T>
    {
        public int id { get; set; }
        public string Name { get; set; }
        public T Value { get; set; }
    }
}
