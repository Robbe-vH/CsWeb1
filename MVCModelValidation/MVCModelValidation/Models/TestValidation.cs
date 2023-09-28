using System.ComponentModel.DataAnnotations;

namespace MVCModelValidation.Models
{
    public class TestValidation
    {
        [Required]
        public int? TestValidationId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
    }
}
