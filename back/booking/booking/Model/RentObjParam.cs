namespace booking.Model
{
    public class RentObjParam<T>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public T Value { get; set; }
    }
}
