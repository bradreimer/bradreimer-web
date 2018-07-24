using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SchrodyWebApp.Pages
{
	public class SchnauzersModel : PageModel
	{
		/// <summary>
		/// Gets a Base64-encoded background image
		/// </summary>
		public string BackgroundImage { get; private set; }

		/// <summary>
		/// Gets an array of hashes referencing Instagram posts
		/// </summary>
		public string[] Posts { get; private set; }

		public void OnGet()
		{
			BackgroundImage = "iVBORw0KGgoAAAANSUhEUgAAACwAAAAsCAMAAAApWqozAAAABGdBTUEAALGPC/xhBQAAAAFzUkdCAK7OHOkAAAAMUExURczMzPf399fX1+bm5mzY9AMAAADiSURBVDjLvZXbEsMgCES5/P8/t9FuRVCRmU73JWlzosgSIIZURCjo/ad+EQJJB4Hv8BFt+IDpQoCx1wjOSBFhh2XssxEIYn3ulI/6MNReE07UIWJEv8UEOWDS88LY97kqyTliJKKtuYBbruAyVh5wOHiXmpi5we58Ek028czwyuQdLKPG1Bkb4NnM+VeAnfHqn1k4+GPT6uGQcvu2h2OVuIf/gWUFyy8OWEpdyZSa3aVCqpVoVvzZZ2VTnn2wU8qzVjDDetO90GSy9mVLqtgYSy231MxrY6I2gGqjrTY0L8fxCxfCBbhWrsYYAAAAAElFTkSuQmCC";

			Posts = new []
			{
				"BlgcRt0geSX",
				"BlOMcyFHtIG",
				"BlMUWZTnrbv",
				"BlJALtMjwXY",
				"BlDuolyD-Ml",
				"BlBvyLSDzaF",
				"BlBvIbSDnbL",
				"BlBSHDjDZHg",
				"BlBRc53jjmI",
				"BlBRW-pD9BL",
				"BlBQLEVB9te",
			};
		}
	}
}
