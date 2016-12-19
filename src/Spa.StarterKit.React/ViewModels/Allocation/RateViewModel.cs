

using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;

namespace Spa.StarterKit.React.ViewModels.Allocation
{
    public class RateViewModel
    {
        public decimal GrossAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal VatAmount { get; set; }
        public VatRate VatRate { get; set; }
    }
}