using System.ComponentModel.DataAnnotations;

namespace WebAppMVCCliebtLocationEFCore.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public string ClientName { get; set; }
    }
}
