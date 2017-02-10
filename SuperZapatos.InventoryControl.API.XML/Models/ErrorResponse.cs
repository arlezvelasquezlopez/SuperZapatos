using System.Xml.Serialization;

namespace SuperZapatos.InventoryControl.API.XML.Models
{
    [XmlRoot(ElementName = "", Namespace = "", IsNullable = true)]
    public class ErrorResponse: BaseResponse
    {
        [XmlElement("errorMsg")]
        public string MessageError { get; set; }

        [XmlElement("error_code")]
        public int CodeError { get; set; }
    }
}