using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Configuration.CarrierServices
{
    public class EditMpdCarrierServiceViewModel : MpdCarrierServiceOptionsViewModel
    {
        private string _reference;

        public EditMpdCarrierServiceViewModel()
        {
            _reference = string.Empty;
            Options = new OptionsCollection();
            Lookups = new LookupsCollection();
            Journeys = new List<CarrierServiceJourneyViewModel>();
        }

        public string MpdCarrierServiceReference
        {
            get { return _reference.ToUpper(); }
            set { _reference = value.ToUpper(); }
        }

        public string Name { get; set; }
        public string MpdCarrierReference { get; set; }
        public int PriceModel { get; set; }
        public List<CarrierServiceJourneyViewModel> Journeys { get; set; }

        public MpdCarrierServicePageMode Mode { get; set; }

        public string PageTitle => Mode == MpdCarrierServicePageMode.Create ? "Create Carrier Service" : "Manage Carrier Service";
    }

    public enum MpdCarrierServicePageMode
    {
        Create,
        View,
        Edit
    }


}