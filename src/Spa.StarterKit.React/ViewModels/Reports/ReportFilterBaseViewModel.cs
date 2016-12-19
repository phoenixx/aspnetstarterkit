using System.Collections.Generic;
using System.Runtime.Serialization;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Reports.v1_1;

namespace Spa.StarterKit.React.ViewModels.Reports
{
	[DataContract]
    public class ReportFilterBaseViewModel : ReportFilters
    {
        public ReportFilterBaseViewModel()
        {
            Carriers = new List<string>();
			CarrierServices = new List<string>();
			ShippedFroms = new List<string>();
			Statuses = new List<string>();
			MetaDataFilters = new List<MetaDataFilter>();
			ConsignmentStates = new List<KeyValuePair<int, string>>();

		}

		///<summary>Contains the ReportFilters.States mapped up into something more palatable for the UI</summary>
		[DataMember]
		public List<KeyValuePair<int, string>> ConsignmentStates { get; set; }
	}
}