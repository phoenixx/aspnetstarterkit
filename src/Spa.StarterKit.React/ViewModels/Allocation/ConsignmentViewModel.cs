using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Enums;
using Spa.StarterKit.React.ViewModels.Shared;
using RequestedDeliveryDate = Spa.StarterKit.React.ViewModels.Allocation.ManualUpload.RequestedDeliveryDate;

namespace Spa.StarterKit.React.ViewModels.Allocation
{
    public class ConsignmentViewModel
    {
        public ConsignmentViewModel()
        {
            OriginAddress = new ConsignmentAddressViewModel();
            DestinationAddress = new ConsignmentAddressViewModel();
        }

        [Display(Name = "Electio Reference")]
        public string ConsignmentReference { get; set; }

        public Guid? CustomerReference { get; set; }

        [Display(Name="Your reference")]
        public string ClientReference { get; set; }

        public ConsignmentAddressViewModel OriginAddress { get; set; }
        public ConsignmentAddressViewModel DestinationAddress { get; set; }

        [Display(Name = "Please specify")]
        public string CollectionDate { get; set; }

        [Display(Name = "Service Group Name")]
        public string ServiceGroupName { get; set; }
        [Display(Name = "Service Group Code")]
        public string ServiceGroupReference { get; set; }

        public FailedAllocationViewModel FailedAllocation { get; set; }

        public string Source { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTimeOffset? ShippingDate { get; set; }
        public DateTimeOffset? ShippedDate { get; set; }
        public DateTimeOffset? EarliestDeliveryDate { get; set; }
        public DateTimeOffset? DeliveredDate { get; set; }
        public DateTime? ScheduledDeliveryDate { get; set; }
        
        public string CarrierName { get; set; }
        public string CarrierCode { get; set; }

        [Display(Name = "Service Name")]
        public string CarrierServiceName { get; set; }
        [Display(Name = "Service Code")]
        public string CarrierServiceCode { get; set; }

        public ConsignmentState ConsignmentState { get; set; }
        public string ConsignmentStateSeverity { get; set; }
        public string TrackingReference { get; set; }

        [Display(Name = "Price")]
        public PriceViewModel Price { get; set; }

        public RequestedDeliveryDate RequestedDeliveryDate { get; set; }

        public AllocationViewModel Allocation { get; set; }

        public DateTimeOffset? DateLabelsWereFirstPrinted { get; set; }
        public bool HaveLabelsEverBeenPrinted { get; set; }
        public bool IsLate { get; set; }
        public string ShippingTerms { get; set; }

        public List<MetaDataViewModel> MetaData { get; set; }
    }
}
