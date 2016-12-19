using System;
using Spa.StarterKit.React.ViewModels.Shared.Address;

namespace Spa.StarterKit.React.ViewModels.Shared.CarriersAndServices
{
    public class CarrierServiceLookupViewModel
    {
        //public ServiceType ServiceType { get; set; } //e.g. scheduled/ad-hoc
        public string CarrierCode { get; set; }
        public string CarrierName { get; set; }
        public string CarrierServiceCode { get; set; }
        public string CarrierServiceName { get; set; }
        public string CarrierAccountOwner { get; set; }
        public AddressViewModel Address { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? EarliestCollectionDate { get; set; }
        public decimal Cost { get; set; }
    }
}