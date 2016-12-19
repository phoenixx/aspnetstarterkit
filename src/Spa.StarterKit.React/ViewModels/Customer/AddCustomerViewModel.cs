using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;
using MPD.Electio.SDK.NetCore.Internal.CoreLib.Customers;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Accounts;
using Spa.StarterKit.React.ViewModels.AddressLookup;

namespace Spa.StarterKit.React.ViewModels.Customer
{
    public class AddCustomerViewModel
    {
        public int? Id { get; set; }
        public CustomerReference? Reference { get; set; }
        public string ReferenceString { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public string VATNumber { get; set; }
        public string RegistrationCountryISOCode { get; set; }
        public string CurrencyCode { get; set; }
        public PaymentModel PaymentModel { get; set; }
        public string InternalReference { get; set; }

        public AddAddressViewModel RegisteredAddress { get; set; }
        public AddAddressViewModel BillingAddress { get; set; }
        public AddCustomerCreditAccountInfoViewModel CreditAccountInfo { get; set; }
        public AddCustomerSubscriptionInfoViewModel SubscriptionInfo { get; set; }

        public List<CountryViewModel> Countries { get; set; }
        public List<Currency> Currencies { get; set; }

        public AddCustomerViewModel()
        {
            this.RegisteredAddress = new AddAddressViewModel();
            this.BillingAddress = new AddAddressViewModel();
            this.CreditAccountInfo = new AddCustomerCreditAccountInfoViewModel();
            this.SubscriptionInfo = new AddCustomerSubscriptionInfoViewModel();
        }
    }
}