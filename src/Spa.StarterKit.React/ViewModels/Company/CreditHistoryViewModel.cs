using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Company
{
    public class CreditHistoryViewModel
    {
        public IList<CreditHistoryItemViewModel> CreditHistory { get; set; }
        public decimal DueNow { get; set; }
    }
}