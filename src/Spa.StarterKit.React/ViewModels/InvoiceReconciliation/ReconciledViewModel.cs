using System;
using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.InvoiceReconciliation
{
    public class ReconciledViewModel
    {
        public Guid InvoiceReconciliationReference { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int DiscrepanciesCount { get; set; }
        public int AcceptedDiscrepanciesCount { get; set; }
        public int ReconciledLinesCount { get; set; }
        public IList<ReconciledLineViewModel> ReconciledLines { get; set; }
        public decimal Expected { get; set; }
        public decimal Actual { get; set; }
        public decimal Variance { get; set; }
    }
}