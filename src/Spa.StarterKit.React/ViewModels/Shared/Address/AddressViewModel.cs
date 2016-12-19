using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using Newtonsoft.Json;
using Spa.StarterKit.React.ViewModels.FluentValidators.Shared;

namespace Spa.StarterKit.React.ViewModels.Shared.Address
{
    [Validator(typeof(AddressViewModelValidator<AddressViewModel>))]
    public class AddressViewModel
    {
        public string Reference { get; set; }

        [Display(Name = "Company name")]
        public string Company { get; set; }

        [Display(Name = "Address 1")]
        public string Line1 { get; set; }

        [Display(Name = "Address 2")]
        public string Line2 { get; set; }

        [Display(Name = "Address 3")]
        public string Line3 { get; set; }

        [Display(Name = "Town")]
        public string Town { get; set; }

        [Display(Name = "County")]
        public string County { get; set; }

        [Display(Name = "Postcode")]
        public string PostCode { get; set; }

        /// <summary>
        /// Two letter ISO Code
        /// </summary>
        [Display(Name = "Country")]
        public string CountryIsoCode { get; set; }

        public string Country { get; set; }

        [Display(Name = "Special Instructions")]
        public string SpecialInstructions { get; set; }

        [JsonIgnore]
        public string SingleLineAddress
        {
            get
            {
                var address = string.Empty;

                if (!string.IsNullOrEmpty(Line1)) address += Line1 + " ";
                if (!string.IsNullOrEmpty(Line2)) address += Line2 + " ";
                if (!string.IsNullOrEmpty(Line3)) address += Line3 + " ";
                if (!string.IsNullOrEmpty(Town)) address += Town + " ";
                if (!string.IsNullOrEmpty(PostCode)) address += PostCode;

                return address.Trim();
            }
        }
    }
}