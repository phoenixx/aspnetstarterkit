using System.ComponentModel.DataAnnotations;

namespace Spa.StarterKit.React.ViewModels.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "You must enter an email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}