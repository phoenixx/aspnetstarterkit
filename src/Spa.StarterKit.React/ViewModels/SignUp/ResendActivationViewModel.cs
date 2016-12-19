using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Spa.StarterKit.React.ViewModels.SignUp
{
    public class ResendActivationViewModel
    {
        [Required]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }
    }
}