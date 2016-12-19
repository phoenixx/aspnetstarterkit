using System;

namespace Spa.StarterKit.React.ViewModels.Allocation
{
	public class SetConsignmentDetailsViewModel
	{
		public string ClientReference { get; set; }

		public DateTime? RequestedDeliveryDate { get; set; }

        public string OriginAddressSpecialInstructions { get; set; }

        public string DestinationAddressSpecialInstructions { get; set; }
	}
}