using PXLHotel_12200496.Models;

namespace PXLHotel_12200496.Data.DefaultData
{
    public static class SeedData
    {
        public static void EnsurePopulated(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<HotelDbContext>();
                if (!context.Hotels.Any())
                {
                    foreach (var hotel in GetHotels())
                    {
                        context.Hotels.Add(hotel);
                    }

                    context.SaveChanges();
                }

                if (!context.HotelRooms.Any())
                {
                    foreach (var room in GetRooms())
                    {
                        context.HotelRooms.Add(room);
                    }

                    context.SaveChanges();
                }
            }
        }

        private static Hotel[] GetHotels()
        {
            var hotels = new Hotel[2];
            hotels[0] = new Hotel
            {
                HotelName = "Mirage",
                HotelCountry = "BE"
            };
            hotels[1] = new Hotel
            {
                HotelName = "Piramide",
                HotelCountry = "NL"
            };

            return hotels;
        }

        private static HotelRoom[] GetRooms()
        {
            var rooms = new HotelRoom[4];
            rooms[0] = new HotelRoom
            {
                HotelId = 0,
                HotelRoomName = "Dracula",
                HotelRoomNumber = 13
            };
            rooms[1] = new HotelRoom
            {
                HotelId = 0,
                HotelRoomName = "Scream",
                HotelRoomNumber = 14
            };
            rooms[2] = new HotelRoom
            {
                HotelId = 1,
                HotelRoomName = "Dracula",
                HotelRoomNumber = 13
            };
            rooms[3] = new HotelRoom
            {
                HotelId = 1,
                HotelRoomName = "London Bridge",
                HotelRoomNumber = 14
            };

            return rooms;
        }
    }
}
