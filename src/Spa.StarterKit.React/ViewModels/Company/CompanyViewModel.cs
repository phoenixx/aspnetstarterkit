using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.DataTypes.Accounts.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Security.v1_1;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Common;
using PaymentModel = Spa.StarterKit.React.ViewModels.Billing.Enums.PaymentModel;

namespace Spa.StarterKit.React.ViewModels.Company
{
    public class CompanyViewModel
    {
        public string Reference { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public string VatNumber { get; set; }
        public string RegistrationCountryRef { get; set; }
        public Country RegistrationCountry { get; set; }
        public string CurrencyRef { get; set; }
        public Currency Currency { get; set; }
        public Address RegisteredAddress { get; set; }
        public Address BillingAddress { get; set; }
        public Account MainContactAccount { get; set; }
        public IList<BasicRole> Roles { get; set; }
        public List<MpdCarrierServiceGroup> CarrierServiceGroups { get; set; }
        public IList<MpdCarrier> AvailableCarriers { get; set; }
        public IList<Permission> PermissionRestrictions { get; set; }
        public PaymentModel PaymentModel { get; set; }
    }
}