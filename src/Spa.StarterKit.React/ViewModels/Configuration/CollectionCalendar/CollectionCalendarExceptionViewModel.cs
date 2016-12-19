using System;
using Spa.StarterKit.React.ViewModels.Configuration.CollectionCalendar.Enums;

namespace Spa.StarterKit.React.ViewModels.Configuration.CollectionCalendar
{
    public class CollectionCalendarExceptionViewModel
    {
        public Guid Id { get; set; }
        public CollectionExceptionType CollectionExceptionType { get; set; }
        public DateTimeOffset ExceptionDate { get; set; }

        public string ExceptionDateFormatted {
            get
            {
                return ExceptionDate.ToString("dd/MM/yyyy");
            }
        }
        public CollectionCalendarTimeViewModel CarrierCollection { get; set; }
    }
}