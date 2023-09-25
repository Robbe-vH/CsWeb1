namespace WebAppMvcClientLocation.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public int LocationId { get; set; }
        public string ClientName { get; set; }

        public Client(int clientId, int locationId, string clientName)
        {
            ClientId = clientId;
            LocationId = locationId;
            ClientName = clientName;
        }
    }
}
