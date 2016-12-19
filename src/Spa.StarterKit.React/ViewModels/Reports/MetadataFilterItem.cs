using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Enums;

namespace Spa.StarterKit.React.ViewModels.Reports
{
	public class MetadataFilterItem
	{
		public int MetadataDictionaryId { get; set; }

		public string KeyValue { get; set; }

		public string StringValue { get; set; }
		public MetaDataType MetaDataType { get; set; }
	}
}