using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Tracking
{
    public class TrackedLegViewModel
    {
        public string CarrierServiceName { get; set; }

        public IList<TrackingEventViewModel> Events { get; set; }
    }
}