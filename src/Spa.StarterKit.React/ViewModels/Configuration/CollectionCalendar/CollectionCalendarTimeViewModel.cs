using System;
using Spa.StarterKit.React.ViewModels.Configuration.CollectionCalendar.Enums;

namespace Spa.StarterKit.React.ViewModels.Configuration.CollectionCalendar
{
    public class CollectionCalendarTimeViewModel
    {
        public Guid Id { get; set; }
        public TimeSpan CutOffTime { get; set; } 
        public TimeSpan? PreAdviceTime { get; set; }        
	    public TimeSpan ManifestTime { get; set; }
        public TimeSpan? OperationalCutOffTime { get; set; }
        public OperationTimeOffset PreAdviceType { get; set; }
        public OperationTimeOffset CutOffType { get; set; }
        public OperationTimeOffset OperationalCutOffType { get; set; }
    }
}