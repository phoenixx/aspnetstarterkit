using System.Runtime.Serialization;

namespace Spa.StarterKit.React.ViewModels.Subscriptions
{
    public class MpdCarrierServiceViewModel
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Reference { get; set; }
    }
}