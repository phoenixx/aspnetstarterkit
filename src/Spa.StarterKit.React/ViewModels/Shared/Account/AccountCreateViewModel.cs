using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spa.StarterKit.React.Config;

namespace Spa.StarterKit.React.ViewModels.Shared.Account
{
    public class AccountCreateViewModel
    {
        public SelectList Titles { get; set; }
        public SelectList TimeZones { get; set; }
        public SelectList Roles { get; set; }
        public SelectList CarrierServiceSets { get; set; }

        [Required]
        public Guid CompanyReference { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName {get;set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [EmailAddress]
        [Remote("IsEmailAddressAvailable", "IsEmailAddressAvailable", ErrorMessage = "That email address is already in use")]
        [Required]
        [DisplayName("Email Address")]
        public string EmailAddress { get; set; }

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

        [DisplayName("Landline Number")]
        public string LandlineNumber { get; set; }

        [DisplayName("Mobile Number")]
        public string MobileNumber { get;set;}

        [DisplayName("Role(s)")]
        public IList<Guid> RoleReferences { get; set; }

        [DisplayName("Carrier restrictions")]
        public string CarrierServiceSetRef { get; set; }

        //[DisplayName("Main contact?")]
        //public bool IsMainCustomerContact { get; set; }

        [Required]
        [DisplayName("Timezone")]
        public int TimeZoneInfoId { get; set; }

        [DisplayName(("Disable user"))]
        public bool IsDisabled { get; set; }

        public string LanguageCode { get { return "en"; } }
    }
}