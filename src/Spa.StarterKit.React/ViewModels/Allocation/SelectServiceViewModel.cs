using Spa.StarterKit.React.Models;
using Spa.StarterKit.React.ViewModels.Allocation.Enums;

namespace Spa.StarterKit.React.ViewModels.Allocation
{
    public class SelectServiceViewModel : SortableModel
    {
        public string ConsignmentKey { get; set; }
        public string ServiceCode { get; set; }
        public CarrierServiceType Mode { get; set; }
    }
}
