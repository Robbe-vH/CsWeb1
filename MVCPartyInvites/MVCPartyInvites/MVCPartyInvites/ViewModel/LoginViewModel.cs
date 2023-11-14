using System.ComponentModel.DataAnnotations;

namespace MVCPartyInvites.ViewModel
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
