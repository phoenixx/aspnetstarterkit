using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.DataTypes.Subscription.v1_1.Enums;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Subscriptions;

namespace Spa.StarterKit.React.ViewModels.Customer
{
	public class AddCustomerSubscriptionInfoViewModel
	{
        public int? Id { get; set; }
        public int CustomerId { get; set; }
        public SubscriptionStatus Status { get; set; }
        public string BillingCycle { get; set; }
        public string SubscriptionPlanReferenceString { get; set; }

        public List<SubscriptionPlanContract> SubscriptionPlans { get; set; }
	}
}
