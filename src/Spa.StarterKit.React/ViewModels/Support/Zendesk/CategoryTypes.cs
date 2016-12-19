using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Spa.StarterKit.React.ViewModels.Support.Zendesk
{
	public class CategoryTypes
	{
		public static IEnumerable<SelectListItem> GetCategoriesAsSelectList()
		{
			return new List<SelectListItem>
			{
				new SelectListItem { Text = "problem", Value = "problem" },
				new SelectListItem { Text = "incident", Value = "incident" },
				new SelectListItem { Text = "question", Value = "question" },
				new SelectListItem { Text = "task", Value = "task" }
			};
		}
	}
}