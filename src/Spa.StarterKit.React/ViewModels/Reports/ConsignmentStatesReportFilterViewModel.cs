using System;
using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Reports
{
    public class ConsignmentStatesReportFilterViewModel
    {
        public ConsignmentStatesReportFilterViewModel()
        {
            ExceptionStates = new List<KeyValuePair<int, string>>();
            PreSelectedExceptionStates = new List<int>();
        }

        public IList<int> PreSelectedExceptionStates { get; set; }

        public IList<KeyValuePair<int, string>> ExceptionStates { get; set; }
        
        public ReportingLevel ReportingLevel { get; set; }

        public DateTime MaxReportTo { get; set; }

        public DateTime MinReportFrom { get; set; }
      
        public DateTime? ReportFrom { get; set; }
       
        public DateTime? ReportTo { get; set; }

        public DateTime? EstimatedDeliveryDateFrom { get; set; }

        public DateTime? EstimatedDeliveryDateTo { get; set; }

        public int MaxDateRangeInDays { get; set; }
    }
}