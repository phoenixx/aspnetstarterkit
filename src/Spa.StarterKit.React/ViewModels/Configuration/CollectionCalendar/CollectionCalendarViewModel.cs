using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Spa.StarterKit.React.ViewModels.Configuration.CollectionCalendar
{
    public class CollectionCalendarViewModel
    {
        public SelectList ShippingLocations { get; set; }
        public SelectList Carriers { get; set; }
        public SelectList ExceptionTypes { get; set; }
        public SelectList PreAdviceTypes { get; set; }
        public string ShippingLocationName { get; set; }
        public string ShippingLocationReference { get; set; }

        public List<CollectionCalendarFormViewModel> CollectionCalendarForms { get; set; }

        public CollectionCalendarViewModel()
        {
            CollectionCalendarForms = new List<CollectionCalendarFormViewModel>();
        }
    }
}