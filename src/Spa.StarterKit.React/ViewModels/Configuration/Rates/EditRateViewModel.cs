using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Rates;

namespace Spa.StarterKit.React.ViewModels.Configuration.Rates
{
    public class EditRateViewModel
    {
        public bool MaintainCosts { get; set; }
        public string MpdCarrierServiceReference { get; set; }
        public string Name { get; set; }
		public string AccountName { get; set; }
        public MpdCarrierServiceBasePriceViewModel MpdCarrierServiceBasePriceModel { get; set; }

        public IList<MpdCarrierServiceZoneViewModel> MpdCarrierServiceBasePriceZones { get; set; }
        public IList<MpdCarrierServiceZoneViewModel> MpdCarrierServiceSurchargeZones { get; set; }

        public IList<MpdCarrierServiceSurchargeViewModel> MpdCarrierServiceSurcharges { get; set; }
        public IList<MpdCarrierServiceZoneSurchargeViewModel> MpdCarrierServiceZoneSurcharges { get; set; }

        public IList<CarrierServiceSurchargeViewModel> CarrierServiceSurcharges { get; set; }
        public IList<CarrierServiceZoneSurchargeViewModel> CarrierServiceZoneSurcharges { get; set; }

        public IList<CostFileViewModel> CostFiles { get; set; }

        public bool IsElectioService { get; set; }
        public string CurrencyIsoCode { get; set; }
        public IList<VatRateViewModel> VatRates { get; set; }
        public IList<SurchargeOptionsModel> SurchargeOptions { get; set; }
        public IEnumerable<string> EndpointInvolvementOptions { get; set; }
        public IEnumerable<string> ApplicationTypes { get; set; }
        public List<MpdCarrierServiceBasePriceViewModel> PriceModels { get; set; }
        public IList<Zone> Zones { get; set; }
        public bool ReadOnly { get; set; }
    }
}