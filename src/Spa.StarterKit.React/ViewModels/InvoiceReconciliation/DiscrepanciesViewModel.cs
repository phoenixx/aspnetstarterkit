using System;
using System.Collections.Generic;
using Spa.StarterKit.React.ViewModels.AddressLookup;

namespace Spa.StarterKit.React.ViewModels.InvoiceReconciliation
{
    public class DiscrepanciesViewModel
    {
        public Guid InvoiceReconciliationReference { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int DiscrepanciesCount { get; set; }
        public int AcceptedDiscrepanciesCount { get; set; }
        public int ReconciledLinesCount { get; set; }
        public IList<DiscrepancyViewModel> Discrepancies { get; set; }
        public IList<CountryViewModel> Countries { get; set; }
        public IList<Tuple<int, string>> ResolutionReasons { get; set; }
        public decimal Expected { get; set; }
        public decimal Actual { get; set; }
        public decimal Variance { get; set; }
    }
}