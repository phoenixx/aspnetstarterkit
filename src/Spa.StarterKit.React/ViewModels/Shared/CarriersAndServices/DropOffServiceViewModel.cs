using System;
using Spa.StarterKit.React.ViewModels.Shared.Address;

namespace Spa.StarterKit.React.ViewModels.Shared.CarriersAndServices
{
    /// <summary>
    /// This is a mock model until a service is available with a relevant data contract
    /// </summary>
    public class DropOffServiceViewModel
    {
        public string CarrierCode { get; set; }
        public string CarrierServiceCode { get; set; }
        public string CarrierServiceName { get; set; }
        public AddressViewModel DropOffAddress { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public decimal Cost { get; set; }
    }
}