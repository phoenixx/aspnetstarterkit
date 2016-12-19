using System.Collections.Generic;
using System.Linq;

namespace Spa.StarterKit.React.ViewModels.InvoiceReconciliation
{
    internal class ReconciliationPriceItemsViewModel
    {
        public List<PriceItemViewModel> PriceItems { get; set; }

        public decimal Total
        {
            get { return PriceItems.Sum(x => x.TotalPrice); }
        }
    }
}