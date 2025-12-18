namespace UserApiService.Models
{
    public class ClientOrderLink
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int OrderId { get; set; }

        public Client Client { get; set; }
    }
}
