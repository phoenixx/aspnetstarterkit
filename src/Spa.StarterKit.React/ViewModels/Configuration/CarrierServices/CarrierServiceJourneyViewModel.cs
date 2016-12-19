using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1.Enums;

namespace Spa.StarterKit.React.ViewModels.Configuration.CarrierServices
{
    public class CarrierServiceJourneyViewModel
    {
        private string _carrierAccountReference;

        public CarrierServiceJourneyViewModel()
        {
            _carrierAccountReference = string.Empty;
            CollectionType = CollectionType.Scheduled;
        }
        public string CarrierReference { get; set; }
        public string CarrierServiceReference { get; set; }

        public string CarrierAccountReference
        {
            get { return _carrierAccountReference.ToUpper(); }
            set { _carrierAccountReference = value; }
        }

        public string CustomerReference { get; set; }

        public CollectionType CollectionType { get; set; }
    }
}