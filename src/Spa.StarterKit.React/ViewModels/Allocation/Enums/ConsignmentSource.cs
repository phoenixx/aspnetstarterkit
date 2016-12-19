using System.ComponentModel;

namespace Spa.StarterKit.React.ViewModels.Allocation.Enums
{
    public enum ConsignmentSource
    {
        [Description("CSV Upload")]
        CsvUpload = 0,
        [Description("Amazon Marketplace")]
        AmazonMarketplace,
        [Description("Ebay")]
        Ebay,
        [Description("Manual")]
        Manual
    }
}