using System;
using Spa.StarterKit.React.ViewModels.Shared.Address;

namespace Spa.StarterKit.React.ViewModels.Shared.CarriersAndServices
{
    public class PickUpLocationViewModel
    {
        public string CarrierCode { get; set; }
        public string CarrierName { get; set; }
        public string CarrierServiceCode { get; set; }
        public string CarrierServiceName { get; set; }
        public AddressViewModel Address { get; set; }
        public DateTime EstimatedPickUpDate { get; set; }
        public decimal Cost { get; set; }
    }
}
