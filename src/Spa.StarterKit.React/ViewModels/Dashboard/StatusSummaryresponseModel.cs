using System;
using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Enums;

namespace Spa.StarterKit.React.ViewModels.Dashboard
{
	public class StatusSummaryResponseModel
	{
		public int NumberOfConsignments { get; set; }

		public Dictionary<ConsignmentState, int> Summary { get; set; }

		public DateTimeOffset StartFrom { get; set; }

		public DateTimeOffset EndAt { get; set; }
	}
}