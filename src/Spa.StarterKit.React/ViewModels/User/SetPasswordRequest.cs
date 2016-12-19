using System;
using System.ComponentModel.DataAnnotations;
using Spa.StarterKit.React.Config;

namespace Spa.StarterKit.React.ViewModels.User
{
	public class SetPasswordRequest
	{
		public Guid AccountReference { get; set; }
        
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Please enter your new password")]
        [RegularExpression(Constants.Passwords.VALIDATION_REGEX, ErrorMessage = Constants.Passwords.VALIDATION_ERROR_MESSAGE)]
        [MaxLength(30, ErrorMessage = "Password cannot be more than 30 characters")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Please confirm your new password")]
		public string ConfirmNewPassword { get; set; }
	}
}