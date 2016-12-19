//using System.ComponentModel.DataAnnotations;
//using Newtonsoft.Json;
//using Spa.StarterKit.React.ViewModels.Support.Zendesk;

//namespace Spa.StarterKit.React.ViewModels.Support
//{
//	public class CreateTicket
//	{
//		public CreateTicket()
//		{
//			Comment = new CreateTicketComment();
//			Requester = new Requester();
//		}

//		/// <summary>
//		/// Allowed values are problem, incident, question, or task.
//		/// </summary>
//		[JsonProperty("type")]
//		public string Type { get; set; }

//		/// <summary>
//		/// Gets the priority of the new ticket (Defaults to Normal).
//		/// </summary>
//		[JsonProperty("priority")]
//		public string Priority
//		{
//			get { return PriorityTypes.Normal; }
//		}

//		/// <summary>
//		/// Gets the status of the new ticket (Defaults to Open).
//		/// </summary>
//		[JsonProperty("status")]
//		public string Status
//		{
//			get { return StatusTypes.Open; }
//		}

//		[JsonProperty("subject")]
//		public string Subject { get; set; }

//		[JsonProperty("comment")]
//		public CreateTicketComment Comment { get; set; }

//		public class CreateTicketComment
//		{
//			[JsonProperty("body")]
//			public string Body { get; set; }
//		}

//		[JsonProperty("requester")]
//		public Requester Requester { get; set; }
//	}

//	public class CreateTicketViewModel
//	{
//		/// <summary>
//		/// Allowed values are problem, incident, question, or task.
//		/// </summary>
//		[Required(AllowEmptyStrings = false, ErrorMessage = "Please select a category")]
//		public string CategoryType { get; set; }

//		/// <summary>
//		/// The ticket subject. 
//		/// </summary>
//		[Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a subject")]
//		public string Subject { get; set; }

//		/// <summary>
//		/// Required. A comment object that describes the problem, incident, question, or task. 
//		/// See Ticket comments in Audit Events.
//		/// </summary>
//		[Required(AllowEmptyStrings = false, ErrorMessage = "Please enter a description")]
//		public string Description { get; set; }
//	}
//}