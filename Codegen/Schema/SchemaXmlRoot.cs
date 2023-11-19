using System.Xml.Serialization;

namespace Ans.Net8.Common.Codegen.Schema
{

	/// <summary>
	/// Ans.Net8.Common.Codegen.xsd
	/// </summary>
	[XmlRoot("schema")]
	public class SchemaXmlRoot
	{
		[XmlElement("face")]
		public List<FaceXmlElement> Faces { get; set; }

		[XmlElement("catalog")]
		public List<CatalogXmlElement> Catalogs { get; set; }
	}

}
