using System;

namespace Spa.StarterKit.React.ViewModels.Allocation
{
    public class AllocationViewModel
    {
        public DateTimeOffset AllocationDate { get; set; }
        public string CarrierServiceGroupReference { get; set; }
        public string MpdCarrierServiceGroupName { get; set; }
        public string MpdCarrierServiceName { get; set; }
        public string MpdCarrierServiceReference { get; set; }
        public RateViewModel Price { get; set; }
    }
}