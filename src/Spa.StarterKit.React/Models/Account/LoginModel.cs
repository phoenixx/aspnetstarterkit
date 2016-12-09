using System.ComponentModel.DataAnnotations;

namespace Spa.StarterKit.React.Models.Account
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}