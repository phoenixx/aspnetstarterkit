using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Spa.StarterKit.React.Config;

namespace Spa.StarterKit.React.ViewModels.User
{
    public class PasswordResetViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("New password")]
        [RegularExpression(Constants.Passwords.VALIDATION_REGEX, ErrorMessage = Constants.Passwords.VALIDATION_ERROR_MESSAGE)]
        [MaxLength(30, ErrorMessage = "Password cannot be more than 30 characters")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; }

        public Guid TokenValue { get; set; }
    }
}