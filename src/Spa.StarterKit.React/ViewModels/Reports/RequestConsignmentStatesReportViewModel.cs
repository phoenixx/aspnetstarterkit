using System;
using System.Collections.Generic;
using FluentValidation.Attributes;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Enums;
using Spa.StarterKit.React.ViewModels.FluentValidators.Reports;

namespace Spa.StarterKit.React.ViewModels.Reports
{
    [Validator(typeof(RequestConsignmentStatesReportViewModelValidator))]
    public class RequestConsignmentStatesReportViewModel
    {
        public ReportingLevel ReportingLevel { get; set; }
        
        public DateTime ReportFrom { get; set; }
        
        public DateTime ReportTo { get; set; }

        public DateTime? EstimatedDeliveryDateFrom { get; set; }

        public DateTime? EstimatedDeliveryDateTo { get; set; }

        public List<ConsignmentState> SelectedExceptionStates { get; set; }

        public RequestConsignmentStatesReportViewModel()
        {
            SelectedExceptionStates = new List<ConsignmentState>();
        }
    }
}