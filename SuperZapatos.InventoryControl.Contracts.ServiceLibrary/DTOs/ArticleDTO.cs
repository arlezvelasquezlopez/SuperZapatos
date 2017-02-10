
using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.DTOs;
using System.Xml.Serialization;

namespace SuperZapatos.InventoryControl.Contracts.ServiceLibrary.DTOs
{
    public class ArticleDTO
    {
        [XmlElement("id")]
        public int Id { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("total_in_shelf")]
        public int TotalInShelf { get; set; }

        [XmlElement("total_in_vault")]
        public int TotalInVault { get; set; }

        [XmlIgnore]
        public int StoreId { get; set; }

        [XmlElement("store_name")]
        public virtual StoreDTO Store { get; set; }

    }
}
