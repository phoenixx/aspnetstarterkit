using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Dashboard
{
	public class CarrierStatusResponseModel
	{
		public IList<ConsignmentStateByCarrier> Summary { get; set; }
	}
}