using System.ComponentModel;
using Spa.StarterKit.React.ViewModels.Shared.Account;

namespace Spa.StarterKit.React.ViewModels.Shared.Company
{
    public class BasicCompanyInfoViewModel
    {
        public BasicCompanyInfoViewModel()
        {
            RegisteredAddress = new AddressInfoViewModel();
            BillingAddress = new AddressInfoViewModel();
        }

        public string Reference { get; set; }

        [DisplayName("Company Name")]
        public string Name { get; set; }

        [DisplayName("Registration Country")]
        public string RegistrationCountry { get; set; }

        [DisplayName("Company Registration Number")]
        public string RegistrationNumber { get; set; }
        
        [DisplayName("VAT Number")]
        public string VatNumber { get; set; }

        [DisplayName("Currency")]
        public string Currency { get; set; }

        public AddressInfoViewModel RegisteredAddress { get; set; }
        public AddressInfoViewModel BillingAddress { get; set; }

        public BasicAccountInfoViewModel MainContactAccount { get; set; }
    }
}