using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MPD.Electio.SDK.NetCore.DataTypes.Profile.v1_1;
using Spa.StarterKit.React.ViewModels.Configuration.CarrierServiceGroups;

namespace Spa.StarterKit.React.ViewModels.Reports
{
	[DataContract]
	public class ReportFilterViewModel
    {
        public ReportFilterViewModel()
        {
			AppliedFilter = new ReportFilterBaseViewModel();
            Carriers = new List<KeyValuePair<string, string>>();
            CarrierServices = new List<CarrierServiceViewModel>();
            ConsignmentStates = new List<KeyValuePair<int, string>>();
            SavedReportFilters = new List<SavedReportFilterViewModel>();
        }

		[DataMember]
        public IList<KeyValuePair<string,string>> Carriers { get; set; }

		[DataMember]
		public IList<ShippingLocation> ShippingLocations { get; set; }

		[DataMember]
		public IList<CarrierServiceViewModel> CarrierServices { get; set; }

		[DataMember]
		public IList<KeyValuePair<int,string>> ConsignmentStates { get; set; }

		[DataMember]
		public IList<SavedReportFilterViewModel> SavedReportFilters { get; set; }

		[DataMember]
		public ReportFilterBaseViewModel AppliedFilter { get; set; }

		[DataMember]
		public Tuple<string, MetadataFilterItem[]>[] MetaDataFilters { get; set; }
    }
}
