using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Spa.StarterKit.React.ViewModels.Company.CarrierRanges
{
    public class ViewSequenceMetricsViewModel
    {
        public DateTime DateCreated { get; set; }
        public long Start { get; set; }
        public long End { get; set; }
        public bool IsCircular { get; set; }
        public string SequenceName { get; set; }
        public long SequenceValue { get; set; }
        public TimeSpan EstimatedLifeSpan { get; set; }
    }

    public class ViewSequenceMetricsListViewModel
    {
        public const int DefaultPageSize = 25;

        [DataMember]
        public int PageSize => DefaultPageSize;
        public int TotalRecords { get; set; }

        public IEnumerable<ViewSequenceMetricsViewModel> SequenceMetrics { get; set; }

        [DataMember]
        public string CarrierAccountReference { get; set; }
        [DataMember]
        public string CarrierReference { get; set; }
        [DataMember]
        public string CarrierServiceReference { get; set; }
    }
}