using Spa.StarterKit.React.ViewModels.Shared;

namespace Spa.StarterKit.React.ViewModels.Support.Zendesk
{
	public class Ticket : TicketSummary
	{
		public PagedListViewModel<CommentSummary> Comments { get; set; } 
	}
}