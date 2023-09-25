namespace WebAppMvcClientLocation.Models
{
    public class ClientLocation
    {
        public string ClientName { get; set; }
        public string City { get; set; }

        public IEnumerable<ClientLocation> Overview()
        {
            return new List<ClientLocation>();
        }
    }
}
