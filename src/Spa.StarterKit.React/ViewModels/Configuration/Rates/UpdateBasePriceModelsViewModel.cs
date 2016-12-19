using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Configuration.Rates
{
    public class UpdateBasePriceModelsViewModel
    {
        public string MpdCarrierServiceReference { get; set; }
        public List<MpdCarrierServiceBasePriceViewModel> BasePriceViewModels { get; set; }
    }
}