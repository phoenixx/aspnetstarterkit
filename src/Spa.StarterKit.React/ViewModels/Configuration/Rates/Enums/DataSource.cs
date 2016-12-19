using System.ComponentModel;

namespace Spa.StarterKit.React.ViewModels.Configuration.Rates.Enums
{
    public enum DataSource
    {
        [Description("Set by user")]
        UserDefined,

        [Description("API")]
        Api
    }
}