using WebAppMvcClientLocation.Models;

namespace WebAppMvcClientLocation.Data
{
    public static class Database
    {
        public static List<Client> Clients { get; set; }
        public static List<Location> Locations { get; set; }

        public static void StartDatabase()
        {
            Locations = new List<Location>
            {
                new Location(1, "3500", "Hasselt"),
                new Location(2, "3920", "Lommel")
            };

            Clients = new List<Client>
            {
                new Client(1, 1, "John"),
                new Client(2, 2, "Cena")
            };

        }
    }
}
