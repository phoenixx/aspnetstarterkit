using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Shared
{
	public class PagedListViewModel<T>
	{
		public int TotalRecords { get; set; }

		public int PageSize { get; set; }

		public int PageNumber { get; set; }

		public IList<T> Records { get; set; }

		public static PagedListViewModel<T> Empty
		{
			get
			{
				return new PagedListViewModel<T>
				{
					PageNumber = 0,
					PageSize = 0,
					Records = new List<T>(),
					TotalRecords = 0
				};
			}
		}
	}
}