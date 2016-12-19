using System;

namespace Spa.StarterKit.React.ViewModels.Allocation.ManualUpload
{
    public class RequestedDeliveryDate
    {
        public DateTimeOffset? Date { get; set; }
        public bool IsToBeExactlyOnTheDateSpecified { get; set; }

    }
}