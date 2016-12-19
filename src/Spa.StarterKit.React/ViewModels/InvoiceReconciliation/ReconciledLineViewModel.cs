namespace Spa.StarterKit.React.ViewModels.InvoiceReconciliation
{
    public class ReconciledLineViewModel
    {        
        public int Id { get; set; }             
        public int LineNumber { get; set; }                
        public string MpdConsignmentReference { get; set; }        
        public decimal? ExpectedCost { get; set; }        
        public decimal? ActualCost { get; set; }
    }
}