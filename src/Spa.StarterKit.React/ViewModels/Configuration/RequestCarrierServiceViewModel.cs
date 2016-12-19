using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Configuration
{
    public class RequestCarrierServiceViewModel
    {
        public RequestCarrierServiceViewModel()
        {
            SelectedShippingLocations = new List<string>();
            ShippingVolumes = new List<ShippingVolumeViewModel>();
        }

        public string CarrierServiceReference { get; set; }
        public IList<ShippingLocationViewModel> ShippingLocations { get; set; }
        public IList<string> SelectedShippingLocations { get; set; }
        public IList<ShippingVolumeViewModel> ShippingVolumes { get; set; }
        public string RequestorName { get; set; }
        public string RequestorTelephone { get; set; }
        public string RequestorEmail { get; set; }
        public string CarrierAccountNumber { get; set; }
    }
}