using System;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1.Enums;

namespace Spa.StarterKit.React.ViewModels.Configuration.Rates
{
    public class VatRateViewModel
    {

        public VatRateType Type { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string CountryIsoCode { get; set; }
        public decimal Rate { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}