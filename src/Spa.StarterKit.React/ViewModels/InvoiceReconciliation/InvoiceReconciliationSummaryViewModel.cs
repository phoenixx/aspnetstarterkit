using System;
using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Reconciliation;

namespace Spa.StarterKit.React.ViewModels.InvoiceReconciliation
{
    public class InvoiceReconciliationSummaryViewModel
    {
        public DateTime Created { get; set; }
        public InvoiceReconciliationFileViewModel File { get; set; }
        public IList<ConfidenceViewModel> FileGradings { get; set; }
        public bool Locked { get; set; }
        public string Reader { get; set; }
        public Guid Reference { get; set; }
        public ReconciliationStatus Status { get; set; }        
        public bool GradingFailed { get; set; }
    }
}