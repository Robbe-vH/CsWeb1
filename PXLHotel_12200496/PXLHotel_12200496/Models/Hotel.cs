using PXLHotel_12200496.ModelValidations;
using System.ComponentModel.DataAnnotations;

namespace PXLHotel_12200496.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        [MaxLength(50)]
        public string? HotelName { get; set; }
        [MaxLength(2), Country]
        public string? HotelCountry { get; set; }
    }
}
