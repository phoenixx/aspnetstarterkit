using System;
using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Configuration.CollectionCalendar
{
    public class AddRuleViewModel
    {
        public AddRuleViewModel()
        {
            MpdCarrierServices = new List<string>();
        }

        public CollectionCalendarTimeViewModel Rule { get; set; }
        public List<string> MpdCarrierServices { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public string ShippingLocationReference { get; set; }
        public string MpdCarrierReference { get; set; }
    }
}