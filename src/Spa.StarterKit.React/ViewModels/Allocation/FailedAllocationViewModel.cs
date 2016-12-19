using System;

namespace Spa.StarterKit.React.ViewModels.Allocation
{
    public class FailedAllocationViewModel
    {
        public string CarrierServiceGroupReference { get; set; }

        public string MpdCarrierServiceGroupName { get; set; }

        public string MpdCarrierServiceReference { get; set; }

        public string MpdCarrierServiceName { get; set; }

        public DateTimeOffset AttemptedAllocationDate { get; set; }

        public string Message { get; set; }
        
    }
}