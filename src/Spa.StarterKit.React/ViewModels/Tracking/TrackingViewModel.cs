using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Tracking
{
    public class TrackingViewModel
    {
        public string ConsignmentReferenceForAllLegsAssignedByMpd { get; set; }

        public IList<TrackedPackageViewModel> TrackedPackages { get; set; }
        
    }
}