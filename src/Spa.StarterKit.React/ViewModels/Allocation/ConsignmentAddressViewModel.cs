using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentValidation.Attributes;
using MPD.Electio.SDK.NetCore.Internal.CoreLib.CustomsDeclarations;
using MPD.Electio.SDK.NetCore.Internal.CoreLib.Locations.Addresses.Postcodes;
using MPD.Electio.SDK.NetCore.Internal.CoreLib.Locations.Countries.IsoCodes;
using Spa.StarterKit.React.ViewModels.FluentValidators.ManualUpload;
using Spa.StarterKit.React.ViewModels.Shared.Address;

namespace Spa.StarterKit.React.ViewModels.Allocation
{
    [Validator(typeof(ConsignmentAddressValidator))]
    public class ConsignmentAddressViewModel : AddressViewModel
    {
        public string Key { get; set; }

        [Display(Name = "Contact Title")]
        public string Title { get; set; }

        [Display(Name = "Contact Forename")]
        public string Forename { get; set; }

        [Display(Name = "Contact Surname")]
        public string Surname { get; set; }

        [Display(Name = "Contact email")]
        public string Email { get; set; }

        [Display(Name = "Landline Number")]
        public string LandlineNumber { get; set; }

        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        //[Display(Name = "Company name")]
        //public string Company { get; set; }

        //[Display(Name = "Address 1")]
        //public string Line1 { get; set; }

        //[Display(Name = "Address 2")]
        //public string Line2 { get; set; }

        //[Display(Name = "Address 3")]
        //public string Line3 { get; set; }

        //[Display(Name = "Town")]
        //public string Town { get; set; }

        //[Display(Name = "County")]
        //public string County { get; set; }

        //[Display(Name = "Postcode")]
        //public string PostCode { get; set; }

        [Display(Name = "Country")]
        public string CountryRef { get; set; }

        ///// <summary>
        ///// Two letter ISO Code
        ///// </summary>
        //[Display(Name = "Country")]
        //public string CountryIsoCode { get; set; }

        //[Display(Name = "Special Instructions")]
        //public string SpecialInstructions { get; set; }

        public string ShippingLocationReference { get; set; }

        public override string ToString()
        {
            var fields = new List<string>
            {
                Company,
                Line1,
                Town,
                County,
                PostCode,
                CountryIsoCode
            };
            return string.Join(",", fields.Where(f => !String.IsNullOrEmpty(f)));
        }
    }

    public static class ConsignmentAddressViewModelExtended
    {
        private static readonly CountryShippingDocuments CountryShippingDocuments;

        static ConsignmentAddressViewModelExtended()
        {
            CountryShippingDocuments = new CountryShippingDocuments();
        }

        public static bool AreCustomDocumentsRequiredForShippingBetweenAddresses(this ConsignmentAddressViewModel originConsignmentAddressViewModel,
            ConsignmentAddressViewModel destinationConsignmentAddressViewModel)
        {

            if (destinationConsignmentAddressViewModel == null)
                throw new ArgumentNullException("destinationConsignmentAddressViewModel");

            if (string.IsNullOrWhiteSpace(originConsignmentAddressViewModel.CountryIsoCode))
                throw new ArgumentException(@"CountryIsoCode of origin should not be null or empty.");

            if (string.IsNullOrWhiteSpace(destinationConsignmentAddressViewModel.CountryIsoCode))
                throw new ArgumentException(@"CountryIsoCode of destination should not be null or empty.");

            return
                CountryShippingDocuments.AreCustomDocumentsRequiredForShippingBetweenAddresses(
                    TwoLetterIsoCode.Parse(originConsignmentAddressViewModel.CountryIsoCode),
                    new Postcode(originConsignmentAddressViewModel.PostCode),
                    TwoLetterIsoCode.Parse(destinationConsignmentAddressViewModel.CountryIsoCode),
                    new Postcode(destinationConsignmentAddressViewModel.PostCode));
        }
    }
}