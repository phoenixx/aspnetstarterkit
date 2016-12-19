using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spa.StarterKit.React.ViewModels.Configuration.CarrierServiceGroups;

namespace Spa.StarterKit.React.ViewModels.Configuration.CollectionCalendar
{
    public class CollectionCalendarForCarrierViewModel
    {
        public CollectionCalendarForCarrierViewModel()
        {
            CalendarsApplicableToIndividualServices = new List<CollectionCalendarFormViewModel>();
            CalendarApplicableToMultipleServices = new CollectionCalendarFormViewModel();
            MpdCarrierServices = new List<CarrierServiceViewModel>();
            ServicesWithSingleCalendars = new List<CarrierServiceViewModel>();
            ServicesWithSharedCalendar = new List<CarrierServiceViewModel>();
        }

        public SelectList ExceptionTypes { get; set; }
        public SelectList PreAdviceTypes { get; set; }

        public string MpdCarrierReference { get; set; }
        public string MpdCarrierName { get; set; }
        public List<CarrierServiceViewModel> ServicesWithSharedCalendar { get; set; }
        public List<CarrierServiceViewModel> ServicesWithSingleCalendars { get; set; }
        public List<CarrierServiceViewModel> MpdCarrierServices { get; set; }
        public string ShippingLocationReference { get; set; }
        public string ShippingLocationName { get; set; }
        public CollectionCalendarFormViewModel CalendarApplicableToMultipleServices { get; set; }
        public List<CollectionCalendarFormViewModel> CalendarsApplicableToIndividualServices { get; set; }
        public bool InEditCalendarMode { get; set; }
    }
}