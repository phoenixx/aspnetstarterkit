using System;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Accounts;

namespace Spa.StarterKit.React.ViewModels.Customer
{
	public class CustomerAccountSummaryViewModel
	{
        // here for automapper
        public CustomerAccountSummaryViewModel()
        { }

        public CustomerAccountSummaryViewModel(CustomerAccountSummary fromSummary)
		{
			AccountFullName = fromSummary.AccountFullName;
			AccountReference = fromSummary.AccountReference;
			CustomerName = fromSummary.CustomerName;
			CustomerReference = fromSummary.CustomerReference;
			CustomerRegistrationNumber = fromSummary.CustomerRegistrationNumber;
			SubscriptionPlanId = fromSummary.SubscriptionPlanId;
			SubscriptionPlanName = fromSummary.SubscriptionPlanName;
		}

		public string AccountFullName { get; set; }

		public Guid AccountReference { get; set; }

		public string CustomerName { get; set; }

		public Guid CustomerReference { get; set; }

		public string CustomerRegistrationNumber { get; set; }

		public int? SubscriptionPlanId { get; set; }

		public string SubscriptionPlanName { get; set; }

		public string Status { get; set; }
	}
}