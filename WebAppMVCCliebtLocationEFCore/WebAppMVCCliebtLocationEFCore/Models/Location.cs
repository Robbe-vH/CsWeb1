using System.ComponentModel.DataAnnotations;

namespace WebAppMVCCliebtLocationEFCore.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        [StringLength(15)]
        [Required]
        public string PostCode { get; set; }
        [StringLength(100)]
        [Required]
        public string City { get; set; }
    }
}
