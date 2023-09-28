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

        public static InsertResult AddClient(Client client)
        {
            var result = new InsertResult();
            try
            {
                Clients.Add(client);
                result.Succeeded = true;
            }
            catch (Exception e)
            {
                result.Errors.Add(e.Message);
                result.Succeeded = false;
            }

            return result;
        }

        public static InsertResult AddLocation(Location location)
        {
            var result = new InsertResult();
            try
            {
                Locations.Add(location);
                result.Succeeded = true;
            }
            catch (Exception e)
            {
                result.Errors.Add(e.Message);
                result.Succeeded = false;
            }

            return result;
        }
    }
}
