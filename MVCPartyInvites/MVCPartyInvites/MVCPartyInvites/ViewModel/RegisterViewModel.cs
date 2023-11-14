using System.ComponentModel.DataAnnotations;

namespace MVCPartyInvites.ViewModel
{
    public class RegisterViewModel : LoginViewModel
    {
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }
    }
}
