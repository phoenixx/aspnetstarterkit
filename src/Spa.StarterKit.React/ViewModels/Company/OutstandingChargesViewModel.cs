using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Company
{
    public class OutstandingChargesViewModel
    {
        public decimal? TotalOutstanding { get; set; }
        public List<OutstandingChargeViewModel> OutstandingCharges { get; set; } 
    }
}