using System.ComponentModel;

namespace Spa.StarterKit.React.ViewModels.Configuration.CollectionCalendar.Enums
{
    public enum OperationTimeOffset
    {
        [Description("On Collection Day")]
        OnCollectionDay = 0,

        [Description("One Day Before")]
        OneDayBefore = 1,

        [Description("Two Days Before")]
        TwoDaysBefore = 2,

        [Description("Three Days Before")]
        ThreeDaysBefore = 3,
    }
}