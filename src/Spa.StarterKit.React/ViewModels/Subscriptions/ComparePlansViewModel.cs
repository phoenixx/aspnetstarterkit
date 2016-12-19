using System;
using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Subscriptions
{
    public class ComparePlansViewModel
    {
        public IList<PricingPlanViewModel> PricingPlans { get; set; }
        public Guid CurrentPlanReference { get; set; }
        public int CurrentPlanLevel { get; set; }
    }
}
