using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Enums;
using MPD.Electio.SDK.NetCore.DataTypes.Profile.v1_1;
using Spa.StarterKit.React.ViewModels.Allocation.Enums;
using Spa.StarterKit.React.ViewModels.Allocation.ManualUpload;
using Spa.StarterKit.React.ViewModels.Configuration.CarrierServiceGroups;
using Spa.StarterKit.React.ViewModels.Dashboard;

namespace Spa.StarterKit.React.ViewModels.Allocation
{
    public class ConsignmentsViewModel
    {
        public List<ConsignmentDetailViewModel> Consignments { get; set; }
        public ConsignmentState? ConsignmentState { get; set; }
        public int TotalRecords { get; set; }
        public int PageSize { get; set; }
        public List<KeyValuePair<int, string>> ConsignmentSources { get; set; }
        public ConsignmentStateType ConsignmentStateType { get; set; }
        public IList<ShippingLocation> ShippingLocations { get; set; }
        public IList<RadialItemViewModel> ConsignmentStateHeaders { get; set; }
        public IList<CarrierServiceViewModel> CustomerCarrierServices { get; set; }
        public IEnumerable<ConsignmentStateFilter> StateFilters { get; set; }
		public bool ShowingLateConsignments { get; set; }
        public IList<ServiceGroupViewModel> CarrierServiceGroups { get; set; }
    }
}