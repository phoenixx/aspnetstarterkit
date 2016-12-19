using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Subscriptions;

namespace Spa.StarterKit.React.ViewModels.Subscriptions
{
    public class ManageSubscriptionPlansViewModel
    {
        public string SearchExpression { get; set; }
        public IList<SubscriptionPlanContract> SubscriptionPlans { get; set; }
    }
}