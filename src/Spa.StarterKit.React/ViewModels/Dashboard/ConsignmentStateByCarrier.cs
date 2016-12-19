using System;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Enums;

namespace Spa.StarterKit.React.ViewModels.Dashboard
{
	public class ConsignmentStateByCarrier
	{
        public string MpdCarrierName { get; set; }

        public string MpdCarrierServiceName { get; set; }

		/// <summary>MPD Reference for the Carrier (like MPD_DPD)</summary>
		public string MpdCarrierReference { get; set; }

		/// <summary>MPD Carrier Service Reference (like MPD_DPDEC)</summary>
		public string MpdCarrierServiceReference { get; set; }

		/// <summary>Number of consignments for this service and state</summary>
		public int NumberOfConsignments { get; set; }

		/// <summary>Consignment State that this response relates to</summary>
		public ConsignmentState ConsignmentState { get; set; }

        /// <summary>
        /// The date that the consignment was created - used for grouping in dashboard
        /// </summary>
        public DateTimeOffset Created { get; set; }
	}
}