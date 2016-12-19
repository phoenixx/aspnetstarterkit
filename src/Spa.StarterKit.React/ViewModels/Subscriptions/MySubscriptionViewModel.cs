namespace Spa.StarterKit.React.ViewModels.Subscriptions
{
    public class MySubscriptionViewModel
    {
        public int LabelsPrintedThisBillingCycle { get; set; }
        public int CarriersEnabled { get; set; }
        public int CarrierServicesEnabled { get; set; }
        public int MarketplacesLinked { get; set; }

        public PricingPlanViewModel PricingPlan { get; set; }
    }
}
