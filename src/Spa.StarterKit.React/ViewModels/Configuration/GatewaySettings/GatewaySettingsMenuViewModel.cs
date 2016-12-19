using System.Collections.Generic;
using Spa.StarterKit.React.ViewModels.EditorTemplating;

namespace Spa.StarterKit.React.ViewModels.Configuration.GatewaySettings
{
    public class GatewaySettingsMenuViewModel
    {
        public MPD.Electio.SDK.NetCore.Internal.DataTypes.CarrierBooking.GatewaySettings CurrentSettings { get; set; }
        public List<MPD.Electio.SDK.NetCore.Internal.DataTypes.CarrierBooking.GatewaySettings> AllSettings { get; set; }
        public IEnumerable<TemplateNodeViewModel> Content { get; set; }
        public bool HasNoSettings { get; set; }
        public int CurrentSettingsId { get; set; }
        public bool IsTemplateError { get; set; }
        public string CarrierAccountReference { get; set; }
        public string CarrierServiceReference { get; set; }
    }
}