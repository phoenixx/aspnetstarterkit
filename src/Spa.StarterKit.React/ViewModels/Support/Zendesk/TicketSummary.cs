using System;

namespace Spa.StarterKit.React.ViewModels.Support.Zendesk
{
	public class Entity
	{
		public long? Id { get; set; }

		public DateTime? CreatedDate { get; set; }
	}

	public class TicketSummary : Entity
	{
		public string Subject { get; set; }

		public string Description { get; set; }

		public string Priority { get; set; }

		public string Status { get; set; }

		public string CategoryType { get; set; }

		public DateTime? UpdatedDate { get; set; }

		public string AssigneeName { get; set; }
	}
}