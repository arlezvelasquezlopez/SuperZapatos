using System.Xml.Serialization;

namespace SuperZapatos.InventoryControl.API.XML.Models
{
    [XmlRoot(ElementName = "")]
    public class BaseResponse
    {
        [XmlElement("success")]
        public bool Success { get; set; }
    }
}