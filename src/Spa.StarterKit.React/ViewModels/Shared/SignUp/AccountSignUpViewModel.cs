using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spa.StarterKit.React.Config;
using Spa.StarterKit.React.ViewModels.CustomValidationAttributes;

namespace Spa.StarterKit.React.ViewModels.Shared.SignUp
{
    public class AccountSignUpViewModel
    {
        public SelectList Titles { get; set; }

        [MustBeTrue(ErrorMessage = "You must accept the terms and conditions")]
        [DisplayName("Accept the terms and conditions")]
        public bool TermsAndConditions { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [EmailAddress]
        [Remote("IsEmailAddressAvailable", "IsEmailAddressAvailable", ErrorMessage = "An account already exists for this email address")]
        [Required]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

        [DisplayName("Landline Number")]
        public string LandlineNumber { get; set; }

        [DisplayName("Mobile Number")]
        public string MobileNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(Constants.Passwords.VALIDATION_REGEX, ErrorMessage = Constants.Passwords.VALIDATION_ERROR_MESSAGE)]
        [MaxLength(30, ErrorMessage = "Password cannot be more than 30 characters")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; }

        public string LanguageCode { get { return "en"; } }
        public string TimeZoneInfoId { get { return "UTC"; } }

        public Guid? SubscriptionReference { get; set; }
    }
}