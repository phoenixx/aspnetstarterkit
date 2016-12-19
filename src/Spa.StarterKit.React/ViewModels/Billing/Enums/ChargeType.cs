using System.ComponentModel;

namespace Spa.StarterKit.React.ViewModels.Billing.Enums
{
    public enum ChargeType
    {
        [Description(@"Unknown")]
        Unknown = 0,
        [Description(@"Labels")]
        Labels = 1,
        [Description(@"MPD_Carrier_Service")]
        MpdCarrierService = 2,
        [Description(@"Outstanding_Charge")]
        OutstandingCharge = 3,
        [Description(@"Subscription_Fees")]
        SubscriptionFees = 4
    }
}