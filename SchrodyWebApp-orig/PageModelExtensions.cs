using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SchrodyWebApp
{
	public static class PageModelExtensions
	{
		public static string ActiveNavItemHtml(this PageModel page, string targetPage, string displayName = null)
		{
			string title = (string)page.ViewData["Title"];
			displayName = displayName ?? targetPage;

			return (title == targetPage) ? "active" : "";
		}
	}
}
