using Spa.StarterKit.React.ViewModels.Shared.Company;
using Spa.StarterKit.React.ViewModels.Shared.Payment;

namespace Spa.StarterKit.React.ViewModels.Subscriptions
{
    public class UpgradePaymentViewModel
    {
        public decimal PayableToday { get; set; }
        public AddressEditViewModel Address { get; set; }
        public AddressEditViewModel CompanyBillingAddress { get; set; }
        public CardDetailsViewModel CardDetails { get; set; }
        public string UpgradePlanreference { get; set; }
    }
}
