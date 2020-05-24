using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace SchrodyWebApp.Pages
{
	public class ExperimentsModel : PageModel
	{
		public List<ExperimentItemModel> Items { get; } = new List<ExperimentItemModel>();

		public void OnGet()
		{
			Items.Add(new ExperimentItemModel
			{
				IsUnderDevelopment = true,
				Title = "Fletch & Fibs Present: The Schnauzer Memory Game",
				Text = "The schnauzer memory game is a simple matching game with cards. Test your memory, and see pictures of schnauzers. What could be better!",
				PreviewImage = "/images/schrody_overlay.jpg",
				Timestamp = new DateTime(2019, 05, 12),
			});
		}
	}

	public class ExperimentItemModel
	{
		public bool IsUnderDevelopment { get; set; }
		public string Title { get; set; }
		public string Text { get; set; }
		public string PreviewImage { get; set; }
		public DateTime Timestamp { get; set; }
	}
}
