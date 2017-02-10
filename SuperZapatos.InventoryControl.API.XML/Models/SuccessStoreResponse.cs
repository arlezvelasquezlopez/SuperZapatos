using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.DTOs;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SuperZapatos.InventoryControl.API.XML.Models
{
    [XmlRoot(ElementName = "response", Namespace = "", IsNullable = true)]
    public class SuccessStoreResponse: BaseResponse
    {
        [XmlElement("stores")]
        public List<StoreDTO> Stores { get; set; }

        [XmlElement("total_elements")]
        public int TotalStores { get; set; }

        
    }
}