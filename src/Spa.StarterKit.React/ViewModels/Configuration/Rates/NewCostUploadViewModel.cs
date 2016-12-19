using System;
using Spa.StarterKit.React.ViewModels.InvoiceReconciliation.Enums;

namespace Spa.StarterKit.React.ViewModels.Configuration.Rates
{
	public class NewCostUploadViewModel
	{
		public byte[] File { get; set; }

		public string FileName { get; set; }

		public string MpdCarrierServiceReference { get; set; }

        public string CarrierServiceReference { get; set; }

		public Guid UploadedByAccountReference { get; set; }

		public string UploadedByAccountName { get; set; }

	    public UploadType UploadType { get; set; }

        public bool IgnoreValidationWarnings { get; set; }
	}
}