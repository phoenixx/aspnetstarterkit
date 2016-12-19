using MPD.Electio.SDK.NetCore.Internal.DataTypes.Reconciliation;

namespace Spa.StarterKit.React.ViewModels.InvoiceReconciliation
{
    public class DiscrepancyResolutionViewModel
    {
        public int DiscrepancyId { get; set; }
        public bool Accepted { get; set; }
        public ResolutionReason Reason { get; set; }
        public string Comments { get; set; }
    }
}