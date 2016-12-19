using System.Runtime.Serialization;

namespace Spa.StarterKit.React.ViewModels.Configuration.CarrierServiceGroups
{
	[DataContract]
    public class CarrierServiceViewModel
    {
		[DataMember]
        public string Name { get; set; }

		[DataMember]
		public string Reference { get; set; }

		[DataMember]
		public string CarrierReference { get; set; }

		[DataMember]
		public string CarrierName { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public string CarrierAccountOwner { get; set; }

		[DataMember]
		public bool IsEnabled { get; set; }

		[DataMember]
		public bool IsSelected { get; set; }

		[DataMember]
		public bool IsElectioService { get; set; }

		[DataMember]
		public string CollectionType { get; set; }

		[DataMember]
		public string CarrierAccountReference { get; set; }

        [DataMember]
        public bool IsConfigured { get; set; }

        [DataMember]
        public bool MaintainCosts { get; set; }

        [DataMember]
        public string CarrierServiceReference { get; set; }
    }
}