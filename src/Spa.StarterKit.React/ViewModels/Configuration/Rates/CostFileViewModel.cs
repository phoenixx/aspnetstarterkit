using System;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Rates.Enums;

namespace Spa.StarterKit.React.ViewModels.Configuration.Rates
{
	public class CostFileViewModel
	{
		public int Id { get; set; }

		public string CustomerReference { get; set; }

		public string MpdCarrierServiceReference { get; set; }

		public string FileName { get; set; }

		public DateTime CreatedDate { get; set; }

		public Guid UploadedByAccountReference { get; set; }

		public string UploadedByAccountName { get; set; }

        public bool IsDefault { get; set; }

	    public FileUploadType FileUploadType { get; set; }

	}
}