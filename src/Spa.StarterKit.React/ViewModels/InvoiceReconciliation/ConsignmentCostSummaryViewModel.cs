
using System;

namespace Spa.StarterKit.React.ViewModels.InvoiceReconciliation
{
    public class ConsignmentCostSummaryViewModel
    {
        public string ConsignmentReference { get; set; }
        public string ClientReference { get; set; }
        public string DestinationAddress { get; set; }
        public decimal TotalCost { get; set; }
        public DateTimeOffset? Created { get; set; }
    }
}