using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Customer
{
	public class CustomerAccountQueryViewModel
	{
		public CustomerAccountQueryViewModel()
		{
			Records = new List<CustomerAccountSummaryViewModel>();
		}

		public string CustomerRegistrationNumber { get; set; }

		public string CustomerName { get; set; }

		public string AccountFullName { get; set; }

		public string AccountEmailAddress { get; set; }

		public bool HasValue()
		{
			return !string.IsNullOrWhiteSpace(CustomerRegistrationNumber) ||
				!string.IsNullOrWhiteSpace(CustomerName) ||
				!string.IsNullOrWhiteSpace(AccountFullName) ||
				!string.IsNullOrWhiteSpace(AccountEmailAddress);
		}

		public int PageSize { get; set; }

		public int PageNumber { get; set; }

		public int TotalRecords { get; set; }

		public IList<CustomerAccountSummaryViewModel> Records { get; set; } 
	}
}