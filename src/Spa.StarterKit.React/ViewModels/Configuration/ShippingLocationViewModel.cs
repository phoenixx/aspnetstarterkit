using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Spa.StarterKit.React.ViewModels.Configuration.Enums;
using Spa.StarterKit.React.ViewModels.Shared.Address;

namespace Spa.StarterKit.React.ViewModels.Configuration
{
    public class ShippingLocationViewModel
    {
        public int ShippingLocationId { get; set; }

        [Required]
        [Remote("IsShippingLocationReferenceAvailable", "IsShippingLocationReferenceAvailable", ErrorMessage = @"This shipping location reference has been used previously")]
        [DisplayName("Reference")]
        [MaxLength(200)]
        public string Reference { get; set; }

        [Required]
        //[Remote("IsShippingLocationNameAvailable", "Validation", ErrorMessage = "name must be unique")]
        [DisplayName("Location Name")]
        [MaxLength(200)]
        public string LocationName { get; set; }

        public ShippingLocationType Type { get; set; }

        [DisplayName("Make this my default location for returns")]
        public bool IsDefaultReturnLocation { get; set; }

		[DisplayName("Title")]
		[MaxLength(10)]
		public string ContactTitle { get; set; }

        [Required]
        [DisplayName("First Name")]
        [MaxLength(100)]
        public string ContactFirstName { get; set; }

		[Required]
		[DisplayName("Last Name")]
		[MaxLength(100)]
		public string ContactLastName { get; set; }

        [DisplayName("Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [DisplayName("Contact Telephone")]
        [MaxLength(100)]
        public string ContactTelephone { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public AddressViewModel Address { get; set; }

        [DisplayName("Notes to carrier")]
        public string NotesToCarrier { get; set; }

        public IList<ShippingLocationAccountViewModel> LinkedAccounts { get; set; }

		public bool CascadeUnshippedConsignmentAddressDetails { get; set; }

        public ShippingLocationViewModel()
        {
            Address = new AddressViewModel();
        }
    }
}
