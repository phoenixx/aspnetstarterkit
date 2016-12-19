using System;

namespace Spa.StarterKit.React.ViewModels.Tracking
{
    public class TrackingEventViewModel
    {
        public DateTimeOffset TimeStamp { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string SignedBy { get; set; }
        public string Location { get; set; }
    }

    //  [Obsolete]
    //  public class ConsignmentTrackingViewModel
    //  {
    //      public ConsignmentTrackingViewModel()
    //      {
    //          TrackedPackages = new List<PackageTrackingViewModel>();
    //      }

    //      public string ConsignmentReferenceForAllLegsAssignedByMpd { get; set; }
    //      public IList<PackageTrackingViewModel> TrackedPackages { get; set; }
    //  }

    //  public class PackageTrackingViewModel
    //  {
    //      public PackageTrackingViewModel()
    //      {
    //          Legs = new List<LegTrackingViewModel>();
    //      }

    //      public string PackageReferenceForAllLegsAssignedByMpd { get; set; }
    //      public IList<LegTrackingViewModel> Legs { get; set; }
    //  }

    //  public class LegTrackingViewModel
    //  {
    //      public LegTrackingViewModel()
    //      {
    //          Events = new List<EventTrackingViewModel>();
    //      }

    //      public string CarrierServiceName { get; set; }
    //      public IList<EventTrackingViewModel> Events { get; set; }
    //  }

    //  public class EventTrackingViewModel
    //  {
    //      public DateTime TimeStamp { get; set; }
    //      public string Code { get; set; }
    //      public string Description { get; set; }
    //      public string SignedBy { get; set; }
    //public string Location { get; set; }
    //  }
}