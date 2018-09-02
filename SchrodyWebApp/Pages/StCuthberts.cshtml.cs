using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchrodyWebApp.Pages.StCuthberts;

namespace SchrodyWebApp.Pages
{
	public class StCuthbertsModel : PageModel
	{
		public Show Show { get; private set; }
		public string DebugMessage { get; set; }

		public void OnGet()
		{
			var xml = new XmlSerializer(typeof(Show));
			var assembly = Assembly.GetExecutingAssembly();

			string resource = "SchrodyWebApp.Properties.tuning_out_cancer.xml";
			using(var stream = assembly.GetManifestResourceStream(resource))
			{
				Show = (Show) xml.Deserialize(stream);
			}

			// Index the presentations
			int index = 0;
			var query =
				from part in Show.Parts
			from presentation in part.Presentations
			select presentation;
			foreach (var presentation in query)
				presentation.Index = ++index;

			// Mark last part of show
			Show.Parts.Last().IsLast = true;
		}
	}
}
