using System.Xml.Serialization;

namespace SchrodyWebApp.Pages.StCuthberts
{
	public class Part
	{
		[XmlAttribute]
		public string Description { get; set; }
		public Presentation[] Presentations { get; set; }
		public bool IsLast { get; set; }
	}
}
