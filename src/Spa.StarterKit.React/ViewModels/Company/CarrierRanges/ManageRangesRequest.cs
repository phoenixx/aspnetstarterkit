using MPD.Electio.SDK.NetCore.Internal.CoreLib.Customers;

namespace Spa.StarterKit.React.ViewModels.Company.CarrierRanges
{
    public class ManageRangesRequest
    {
        public string CarrierReference { get; set; } // e.g. DPD
        public CustomerReference CustomerReference { get; set; } // internal guid class
        public string CarrierAccountReference { get; set; } // e.g. DYSON_DPDCON1
        public string CarrierServiceReference { get; set; } // e.g. DPDND
    }
}