using System.Collections.Generic;
using Spa.StarterKit.React.ViewModels.EditorTemplating;

namespace Spa.StarterKit.React.ViewModels.Configuration.GatewaySettings
{
    public class GatewaySettingsViewModel
    {
        public GatewaySettingsViewModel()
        {
            
        }
        public GatewaySettingsViewModel(GatewaySettingsPageMode mode)
        {
            Mode = mode;
        }

        public IEnumerable<TemplateNodeViewModel> Content { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public string CarrierAccountReference { get; set; }
        public string CarrierServiceReference { get; set; }
        public GatewaySettingsPageMode Mode { get; set; }
    }

    public enum GatewaySettingsPageMode
    {
        Create,
        Edit
    }

}