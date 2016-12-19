namespace Spa.StarterKit.React.ViewModels.InvoiceReconciliation
{
    public class ConfidenceViewModel
    {
        public decimal ConfidencePercent { get; set; }
        public bool EncounteredException { get; set; }
        public int ErrorLines { get; set; }
        public int MatchedLines { get; set; }
        public string Reader { get; set; }
    }
}