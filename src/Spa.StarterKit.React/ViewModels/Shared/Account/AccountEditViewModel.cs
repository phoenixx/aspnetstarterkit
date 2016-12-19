using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spa.StarterKit.React.Config;
using Spa.StarterKit.React.ViewModels.Configuration;
using Spa.StarterKit.React.ViewModels.Roles;

namespace Spa.StarterKit.React.ViewModels.Shared.Account
{
    public class AccountEditViewModel
    {
        public SelectList Titles { get; set; }

        public SelectList TimeZones { get; set; }

        public SelectList CarrierServiceSets { get; set; }

        public Guid AccountReference { get; set; }
        public Guid CompanyReference { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DisplayName("First Name *")]
        public string FirstName {get;set; }

        [Required]
        [DisplayName("Last Name *")]
        public string LastName { get; set; }

        [EmailAddress]
        [DisplayName("Email Address *")]
        public string CurrentEmailAddress { get; set;}

		[EmailAddress]
		[DisplayName("Email Address *")]
		public string NewEmailAddress { get; set; }

        [DisplayName("Landline Number")]
        public string LandlineNumber { get; set; }

        [DisplayName("Mobile Number")]
        public string MobileNumber { get;set;}

        [DisplayName("Role")]
        public IList<RoleViewModel> Roles { get; set; }

        public IList<RoleViewModel> AvailableRoles { get; set; }

        public IList<ShippingLocationRestrictionViewModel> AvailableShippingLocations { get; set; }

        [DisplayName("Carrier restrictions")]
        public string CarrierServiceSetRef { get; set; }

        [DisplayName("Main contact?")]
        public bool IsMainCustomerContact { get; set; }

        [Required]
        [DisplayName("Timezone *")]
        public string TimeZoneId { get; set; }

        [DisplayName(("Disable user"))]
        public bool IsDisabled { get; set; }

        public string LanguageCode { get { return "en"; } }


        [DataType(DataType.Password)]
        [RegularExpression(Constants.Passwords.VALIDATION_REGEX, ErrorMessage = Constants.Passwords.VALIDATION_ERROR_MESSAGE)]
        [MaxLength(30, ErrorMessage = "Password cannot be more than 30 characters")]
        [DisplayName("New password *")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Re-enter password *")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "The passwords do not match.")]
        public string ConfirmNewPassword { get; set; }

        public bool PasswordChanged { get; set; }

        public bool IsOwnAccount { get; set; }

        public string PrimaryApiKey { get; set; }
        public string SecondaryApiKey { get; set; }
    }
}