using System.Xml.Serialization;

namespace SuperZapatos.InventoryControl.Contracts.ServiceLibrary.DTOs
{
    [XmlRoot( ElementName = "store", Namespace = "")]
    public class StoreDTO
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("address")]
        public string Address { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }
    }
}