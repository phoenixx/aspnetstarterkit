using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Configuration.Rates
{
	public class NewCostUploadProgressViewModel
	{
		public int RowsProcessed { get; set; }

		public int TotalRows { get; set; }

		public List<string> Messages { get; set; }

		public List<ValidationMessage> ValidationMessages { get; set; }

		public NewCostUploadStatus Status { get; set; }
    }

    public class ValidationMessage
    {
        public int Row { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
    }
}