using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Spa.StarterKit.React.ViewModels.User
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "You must enter an email")]
        [DisplayName("Registered email address")]
        public string Email { get; set; }
    }
}