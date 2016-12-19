using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Profile.v1_1;
using Spa.StarterKit.React.ViewModels.AddressLookup;
using Spa.StarterKit.React.ViewModels.Allocation.Enums;
using Spa.StarterKit.React.ViewModels.Allocation.ManualUpload;
using Spa.StarterKit.React.ViewModels.Configuration.CarrierServiceGroups;
using Spa.StarterKit.React.ViewModels.Configuration.PackagingSizes;

namespace Spa.StarterKit.React.ViewModels.Allocation
{
    public class ViewConsignmentViewModel
    {
        public ViewConsignmentViewModel()
        {
            ShippingLocations = new List<ShippingLocation>();
            PackageSizes = new List<PackagingSizeViewModel>();
            Countries = new List<CountryViewModel>();
            Currencies = new List<string>();
			AuditMessages = new List<ConsignmentAuditMessage>();
            CustomerCarrierServices = new List<CarrierServiceViewModel>();
            TrackingEvents = new MPD.Electio.SDK.NetCore.DataTypes.Tracking.v1_1.ConsignmentViewModel();
            BarcodeOptions = new List<KeyValuePair<int, string>>();
        }

        public ConsignmentViewModel Consignment { get; set; }

        public List<ShippingLocation> ShippingLocations { get; set; }
        public List<PackagingSizeViewModel> PackageSizes { get; set; }
        public List<CountryViewModel> Countries { get; set; }
        public List<string> Currencies { get; set; }
		public List<string> Titles { get; set; }

        public List<PackageViewModel> Packages { get; set; }
        public bool SupportsPackageLabelPrinting { get; set; }
        public MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Allocation Allocation { get; set; }
        public ConsignmentStateType ConsignmentStateType { get; set; }
        public MPD.Electio.SDK.NetCore.DataTypes.Tracking.v1_1.ConsignmentViewModel TrackingEvents { get; set; }
		public List<ConsignmentAuditMessage> AuditMessages { get; set; }
        public IList<CarrierServiceViewModel> CustomerCarrierServices { get; set; }
        public IList<ServiceGroupViewModel> CarrierServiceGroups { get; set; }
        public IList<KeyValuePair<int, string>> BarcodeOptions { get; set; }
    }
}