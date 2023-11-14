using PXLHotel_12200496.ModelValidations;
using System.ComponentModel.DataAnnotations;

namespace PXLHotel_12200496.Models
{
    public class HotelRoom
    {
        public int HotelRoomId { get; set; }
        public int HotelId { get; set; }
        [MaxLength(25), NoNumeric]
        public string? HotelRoomName { get; set; }
        [Between10And100]
        public int? HotelRoomNumber { get; set; }

    }
}
