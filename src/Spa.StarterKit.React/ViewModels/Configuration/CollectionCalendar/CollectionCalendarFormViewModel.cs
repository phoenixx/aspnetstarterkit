using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Configuration.CollectionCalendar
{
    public class CollectionCalendarFormViewModel
    {
        public string ShippingLocationReference { get; set; }
        public string MpdCarrierReference { get; set; }
        public string CarrierName { get; set; }
        public bool CalendarIsApplicableToAllCarrierServices { get; set; }
        public List<string> ApplicableMpdCarrierServices { get; set; }
        public bool IsSharedCalendar { get; set; }

        public IList<CollectionCalendarTimeViewModel> CollectionTimesMon { get; set; }
        public IList<CollectionCalendarTimeViewModel> CollectionTimesTue { get; set; }
        public IList<CollectionCalendarTimeViewModel> CollectionTimesWed { get; set; }
        public IList<CollectionCalendarTimeViewModel> CollectionTimesThu { get; set; }
        public IList<CollectionCalendarTimeViewModel> CollectionTimesFri { get; set; }
        public IList<CollectionCalendarTimeViewModel> CollectionTimesSat { get; set; }
        public IList<CollectionCalendarTimeViewModel> CollectionTimesSun { get; set; }
        public IList<CollectionCalendarExceptionViewModel> CollectionExceptions { get; set; }

        public CollectionCalendarFormViewModel()
        {
            CollectionTimesMon = new List<CollectionCalendarTimeViewModel>();
            CollectionTimesTue = new List<CollectionCalendarTimeViewModel>();
            CollectionTimesWed = new List<CollectionCalendarTimeViewModel>();
            CollectionTimesThu = new List<CollectionCalendarTimeViewModel>();
            CollectionTimesFri = new List<CollectionCalendarTimeViewModel>();
            CollectionTimesSat = new List<CollectionCalendarTimeViewModel>();
            CollectionTimesSun = new List<CollectionCalendarTimeViewModel>();
            CollectionExceptions = new List<CollectionCalendarExceptionViewModel>();
            ApplicableMpdCarrierServices = new List<string>();
        }        
    }
}