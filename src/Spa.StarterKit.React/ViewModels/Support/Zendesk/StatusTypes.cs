namespace Spa.StarterKit.React.ViewModels.Support.Zendesk
{
	public class StatusTypes
	{
		public const string New = "new";
		public const string Open = "open";
		public const string Pending = "pending";
		public const string Hold = "hold";
		public const string Solved = "solved";
		public const string Closed = "closed";

		public static string[] InProgressStatusTypes
		{
			get { return new [] {New, Open, Pending, Hold}; }
		}
	}
}