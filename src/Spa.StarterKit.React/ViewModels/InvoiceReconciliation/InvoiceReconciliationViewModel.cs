using System;

namespace Spa.StarterKit.React.ViewModels.InvoiceReconciliation
{
    public class InvoiceReconciliationViewModel
    {
        public int AcceptedDiscrepancyCount { get; set; }
        public int DiscrepancyCount { get; set; }
        public int ReconciledLines { get; set; }
        public string Reader { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public bool Locked { get; set; }
        public Guid Reference { get; set; }
        public DateTime? ProcessingStarted { get; set; }
        public DateTime? ProcessingCompleted { get; set; }
        public bool CurrentlyProcessing { get; set; }

        public string Duration
        {
            get
            {
                if (ProcessingStarted != null)
                {
                    var endTime = ProcessingCompleted ?? DateTime.Now.ToUniversalTime();

                    var duration = endTime - ProcessingStarted.Value;

                    if (duration.Minutes >= 60)
                    {
                        return $"{duration.Hours} hour(s), {duration.Minutes} minutes";
                    }
                    if (duration.Minutes >= 1)
                    {
                        return $"{duration.Minutes} minutes";
                    }
                    if (duration.Seconds >= 1)
                    {
                        return $"{duration.Seconds} seconds";
                    }
                    return "less than a second";
                }
                return string.Empty;
            }
        }
    }
}