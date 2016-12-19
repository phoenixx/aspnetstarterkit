using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Configuration.CarrierServices
{
    public class CreateMpdCarrierServiceViewModel : MpdCarrierServiceOptionsViewModel
    {
        public List<MpdCarrierServiceViewModel> MpdCarrierServices { get; set; }

        public CreateMpdCarrierServiceViewModel()
        {
            Options = new OptionsCollection();
            Lookups = new LookupsCollection();
            MpdCarrierServices = new List<MpdCarrierServiceViewModel>();
        }

        public string PageTitle = "Create Carrier Service";
    }
}