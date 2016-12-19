using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Configuration.CarrierServices
{
    public class MpdCarrierServiceViewModel
    {
        private string _reference;

        public MpdCarrierServiceViewModel()
        {
            _reference = string.Empty;
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
    }
}