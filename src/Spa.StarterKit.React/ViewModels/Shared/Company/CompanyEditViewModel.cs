using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Spa.StarterKit.React.ViewModels.Shared.Company
{
    public class CompanyEditViewModel
    {
        public CompanyEditViewModel()
        {
            RegisteredAddress = new AddressEditViewModel();
            BillingAddress = new AddressEditViewModel();
        }

        public SelectList AvailableCurrencies { get; set; }

        private SelectList _availableCountries;
        public SelectList AvailableCountries
        {
            get { return _availableCountries; }
            set
            {
                _availableCountries = value;
                if (RegisteredAddress != null)
                {
                    RegisteredAddress.AvailableCountries = value;
                }
                if (BillingAddress != null)
                {
                    BillingAddress.AvailableCountries = value;
                }
            }
        }

        public Guid Reference { get; set; }

        [Required]
        [DisplayName("Company Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Registration Country")]
        public string RegistrationCountryRef { get; set; }

        [Required]
        [DisplayName("Company Registration Number")]
        public string RegistrationNumber { get; set; }
        
        [DisplayName("VAT Number")]
        public string VatNumber { get; set; }

        [Required]
        [DisplayName("Currency")]
        public string CurrencyRef { get; set; }

        public AddressEditViewModel RegisteredAddress { get; set; }
        public AddressEditViewModel BillingAddress { get; set; }

        public bool BillingAddressSameAsRegistered
        {
            get
            {
                if (BillingAddress == null || RegisteredAddress == null)
                {
                    return false;
                }
                return (BillingAddress.Company == RegisteredAddress.Company
                        && BillingAddress.Line1 == RegisteredAddress.Line1
                        && BillingAddress.Line2 == RegisteredAddress.Line2
                        && BillingAddress.Line3 == RegisteredAddress.Line3
                        && BillingAddress.County == RegisteredAddress.County
                        && BillingAddress.PostCode == RegisteredAddress.PostCode
                        && BillingAddress.CountryIsoCode == RegisteredAddress.CountryIsoCode);
            }
        }
    }
}