



using System.ComponentModel.DataAnnotations;

namespace MVCPartyInvites.Models
{
    public class Gast
    {
        public Gast()
        {
            SetPrimaryKey();
        }
        public string Id { get; set; }
        [Required]
        public string Naam { get; set; }
        [EmailAddress]
        [Required]
        public string? Email { get; set; }
        public string? Telefoon { get; set; } 
        public bool? Aanwezig { get; set; }
        private void SetPrimaryKey()
        {
            Id = Guid.NewGuid().ToString();
        }

    }
}
