using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Carriers;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Common;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Rates.Carriers;
using Spa.StarterKit.React.ViewModels.Configuration.Rates;

namespace Spa.StarterKit.React.ViewModels.Configuration.CarrierServices
{
    public class MpdCarrierServiceOptionsViewModel
    {
        public OptionsCollection Options { get; set; }
        public LookupsCollection Lookups { get; set; }
        public string CustomerReference { get; set; }
    }

    public class OptionsCollection
    {
        public IEnumerable<MpdCarrier> MpdCarriers { get; set; }
        public IEnumerable<MPD.Electio.SDK.NetCore.DataTypes.CarrierServiceDirectory.v1_1.Carrier> Carriers { get; set; }
        public IEnumerable<CarrierService> AllCarrierServices { get; set; }
        public IEnumerable<CarrierAccount> CarrierAccounts { get; set; }
        public List<MpdCarrierServiceBasePriceViewModel> PriceModels { get; set; }
    }

    public class LookupsCollection
    {
        public List<CarrierAccountCarrierService> CarrierAccountCarrierServices { get; set; }
    }
}