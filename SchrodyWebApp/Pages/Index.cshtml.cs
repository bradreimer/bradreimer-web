using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SchrodyWebApp.Pages
{
	public class IndexModel : PageModel
	{
		public ArticleModel[] Articles;

		public sealed class ArticleModel
		{
			public string ImageSource { get; set; }
			public string Category { get; set; }
			public string Title { get; set; }
			public string Details { get; set; }
			public string Link { get; set; }
			public string LinkText { get; set; }
		}

		public void OnGet()
		{
			Articles = new[]
			{
				CreateArticle("images/fletch_16_9.jpg", "Schnauzers", "@fletchtheschnauzer",
				@"Hi, I’m <span class=""text-warning"">Fletcher</span>; 1/2 miniature " +
				"schnauzer, 1/2 poodle. I live near Vancouver, Canada and I love car rides and " +
				"my brother @niblets_of_fiblets!",
				"https://www.instagram.com/fletchtheschnauzer/",
				"Visit Fletch on Instagram"),

				CreateArticle("images/fibs_16_9.jpg", "Schnauzers", "@niblets_of_fiblets",
				@"Herrrrooowww, Friends! I'm <span class=""text-warning"">Fibs</span>, " +
				"and I run this account for my brother and me, with some help from my mom!",
				"https://www.instagram.com/niblets_of_fiblets/",
				"Visit Fibs on Instagram"),

				CreateArticle("images/schrody_16_9.jpg", "Software", "Brad Reimer on GitHub",
				@"I've created my first project on GitHub! <span class=""text-warning"">cs-sequence-diagrams</span> is a " +
				"C# library that draws sequence diagrams in a WPF.",
				"https://www.github.com/bradreimer/",
				"View Projects"),
			};
		}

		private ArticleModel CreateArticle(string image, string category, string title, string details, string link, string linkText)
		{
			return new ArticleModel
			{
				ImageSource = image,
				Category = category,
				Title = title,
				Details = details,
				Link = link,
				LinkText = linkText,
			};
		}
	}
}
