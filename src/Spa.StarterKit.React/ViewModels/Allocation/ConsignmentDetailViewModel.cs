using System;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;
using Spa.StarterKit.React.ViewModels.Allocation.ManualUpload;

namespace Spa.StarterKit.React.ViewModels.Allocation
{
    public class ConsignmentDetailViewModel
    {
        public bool Selected { get; set; }

        public string ConsignmentReference { get; set; }

        public string ClientReference { get; set; }

        public string Source { get; set; }

        public string ServiceGroupReference { get; set; }

        public string ServiceGroupName { get; set; }

        public decimal Weight { get; set; }

        public Money Value { get; set; }

        public DateTimeOffset? Created { get; set; }
        public DateTimeOffset? CollectionDate { get; set; }
        public DateTimeOffset? ShippedDate { get; set; }
        public DateTimeOffset? ShippingDate { get; set; }
        public DateTimeOffset? EarliestDeliveryDate { get; set; }

        public string DestinationAddress { get; set; }

        public string CarrierCode { get; set; }
        public string CarrierName { get; set; }
        public string CarrierServiceCode { get; set; }
        public string CarrierServiceName { get; set; }
        public string ShippingLocationReference { get; set; }
        public string TrackingReference { get; set; }

        public AllocationViewModel Allocation { get; set; }
        public FailedAllocationViewModel FailedAllocation { get; set; }

        public DateTimeOffset? DateLabelsWereFirstPrinted { get; set; }
        public bool HaveLabelsEverBeenPrinted { get; set; }

        public RequestedDeliveryDate RequestedDeliveryDate { get; set; }

        public string ConsignmentState { get; set; }

        public bool IsLate { get; set; }
        public string FailedManifestMessage { get; set; }
        public DateTimeOffset? FailedManifestTimeStamp { get; set; }
    }
}