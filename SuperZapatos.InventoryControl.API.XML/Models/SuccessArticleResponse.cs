using SuperZapatos.InventoryControl.Contracts.ServiceLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SuperZapatos.InventoryControl.API.XML.Models
{
    [XmlRoot(ElementName = "response", Namespace = "")]
    public class SuccessArticleResponse: BaseResponse
    {
        [XmlElement("articles")]
        public List<ArticleDTO> Articles { get; set; }

        [XmlElement("total_elements")]
        public int TotalArticle { get; set; }
    }
}