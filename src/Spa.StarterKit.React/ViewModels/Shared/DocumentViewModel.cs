namespace Spa.StarterKit.React.ViewModels.Shared
{
	public class DocumentViewModel
	{
		public string ContentType { get; set; }

		public string ContentDisposition { get; set; }

		public byte[] Content { get; set; }

		public string Filename { get; set; }
	}
}