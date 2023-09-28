using System.ComponentModel.DataAnnotations;

namespace MVCModelValidation.Models
{
    public class TestData
    {
        public int? TestDataID { get; set; }
        [StringLength(50)]
        public string? Tekst { get; set; }
        //[CustomDate]
        public DateTime? Datum { get; set; }
    }
}
