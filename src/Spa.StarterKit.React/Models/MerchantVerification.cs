using System;

namespace Spa.StarterKit.React.Models
{
    [Serializable]
    [Obsolete("Shouldn't be defined in web...")]
    public class MerchantVerification
    {
        public string AdditionalData { get; set; }
        public string Data { get; set; }
        public string EndpointAddress { get; set; }
        public string OrderReference { get; set; }
        public string Reference { get; set; }
    }
}