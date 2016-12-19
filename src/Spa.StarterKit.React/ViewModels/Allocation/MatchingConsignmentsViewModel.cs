using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Allocation
{
	public class MatchingConsignmentsViewModel
	{
		public int TotalMatchingCount { get; set; }
		public IList<ConsignmentDetailViewModel> ElectioConsignments;
	}
}