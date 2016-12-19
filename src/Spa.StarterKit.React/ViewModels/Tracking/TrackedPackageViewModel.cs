using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Tracking
{
    public class TrackedPackageViewModel
    {
        public string PackageReferenceForAllLegsAssignedByMpd { get; set; }

        public string CarrierTrackingReference { get; set; }

        public IList<TrackedLegViewModel> Legs { get; set; }
    }
}