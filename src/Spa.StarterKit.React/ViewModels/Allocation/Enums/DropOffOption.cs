using System.ComponentModel;

namespace Spa.StarterKit.React.ViewModels.Allocation.Enums
{
    public enum DropOffOption
    {
        [Description("Location near origin location")]
        LocationNearOrigin = 0,
        [Description("Another postcode")]
        AnotherPostcode = 1
    }
}