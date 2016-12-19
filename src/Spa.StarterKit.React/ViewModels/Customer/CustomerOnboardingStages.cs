using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Spa.StarterKit.React.ViewModels.Customer
{
    public enum CustomerOnboardingStages
    {
        [Display(Name = "Basic Customer Details")]
        BasicDetails,
        [Display(Name = "Customer Subscription Plan")]
        SubscriptionPlan,
        [Display(Name = "Customer Payment Details")]
        PaymentDetails,
        [Display(Name = "Authorised Users")]
        Users
    }

    public static class CustomerOnboardingStagesExtension
    {
        public static CustomerOnboardingStages GetNextCustomerOnboardingStage(this CustomerOnboardingStages stage)
        {
            return Enum.GetValues(typeof(CustomerOnboardingStages))
                 .Cast<CustomerOnboardingStages>()
                 .Where(x => x >= stage)
                 .OrderBy(x => x)
                 .Take(2)
                 .Last();
        }
    }
}