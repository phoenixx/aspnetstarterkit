using System.Collections.Generic;
using FluentValidation.Attributes;
using Spa.StarterKit.React.ViewModels.FluentValidators.CollectionCalendar;

namespace Spa.StarterKit.React.ViewModels.Configuration.CollectionCalendar
{
    [Validator(typeof(AddExceptionValidator))]
    public class AddExceptionViewModel
    {
        public AddExceptionViewModel()
        {
            MpdCarrierServices = new List<string>();
        }
        public string ShippingLocationReference { get; set; }
        public string MpdCarrierReference { get; set; }
        public CollectionCalendarExceptionViewModel Exception { get; set; }
        public List<string> MpdCarrierServices { get; set; }
    }
}